using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Usuario {
		private string _nomUsu;
		public Usuario() {
			_permisos = new List<Componente>();
		}

		public string nomUsu {
			get { return _nomUsu; }
			set { _nomUsu = value; }
		}
		private string _pass;

		public string pass {
			get { return _pass; }
			set { _pass = value; }
		}
		private List<Componente> _permisos;

		public List<Componente> permisos {
			get { return _permisos; }
			set { _permisos = value; }
		}
		private string _idioma;

		public string idioma {
			get { return _idioma; }
			set { _idioma = value; }
		}

	}
}
