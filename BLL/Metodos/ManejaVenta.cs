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
    }
}
