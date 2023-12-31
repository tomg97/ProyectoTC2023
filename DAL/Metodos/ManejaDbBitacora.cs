﻿using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;
using System.Collections;

namespace DAL.Metodos {
    public class ManejaDbBitacora {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper();

        public List<Mensaje> lookupMensajesBitacora(Dictionary<string, string> parametros) {
            List<Mensaje> resultado = new List<Mensaje>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("lookupMensajesBitacora", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, string> entry in parametros) {
                        command.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Mensaje mensaje = storedProcedureHelper.crearObjetoDeDataReader<Mensaje>(reader);
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
                    SqlCommand command = storedProcedureHelper.rellenarYDevolverSPUpsert(mensaje, connection, "CrearUsuario");
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
