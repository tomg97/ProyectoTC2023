using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CUL.Entidades {
    [Serializable]
    public class Producto {
		public Producto(string nombreProducto, string marcaProducto, string id, string cantidad, string precio) {
			this.nombreProducto = nombreProducto;
			this.marcaProducto = marcaProducto;
			this.id = id;
			this.cantidad = Convert.ToInt32(cantidad);
			this.precio = precio;
		}
		public Producto() { }
		private string _nombreProducto;
        [XmlElement]
        public string nombreProducto {
			get { return _nombreProducto; }
			set { _nombreProducto = value; }
		}
		private string _marcaProducto;
        [XmlElement]
        public string marcaProducto {
			get { return _marcaProducto; }
			set { _marcaProducto = value; }
		}
		private string _id;
        [XmlElement]
        public string id {
			get { return _id; }
			set { _id = value; }
		}
		private int _cantidad;
        [XmlElement]
        public int cantidad {
			get { return _cantidad; }
			set { _cantidad = value; }
		}
		private string _precio;
        [XmlElement]
        public string precio {
			get { return _precio; }
			set { _precio = value; }
		}

	}
}
