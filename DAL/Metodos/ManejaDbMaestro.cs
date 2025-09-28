using CUL.Entidades;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbMaestro {
        string tipo;
        public ManejaDbMaestro(string tipo) { this.tipo = tipo; }
        public ManejaDbMaestro() { }
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private StoredProcedureHelper storedProcedureHelper;

        public void guardarProductoNuevo(Producto producto) {
            if (esIdUnico(producto.id)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Producto " +
                        "(nombreProducto, marcaProducto, id, cantidad, precio) " +
                        "VALUES (@nombreProducto, @marcaProducto, @id, @cantidad, @precio)", connection);
                    cmd.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                    cmd.Parameters.AddWithValue("@marcaProducto", producto.marcaProducto);
                    cmd.Parameters.AddWithValue("@id", producto.id);
                    cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
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
                    list.Add(producto);
                }
                    reader.Close();
                    return list;
            }
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
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand cmd = new SqlCommand(
                    $"UPDATE Usuarios SET nombre = '{usuario.nombre}'," +
                    $"apellido = '{usuario.apellido}'," +
                    $"telefono = {usuario.telefono}," +
                    $"dni = '{usuario.dni}'," +
                    $"nomUsu = '{usuario.nomUsu}'," +
                    $"email = '{usuario.email}' " +
                    $"WHERE nomUsu = '{keyOg}' ", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        

        public void modificarProducto(Producto producto, string keyOg) {
            if (!esIdUnico(producto.id)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand($"UPDATE Producto SET nombreProducto='{producto.nombreProducto}'," +
                                                    $"marcaProducto = '{producto.marcaProducto}'," +
                                                    $"cantidad = {producto.cantidad}," +
                                                    $"precio = '{producto.precio}'," +
                                                    $"usuMod = '{SingletonSesion.getInstance.getUsuarioActual().nomUsu}'," +
                                                    $"id = '{producto.id}'" +
                                                    $"WHERE id = '{keyOg}' ",connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }                
            }
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
        }
    }
}
