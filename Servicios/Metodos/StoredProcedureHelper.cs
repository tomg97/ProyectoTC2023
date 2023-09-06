using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Metodos {
    public class StoredProcedureHelper {
        public StoredProcedureHelper() { }
        public SqlCommand rellenarYDevolverSPUpsert(Object obj, SqlConnection connection, string spText) {
            SqlCommand sqlCommand = new SqlCommand(spText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Dictionary<string, string> paramYValor = generarDiccionarioConObjeto(obj);
            foreach (KeyValuePair<string, string> param in paramYValor) {
                sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
            }
            return sqlCommand;
        }
        private Dictionary<string, string> generarDiccionarioConObjeto(Object obj) {
            var type = obj.GetType();
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            var dictionary = new Dictionary<string, string>();

            foreach (var property in properties) {
                var propertyName = property.Name;
                var key = "@" + propertyName;
                var value = property.GetValue(obj)?.ToString() ?? string.Empty;
                dictionary[key] = value;    
            }
            return dictionary;
        }
    }
}
