using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbClientes {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        public string crearCliente(Cliente cliente) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("CrearCliente", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", cliente.id);
                    command.Parameters.AddWithValue("@Nombre", cliente.nombre);
                    command.Parameters.AddWithValue("@Apellido", cliente.apellido);
                    command.Parameters.AddWithValue("@Domicilio", cliente.domicilio);
                    command.Parameters.AddWithValue("@Telefono", cliente.telefono);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Cliente ha sido creado.";
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
                return "Error";
            }
        }
        public int lookupCliente(string id) {
            int resultado = -1;
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("LookupCliente", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
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
    }
}
