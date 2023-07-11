using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Permiso : Componente {
        public override List<Componente> hijos {
            get {
                return new List<Componente>();
            }
        }

        public override void agregar(Componente componente) {
            
        }

        public override void remover(Componente componente) {
            
        }
        public override void vaciarHijos() {

        }
    }
}
