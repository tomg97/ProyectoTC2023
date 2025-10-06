using CUL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.Metodos;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using System.Reflection;

namespace DAL.Metodos {
    public class ManejaDbBitacora {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
        private StoredProcedureHelper storedProcedureHelper = new StoredProcedureHelper();

        public List<MensajeEvento> lookupMensajesBitacoraEventos(Dictionary<string, string> parametros) {
            List<MensajeEvento> resultado = new List<MensajeEvento>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("lookupMensajesBitacora", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, string> entry in parametros) {
                        command.Parameters.AddWithValue(entry.Key, string.IsNullOrEmpty(entry.Value) ? (object)DBNull.Value : entry.Value);
                    }
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            MensajeEvento mensaje = new MensajeEvento();
                            mensaje.id = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                            mensaje.contenido = parsearEvento(reader.GetString(reader.GetOrdinal("contenido")));
                            mensaje.usuario = reader.GetString(reader.GetOrdinal("usuario"));
                            mensaje.fecha = reader.GetDateTime(reader.GetOrdinal("fecha"));
                            mensaje.modulo = parsearModulo(reader.GetString(reader.GetOrdinal("modulo")));
                            mensaje.criticidad = parsearCriticidad(reader.GetString(reader.GetOrdinal("criticidad")));

                            resultado.Add(mensaje);
                        }
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return resultado;
        }
        public List<MensajeCambio> lookupMensajesBitacoraCambios(Dictionary<string, string> parametros) {
            List<MensajeCambio> resultado = new List<MensajeCambio>();
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("lookupMensajesBitacoraCambios", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (KeyValuePair<string, string> entry in parametros) {
                        command.Parameters.AddWithValue(entry.Key, string.IsNullOrEmpty(entry.Value) ? (object)DBNull.Value : entry.Value);
                    }
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            MensajeCambio mensaje = new MensajeCambio();
                            mensaje.idOperacion = reader.GetInt32(reader.GetOrdinal("idOp")).ToString();
                            mensaje.idProducto = reader.GetInt32(reader.GetOrdinal("id")).ToString();
                            mensaje.nombreProducto = reader.GetString(reader.GetOrdinal("nombreProducto"));
                            mensaje.precio = reader.GetString(reader.GetOrdinal("precio"));
                            mensaje.cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")).ToString();
                            mensaje.fecha = reader.GetDateTime(reader.GetOrdinal("fechaMod"));
                            mensaje.tipoOp = parsearTipoOp(reader.GetString(reader.GetOrdinal("tipoOp")));
                            mensaje.marcaProducto = parsearMarcaProducto(reader.GetString(reader.GetOrdinal("marcaProducto")));                            
                            mensaje.activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1;
                            mensaje.usuario = reader.GetString(reader.GetOrdinal("usuMod"));

                            resultado.Add(mensaje);
                        }
                    }
                    reader.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            return resultado;
        }

        public void crearEntradaBitacora(MensajeEvento mensaje) {
            try {
                using (SqlConnection connection = new SqlConnection(_connectionString)) {
                    SqlCommand command = new SqlCommand("INSERT INTO Bitacora (contenido, fecha, usuario, criticidad, modulo) VALUES (@contenido, @fecha, @usuario, @criticidad, @modulo)", connection);
                    command.Parameters.AddWithValue("@contenido", mensaje.contenido);
                    command.Parameters.AddWithValue("@fecha", mensaje.fecha);
                    command.Parameters.AddWithValue("@usuario", mensaje.usuario);
                    command.Parameters.AddWithValue("@criticidad", mensaje.criticidad);
                    command.Parameters.AddWithValue("@modulo", mensaje.modulo.ToString());

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public List<MensajeEvento> traerTodaBitacoraEventos() {
            List<MensajeEvento> list = new List<MensajeEvento>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("SELECT * FROM Bitacora ORDER BY fecha DESC", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    MensajeEvento mensaje = new MensajeEvento {
                        id = reader.GetInt32(reader.GetOrdinal("id")).ToString(),
                        contenido = parsearEvento(reader.GetString(reader.GetOrdinal("contenido"))),
                        usuario = reader.GetString(reader.GetOrdinal("usuario")),
                        fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                        modulo = parsearModulo(reader.GetString(reader.GetOrdinal("modulo"))),
                        criticidad = parsearCriticidad(reader.GetString(reader.GetOrdinal("criticidad")))
                    };
                    list.Add(mensaje);
               }
                reader.Close();
            }            
            return list;
        }
        public List<MensajeCambio> traerTodaBitacoraCambios() {
            List<MensajeCambio> list = new List<MensajeCambio>();
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand command = new SqlCommand("SELECT * FROM ProductoHistorico ORDER BY fechaMod DESC", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    MensajeCambio mensaje = new MensajeCambio {
                        idOperacion = reader.GetInt32(reader.GetOrdinal("idOp")).ToString(),
                        idProducto = reader.GetInt32(reader.GetOrdinal("id")).ToString(),
                        nombreProducto = reader.GetString(reader.GetOrdinal("nombreProducto")),
                        precio = reader.GetString(reader.GetOrdinal("precio")),
                        cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")).ToString(),
                        fecha = reader.GetDateTime(reader.GetOrdinal("fechaMod")),
                        tipoOp = parsearTipoOp(reader.GetString(reader.GetOrdinal("tipoOp"))),
                        marcaProducto = parsearMarcaProducto(reader.GetString(reader.GetOrdinal("marcaProducto"))),
                        activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1,
                        usuario = reader.GetString(reader.GetOrdinal("usuMod"))
                    };
                    list.Add(mensaje);
               }
                reader.Close();
            }            
            return list;
        }

        static private Modulo parsearModulo(string moduloIn) {
            if(Enum.TryParse(moduloIn, true, out Modulo moduloOut)){
                return moduloOut;
            } else {
                throw new ArgumentException($"Valor de módulo inválido: {moduloIn}");
            }
        }
        static private Criticidad parsearCriticidad(string criticidadIn) {
            if (Enum.TryParse(criticidadIn, true, out Criticidad criticidadOut)) {
                return criticidadOut;
            } else {
                throw new ArgumentException($"Valor de criticidad inválido: {criticidadIn}");
            }
        }
        static private EventoEnum parsearEvento(string eventoIn) {
            if (Enum.TryParse(eventoIn, true, out EventoEnum eventoOut)) {
                return eventoOut;
            } else {
                throw new ArgumentException($"Valor de evento inválido: {eventoIn}");
            }
        }
        static private MensajeCambio.TipoOperacion parsearTipoOp(string tipoOpIn) {
            if(Enum.TryParse(tipoOpIn, true, out MensajeCambio.TipoOperacion tipoOpOut)){
                return tipoOpOut;
            } else {
                throw new ArgumentException($"Valor de Tipo Operación inválido: {tipoOpIn}");
            }
        }
        static private MarcaProducto parsearMarcaProducto(string marcaIn) {
            if(Enum.TryParse(marcaIn, true, out MarcaProducto marcaOut)){
                return marcaOut;
            } else {
                throw new ArgumentException($"Valor de Marca de Producto inválido: {marcaIn}");
            }
        }        
    }
}
