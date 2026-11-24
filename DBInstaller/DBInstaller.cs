using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;

namespace DBInstaller
{
    [RunInstaller(true)]
    public class DBInstaller : Installer {

        public override void Install(System.Collections.IDictionary stateSaver) {
            base.Install(stateSaver);

            string connectionString = Context.Parameters["connectionString"];
            string scriptPath = Context.Parameters["scriptPath"];

            if (File.Exists(scriptPath)) {
                ExecuteSqlScript(connectionString, scriptPath);
            } else {
                throw new FileNotFoundException("The SQL script file was not found.", scriptPath);
            }
        }
        private void ExecuteSqlScript(string connectionString, string scriptPath) {
            string script = File.ReadAllText(scriptPath);
            int useDatabase = script.IndexOf("USE [ComercializAR]", StringComparison.OrdinalIgnoreCase);
            if (useDatabase >= 0) {
                script = script.Substring(useDatabase);
            }

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                foreach (string batch in System.Text.RegularExpressions.Regex.Split(script, @"(?im)^\s*GO\s*$")) {
                    if (string.IsNullOrWhiteSpace(batch)) {
                        continue;
                    }

                    using (SqlCommand command = new SqlCommand(batch, connection)) {
                        command.CommandTimeout = 300;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
