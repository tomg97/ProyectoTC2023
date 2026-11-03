using CUL.Entidades;
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
    public class ProductoDAL : IDVDAL<Producto> {
        private readonly string _connectionString = DbConfig.Instance.ConnectionString;

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
                    SqlCommand command = new SqlCommand("SELECT nombreProducto, marcaProducto, id, cantidad, precio FROM Producto WHERE id = @idProducto", connection);
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
        public void modificarProducto(Producto producto, string keyOg) {
            if (!esIdUnico(producto.id)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand($"UPDATE Producto SET nombreProducto='{producto.nombreProducto}'," +
                                                    $"marcaProducto = '{producto.marcaProducto}'," +
                                                    $"cantidad = {producto.cantidad}," +
                                                    $"precio = '{producto.precio}'," +
                                                    $"dvh = '{calcularDVH(producto)}'," +
                                                    $"usuMod = '{SingletonSesion.getInstance.getUsuarioActual().nomUsu}'," +
                                                    $"id = '{producto.id}'" +
                                                    $"WHERE id = '{keyOg}' ", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            actualizarDVV();
        }
        public List<Producto> traerTodosProductos() {
            List<Producto> list = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("SELECT * FROM Producto", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Producto producto = new Producto(
                        reader["nombreProducto"].ToString(),
                        reader["marcaProducto"].ToString(),
                        reader["id"].ToString(),
                        reader["cantidad"].ToString(),
                        reader["precio"].ToString());
                    producto.dvh = reader["dvh"].ToString();
                    list.Add(producto);
                }
                reader.Close();
                return list;
            }
        }
        public void guardarProductoNuevo(Producto producto) {
            if (esIdUnico(producto.id)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Producto " +
                        "(nombreProducto, marcaProducto, id, cantidad, precio, dvh) " +
                        "VALUES (@nombreProducto, @marcaProducto, @id, @cantidad, @precio, @dvh)", connection);
                    cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@marcaProducto", producto.marcaProducto);
                    cmd.Parameters.AddWithValue("@id", producto.id);
                    cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@dvh", calcularDVH(producto));

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                actualizarDVV();
            } else {
                throw new Exception("El id de Producto no es único. Ingrese uno nuevo.");
            }
        }
        public bool esIdUnico(string id) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Producto WHERE id = '{id}'", connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }
        public string calcularDVH(Producto producto) {
            StringBuilder sb = new StringBuilder();
            sb.Append(producto.nombreProducto);
            sb.Append(producto.marcaProducto);
            sb.Append(producto.id);
            sb.Append(producto.cantidad);
            sb.Append(producto.precio);

            return ServicioDV.obtenerDV(sb.ToString());
        }
        public string calcularDVV(List<Producto> lista) {
            return lista.Aggregate<Producto, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = 'Producto'", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(traerTodosProductos()));
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void actualizarTodosDV() {
            List<Producto> productos = traerTodosProductos();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE Producto SET dvh = @dvh WHERE id = @id", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@id", SqlDbType.VarChar);

                connection.Open();

                foreach (var p in productos) {
                    p.dvh = calcularDVH(p);
                    command.Parameters["@dvh"].Value = p.dvh;
                    command.Parameters["@id"].Value = p.id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public string obtenerDVV() {
            string dvv = "";
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = 'Producto'", connection);
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
