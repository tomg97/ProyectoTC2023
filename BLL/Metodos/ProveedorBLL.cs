using CUL.Entidades;
using DAL.Metodos;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ProveedorBLL : IDVManejadores {
        ProveedorDAL proveedorDAL = new ProveedorDAL();
        public List<Proveedor> getProveedores() {            
            List<Proveedor> listaProveedores = proveedorDAL.getProveedores();
            return listaProveedores;
        }
        public Proveedor getProveedor(string cuit) {
            return proveedorDAL.getProveedor(cuit);
        }
        public void agregarProveedorCompleto(string cuit, string email, string nombre, string telefono, string domicilio, string banco) {
            Proveedor proveedor = new Proveedor(cuit, email, nombre, telefono, domicilio, banco);
            proveedorDAL.guardarProveedorNuevo(proveedor);
        }
        public void agregarProveedorBasico(string cuit, string email, string nombre) {
            Proveedor proveedor = new Proveedor(cuit, email, nombre, "0", "", "");
            proveedorDAL.guardarProveedorNuevo(proveedor);
        }

        public void completarRegistroProveedor(string cuit, string email, string nombre, string telefono, string domicilio, string banco) {
            Proveedor proveedorAlmacenar = new Proveedor(cuit, email, nombre, telefono, domicilio, banco);
            proveedorDAL.completarRegistroProveedor(proveedorAlmacenar);
        }
        public void recalcularDV() {
            proveedorDAL.actualizarTodosDV();
            proveedorDAL.actualizarDVV();
        }

        public List<string> chequearIntegridad() {
            List<String> errores = new List<String>();
            List<Proveedor> proveedores = proveedorDAL.getProveedores();

            proveedores.ForEach(c => {
                if (!c.dvh.Equals(proveedorDAL.calcularDVH(c))) {
                    errores.Add($"En la tabla Proveedor, el proveedor cuit : {c.CUIT} fue modificada");
                }
            });
            if (!proveedorDAL.calcularDVV(proveedores).Equals(proveedorDAL.obtenerDVV())) {
                errores.Add("En la tabla Proveedor, el DVV es incorrecto");
            }
            return errores;
        }
    }
}
