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
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand command = new SqlCommand(script, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
