using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.Metodos {
    public class Encriptador {
        public string encriptar(string pass) {

            byte[] data = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(pass));
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < data.Length; i++) {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
