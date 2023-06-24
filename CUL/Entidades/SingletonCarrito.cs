using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public sealed class SingletonCarrito {
        private static SingletonCarrito instance = null;
        private static readonly object lockObject = new object();
        private List<Producto> listaProductosSeleccionados;
        private List<Producto> listaProductosEnStock;
        private SingletonCarrito() {

        }
        public static SingletonCarrito getInstance {
            get {
                if (instance == null) {
                    lock (lockObject) {
                        if (instance == null) {
                            instance = new SingletonCarrito();
                        }
                    }
                }
                return instance;
            }
        }
        public void agregarProducto(Producto producto) {
            if (listaProductosSeleccionados == null) {
                listaProductosSeleccionados = new List<Producto>();
            }
            listaProductosSeleccionados.Add(producto);
        }
        public void vaciarLista() {
            listaProductosSeleccionados = null;
        }
        public void cargarListaStock(List<Producto> productos) {
            listaProductosEnStock = productos;
        }
        public List<Producto> getListaProductos(string seleccion) {
            if(seleccion == "carrito") {
                return listaProductosSeleccionados;
            }
            return listaProductosEnStock;
        }
    }
}
