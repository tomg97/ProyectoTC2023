using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Cliente {
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private string _nombre;

		public string nombre {
			get { return _nombre; }
			set { _nombre = value; }
		}
		private string _apellido;

		public string apellido {
			get { return _apellido; }
			set { _apellido = value; }
		}
		private string _domicilio;

		public string domicilio {
			get { return _domicilio; }
			set { _domicilio = value; }
		}
		private string _telefono;

		public string telefono {
			get { return _telefono; }
			set { _telefono = value; }
		}

	}
}
