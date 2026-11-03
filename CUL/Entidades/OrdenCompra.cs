using Newtonsoft.Json;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class OrdenCompra : IDVEntidades {
        public OrdenCompra() {
            
        }
        public OrdenCompra(string i, string ic, string e, string t, string p, string c) {
			_id = i;
			_idCotizacion = ic;
			_estado = e;
			_total = t; 
			_productos = JsonConvert.DeserializeObject<List<Producto>>(p);
            _cuitProveedor = c;
			_comentario = "";
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
		private string _comentario;

		public string comentario {
			get { return _comentario; }
			set { _comentario = value; }
		}
		private string _dvh;

		public string dvh {
			get { return _dvh; }
			set { _dvh = value; }
		}
	}
}
