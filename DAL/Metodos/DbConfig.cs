using System;

namespace DAL.Metodos {
    public sealed class DbConfig {
        private static readonly Lazy<DbConfig> _instance = new Lazy<DbConfig>(() => new DbConfig());
        public static DbConfig Instance => _instance.Value;
        public string ConnectionString { get; }

        private DbConfig() {
            // Read from the DAL project's Settings default (generated settings). This avoids adding a System.Configuration reference.
            try {
                ConnectionString = DAL.Properties.Settings.Default.ComercializARConnectionString;
            } catch {
                ConnectionString = string.Empty;
            }
        }
    }
}
