using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Familia : Componente {
        private List<Componente> _hijos;
        public override List<Componente> hijos {
            get { return _hijos; }
        }
        public Familia() {
            _hijos = new List<Componente>();
        }
        public override void agregar(Componente componente) {
            _hijos.Add(componente);
        }

        public override void remover(Componente componente) {
            _hijos.Remove(componente);
        }
        public override void vaciarHijos() {
            _hijos = new List<Componente>();
        }
    }
}
