using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class OrdenCompra {
        public OrdenCompra() {
            
        }
        public OrdenCompra(string i, string ic, string fc, string e, string t, string p, string c, string fr) {
			_id = i;
			_idCotizacion = ic;
			_fechaCreacion = DateTime.Parse(fc);
			_estado = e;
			_total = t; 
			_productos = JsonConvert.DeserializeObject<List<Producto>>(p);
            _cuitProveedor = c;
			_fechaRecepcion = DateTime.Parse(fr);
			_motivo = "";
        }
        private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private string _idCotizacion;

		public string idCotizacion {
			get { return _idCotizacion; }
			set { _idCotizacion = value; }
		}
		private DateTime _fechaCreacion;

		public DateTime fechaCreacion {
			get { return _fechaCreacion; }
			set { _fechaCreacion = value; }
		}
        private DateTime _fechaRecepcion;

        public DateTime fechaRecepcion {
            get { return _fechaRecepcion; }
            set { _fechaRecepcion = value; }
        }

        private string _estado;

		public string estado {
			get { return _estado; }
			set { _estado = value; }
		}
		private string _total;

		public string total {
			get { return _total; }
			set { _total = value; }
		}
		private string _cuitProveedor;

		public string cuitProveedor {
			get { return _cuitProveedor; }
			set { _cuitProveedor = value; }
		}
		private List<Producto> _productos;

		public List<Producto> productos {
			get { return _productos; }
			set { _productos = value; }
		}
		private string _motivo;

		public string motivo {
			get { return _motivo; }
			set { _motivo = value; }
		}

	}
}
