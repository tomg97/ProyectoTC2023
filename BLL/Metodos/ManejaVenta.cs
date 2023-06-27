using CUL.Entidades;
using DAL.Metodos;
using Newtonsoft.Json;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL.Metodos {
    public class ManejaVenta {
        ManejaDbVenta manejaDbVenta = new ManejaDbVenta();
        Guuido guidGenerator = new Guuido();
        Jsonifier jsonificador = new Jsonifier();

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
        public void vaciarCarrito() {
            SingletonCarrito.getInstance.vaciarCarrito();
        }
        public string commitCarrito(Cliente cliente) {
            string mensaje;
            List<Producto> carrito = SingletonCarrito.getInstance.getCarrito();
            Venta venta = new Venta(guidGenerator.getUuidString(), carrito, cliente, DateTime.Now.ToString());
            mensaje = manejaDbVenta.actualizarStock(carrito);
            manejaDbVenta.crearVentaNoFacturada(venta);
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
        public List<Venta> getVentasNoFacturadas() {
            return manejaDbVenta.getVentasNoFacturadas();
        }
        public void facturarVenta(Venta venta) {
            Factura factura = new Factura(venta);
            jsonificador.guardarAJsonConLocación(factura, "Factura-" + venta.id);
            manejaDbVenta.facturarVenta(venta);
        }
        public void devolverFacturaYCargarTreeView(TreeView control) {
            Factura factura = jsonificador.cargarFacturaYRellenarTreeView<Factura>(control);
        }
        public void despacharFactura(params string[] datos) {
            string rutaArchivo = SingletonRutaArchivo.getInstance.getRutaArchivo();
            manejaDbVenta.despacharFactura(datos);
            jsonificador.moverArchivoDone(rutaArchivo, "Facturas despachadas");
        }
    }
}
