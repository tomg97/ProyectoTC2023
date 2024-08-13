using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Servicios.Metodos {
    public class Encriptador {
        public string encriptarIrreversible(string pass) {

            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++) {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public string encriptarReversible(string monto) {
            byte[] bytes = Encoding.UTF8.GetBytes(monto);
            return Convert.ToBase64String(bytes);
        }
        public string desencriptarReversible(string monto) {
            byte[] data = Convert.FromBase64String((monto));
            return Encoding.UTF8.GetString(data);
        }
    }
}
