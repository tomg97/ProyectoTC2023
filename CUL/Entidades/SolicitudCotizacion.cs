using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class SolicitudCotizacion {
		public SolicitudCotizacion(string i, string p, string f, string c, string t, string e) {
			_id = i;
			_proveedor = new Proveedor(c,"","","","","");
			_productos = JsonConvert.DeserializeObject<List<Producto>>(p);
			_fecha = DateTime.Parse(f);
			_subtotal = t;
			_estado = e;
        }
        public SolicitudCotizacion() {
            
        }
        private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private Proveedor _proveedor;

		public Proveedor proveedor {
			get { return _proveedor; }
			set { _proveedor = value; }
		}
		private List<Producto> _productos;

		public List<Producto> productos {
			get { return _productos; }
			set { _productos = value; }
		}
		private DateTime _fecha;

		public DateTime fecha {
			get { return _fecha; }
			set { _fecha = value; }
		}
		private string _subtotal;

		public string subtotal {
			get { return _subtotal; }
			set { _subtotal = value; }
		}
		private string _estado;

		public string estado {
			get { return _estado; }
			set { _estado = value; }
		}


	}
}
