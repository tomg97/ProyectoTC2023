using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ProductoBLL : IDVManejadores {
        ManejaBR manejaBR = new ManejaBR();
        ProductoDAL productoDAL = new ProductoDAL();
        ManejaDbMaestro manejaDbMaestro = new ManejaDbMaestro("Producto");

        public List<Producto> getProductosBajoStock() {
            List<Producto> listaProductosBajoStock = productoDAL.getProductosBajoStock().Where(p => p.cantidad <= 5).ToList();

            return listaProductosBajoStock;
        }
        public Producto getProducto(string idProducto) {
            return productoDAL.getProducto(idProducto);
        }

        public void recalcularDV() {
            manejaDbMaestro.actualizarTodosDV();
            manejaDbMaestro.actualizarDVV();
        }

        public List<String> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<Producto> productos = manejaDbMaestro.traerTodosProductos();

            productos.ForEach(p => {
                if (!string.Equals(p.dvh, manejaDbMaestro.calcularDVH(p))) {
                    errores.Add($"En la tabla Producto, el Producto id : {p.id} fue modificado");
                }
            });

            if (!manejaDbMaestro.calcularDVV(productos).Equals(manejaDbMaestro.obtenerDVV())) {
                errores.Add("En la tabla Producto, el DVV es incorrecto");
            }

            return errores;
        }
    }
}
