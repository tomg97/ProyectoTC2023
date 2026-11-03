using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;
using Servicios.Interfaces;

namespace DAL.Metodos {
    public class ManejaDbClientes : IDVDAL<Cliente> {
        private readonly string _connectionString = DbConfig.Instance.ConnectionString;
        private StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper();
        public string crearCliente(Cliente cliente) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {

                    SqlCommand command = storedProcedureHelper.rellenarYDevolverSPUpsert(cliente, connection, "CrearCliente");
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", cliente.id);
                    command.Parameters.AddWithValue("@nombre", cliente.nombre);
                    command.Parameters.AddWithValue("@apellido", cliente.apellido);
                    command.Parameters.AddWithValue("@domicilio", cliente.domicilio);
                    command.Parameters.AddWithValue("@telefono", cliente.telefono);
                    command.Parameters.AddWithValue("@dvh", calcularDVH(cliente));

                    connection.Open();
                    command.ExecuteNonQuery();
                    actualizarDVV();
                    return "Cliente ha sido creado.";
                }
                
            } catch (Exception ex) {
                return "Error al crear cliente: " + ex.Message;
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
        public string calcularDVH(Cliente cliente) {
            StringBuilder sb = new StringBuilder();
            sb.Append(cliente.id);
            sb.Append(cliente.nombre);
            sb.Append(cliente.apellido);
            sb.Append(cliente.domicilio);
            sb.Append(cliente.telefono);

            return ServicioDV.obtenerDV(sb.ToString());
        }

        public string calcularDVV(List<Cliente> lista) {
            return lista.Aggregate<Cliente, String>("", (a, b) => ServicioDV.obtenerDV(a + b.dvh));
        }

        public void actualizarTodosDV() {
            List<Cliente> clientes = traerTodosClientes();

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("UPDATE Cliente SET dvh = @dvh WHERE id = @id", connection);
                command.Parameters.Add("@dvh", SqlDbType.VarChar);
                command.Parameters.Add("@id", SqlDbType.VarChar);

                connection.Open();

                foreach (var v in clientes) {
                    v.dvh = calcularDVH(v);
                    command.Parameters["@dvh"].Value = v.dvh;
                    command.Parameters["@id"].Value = v.id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void actualizarDVV() {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("UPDATE DVV SET dvv = @dvv WHERE nombreTabla = 'Cliente'", connection);
                    command.Parameters.AddWithValue("@dvv", calcularDVV(traerTodosClientes()));
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
                    SqlCommand command = new SqlCommand("SELECT dvv FROM DVV WHERE nombreTabla = 'Cliente'", connection);
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
