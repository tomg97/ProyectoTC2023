using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaVenta {
        ManejaDbVenta manejaDbVenta = new ManejaDbVenta();
        public void llenarCarrito(Producto producto) {
            SingletonCarrito.getInstance.agregarProducto(producto);
        }
        public List<Producto> getListaProductosEnStock() {
            List<Producto> listaProductosEnStock = new List<Producto>();
            listaProductosEnStock = manejaDbVenta.getProductosEnStock();
            SingletonCarrito.getInstance.cargarListaStock(listaProductosEnStock);
            return listaProductosEnStock;
        }
        public void removerDelCarrito(Producto producto) {
            SingletonCarrito.getInstance.removerDeCarrito(producto);
        }
        public List<Producto> devolverCarrito() {
            return SingletonCarrito.getInstance.getCarrito();
        }
        public List<Producto> devolverStock() {
            return SingletonCarrito.getInstance.getExistencias();
        }
        public void vaciarCarrito() {
            SingletonCarrito.getInstance.vaciarCarrito();
        }
        public string commitCarrito(Cliente cliente) {
            string mensaje;
            Guid uuid = Guid.NewGuid();
            List<Producto> carrito = SingletonCarrito.getInstance.getCarrito();
            Venta venta = new Venta(uuid.ToString(), carrito, cliente, DateTime.Now.ToString());
            mensaje = manejaDbVenta.actualizarStock(carrito);
            return mensaje;
        }
        public decimal getSubtotalCarrito() {
            List<Producto> carrito = devolverCarrito();
            decimal subtotal = 0;
            foreach (Producto producto in carrito) {
                subtotal += producto.cantidad * Convert.ToInt32(producto.precio);
            }            
            return subtotal;
        }
        public decimal getSubtotalCuotas(string cuotas) {
            decimal subtotal = getSubtotalCarrito();
            return subtotal / Convert.ToDecimal(cuotas);
        }
    }
}
