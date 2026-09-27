using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces {
    public interface IDVManejadores {
        void recalcularDV();
        List<String> chequearIntegridad();
    }
}
