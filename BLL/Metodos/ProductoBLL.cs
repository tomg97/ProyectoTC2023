using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ProductoBLL {
        ManejaBR manejaBR = new ManejaBR();
        ProductoDAL productoDAL = new ProductoDAL();

        public List<Producto> getProductosBajoStock() {
            List<Producto> listaProductosBajoStock = productoDAL.getProductosBajoStock().Where(p => p.cantidad <= 5).ToList();

            return listaProductosBajoStock;
        }
        public Producto getProducto(string idProducto) {
            return productoDAL.getProducto(idProducto);
        }
    }
}
