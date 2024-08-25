using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Metodos {
    public class ManejaDbBR {
        private string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ComercializAR;Integrated Security=True";

        public void realizarBackup(string filePath) {
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                string query = $"BACKUP DATABASE ComercializAR TO DISK = '{filePath}'";
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void realizarRestore(string filePath) {
            string singleUserQuery = $"ALTER DATABASE ComercializAR SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            string restoreQuery = $"USE MASTER RESTORE DATABASE ComercializAR FROM DISK = '{filePath}' WITH REPLACE;";
            string multiUserQuery = $"ALTER DATABASE ComercializAR SET MULTI_USER";
            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                SqlCommand singleUserCmd = new SqlCommand(singleUserQuery, connection);
                SqlCommand restoreCmd = new SqlCommand(restoreQuery, connection);
                SqlCommand multiUserCmd = new SqlCommand(multiUserQuery, connection);
                connection.Open();
                singleUserCmd.ExecuteNonQuery();
                restoreCmd.ExecuteNonQuery();
                multiUserCmd.ExecuteNonQuery();
            }
        }
    }
}
