using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class OrdenCompraBLL {
        OrdenCompraDAL ordenCompraDAL = new OrdenCompraDAL();
        public bool estaRegistradoProveedor(string cuitProveedor) {
            ProveedorDAL proveedorDAL = new ProveedorDAL();
            Proveedor proveedor = proveedorDAL.getProveedor(cuitProveedor);
                if (proveedor.CUIT == cuitProveedor) {
                    return true;
                }
            return false;
        }

        public void generarOrden(OrdenCompra orden) {
            if (ordenCompraDAL.esUnico(orden.idCotizacion)) {
                ordenCompraDAL.almacenarOrdenCompra(orden);
            } else {
                throw new ConstraintException();
            }            
        }

        public bool registroCompleto(Proveedor proveedor) {
            if (proveedor.telefono != "0") {
                return true;
            }
            return false;
        }
        public void modificarOrdenCompra(OrdenCompra ordenCompra) {
            ordenCompraDAL.modificarOrdenCompra(ordenCompra);
        }

        public List<OrdenCompra> traerOrdenesCompraPendientes() {
            var aux = ordenCompraDAL.getOrdenesCompra();
            return aux.Where(o => o.estado == "Pendiente").ToList();
        }
        public List<OrdenCompra> traerOrdenesCompraRechazadas() {
            var aux = ordenCompraDAL.getOrdenesCompra();
            return aux.Where(o => o.estado == "Rechazada").ToList();
        }
        public void rechazarOrdenCompra(OrdenCompra ordenCompra, string motivo) {
            ordenCompra.estado = "Rechazada";
            ordenCompra.motivo = motivo;
            modificarOrdenCompra(ordenCompra);
        }
    }
}
