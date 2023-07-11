using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public abstract class Componente {
        private string _nombre;

        public string nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _id;

        public int id {
            get { return _id; }
            set { _id = value; }
        }
        public abstract List<Componente> hijos { get; }
        private TipoPermiso _tipoPermiso;

        public TipoPermiso tipoPermiso {
            get { return _tipoPermiso; }
            set { _tipoPermiso = value; }
        }

        public abstract void agregar(Componente componente);
        public abstract void remover(Componente componente);
        public abstract void vaciarHijos();
    }
}
