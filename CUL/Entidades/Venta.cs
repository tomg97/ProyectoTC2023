using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CUL.Entidades {
    public class Venta {
		public Venta() {

		}
		public Venta(string id, List<Producto> productosVendidos, Cliente cliente, string fecha) {
			_id = id;
			_productosVendidos = JsonConvert.SerializeObject(productosVendidos);
			_idCliente = cliente.id;
			_fecha = fecha;
			facturada = false;
			calcularMontoYEncriptar(productosVendidos);
		}
		public Venta(string id, string productosVendidos, string idCliente, string fecha) {
			_id = id;
			_productosVendidos = productosVendidos;
			_listaProductosVendidos = JsonConvert.DeserializeObject<List<Producto>>(productosVendidos);
            _idCliente = idCliente;
			_fecha = fecha;
			facturada = true;
		}
		[JsonProperty(PropertyName = "_listaProductosVendidos")]
		private List<Producto> _listaProductosVendidos;


        private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private string _productosVendidos;

		public string productosVendidos {
			get { return _productosVendidos; }
			set { _productosVendidos = value; }
		}
		private string _idCliente;

		public string idCliente {
			get { return _idCliente; }
			set { _idCliente = value; }
		}
		private string _fecha;

		public string fecha {
			get { return _fecha; }
			set { _fecha = value; }
		}
		private string _monto;

		public string monto {
			get { return _monto; }
			set { _monto = value; }
		}
		private bool facturada;
		
		public void calcularMontoYEncriptar(List<Producto> productosVendidos) {
			Encriptador encriptador = new Encriptador();
            decimal subtotal = 0;
            foreach (Producto producto in productosVendidos) {
                subtotal += producto.cantidad * Convert.ToInt32(producto.precio);
            }
			string montoNoEncriptado = subtotal.ToString();
			_monto = encriptador.encriptarReversible(montoNoEncriptado);
		}
	}
}
