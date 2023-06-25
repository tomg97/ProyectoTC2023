using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUL.Entidades {
    public sealed class SingletonCarrito {
        private static SingletonCarrito instance = null;
        private static readonly object lockObject = new object();
        private List<Producto> carrito;
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
            ValidarCampos validar = new ValidarCampos();
            if (!validar.validarListaNoNulaNoVacia(carrito)) {
                carrito = new List<Producto>();
            }
            carrito.Add(producto);
        }
        public void vaciarCarrito() {
            carrito = null;
        }
        public void cargarListaStock(List<Producto> productos) {
            listaProductosEnStock = productos;
        }
        public List<Producto> getCarrito() {
            return carrito;
        }
        public List<Producto> getExistencias() {
            return listaProductosEnStock;
        }
        public void removerDeCarrito(Producto productoARemover) {
            ValidarCampos validar = new ValidarCampos();
            if (validar.validarListaNoNulaNoVacia(carrito)) {
                carrito.Remove(productoARemover);
            }
        }
    }
}
