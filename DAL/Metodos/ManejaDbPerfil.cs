using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbPerfil {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";

        public Array GetAllPermisos() {
            return Enum.GetValues(typeof(TipoPermiso));
        }
        public void GuardarComponente(Componente componente, bool esfamilia) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("GuardarComponente", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@nombre", componente.nombre);

                    if (esfamilia)
                        command.Parameters.AddWithValue("@permiso", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@permiso", componente.tipoPermiso.ToString());
                    command.ExecuteNonQuery();
                }                
            } catch (Exception e) {
                throw e;
            }
        }

        public void GuardarFamilia(Familia familia) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    connection.Open();
                    var cmd = new SqlCommand("GuardarFamiliaPaso1", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", familia.id);
                    cmd.ExecuteNonQuery();

                    foreach (var item in familia.hijos) {
                        cmd = new SqlCommand("GuardarFamiliaPaso2", connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@idPadre", familia.id));
                        cmd.Parameters.Add(new SqlParameter("@idHijo", item.id));

                        cmd.ExecuteNonQuery();
                    }
                }                
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public List<Permiso> GetAllPatentes() {
            var lista = new List<Permiso>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    var cmd = new SqlCommand("TraerTodasPatentes", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        Permiso c = new Permiso();
                        c.id = Convert.ToInt32(reader["idPermiso"]);
                        c.nombre = reader["nombre"].ToString();
                        var permiso = reader["permiso"].ToString();
                        c.tipoPermiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);
                        lista.Add(c);
                    }
                    reader.Close();
                    return lista;
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return lista;
        }
        public List<Familia> GetAllFamilias() {
            var lista = new List<Familia>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("TraerFamilias", connection);

                    cmd.CommandType = CommandType.StoredProcedure;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read()) { 
                        Familia c = new Familia();
                        c.id = Convert.ToInt32(reader["idPermiso"]);
                        c.nombre = reader["nombre"].ToString();
                        lista.Add(c);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return lista;
        }
        public List<Componente> GetAll(string familia) {
            var where = "is NULL";
            var lista = new List<Componente>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    if (!String.IsNullOrEmpty(familia)) {
                        where = familia;
                    }
                    connection.Open();
                    var cmd = new SqlCommand();
                    cmd.Connection = connection;

                    var sql = $@"with recursivo as (
                        select sp2.idPerfilPadre, sp2.idPerfilHijo  from PermisoPermiso SP2
                        where sp2.idPerfilPadre {where} --acá se va variando la familia que busco
                        UNION ALL 
                        select sp.idPerfilPadre, sp.idPerfilHijo from PermisoPermiso sp 
                        inner join recursivo r on r.idPerfilHijo= sp.idPerfilPadre
                        )
                        select r.idPerfilPadre,r.idPerfilHijo,p.idPermiso,p.nombre, p.permiso
                        from recursivo r 
                        inner join Permisos p on r.idPerfilHijo = p.idPermiso";

                    cmd.CommandText = sql;

                    var reader = cmd.ExecuteReader();

                    while (reader.Read()) {
                        int id_padre = 0;
                        if (reader["idPerfilPadre"] != DBNull.Value) {
                            id_padre = Convert.ToInt32(reader["idPerfilPadre"]);
                        }

                        var id = Convert.ToInt32(reader["idPermiso"]);
                        var nombre = reader["nombre"].ToString();

                        var permiso = string.Empty;
                        if (reader["permiso"] != DBNull.Value)
                            permiso = reader["permiso"].ToString();

                        Componente c;

                        if (string.IsNullOrEmpty(permiso))//usamos este campo para identificar. Solo las patentes van a tener un permiso del sistema relacionado
                            c = new Familia();

                        else
                            c = new Permiso();

                        c.id = id;
                        c.nombre = nombre;
                        if (!string.IsNullOrEmpty(permiso))
                            c.tipoPermiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permiso);

                        var padre = GetComponent(id_padre, lista);

                        if (padre == null) {
                            lista.Add(c);
                        } else {
                            padre.agregar(c);
                        }
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return lista;
        }

        private Componente GetComponent(int id, IList<Componente> lista) {

            Componente component = lista != null ? lista.Where(i => i.id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null) {
                foreach (var item in lista) {
                    var componente = GetComponent(id, item.hijos);
                    if (componente != null && componente.id == id) 
                        return componente;
                    else
                    if (componente != null)
                        return GetComponent(id, componente.hijos);
                }
            }
            return component;
        }

        public void FillUserComponents(Usuario u) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    var cmd2 = new SqlCommand("TraerPermisosByUsuario", connection);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@nomUsu", u.nomUsu);
                    connection.Open();

                    var reader = cmd2.ExecuteReader();
                    u.permisos.Clear();
                    while (reader.Read()) {
                        int idp = Convert.ToInt32(reader["idPermiso"]);
                        string nombrep = reader["nombre"].ToString();

                        var permisop = String.Empty;
                        if (reader["permiso"] != DBNull.Value)
                            permisop = reader["permiso"].ToString();

                        Componente c1;
                        if (!String.IsNullOrEmpty(permisop)) {
                            c1 = new Permiso();
                            c1.id = idp;
                            c1.nombre = nombrep;
                            c1.tipoPermiso = (TipoPermiso)Enum.Parse(typeof(TipoPermiso), permisop);
                            u.permisos.Add(c1);
                        } else {
                            c1 = new Familia();
                            c1.id = idp;
                            c1.nombre = nombrep;

                            var f = GetAll("=" + idp);

                            foreach (var familia in f) {
                                c1.agregar(familia);
                            }
                            u.permisos.Add(c1);
                        }
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void FillFamilyComponents(Familia familia) {
            familia.vaciarHijos();
            foreach (var item in GetAll("=" + familia.id)) {
                familia.agregar(item);
            }
        }
    }
}
