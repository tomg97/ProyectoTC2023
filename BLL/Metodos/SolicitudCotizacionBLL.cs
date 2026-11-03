using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class SolicitudCotizacionBLL : IDVManejadores {
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
        public void recalcularDV() {
            solicitudCotizacionDAL.actualizarTodosDV();
            solicitudCotizacionDAL.actualizarDVV();
        }

        public List<string> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<SolicitudCotizacion> solicitudes = solicitudCotizacionDAL.traerTodasSolicitudesCotizacion();

            solicitudes.ForEach(s => {
                if (!s.dvh.Equals(solicitudCotizacionDAL.calcularDVH(s))) {
                    errores.Add($"En la tabla SolicitudCotizacion, la solicitud id : {s.id} fue modificada");
                }
            });
            if (!solicitudCotizacionDAL.calcularDVV(solicitudes).Equals(solicitudCotizacionDAL.obtenerDVV())) {
                errores.Add("En la tabla SolicitudCotizacion, el DVV es incorrecto");
            }
            return errores;
        }
    }
}
