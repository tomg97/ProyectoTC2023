using CUL.Entidades;
using Newtonsoft.Json;
using Servicios.Interfaces;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class SolicitudCotizacionDAL : IDVDAL<SolicitudCotizacion> {
        private readonly string _connectionString = DbConfig.Instance.ConnectionString;

        public void eliminarSolicitudCotizacion(string idSolicitud) {
            try {
                using (SqlConnection conn = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand($"DELETE FROM Cotizacion WHERE {idSolicitud} = 'id'");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        public void guardarSolicitudCotizacion(SolicitudCotizacion solicitud) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand("guardarSolicitudCotizacion", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fecha", solicitud.fecha);
                    cmd.Parameters.AddWithValue("@IdProveedor", solicitud.proveedor.CUIT); // Asumiendo que Proveedor tiene propiedad CUIT
                    cmd.Parameters.AddWithValue("@Productos", JsonConvert.SerializeObject(solicitud.productos)); // Serializa si es necesario
                    cmd.Parameters.AddWithValue("@Total", solicitud.subtotal);
                    cmd.Parameters.AddWithValue("@dvh", calcularDVH(solicitud)); // Calcula el DVH para la solicitud

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                actualizarDVV(); // Actualiza el DVV después de guardar la solicitud
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public List<SolicitudCotizacion> traerTodasSolicitudesCotizacion() {
            List<SolicitudCotizacion> solicitudes = new List<SolicitudCotizacion>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getAllSolicitudesCotizacion", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        SolicitudCotizacion solicitudCotizacion = new SolicitudCotizacion(
                            reader["id"].ToString(),
                            reader["productos"].ToString(),
                            reader["fecha"].ToString(),
                            reader["idProveedor"].ToString(),
                            reader["total"].ToString());
                        solicitudes.Add(solicitudCotizacion);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return solicitudes;
        }
        public string calcularDVH(SolicitudCotizacion solicitud) {
            StringBuilder sb = new StringBuilder();
            sb.Append(solicitud.id);
            sb.Append(solicitud.fecha);
            sb.Append(solicitud.proveedor.CUIT);
            sb.Append(solicitud.productos.ToString());
            sb.Append(solicitud.subtotal);
            return ServicioDV.obtenerDV(sb.ToString());
        }
        public string calcularDVV(List<SolicitudCotizacion> lista) {
            return lista.Aggregate<SolicitudCotizacion, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarTodosDV() {
            List<SolicitudCotizacion> cotizaciones = traerTodasSolicitudesCotizacion();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE Cotizacion SET dvh = @dvh WHERE id = @id", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@id", SqlDbType.VarChar);

                connection.Open();

                foreach (var c in cotizaciones) {
                    c.dvh = calcularDVH(c);
                    command.Parameters["@dvh"].Value = c.dvh;
                    command.Parameters["@id"].Value = c.id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = 'Cotizacion'", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(traerTodasSolicitudesCotizacion()));
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public string obtenerDVV() {
            string dvv = "";
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = 'Cotizacion'", connection);
                    connection.Open();
                    dvv = command.ExecuteScalar().ToString();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return dvv;
        }
    }
}
