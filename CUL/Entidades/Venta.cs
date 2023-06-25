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
			this.id = id;
			this.productosVendidos = JsonConvert.SerializeObject(productosVendidos);
			this.cliente = cliente;
			this.fecha = fecha;
			facturada = false;
			calcularMontoYEncriptar(productosVendidos);
		}

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
		private Cliente _cliente;

		public Cliente cliente {
			get { return _cliente; }
			set { _cliente = value; }
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
			monto = encriptador.encriptarReversible(montoNoEncriptado);
		}
	}
}
