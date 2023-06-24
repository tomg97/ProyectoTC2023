using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public class Venta {
		private string _id;

		public string id {
			get { return _id; }
			set { _id = value; }
		}
		private List<Producto> _productosVendidos;

		public List<Producto> productosVendidos {
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
		public void calcularMontoYEncriptar() {
			Encriptador encriptador = new Encriptador();
			string montoNoEncriptado = productosVendidos.Sum(producto => Convert.ToInt32(producto.precio)).ToString();
			monto = encriptador.encriptarReversible(montoNoEncriptado);
		}

	}
}
