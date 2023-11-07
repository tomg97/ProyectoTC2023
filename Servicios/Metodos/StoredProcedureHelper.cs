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
        public T crearObjetoDeDataReader<T>(SqlDataReader reader) where T : new() {
            T obj = new T();
            for(int i = 0; i < reader.FieldCount; i++) {
                string fieldName = reader.GetName(i);
                PropertyInfo propertyInfo = typeof(T).GetProperty(fieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null && !reader.IsDBNull(i)) {
                    object value = reader.GetValue(i);
                    propertyInfo.SetValue(obj, value is DBNull ?  null : value);
                }
            }
            return obj;
        }
    }
}
