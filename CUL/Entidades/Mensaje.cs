using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Mensaje {
		
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private string _contenido;

		public string contenido {
			get { return _contenido; }
			set { _contenido = value; }
		}
		private DateTime _fecha;

		public DateTime fecha {
			get { return _fecha; }
			set { _fecha = value; }
		}
		private string _usuario;

		public string usuario {
			get { return _usuario; }
			set { _usuario = value; }
		}
		private string _tipo;

		public string tipo {
			get { return _tipo; }
			set { _tipo = value; }
		}
		public Mensaje() { }
		public Mensaje(string id, string contenido, DateTime fecha, string usuario, string tipo) {
			_id = id;
			_contenido = contenido;
			_fecha = fecha;
			_usuario = usuario;
			_tipo = tipo;
		}
		public Mensaje(string id, string contenido, string usuario, string tipo) {
			_id = id;
			_contenido = contenido;
			_usuario = usuario;
			_tipo = tipo;
		}
		private Tabla _tabla;

		public Tabla tabla {
			get { return _tabla; }
			set { _tabla = value; }
		}

	}
}
