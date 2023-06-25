using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbVenta {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        public List<Producto> getProductosEnStock() {
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
        public string actualizarStock(List<Producto> productos) {
            string mensaje = "0";
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand("RemoverDeStock", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    foreach (Producto producto in productos) {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@Id", producto.id);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", producto.cantidad);
                        sqlCommand.ExecuteNonQuery();
                    }
                    mensaje = "éxito";
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
                mensaje = "error";
            }
            return mensaje;
        }
        public void crearVentaNoFacturada(Venta venta) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand("CrearVenta", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@productosVendidos", venta.productosVendidos.ToString());
                    sqlCommand.Parameters.AddWithValue("@id", venta.id);
                    sqlCommand.Parameters.AddWithValue("@monto", venta.monto);
                    sqlCommand.Parameters.AddWithValue("@fecha", venta.fecha);
                    sqlCommand.Parameters.AddWithValue("@cliente", venta.cliente.id);
                    sqlCommand.Parameters.AddWithValue("@facturada", 0);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
