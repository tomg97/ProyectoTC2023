using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Metodos {
    public class Guuido {
        public Guid getUuid() {
            return Guid.NewGuid();
        }
        public string getUuidString() {
            Guid guid = Guid.NewGuid();
            string uuid = guid.ToString();
            return uuid;
        }
    }
}
