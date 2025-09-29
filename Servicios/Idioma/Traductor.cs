using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.Idioma {
    public class Traductor {
        private readonly ResourceManager _resourceManager;

        public Traductor(string resourceBaseName, Type resourceAssemblyType, string codigoIdioma) {
            _resourceManager = new ResourceManager(resourceBaseName, resourceAssemblyType.Assembly);
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoIdioma);
        }

        public void ActualizarIdioma(Control parentControl) {                
            TraducirControl(parentControl);
        }

        private void TraducirControl(Control control) {
            //control.Text = _resourceManager.GetString(control.Name) ?? control.Text;
            if (control is MenuStrip menuStrip) {
                foreach (ToolStripMenuItem item in menuStrip.Items) {
                    if (item.HasDropDownItems) {
                        foreach(ToolStripMenuItem tsmi in item.DropDownItems) {
                            tsmi.Text = _resourceManager.GetString(tsmi.Name) ?? tsmi.Text;
                        }
                    }
                    item.Text = _resourceManager.GetString(item.Name) ?? item.Text;
                }
            } else {
                control.Text = _resourceManager.GetString(control.Name) ?? control.Text;
                foreach (Control childControl in control.Controls) {
                    TraducirControl(childControl);
                }
            }
        }
    }
}
