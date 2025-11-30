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
    public class BitacoraBLL {
        public BitacoraBLL() { }
        ManejaDbBitacora manejaDbBitacora = new ManejaDbBitacora();
        public void persistirMensajeLogged(EventoEnum contenido, Modulo tabla, Criticidad criticidad) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            if (SingletonSesion.getInstance.getUsuarioActual() != null) {
                MensajeEvento mensaje = new MensajeEvento(contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, criticidad);
                manejaDbBitacora.crearEntradaBitacora(mensaje);
            }            
        }
        public void persistirMensajeNoLogged(EventoEnum contenido, Modulo tabla, Criticidad criticidad, string nomUsu) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            if (SingletonSesion.getInstance.getUsuarioActual() != null) {
                MensajeEvento mensaje = new MensajeEvento(contenido, nomUsu, tabla, criticidad);
                manejaDbBitacora.crearEntradaBitacora(mensaje);
            }            
        }
        /*public void persistirMensaje(string contenido, Modulo tabla, int criticidad, Object cambioDe, Object cambioA) {
            Guuido guuido = new Guuido();
            Mensaje mensaje = new Mensaje(guuido.getUuidString(), contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, cambioDe, cambioA, criticidad);
            manejaDbBitacora.crearEntradaBitacora(mensaje);
        }*/
        public DataTable lookupBitacoraEventosParametros(Dictionary<string, string> dic) {
            List<MensajeEvento> list = manejaDbBitacora.lookupMensajesBitacoraEventos(dic);
            persistirMensajeLogged(EventoEnum.LookupEventoOk, Modulo.Bitacora, Criticidad.Dos);
            DataTable dataTable = cargarDataTableBitEventos(list);
            return dataTable;
        }
        public DataTable lookupBitacoraCambiosParametros(Dictionary<string, string> dic) {
            List<MensajeCambio> list = manejaDbBitacora.lookupMensajesBitacoraCambios(dic);
            persistirMensajeLogged(EventoEnum.LookupCambioOk, Modulo.Bitacora, Criticidad.Dos);
            DataTable dataTable = cargarDataTableBitCambio(list);
            return dataTable;
        }
        private static string armarMensajeDiccionario(Dictionary<string, string> dic) {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in dic) {
                if (!string.IsNullOrEmpty(kvp.Value)) {
                    sb.Append($"\"{kvp.Key}\": \"{kvp.Value}\", ");
                }
            }
            if (sb.Length > 0) {
                sb.Length -= 2;
            }
            return sb.ToString();
        }

        private static DataTable cargarDataTableBitEventos(List<MensajeEvento> list) {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            string username = codigoIdioma == "es-AR" ? "Nombre de Usuario" : "Username";
            string contents = codigoIdioma == "es-AR" ? "Contenido" : "Contents";
            string module = codigoIdioma == "es-AR" ? "Módulo" : "Module";
            string severity = codigoIdioma == "es-AR" ? "Criticidad" : "Severity";
            string date = codigoIdioma == "es-AR" ? "Fecha" : "Date";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(username, typeof(string));
            dataTable.Columns.Add(contents, typeof(string));
            dataTable.Columns.Add(module, typeof(Modulo));
            dataTable.Columns.Add(severity, typeof(Criticidad));            
            dataTable.Columns.Add(date, typeof(DateTime));
        
            foreach (var log in list) {
                DataRow row = dataTable.NewRow();
                row[username] = log.usuario;
                row[contents] = log.contenido.GetDescripcionTraducida();
                row[module] = log.modulo;
                row[severity] = log.criticidad;
                row[date] = log.fecha;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
        private static DataTable cargarDataTableBitCambio(List<MensajeCambio> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id Operacion", typeof(string));
            dataTable.Columns.Add("Id Producto", typeof(string));
            dataTable.Columns.Add("Marca Producto", typeof(MarcaProducto));
            dataTable.Columns.Add("Nombre Producto", typeof(string));
            dataTable.Columns.Add("Precio", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(string));
            dataTable.Columns.Add("Fecha", typeof(DateTime));
            dataTable.Columns.Add("Usuario", typeof(string));
            dataTable.Columns.Add("Activo", typeof(bool));
            dataTable.Columns.Add("Tipo Operacion", typeof(MensajeCambio.TipoOperacion));

            foreach (var log in list) {
                DataRow row = dataTable.NewRow();
                row["Id Operacion"] = log.idOperacion;
                row["Id Producto"] = log.idProducto;
                row["Marca Producto"] = log.marcaProducto;
                row["Nombre Producto"] = log.nombreProducto;
                row["Precio"] = log.precio;
                row["Cantidad"] = log.cantidad;
                row["Fecha"] = log.fecha;
                row["Tipo Operacion"] = log.tipoOp;
                row["Usuario"] = log.usuario;
                row["Activo"] = log.activo;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable traerTodaBitacoraEventos() {
            List<MensajeEvento> list = manejaDbBitacora.traerTodaBitacoraEventos();
            DataTable dataTable = cargarDataTableBitEventos(list);
            return dataTable;
        }
        public DataTable traerTodaBitacoraCambios() {
            List<MensajeCambio> list = manejaDbBitacora.traerTodaBitacoraCambios();
            DataTable dataTable = cargarDataTableBitCambio(list);
            return dataTable;
        }

        public Usuario lookupUsuario(string username) {
            ManejaDbUsuarios manejaDbUsuarios = new ManejaDbUsuarios();
            return manejaDbUsuarios.devolverUsuarioNomUsu(username);
        }
        public void rollbackCambio(Producto producto, string keyOg) {
            ManejaDbMaestro manejaDbMaestro = new ManejaDbMaestro();
            manejaDbMaestro.modificarProducto(producto, keyOg);
            persistirMensajeLogged(EventoEnum.RollbackCambioOk, Modulo.Bitacora, Criticidad.Uno);
        }
    }
}
