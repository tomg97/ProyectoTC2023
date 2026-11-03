using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ProductoBLL : IDVManejadores {
        ManejaBR manejaBR = new ManejaBR();
        ProductoDAL productoDAL = new ProductoDAL();
        BitacoraBLL bitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();

        public List<Producto> getProductosBajoStock() {
            List<Producto> listaProductosBajoStock = productoDAL.getProductosBajoStock().Where(p => p.cantidad <= 5).ToList();

            return listaProductosBajoStock;
        }
        public Producto getProducto(string idProducto) {
            return productoDAL.getProducto(idProducto);
        }

        public void recalcularDV() {
            productoDAL.actualizarTodosDV();
            productoDAL.actualizarDVV();
        }

        public List<String> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<Producto> productos = productoDAL.traerTodosProductos();

            productos.ForEach(p => {
                if (!string.Equals(p.dvh, productoDAL.calcularDVH(p))) {
                    errores.Add($"En la tabla Producto, el Producto id : {p.id} fue modificado");
                }
            });

            if (!productoDAL.calcularDVV(productos).Equals(productoDAL.obtenerDVV())) {
                errores.Add("En la tabla Producto, el DVV es incorrecto");
            }

            return errores;
        }
        public void llenarCarrito(Producto producto) {
            SingletonCarrito.getInstance.agregarProducto(producto);
        }
        public List<Producto> getListaProductosEnStock() {
            List<Producto> listaProductosEnStock = new List<Producto>();
            listaProductosEnStock = productoDAL.getProductosEnStock();
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
        public void modificaProducto(Producto producto, string keyOg) {
            try {
                productoDAL.modificarProducto(producto, keyOg);
                bitacora.persistirMensajeLogged(EventoEnum.ModificacionProductoOk, Modulo.Compras, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged(EventoEnum.ModificacionProductoNoOk, Modulo.Compras, Criticidad.Uno);
            }
        }
    }
}
