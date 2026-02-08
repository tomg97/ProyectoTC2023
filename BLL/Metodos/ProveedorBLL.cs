using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ProveedorBLL {
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
            proveedorDAL.guardarProveeorNuevo(proveedor);
        }
        public void agregarProveedorBasico(string cuit, string email, string nombre) {
            Proveedor proveedor = new Proveedor(cuit, email, nombre, "0", "", "");
            proveedorDAL.guardarProveeorNuevo(proveedor);
        }

        public void completarRegistroProveedor(string cuit, string email, string nombre, string telefono, string domicilio, string banco) {
            Proveedor proveedorAlmacenar = new Proveedor(cuit, email, nombre, telefono, domicilio, banco);
            proveedorDAL.completarRegistroProveedor(proveedorAlmacenar);
        }
    }
}
