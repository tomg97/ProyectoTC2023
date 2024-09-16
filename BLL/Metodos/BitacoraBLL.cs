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
        public void persistirMensajeLogged(string contenido, Modulo tabla, Criticidad criticidad) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            if (SingletonSesion.getInstance.getUsuarioActual() != null) {
                Mensaje mensaje = new Mensaje(contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, criticidad);
                manejaDbBitacora.crearEntradaBitacora(mensaje);
            }            
        }
        public void persistirMensajeNoLogged(string contenido, Modulo tabla, Criticidad criticidad, string nomUsu) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            if (SingletonSesion.getInstance.getUsuarioActual() != null) {
                Mensaje mensaje = new Mensaje(contenido, nomUsu, tabla, criticidad);
                manejaDbBitacora.crearEntradaBitacora(mensaje);
            }            
        }
        /*public void persistirMensaje(string contenido, Modulo tabla, int criticidad, Object cambioDe, Object cambioA) {
            Guuido guuido = new Guuido();
            Mensaje mensaje = new Mensaje(guuido.getUuidString(), contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, cambioDe, cambioA, criticidad);
            manejaDbBitacora.crearEntradaBitacora(mensaje);
        }*/
        public DataTable lookupBitacoraParametros(Dictionary<string, string> dic) {
            List<Mensaje> list = manejaDbBitacora.lookupMensajesBitacora(dic);
            persistirMensajeLogged("Se realizó una búsqueda con los siguientes parámetros: " + armarMensajeDiccionario(dic) + " .", Modulo.Bitacora, Criticidad.Dos);
            DataTable dataTable = cargarDataTableBitEventos(list);
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

        private static DataTable cargarDataTableBitEventos(List<Mensaje> list) {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Nombre de Usuario", typeof(string));
            dataTable.Columns.Add("Contenido", typeof(string));
            dataTable.Columns.Add("Modulo", typeof(Modulo));
            dataTable.Columns.Add("Criticidad", typeof(Criticidad));            
            dataTable.Columns.Add("Fecha", typeof(DateTime));
        
            foreach (var log in list) {
                DataRow row = dataTable.NewRow();
                row["Nombre de Usuario"] = log.usuario;
                row["Contenido"] = log.contenido;
                row["Modulo"] = log.modulo;
                row["Criticidad"] = log.criticidad;
                row["Fecha"] = log.fecha;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        public DataTable traerTodaBitacoraEventos() {
            List<Mensaje> list = manejaDbBitacora.traerTodaBitacoraEventos();
            DataTable dataTable = cargarDataTableBitEventos(list);
            return dataTable;
        }

        public Usuario lookupUsuario(string username) {
            ManejaDbUsuarios manejaDbUsuarios = new ManejaDbUsuarios();
            return manejaDbUsuarios.devolverUsuarioNomUsu(username);
        }
    }
}
