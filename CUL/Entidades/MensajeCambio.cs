using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class MensajeCambio {
		
		private string _idOperacion;

		public string idOperacion {
			get { return _idOperacion; }
			set { _idOperacion = value; }
		}
		private string _idProducto;

		public string idProducto {
			get { return _idProducto; }
			set { _idProducto = value; }
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
		private string _nombreProducto;

		public string nombreProducto {
			get { return _nombreProducto; }
			set { _nombreProducto = value; }
		}
		private bool _activo;

		public bool activo {
			get { return _activo; }
			set { _activo = value; }
		}
		private string _cantidad;

		public string cantidad {
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		private string _precio;

		public string precio {
			get { return _precio; }
			set { _precio = value; }
		}

		public MensajeCambio() { }

		private MarcaProducto _marcaProducto;

		public MarcaProducto marcaProducto {
			get { return _marcaProducto; }
			set { _marcaProducto = value; }
		}
		private TipoOperacion _tipoOp;

		public TipoOperacion tipoOp {
			get { return _tipoOp; }
			set { _tipoOp = value; }
		}
		public enum TipoOperacion {
            INSERT,
            UPDATE,
            DELETE
        }
    }
}
