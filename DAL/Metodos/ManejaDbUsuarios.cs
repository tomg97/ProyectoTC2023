using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUL.Entidades;

namespace DAL.Metodos {
    public class ManejaDbUsuarios {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        public int authUsuario(Usuario usuario) {
            int resultado = -1;

            if (!SingletonSesion.getInstance.estaLogged) {
                try {
                    using (SqlConnection connection = new SqlConnection(_connectionString)) {
                        SqlCommand command = new SqlCommand("AutenticarUsuario", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                        command.Parameters.AddWithValue("@pass", usuario.pass);
                        command.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                        connection.Open();
                        command.ExecuteNonQuery();
                        resultado = Convert.ToInt32(command.Parameters["@Result"].Value);
                    }
                } catch (Exception ex) {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            } else {
                throw new InvalidOperationException("Sesión ya iniciada");
            }
            return resultado;
        }
        public int lookupUsuario(string nomUsu) {
            int resultado = -1;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("LookupUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomUsu", nomUsu);
                    command.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    resultado = Convert.ToInt32(command.Parameters["@Result"].Value);
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return resultado;
        }
        public string crearUsuario(Usuario usuario) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("CrearUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                    command.Parameters.AddWithValue("@pass", usuario.pass);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Usuario ha sido creado.";
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
                return "Error";
            }
        }
        public int modificarNombreUsuario(string usuNuevo, string usuViejo) {
            int resultado = -1;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("ModificarNombreUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usuNuevo", usuNuevo);
                    command.Parameters.AddWithValue("@usuViejo", usuViejo);
                    command.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    resultado = Convert.ToInt32(command.Parameters["@Result"].Value);
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return resultado;
        }
        public List<Usuario> getUsuariosBloqueados() {
            List<Usuario> usuariosBloqueados = new List<Usuario>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("GetUsuariosBloqueados", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Usuario usuario = new Usuario() {
                            nomUsu = reader["nomUsu"].ToString()
                        };
                        usuariosBloqueados.Add(usuario);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return usuariosBloqueados;
        }
        public void desbloquearUsuario(string usuario) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("DesbloquearUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomUsu", usuario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public int cambioContraseña(string passActual, string passNueva) {
            int resultado = -1;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("CambioContraseña", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    Usuario usuario = SingletonSesion.getInstance.getUsuarioActual();
                    command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                    command.Parameters.AddWithValue("@pass", passActual);
                    command.Parameters.AddWithValue("@passNueva", passNueva);
                    command.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();
                    resultado = Convert.ToInt32(command.Parameters["@Result"].Value);
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return resultado;
        }
        public List<Usuario> traerTodosUsuarios() {
            List<Usuario> usuarios = new List<Usuario>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("TraerTodosUsuarios", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Usuario usuario = new Usuario() {
                            nomUsu = reader["nomUsu"].ToString()
                        };
                        usuarios.Add(usuario);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return usuarios;
        }
        public void guardarPermisos(Usuario usuario) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("GuardarPerfilPaso1", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                    command.ExecuteNonQuery();
                    foreach (var item in usuario.permisos) {
                        command = new SqlCommand("GuardarPerfilPaso2", connection);
                        command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                        command.Parameters.AddWithValue("@idPermiso", item.id);
                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

