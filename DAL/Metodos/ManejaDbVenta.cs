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
    }
}
