using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaMaestro {
        ManejaDbClientes manejaCliente = new ManejaDbClientes();
        ManejaDbMaestro manejaDbMaestro; 
        ManejaDbUsuarios dbUsuarios = new ManejaDbUsuarios();
        BitacoraBLL bitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();
        Encriptador encriptador = new Encriptador();

        string tipo;
        public ManejaMaestro(string tipo) { this.tipo = tipo; manejaDbMaestro = new ManejaDbMaestro(tipo); }

        public DataTable pedirYTraerDatos() {
            DataTable dt = new DataTable();
            try {
                switch (tipo) {
                    case "Cliente":
                        dt = cargarDataTableClientes(manejaCliente.traerTodosClientes());
                        break;
                    case "Producto":
                        dt = cargarDataTableProductos(manejaDbMaestro.traerTodosProductos());
                        break;
                    case "Usuarios":
                        dt = cargarDataTableUsuarios(dbUsuarios.traerTodosUsuarios());
                        break;
                }
            } catch (Exception ex) {
                mensajeria.mostrarMensaje(ex.Message);
            }
            return dt;
        }

        private DataTable cargarDataTableUsuarios(List<Usuario> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre Usuario", typeof(string));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("DNI", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Teléfono", typeof(string));

            foreach (var cliente in list) {
                DataRow row = dataTable.NewRow();
                row["Nombre Usuario"] = cliente.nomUsu;
                row["Nombre"] = cliente.nombre;
                row["Apellido"] = cliente.apellido;
                row["DNI"] = cliente.dni;
                row["Email"] = cliente.email;
                row["Teléfono"] = cliente.telefono;                
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private DataTable cargarDataTableProductos(List<Producto> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre Producto", typeof(string));
            dataTable.Columns.Add("Marca Producto", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(int));
            dataTable.Columns.Add("Precio", typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            foreach (var producto in list) {
                DataRow row = dataTable.NewRow();
                row["Nombre Producto"] = producto.nombreProducto;
                row["Marca Producto"] = producto.marcaProducto;
                row["Cantidad"] = producto.cantidad; ;
                row["Precio"] = producto.precio;
                row["Id"] = producto.id;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private static DataTable cargarDataTableClientes(List<Cliente> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Apellido", typeof(string));
            dataTable.Columns.Add("Domicilio", typeof(string));
            dataTable.Columns.Add("Teléfono", typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            foreach (var cliente in list) {
                DataRow row = dataTable.NewRow();
                row["Nombre"] = cliente.nombre;
                row["Apellido"] = cliente.apellido;
                row["Domicilio"] = cliente.domicilio;
                row["Teléfono"] = cliente.telefono;
                row["Id"] = cliente.id;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        public void guardarProductoNuevo(Producto producto) {
            try {
                manejaDbMaestro.guardarProductoNuevo(producto);
                bitacora.persistirMensajeLogged("Se dio el alta de un producto nuevo. Id Producto: " + producto.id, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged("Se produjo un error durante el alta de un producto nuevo. Error: " + ex.Message + ". Id Producto: " + producto.id, Modulo.Maestros, Criticidad.Uno);
            }            
        }
        public void guardarUsuario(Usuario usuario) {
            try {
                usuario.pass = encriptador.encriptarIrreversible(usuario.pass);
                dbUsuarios.crearUsuario(usuario);
                bitacora.persistirMensajeLogged("Se dio el alta de un usuario nuevo. Nombre usuario: " + usuario.nomUsu, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                bitacora.persistirMensajeLogged("Se produjo un error durante el alta de un usuario nuevo. Error: " + ex.Message + ". Nombre Usuario: " + usuario.nomUsu, Modulo.Maestros, Criticidad.Uno);
                mensajeria.mostrarMensaje("Error: " + ex.Message);
            }            
        }
        public void crearCliente(Cliente cliente) {
            try {
                manejaCliente.crearCliente(cliente);
                bitacora.persistirMensajeLogged("Se dio el alta de un cliente nuevo. Id Cliente: " + cliente.id, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                bitacora.persistirMensajeLogged("Se produjo un error durante el alta de un cliente nuevo. Error: " + ex.Message + ". Id Cliente: " + cliente.id, Modulo.Maestros, Criticidad.Uno);
                mensajeria.mostrarMensaje("Error: " + ex.Message);
            }            
        }

        public void modificaUsuario(Usuario usuario, string keyOg) {
            try {
                manejaDbMaestro.modificarUsuario(usuario, keyOg);
                bitacora.persistirMensajeLogged("Se modificó un usuario. Nombre de Usuario modificado: " + keyOg, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged("Se produjo un error durante la modificación de un usuario. Error: " + ex.Message + ". Nombre de Usuario: " + usuario.nomUsu, Modulo.Maestros, Criticidad.Uno);
            }
            
        }
        public void modificaProducto(Producto producto, string keyOg) {
            try {
                manejaDbMaestro.modificarProducto(producto, keyOg);
                bitacora.persistirMensajeLogged("Se modificó un producto. Id de producto modificado: " + keyOg, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged("Se produjo un error durante la modificación de un producto. Error: " + ex.Message + ". Id de Producto: " + producto.id, Modulo.Maestros, Criticidad.Uno);
            }
        }
        public void modificaCliente(Cliente cliente, string keyOg) {
            try {
                manejaDbMaestro.modificarCliente(cliente, keyOg);
                bitacora.persistirMensajeLogged("Se modificó un cliente. Id de cliente modificado: " + keyOg, Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged("Se produjo un error durante la modificación de un cliente. Error: " + ex.Message + ". Id de cliente: " + cliente.id, Modulo.Maestros, Criticidad.Uno);
            }
        }

        public void eliminarEntrada(string key) {
            string id = string.Equals(tipo, "Usuarios") ? "Nombre de Usuario" : "Id";
            string modificado = string.Equals(tipo, "Usuarios") ? tipo.Substring(0, tipo.Length - 1).ToLower() : tipo.ToLower();
            try {
                manejaDbMaestro.eliminarEntrada(key);
                bitacora.persistirMensajeLogged($"Se eliminó un {modificado}. {id}: ", Modulo.Maestros, Criticidad.Uno);
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
                bitacora.persistirMensajeLogged($"Se produjo un error al intentar eliminar un un {modificado}. Error: " + ex.Message + $". {id}: ", Modulo.Maestros, Criticidad.Uno);
            }   
        }
    }
}
