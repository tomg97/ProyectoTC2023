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
		public Mensaje(string id, string contenido, string usuario, Tabla tabla, Object cambioDe, Object cambioA, int criticidad) {
			_id = id;
			_contenido = contenido;
			_usuario = usuario;
			_fecha = DateTime.Now;
			_tabla = tabla;
			_cambioDe = cambioDe;
			_cambioA = cambioA;
			_tipo = "Cambios";
			_criticidad = criticidad;
		}
		public Mensaje(string id, string contenido, string usuario, Tabla tabla, int criticidad) {
			_id = id;
			_contenido = contenido;
			_usuario = usuario;
			_fecha = DateTime.Now;
			_tabla = tabla;
			_tipo = "Eventos";
            _criticidad = criticidad;
        }
		private Tabla _tabla;

		public Tabla tabla {
			get { return _tabla; }
			set { _tabla = value; }
		}
		private Object _cambioDe;

		public Object cambioDe {
			get { return _cambioDe; }
			set { _cambioDe = value; }
		}
		private Object _cambioA;

		public Object MyProperty {
			get { return _cambioA; }
			set { _cambioA = value; }
		}
		private int _criticidad;

		public int criticidad {
			get { return _criticidad; }
			set { _criticidad = value; }
		}

	}
}
