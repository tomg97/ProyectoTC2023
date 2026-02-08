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
    public class OrdenCompraDAL {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
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
                            reader["fechaCreacion"].ToString(),
                            reader["estado"].ToString(),
                            reader["total"].ToString(),
                            reader["productos"].ToString(),
                            reader["cuitProveedor"].ToString(),
                            reader["fechaRecepcion"].ToString());
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
                            reader["fechaCreacion"].ToString(),
                            reader["estado"].ToString(),
                            reader["total"].ToString(),
                            reader["productos"].ToString(),
                            reader["cuitProveedor"].ToString(),
                            reader["fechaRecepcion"].ToString());
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
                    // Determinar el nuevo id sumando 1 al último id existente
                    string getMaxIdQuery = "SELECT ISNULL(MAX(CAST(id AS INT)), 0) + 1 FROM OrdenCompra";
                    SqlCommand getMaxIdCmd = new SqlCommand(getMaxIdQuery, connection);

                    connection.Open();
                    int newId = (int)getMaxIdCmd.ExecuteScalar();

                    string insertQuery = "INSERT INTO OrdenCompra " +
                        "(id, idCotizacion, fechaCreacion, estado, productos, total, cuitProveedor, fechaRecepcion, motivo) " +
                        "VALUES (@id, @idCotizacion, @fechaCreacion, @estado, @productos, @total, @cuitProveedor, @fechaRecepcion, '')";

                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@id", newId.ToString());
                    cmd.Parameters.AddWithValue("@idCotizacion", ordenCompra.idCotizacion);
                    cmd.Parameters.AddWithValue("@fechaCreacion", ordenCompra.fechaCreacion);
                    cmd.Parameters.AddWithValue("@estado", ordenCompra.estado);
                    cmd.Parameters.AddWithValue("@productos", JsonConvert.SerializeObject(ordenCompra.productos));
                    cmd.Parameters.AddWithValue("@total", ordenCompra.total);
                    cmd.Parameters.AddWithValue("@cuitProveedor", ordenCompra.cuitProveedor);
                    cmd.Parameters.AddWithValue("@fechaRecepcion", ordenCompra.fechaRecepcion);

                    cmd.ExecuteNonQuery();
                }
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
                        $"UPDATE OrdenCompra SET fechaRecepcion = '{ordenCompra.fechaRecepcion}'," +
                        $"estado = '{ordenCompra.estado}'," +
                        $"motivo = '{ordenCompra.motivo}'," +
                        $"WHERE idCotizacion = '{ordenCompra.idCotizacion}'",connection);
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
