using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Metodos
{
    public class PerfilDAL
    {
        private string _connectionString => ConnectionManager.GetConnectionString();

        #region Operaciones de Componentes

        public int guardarComponente(Componente componente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpsertComponente", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter("@idPermiso", SqlDbType.Int);
                    paramId.Value = componente.id > 0 ? (object)componente.id : DBNull.Value;
                    paramId.Direction = ParameterDirection.InputOutput;
                    command.Parameters.Add(paramId);

                    command.Parameters.AddWithValue("@nombre", componente.nombre);
                    command.Parameters.AddWithValue("@permiso",
                        componente.esCompuesto ? DBNull.Value : (object)componente.tipoPermiso.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();

                    componente.id = (int)paramId.Value;
                    return componente.id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar componente: {ex.Message}", ex);
            }
        }

        public void guardarPerfil(Familia perfil)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    if (perfil.id == 0)
                    {
                        perfil.id = guardarComponente(perfil);
                    }

                    SqlCommand command = new SqlCommand("GuardarJerarquiaPerfil", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPerfil", perfil.id);

                    var hijosIds = perfil.obtenerIdsHijos();
                    var hijosJson = construirJsonArray(hijosIds);
                    command.Parameters.AddWithValue("@hijosIds", hijosJson);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar perfil: {ex.Message}", ex);
            }
        }

        public List<Permiso> obtenerTodosLosPermisos()
        {
            List<Permiso> lista = new List<Permiso>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("ObtenerComponentesConJerarquia", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPerfil", DBNull.Value);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("permiso")))
                        {
                            Permiso permiso = new Permiso();
                            permiso.id = reader.GetInt32(reader.GetOrdinal("idPermiso"));
                            permiso.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            permiso.tipoPermiso = (TipoPermiso)Enum.Parse(
                                typeof(TipoPermiso),
                                reader.GetString(reader.GetOrdinal("permiso")));
                            lista.Add(permiso);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener permisos: {ex.Message}", ex);
            }
            return lista;
        }

        public List<Familia> obtenerTodosLosPerfiles()
        {
            List<Familia> lista = new List<Familia>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("ObtenerComponentesConJerarquia", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPerfil", DBNull.Value);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.IsDBNull(reader.GetOrdinal("permiso")))
                        {
                            Familia familia = new Familia();
                            familia.id = reader.GetInt32(reader.GetOrdinal("idPermiso"));
                            familia.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            lista.Add(familia);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener perfiles: {ex.Message}", ex);
            }
            return lista;
        }

        public void cargarJerarquiaPerfil(Familia perfil)
        {
            try
            {
                perfil.vaciarHijos();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("ObtenerComponentesConJerarquia", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idPerfil", perfil.id);

                    connection.Open();
                    Dictionary<int, Componente> componentes = new Dictionary<int, Componente>();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int idPadre = reader.GetInt32(reader.GetOrdinal("idPerfilPadre"));
                        int idHijo = reader.GetInt32(reader.GetOrdinal("idPermiso"));
                        string nombreHijo = reader.GetString(reader.GetOrdinal("nombre"));
                        bool esCompuesto = reader.IsDBNull(reader.GetOrdinal("permiso"));

                        Componente hijo;
                        if (!componentes.TryGetValue(idHijo, out hijo))
                        {
                            if (esCompuesto)
                            {
                                hijo = new Familia();
                                hijo.id = idHijo;
                                hijo.nombre = nombreHijo;
                            }
                            else
                            {
                                hijo = new Permiso();
                                hijo.id = idHijo;
                                hijo.nombre = nombreHijo;
                                hijo.tipoPermiso = (TipoPermiso)Enum.Parse(
                                    typeof(TipoPermiso),
                                    reader.GetString(reader.GetOrdinal("permiso")));
                            }
                            componentes[idHijo] = hijo;
                        }

                        if (idPadre == perfil.id)
                        {
                            perfil.agregar(hijo);
                        }
                        else if (componentes.ContainsKey(idPadre) && componentes[idPadre].esCompuesto)
                        {
                            componentes[idPadre].agregar(hijo);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar jerarquía del perfil: {ex.Message}", ex);
            }
        }

        #endregion

        #region Operaciones de Usuario

        public void cargarPermisosUsuario(Usuario usuario)
        {
            try
            {
                usuario.permisos.Clear();

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarPermisosUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);
                    command.Parameters.AddWithValue("@permisosIds", DBNull.Value);
                    command.Parameters.AddWithValue("@accion", "GET");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        bool esPerfil = reader.GetBoolean(reader.GetOrdinal("EsPerfil"));

                        if (esPerfil)
                        {
                            Familia familia = new Familia();
                            familia.id = reader.GetInt32(reader.GetOrdinal("idPermiso"));
                            familia.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            cargarJerarquiaPerfil(familia);
                            usuario.permisos.Add(familia);
                        }
                        else
                        {
                            Permiso permiso = new Permiso();
                            permiso.id = reader.GetInt32(reader.GetOrdinal("idPermiso"));
                            permiso.nombre = reader.GetString(reader.GetOrdinal("nombre"));
                            permiso.tipoPermiso = (TipoPermiso)Enum.Parse(
                                typeof(TipoPermiso),
                                reader.GetString(reader.GetOrdinal("permiso")));
                            usuario.permisos.Add(permiso);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar permisos del usuario: {ex.Message}", ex);
            }
        }

        public void guardarPermisosUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GestionarPermisosUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@nomUsu", usuario.nomUsu);

                    List<int> permisosIds = usuario.permisos.Select(p => p.id).ToList();
                    string permisosJson = construirJsonArray(permisosIds);
                    command.Parameters.AddWithValue("@permisosIds", permisosJson);
                    command.Parameters.AddWithValue("@accion", "SET");

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar permisos del usuario: {ex.Message}", ex);
            }
        }

        #endregion

        #region Métodos Auxiliares

        private string construirJsonArray(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
                return "[]";

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < ids.Count; i++)
            {
                sb.Append(ids[i]);
                if (i < ids.Count - 1)
                    sb.Append(",");
            }
            sb.Append("]");
            return sb.ToString();
        }

        #endregion
    }
}