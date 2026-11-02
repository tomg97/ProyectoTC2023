using Newtonsoft.Json;
using Servicios.Metodos;
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
			set { _idCliente = value; }
		}
		public Factura() { }
		public Factura(Venta venta) {
			_id = venta.id;
			_ventaAsociada = venta;
			_despachada = 0;
			_idCliente = venta.idCliente;
		}

		public void desencriptarIdCliente() {
			if (string.IsNullOrWhiteSpace(_idCliente)) {
				return;
			}
			Encriptador encriptador = new Encriptador();
			_idCliente = encriptador.desencriptarReversible(_idCliente);
			if (_ventaAsociada != null) {
				_ventaAsociada.idCliente = _idCliente;
			}
		}
	}
}
