using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class BitacoraBLL {
        public BitacoraBLL() { }
        ManejaDbBitacora manejaDbBitacora = new ManejaDbBitacora();
        public void persistirMensaje(Mensaje mensaje) {
            // TODO: reworkear. no necesitas un mensaje.
            // necesitás una string para el contenido del mensaje,
            // enum del tipo
            // ver si se puede extraer el nombre de la clase. si no un string y fue (para el campo tabla)
            // sobrecargar para poder usar el mismo nombre de método, pero que uno reciba el cambio de y a 
            // criticidad puede depender de la bll que lo mande, fijo
            mensaje.fecha = DateTime.Now;
            mensaje.usuario = SingletonSesion.getInstance.getUsuarioActual().nomUsu;
            manejaDbBitacora.crearEntradaBitacora(mensaje);
        }
        public List<Mensaje> lookupBitacoraParametros(Dictionary<string, string> dic) {
            List<Mensaje> list = new List<Mensaje>();
            list = manejaDbBitacora.lookupMensajesBitacora(dic);
            return list;
        }
    }
}
