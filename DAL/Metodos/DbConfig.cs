using System;
using System.Configuration;

namespace DAL.Metodos {
    public sealed class DbConfig {
        private static readonly Lazy<DbConfig> _instance = new Lazy<DbConfig>(() => new DbConfig());
        public static DbConfig Instance => _instance.Value;
        public string ConnectionString { get; }

        private DbConfig() {
            ConnectionString = GetConnectionString();
        }

        private static string GetConnectionString() {
            string configured = Environment.GetEnvironmentVariable("COMERCIALIZAR_CONNECTION_STRING");
            if (!string.IsNullOrWhiteSpace(configured)) {
                return configured;
            }

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null) {
                ConnectionStringSettings connection = settings["ComercializAR"]
                    ?? settings["DAL.Properties.Settings.ComercializARConnectionString"]
                    ?? settings["ProyectoTC2023.Properties.Settings.ComercializARConnectionString"];

                if (connection != null && !string.IsNullOrWhiteSpace(connection.ConnectionString)) {
                    return connection.ConnectionString;
                }
            }

            try {
                return DAL.Properties.Settings.Default.ComercializARConnectionString;
            } catch {
                return string.Empty;
            }
        }
    }
}
