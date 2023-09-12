using CUL.Entidades;
using DAL.Metodos;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class BitacoraBLL {
        public BitacoraBLL() { }
        ManejaDbBitacora manejaDbBitacora = new ManejaDbBitacora();
        public void persistirMensaje(string contenido, Tabla tabla, int criticidad) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            Guuido guuido = new Guuido();

            if (SingletonSesion.getInstance.getUsuarioActual() != null) {
                Mensaje mensaje = new Mensaje(guuido.getUuidString(), contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, criticidad);
                manejaDbBitacora.crearEntradaBitacora(mensaje);
            }            
        }
        public void persistirMensaje(string contenido, Tabla tabla, int criticidad, Object cambioDe, Object cambioA) {
            Guuido guuido = new Guuido();
            Mensaje mensaje = new Mensaje(guuido.getUuidString(), contenido, SingletonSesion.getInstance.getUsuarioActual().nomUsu, tabla, cambioDe, cambioA, criticidad);
            manejaDbBitacora.crearEntradaBitacora(mensaje);
        }
        public List<Mensaje> lookupBitacoraParametros(Dictionary<string, string> dic) {
            List<Mensaje> list = new List<Mensaje>();
            list = manejaDbBitacora.lookupMensajesBitacora(dic);
            return list;
        }
    }
}
