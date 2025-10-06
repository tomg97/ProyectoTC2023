using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class MensajeEvento {
		
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private EventoEnum _contenido;

		public EventoEnum contenido {
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
		public MensajeEvento() { }
		public MensajeEvento(EventoEnum contenido, string usuario, Modulo tabla, Criticidad criticidad) {
			_contenido = contenido;
			_usuario = usuario;
			_fecha = DateTime.Now;
			_modulo = tabla;
            _criticidad = criticidad;
        }
		private Modulo _modulo;

		public Modulo modulo {
			get { return _modulo; }
			set { _modulo = value; }
		}
		private Criticidad _criticidad;

		public Criticidad criticidad {
			get { return _criticidad; }
			set { _criticidad = value; }
		}
		public string getContenido() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoIdioma);
            return _contenido.GetDescripcionTraducida();
        }
    }
}
