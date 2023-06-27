using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Factura {
		[JsonProperty("_id")]
		private string _id;
        [JsonProperty("_ventaAsociada")]
        private Venta _ventaAsociada;
		[JsonProperty("_despachada")]
		private int _despachada;
		private string _idCliente;
		public string idCliente {
			get { return _idCliente; }
		}
		public Factura() { }
		public Factura(Venta venta) {
			_id = venta.id;
			_ventaAsociada = venta;
			_despachada = 0;
			_idCliente = venta.idCliente;
        }
	}
}
