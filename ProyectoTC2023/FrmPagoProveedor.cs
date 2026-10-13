using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using Servicios.Idioma;
using CUL.Entidades;

namespace ProyectoTC2023 {
    public partial class FrmPagoProveedor : Form {
        public FrmPagoProveedor() {
            InitializeComponent();
            actualizarIdioma();
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmPagoProveedor", typeof(FrmPagoProveedor), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmPagoProveedor", typeof(FrmPagoProveedor).Assembly);
            this.Text = _resourceManager.GetString("FrmPagoProveedor");
        }
    }
}
