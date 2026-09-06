using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ProductoDAL {
        private string _connectionString => ConnectionManager.GetConnectionString();

        public List<Producto> getProductosBajoStock() {
            List<Producto> listaProductos = new List<Producto>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getListaProductosEnStock", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Producto producto = new Producto(
                            reader["nombreProducto"].ToString(),
                            reader["marcaProducto"].ToString(),
                            reader["id"].ToString(),
                            reader["cantidad"].ToString(),
                            reader["precio"].ToString());
                        listaProductos.Add(producto);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return listaProductos;
        }
        public Producto getProducto(string idProducto) {
            Producto producto = null;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("SELECT nombreProducto, marcaProducto, id, cantidad FROM Productos WHERE id = @idProducto", connection);
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@idProducto", idProducto);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) {
                        producto = new Producto(
                            reader["nombreProducto"].ToString(),
                            reader["marcaProducto"].ToString(),
                            reader["id"].ToString(),
                            reader["cantidad"].ToString(),
                            reader["precio"].ToString());
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return producto;
        }
    }
}
