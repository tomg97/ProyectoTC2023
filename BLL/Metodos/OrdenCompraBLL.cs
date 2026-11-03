using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class OrdenCompraBLL : IDVManejadores {
        OrdenCompraDAL ordenCompraDAL = new OrdenCompraDAL();
        BitacoraBLL bitacoraBLL = new BitacoraBLL();
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
                //bitacoraBLL.persistirMensajeLogged(EventoEnum.)
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
        public List<OrdenCompra> traerOrdenesCompraPagas() {
            var aux = ordenCompraDAL.getOrdenesCompra();
            return aux.Where(o => o.estado == "Pagado").ToList();
        }
        public List<OrdenCompra> traerOrdenesCompraRechazadas() {
            var aux = ordenCompraDAL.getOrdenesCompra();
            return aux.Where(o => o.estado == "Rechazada").ToList();
        }
        public void rechazarOrdenCompra(OrdenCompra ordenCompra, string motivo) {
            ordenCompra.estado = "Rechazada";
            ordenCompra.comentario = motivo;
            modificarOrdenCompra(ordenCompra);
        }
        public List<OrdenCompra> traerOrdenesCompra() {
            return ordenCompraDAL.getOrdenesCompra();
        }
        public void recalcularDV() {
            ordenCompraDAL.actualizarTodosDV();
            ordenCompraDAL.actualizarDVV();
        }

        public List<string> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<OrdenCompra> ordenes = ordenCompraDAL.getOrdenesCompra();

            ordenes.ForEach(o => {
                if (!o.dvh.Equals(ordenCompraDAL.calcularDVH(o))) {
                    errores.Add($"En la tabla OrdenCompra, la Orden de compra con id: {o.id} fue modificada");
                }
            });
            if (!ordenCompraDAL.calcularDVV(ordenes).Equals(ordenCompraDAL.obtenerDVV())) {
                errores.Add("En la tabla OrdenCompra, el DVV es incorrecto");
            }
            return errores;
        }
    }
}
