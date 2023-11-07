using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using Servicios.Idioma;
using Servicios.Interfaces;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoTC2023 {
    public partial class FrmDespacho : Form, IObserver {
        ManejaVenta manejaVenta = new ManejaVenta();
        Mensajeria mensajeria = new Mensajeria();
        string pathArchivo;
        public FrmDespacho() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }

        private void btnDespachar_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                ValidarCampos validarCampos = new ValidarCampos();
                string idCliente = txtIdCliente.Text;
                string idFactura = txtIdFactura.Text;
                if (validarCampos.validarNoNuloNoVacio(idFactura, idCliente)) {
                    manejaVenta.despacharFactura(idFactura, idCliente, pathArchivo);
                    mensajeria.mostrarMensaje("Se ha despachado la factura: " + idFactura + ". Podrá ser visualizada en la carpeta Facturas despachadas.");
                } else {
                    mensajeria.mostrarMensaje("Se debe proporcionar id cliente y de factura para despachar.");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }            
        }

        private void btnSelect_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                manejaVenta.devolverFacturaYCargarTreeView(trvFactura);
            } else {
                mensajeria.mostrarErrorNoLogged();
            }            
        }
        private void trvJson_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.C) {
                TreeNode selectedNode = trvFactura.SelectedNode;

                if (selectedNode != null) {
                    string selectedValue = selectedNode.Text; // or selectedNode.Tag.ToString() if you set a custom value

                    // Perform copy operation with the selected value
                    Clipboard.SetText(selectedValue);
                }
            }
        }

        private void FrmDespacho_Load(object sender, EventArgs e) {

        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            gbIdFacturas.Text = Lang.gbIdFacturas;
            lblIdFactura.Text = Lang.lblIdFactura;
            lblDniFactura.Text = Lang.lblDniFactura;
            btnDespachar.Text = Lang.btnDespachar;
            gbSeleccionFactura.Text = Lang.gbSeleccionFactura;
            btnSelect.Text = Lang.btnSelect;
            gbVisualizador.Text = Lang.gbVisualizador;
        }
    }
}
