using CUL.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class SolicitudCotizacionDAL {
        private string _connectionString => ConnectionManager.GetConnectionString();

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
                    cmd.Parameters.AddWithValue("@Estado", "Pendiente");

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
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
                            reader["total"].ToString(),
                            reader["estado"].ToString());
                        solicitudes.Add(solicitudCotizacion);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return solicitudes;
        }
    }
}
