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
    public class ManejaDbMaestro : IDVDAL<Producto> {
        string tipo;
        public ManejaDbMaestro(string tipo) { this.tipo = tipo; }
        public ManejaDbMaestro() { }
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private StoredProcedureHelper storedProcedureHelper;

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

        public bool esIdUnico(string id) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tipo} WHERE id = '{id}'", connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }
        //public bool esNomUsuUnico(string id) {
        //    using (SqlConnection connection = new SqlConnection(_connectionString)) {
        //        SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tipo} WHERE nomUsu = '{id}'", connection);
        //        connection.Open();
        //        int count = (int)command.ExecuteScalar();
        //        return count == 0;
        //    }
        //}

        public void modificarUsuario(Usuario usuario, string keyOg) {
            ManejaDbUsuarios manejaDbUsuarios = new ManejaDbUsuarios();
            manejaDbUsuarios.modificarUsuario(usuario, keyOg);
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
                                                    $"WHERE id = '{keyOg}' ",connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }                
            }
            actualizarDVV();
        }

        public void modificarCliente(Cliente cliente, string keyOg) {
            if (!esIdUnico(cliente.id)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand($"UPDATE Cliente SET nombre ='{cliente.nombre}'," +
                                                    $"apellido = '{cliente.apellido}'," +
                                                    $"telefono = '{cliente.telefono}'," +
                                                    $"domicilio = '{cliente.domicilio}'," +
                                                    $"id = '{cliente.id}'" +
                                                    $"WHERE id = '{keyOg}' ", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }                
            }
        }

        public void eliminarEntrada(string key) {
            string param = tipo.Equals("Usuarios") ? "nomUsu" : "id"; 
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand cmd = new SqlCommand($"DELETE FROM {tipo} WHERE {param} = '{key}' ", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            if (key.Equals("Usuarios")) {
                ManejaDbUsuarios manejaDbUsuarios = new ManejaDbUsuarios();
                manejaDbUsuarios.actualizarDVV();
            }
        }
    }
}
