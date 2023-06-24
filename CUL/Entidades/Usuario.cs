using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Usuario {
		private string _nomUsu;

		public string nomUsu {
			get { return _nomUsu; }
			set { _nomUsu = value; }
		}
		private string _pass;

		public string pass {
			get { return _pass; }
			set { _pass = value; }
		}

	}
}
