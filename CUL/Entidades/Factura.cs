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

		public Factura() { }
		public Factura(Venta venta) {
			_id = venta.id;
			_ventaAsociada = venta;
		}
	}
}
