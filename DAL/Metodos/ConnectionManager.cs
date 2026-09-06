using System;
using System.Configuration;

namespace DAL.Metodos {
    public static class ConnectionManager {
        private static string _connectionString;

        /// <summary>
        /// Obtiene la cadena de conexión configurada
        /// </summary>
        public static string GetConnectionString() {
            if (string.IsNullOrEmpty(_connectionString)) {
                // Intenta leer desde App.config
                _connectionString = ConfigurationManager.ConnectionStrings["ComercializARConnectionString"]?.ConnectionString;
                
                // Fallback a valor por defecto si no se encuentra en config
                if (string.IsNullOrEmpty(_connectionString)) {
                    _connectionString = "Data Source=DESKTOP-FR7EG97\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";
                }
            }
            return _connectionString;
        }

        /// <summary>
        /// Permite establecer la cadena de conexión dinámicamente
        /// </summary>
        public static void SetConnectionString(string connectionString) {
            if (string.IsNullOrEmpty(connectionString)) {
                throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula o vacía");
            }
            _connectionString = connectionString;
        }

        /// <summary>
        /// Resetea la cadena de conexión para forzar recarga desde configuración
        /// </summary>
        public static void ResetConnectionString() {
            _connectionString = null;
        }
    }
}