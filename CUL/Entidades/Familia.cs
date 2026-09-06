using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    /// <summary>
    /// Representa un perfil/familia de permisos (compuesto del Composite)
    /// </summary>
    public class Familia : Componente {
        private List<Componente> _hijos;

        public override bool esCompuesto {
            get { return true; }
        }

        public override List<Componente> hijos {
            get { return _hijos; }
        }

        public Familia() {
            _hijos = new List<Componente>();
        }

        public override void agregar(Componente componente) {
            if (componente == null) return;
            
            // Evitar duplicados
            if (!_hijos.Any(h => h.id == componente.id)) {
                _hijos.Add(componente);
            }
        }

        public override void remover(Componente componente) {
            if (componente == null) return;
            _hijos.RemoveAll(h => h.id == componente.id);
        }

        public override void vaciarHijos() {
            _hijos.Clear();
        }

        /// <summary>
        /// Obtiene los IDs de todos los hijos directos
        /// </summary>
        public List<int> obtenerIdsHijos() {
            return _hijos.Select(h => h.id).ToList();
        }
    }
}
