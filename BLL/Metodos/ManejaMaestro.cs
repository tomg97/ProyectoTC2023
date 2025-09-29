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
        string lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();

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
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Nombre Usuario" : "Username"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Nombre" : "First name"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Apellido" : "Last name"), typeof(string));
            dataTable.Columns.Add("DNI", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Teléfono" : "Phone number"), typeof(string));

            foreach (var cliente in list) {
                DataRow row = dataTable.NewRow();
                row[(lenguajeActual == "es-AR" ? "Nombre Usuario" : "Username")] = cliente.nomUsu;
                row[(lenguajeActual == "es-AR" ? "Nombre" : "First name")] = cliente.nombre;
                row[(lenguajeActual == "es-AR" ? "Apellido" : "Last name")] = cliente.apellido;
                row["DNI"] = cliente.dni;
                row["Email"] = cliente.email;
                row[(lenguajeActual == "es-AR" ? "Teléfono" : "Phone number")] = cliente.telefono;                
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private DataTable cargarDataTableProductos(List<Producto> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Nombre Producto" : "Product Name"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Marca Producto" : "Brand"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Cantidad" : "Quantity"), typeof(int));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Precio" : "Price"), typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            foreach (var producto in list) {
                DataRow row = dataTable.NewRow();
                row[(lenguajeActual == "es-AR" ? "Nombre Producto" : "Product Name")] = producto.nombreProducto;
                row[(lenguajeActual == "es-AR" ? "Marca Producto" : "Brand")] = producto.marcaProducto;
                row[(lenguajeActual == "es-AR" ? "Cantidad" : "Quantity")] = producto.cantidad;
                row[(lenguajeActual == "es-AR" ? "Precio" : "Price")] = producto.precio;
                row["Id"] = producto.id;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private DataTable cargarDataTableClientes(List<Cliente> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Nombre" : "First name"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Apellido" : "Last name"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Domicilio" : "Address"), typeof(string));
            dataTable.Columns.Add((lenguajeActual == "es-AR" ? "Teléfono" : "Phone number"), typeof(string));
            dataTable.Columns.Add("Id", typeof(string));
            Encriptador encriptador = new Encriptador();

            foreach (var cliente in list) {
                DataRow row = dataTable.NewRow();
                row[(lenguajeActual == "es-AR" ? "Nombre" : "First name")] = cliente.nombre;
                row[(lenguajeActual == "es-AR" ? "Apellido" : "Last name")] = cliente.apellido;
                row[(lenguajeActual == "es-AR" ? "Domicilio" : "Address")] = encriptador.desencriptarReversible(cliente.domicilio);
                row[(lenguajeActual == "es-AR" ? "Teléfono" : "Phone number")] = encriptador.desencriptarReversible(cliente.telefono);
                row["Id"] = encriptador.desencriptarReversible(cliente.id);
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
            string id = string.Equals(tipo, "Usuarios") ? (lenguajeActual == "es-AR" ? "Nombre de Usuario" : "Username") : "Id";
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
