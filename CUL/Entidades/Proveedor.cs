using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Proveedor {
        public Proveedor(string c, string e, string n, string t, string d, string b) {
			_CUIT = c;
			_email = e;
			_nombre = n;
			_telefono = t;
			_domicilio = d;
			_banco = b;
        }
		private string _CUIT;

		public string CUIT {
			get { return _CUIT; }
			set { _CUIT = value; }
		}
		private string _email;

		public string email {
			get { return _email; }
			set { _email = value; }
		}
		private string _nombre;

		public string nombre {
			get { return _nombre; }
			set { _nombre = value; }
		}
		private string _telefono;

		public string telefono {
			get { return _telefono; }
			set { _telefono = value; }
		}
		private string _domicilio;

		public string domicilio {
			get { return _domicilio; }
			set { _domicilio = value; }
		}
		private string _banco;

		public string banco {
			get { return _banco; }
			set { _banco = value; }
		}
	}
}
