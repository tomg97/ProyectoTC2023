using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class SolicitudCotizacionBLL {
        SolicitudCotizacionDAL solicitudCotizacionDAL = new SolicitudCotizacionDAL();
        public void guardarSolicitudCotizacion(SolicitudCotizacion solicitudCotizacion) {
            solicitudCotizacionDAL.guardarSolicitudCotizacion(solicitudCotizacion);
        }
        public List<SolicitudCotizacion> traerTodasSolicitudesCotizacion() {
            List<SolicitudCotizacion> solicitudesCotizacion = solicitudCotizacionDAL.traerTodasSolicitudesCotizacion();

            ProveedorBLL proveedorBLL = new ProveedorBLL();
            List<Proveedor> proveedores = proveedorBLL.getProveedores();

            foreach (var solicitud in solicitudesCotizacion) {
                if (solicitud.proveedor != null) {
                    var proveedorCompleto = proveedores.FirstOrDefault(p => p.CUIT == solicitud.proveedor.CUIT);
                    if (proveedorCompleto != null) {
                        solicitud.proveedor = proveedorCompleto;
                    }
                }
            }
            return solicitudesCotizacion;
        }
        public void eliminarSolicitudCotizacion(string idSolicitud) {
            solicitudCotizacionDAL.eliminarSolicitudCotizacion(idSolicitud);
        }
    }
}
