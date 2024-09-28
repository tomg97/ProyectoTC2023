using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;

namespace DAL.Metodos {
    public class ManejaDbClientes {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper();
        public string crearCliente(Cliente cliente) {
            
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = storedProcedureHelper.rellenarYDevolverSPUpsert(cliente, connection, "CrearCliente");
                    connection.Open();
                    command.ExecuteNonQuery();
                    return "Cliente ha sido creado.";
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
        public List<Cliente> traerTodosClientes() {
            List<Cliente> list = new List<Cliente>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("SELECT * FROM Cliente", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();                
                while (reader.Read()) {
                    list.Add(storedProcedureHelper.crearObjetoDeDataReader<Cliente>(reader));
                }
                reader.Close();
                return list;
            }
        }
    }
}
