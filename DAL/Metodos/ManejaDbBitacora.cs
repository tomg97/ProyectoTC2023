using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbBitacora {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";

        public List<Mensaje> lookupMensajesBitacora(Dictionary<string, string> parametros) {
            List<Mensaje> resultado = new List<Mensaje>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("lookupMensajesBitacora", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@usuario", parametros["usuario"]);
                    command.Parameters.AddWithValue("@tipo", parametros["tipo"]);
                    command.Parameters.AddWithValue("@FromDate", parametros["fechaDesde"]);
                    command.Parameters.AddWithValue("@ToDate", parametros["fechaHasta"]);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Mensaje mensaje = new Mensaje(reader["id"].ToString(),
                            reader["contenido"].ToString(),
                            DateTime.Parse(reader["fecha"].ToString()),
                            reader["usuario"].ToString(),
                            reader["tipo"].ToString());
                        resultado.Add(mensaje);
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            resultado.Sort((m1, m2) => m2.fecha.CompareTo(m1.fecha));
            return resultado;
        }
        public void crearEntradaBitacora(Mensaje mensaje) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("CrearUsuario", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", mensaje.id);
                    command.Parameters.AddWithValue("@contenido", mensaje.contenido);
                    command.Parameters.AddWithValue("@fecha", mensaje.fecha);
                    command.Parameters.AddWithValue("@usuario", mensaje.usuario);
                    command.Parameters.AddWithValue("@tipo", mensaje.tipo);
                     
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
