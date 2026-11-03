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
using System.Windows.Forms;

namespace DAL.Metodos {
    public class ProveedorDAL : IDVDAL<Proveedor> {
        private readonly string _connectionString = DbConfig.Instance.ConnectionString;
        public List<Proveedor> getProveedores() {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getAllProveedores", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Proveedor proveedor = new Proveedor(
                            reader["CUIT"].ToString(),
                            reader["email"].ToString(),
                            reader["nombre"].ToString(),
                            reader["telefono"].ToString(),
                            reader["domicilio"].ToString(),
                            reader["banco"].ToString());
                        listaProveedores.Add(proveedor);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return listaProveedores;
        }
        public void guardarProveedorNuevo(Proveedor proveedor) {
            if (esIdUnico(proveedor.CUIT)) {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Proveedor " +
                        "(CUIT, email, nombre, banco, domicilio, telefono) " +
                        "VALUES (@CUIT, @email, @nombre, @banco, @domicilio, @telefono)", connection);
                    cmd.Parameters.AddWithValue("@CUIT", proveedor.CUIT);
                    cmd.Parameters.AddWithValue("@email", proveedor.email);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.nombre);
                    cmd.Parameters.AddWithValue("@banco", proveedor.banco);
                    cmd.Parameters.AddWithValue("@domicilio", proveedor.domicilio);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.telefono);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            } else {
                throw new Exception("El CUIT de Proveedor no es único. Ingrese uno nuevo.");
            }
        }
        public bool esIdUnico(string id) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM Proveedor WHERE CUIT = '{id}'", connection);
                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }
        public Proveedor getProveedor(string cuit) {
            Proveedor proveedor = null;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("getProveedorByCUIT", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CUIT", cuit);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read()) {
                        proveedor = new Proveedor(
                            reader["CUIT"].ToString(),
                            reader["email"].ToString(),
                            reader["nombre"].ToString(),
                            reader["telefono"].ToString(),
                            reader["domicilio"].ToString(),
                            reader["banco"].ToString());
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return proveedor;
        }

        public void completarRegistroProveedor(Proveedor proveedorAlmacenar) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand cmd = new SqlCommand(
                        $"UPDATE Proveedor SET telefono = '{proveedorAlmacenar.telefono}'," +
                        $"domicilio = '{proveedorAlmacenar.domicilio}'," +
                        $"banco = '{proveedorAlmacenar.banco}'," +
                        $"nombre = '{proveedorAlmacenar.nombre}'," +
                        $"email = '{proveedorAlmacenar.email}' " +
                        $"WHERE CUIT = '{proveedorAlmacenar.CUIT}' ", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public string calcularDVH(Proveedor proveedor) {
            StringBuilder sb = new StringBuilder();
            sb.Append(proveedor.CUIT);
            sb.Append(proveedor.nombre);
            sb.Append(proveedor.email);
            sb.Append(proveedor.domicilio);
            sb.Append(proveedor.telefono);
            sb.Append(proveedor.banco);

            return ServicioDV.obtenerDV(sb.ToString());
        }

        public string calcularDVV(List<Proveedor> lista) {
            return lista.Aggregate<Proveedor, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarTodosDV() {
            List<Proveedor> proveedores = getProveedores();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE Proveedor SET dvh = @dvh WHERE CUIT = @CUIT", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@CUIT", SqlDbType.VarChar);

                connection.Open();

                foreach (var p in proveedores) {
                    p.dvh = calcularDVH(p);
                    command.Parameters["@dvh"].Value = p.dvh;
                    command.Parameters["@CUIT"].Value = p.CUIT;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = Proveedor", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(getProveedores()));
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
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = Proveedor", connection);
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
