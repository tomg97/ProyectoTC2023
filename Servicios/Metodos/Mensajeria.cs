using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.Metodos {
    public class Mensajeria {
        public void mostrarErrorNoLogged() {
            MessageBox.Show("No se detecta un usuario loggeado. Se debe ingresar al sistema");
        }
        public void mostrarMensaje(string mensaje) {
            MessageBox.Show(mensaje);
        }
    }
}
