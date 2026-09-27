using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Servicios.Interfaces;
using Servicios.Metodos;

namespace DAL.Metodos {
    public class ManejaDbVenta : IDVDAL<Venta> {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True"; 
        private StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper();
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
        public string actualizarStock(List<Producto> productos, string nomUsu) {
            string mensaje = "0";
            ManejaDbMaestro dbProducto = new ManejaDbMaestro("Producto");
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand();

                    connection.Open();
                    foreach (Producto producto in productos) {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.Parameters.AddWithValue("@Id", producto.id);
                        sqlCommand.Parameters.AddWithValue("@Cantidad", producto.cantidad);
                        sqlCommand.Parameters.AddWithValue("@Usuario", nomUsu);
                        sqlCommand.Parameters.AddWithValue("@dvh", dbProducto.calcularDVH(producto));
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
                    sqlCommand.Parameters.AddWithValue("@cliente", venta.idCliente);
                    sqlCommand.Parameters.AddWithValue("@dvh", calcularDVH(venta));
                    sqlCommand.Parameters.AddWithValue("@facturada", 0);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                actualizarDVV();
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public List<Venta> getVentasNoFacturadas() {
            List<Venta> ventas = new List<Venta>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand("GetVentasNoFacturadas", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read()) {
                        Venta venta = new Venta(
                            reader["id"].ToString(),
                            reader["productosVendidos"].ToString(),
                            reader["clienteId"].ToString(),
                            reader["fecha"].ToString());
                        ventas.Add(venta);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return ventas;
        }
        public void facturarVenta(Venta venta) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand("CrearFactura", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", venta.id);
                    sqlCommand.Parameters.AddWithValue("@jsonVenta", JsonConvert.SerializeObject(venta));
                    sqlCommand.Parameters.AddWithValue("@idCliente", venta.idCliente);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                actualizarDVV();
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void despacharFactura(params string[] datos) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand sqlCommand = new SqlCommand("DespachoFactura", connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", datos[0]);
                    sqlCommand.Parameters.AddWithValue("@idCliente", datos[1]);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                actualizarDVV();
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public List<Venta> traerTodos() {
            List<Venta> ventas = new List<Venta>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("SELECT * FROM Venta", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Venta venta = new Venta(
                            reader["id"].ToString(),
                            reader["productosVendidos"].ToString(),
                            reader["clienteId"].ToString(),
                            reader["fecha"].ToString());
                        venta.monto = reader["monto"].ToString();
                        venta.dvh = reader["dvh"].ToString();
                        ventas.Add(venta);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return ventas;
        }

        public string calcularDVH(Venta venta) {
            StringBuilder sb = new StringBuilder();
            sb.Append(venta.id);
            sb.Append(venta.idCliente);
            sb.Append(venta.fecha);
            sb.Append(venta.monto);

            return ServicioDV.obtenerDV(sb.ToString());
        }

        public string calcularDVV(List<Venta> lista) {
            return lista.Aggregate<Venta, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarTodosDV() {
            List<Venta> ventas = traerTodos();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE Venta SET dvh = @dvh WHERE id = @id", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@id", SqlDbType.VarChar);

                connection.Open();

                foreach (var v in ventas) {
                    v.dvh = calcularDVH(v);
                    command.Parameters["@dvh"].Value = v.dvh;
                    command.Parameters["@id"].Value = v.id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = 'Venta'", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(traerTodos()));
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
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = 'Venta'", connection);
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
