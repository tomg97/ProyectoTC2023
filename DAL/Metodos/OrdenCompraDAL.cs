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
    public class OrdenCompraDAL : IDVDAL<OrdenCompra> {
        private readonly string _connectionString = DbConfig.Instance.ConnectionString;
        public List<OrdenCompra> getOrdenesCompra() {
            List<OrdenCompra> listaOrdenesCompra = new List<OrdenCompra>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getAllOrdenes", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        OrdenCompra ordenCompra = new OrdenCompra(
                            reader["id"].ToString(),
                            reader["idCotizacion"].ToString(),
                            reader["estado"].ToString(),
                            reader["total"].ToString(),
                            reader["productos"].ToString(),
                            reader["cuitProveedor"].ToString());
                        ordenCompra.comentario = reader["comentario"].ToString();
                        ordenCompra.dvh = reader["dvh"].ToString();
                        listaOrdenesCompra.Add(ordenCompra);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return listaOrdenesCompra;
        }
        public OrdenCompra getOrdenCompra(string id) {
            OrdenCompra ordenCompra = null;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getOrdenById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) {
                        ordenCompra = new OrdenCompra(
                            reader["id"].ToString(),
                            reader["idCotizacion"].ToString(),
                            reader["estado"].ToString(),
                            reader["total"].ToString(),
                            reader["productos"].ToString(),
                            reader["cuitProveedor"].ToString());
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return ordenCompra;
        }
        public void almacenarOrdenCompra(OrdenCompra ordenCompra) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    string insertQuery = "INSERT INTO OrdenCompra " +
                        "(fecha, estado, productos, total, cuitProveedor, idCotizacion, dvh) " +
                        "VALUES (@fechaCreacion, @estado, @productos, @total, @cuitProveedor, @idCotizacion, @dvh)";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@estado", "Pendiente");
                    cmd.Parameters.AddWithValue("@productos", JsonConvert.SerializeObject(ordenCompra.productos));
                    cmd.Parameters.AddWithValue("@total", ordenCompra.total);
                    cmd.Parameters.AddWithValue("@cuitProveedor", ordenCompra.cuitProveedor);
                    cmd.Parameters.AddWithValue("@idCotizacion", ordenCompra.idCotizacion);
                    cmd.Parameters.AddWithValue("@dvh", calcularDVH(ordenCompra));

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                actualizarDVV();
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public bool esUnico(string idCotizacion) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM OrdenCompra WHERE idCotizacion = '{idCotizacion}' AND estado = 'Pendiente'", connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }

        public void modificarOrdenCompra(OrdenCompra ordenCompra) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand(
                        $"UPDATE OrdenCompra SET estado = '{ordenCompra.estado}'," +
                        $"comentario = '{ordenCompra.comentario}' ," +
                        $"dvh = '{calcularDVH(ordenCompra)}' " +
                        $"WHERE idCotizacion = '{ordenCompra.idCotizacion}'",connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                actualizarDVV();
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public string calcularDVH(OrdenCompra orden) {
            StringBuilder sb = new StringBuilder();
            sb.Append(orden.id);
            sb.Append(orden.idCotizacion);
            sb.Append(orden.estado);
            sb.Append(orden.total);
            sb.Append(orden.cuitProveedor);
            sb.Append(orden.productos);
            sb.Append(orden.comentario);

            return ServicioDV.obtenerDV(sb.ToString());
        }

        public string calcularDVV(List<OrdenCompra> lista) {
            return lista.Aggregate<OrdenCompra, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarTodosDV() {
            List<OrdenCompra> ordenes = getOrdenesCompra();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE OrdenCompra SET dvh = @dvh WHERE id = @id", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@id", SqlDbType.VarChar);

                connection.Open();

                foreach (var o in ordenes) {
                    o.dvh = calcularDVH(o);
                    command.Parameters["@dvh"].Value = o.dvh;
                    command.Parameters["@id"].Value = o.id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = 'OrdenCompra'", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(getOrdenesCompra()));
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
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = 'OrdenCompra'", connection);
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
