using CUL.Entidades;
using DAL.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Metodos {
    public class ManejaBitacora {
        public ManejaBitacora() { }
        ManejaDbBitacora manejaDbBitacora = new ManejaDbBitacora();
        public void persistirMensaje(Mensaje mensaje) {
            mensaje.fecha = DateTime.Now;
            manejaDbBitacora.crearEntradaBitacora(mensaje);
        }
        public List<Mensaje> lookupBitacoraParametros(Dictionary<string, string> dic) {
            List<Mensaje> list = new List<Mensaje>();
            list = manejaDbBitacora.lookupMensajesBitacora(dic);
            return list;
        }
    }
}
