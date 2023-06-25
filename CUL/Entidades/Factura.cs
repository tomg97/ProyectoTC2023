using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Factura {
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private Venta _ventaAsociada;

		public Venta ventaAsociada {
			get { return _ventaAsociada; }
			set { _ventaAsociada = value; }
		}

	}
}
