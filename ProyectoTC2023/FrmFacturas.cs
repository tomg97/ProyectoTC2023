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

namespace ProyectoTC2023 {
    public partial class FrmFacturas : Form, IObserver {
        ManejaVenta manejaVenta = new ManejaVenta();
        Mensajeria mensajeria = new Mensajeria();
        public FrmFacturas() {
            InitializeComponent();
            resetDgvView();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }

        private void FrmFacturas_Load(object sender, EventArgs e) {

        }
        private void resetDgvView() {
            dgvVentasNoF.DataSource = null;
            dgvVentasNoF.DataSource = manejaVenta.getVentasNoFacturadas();
        }

        private void btnFacturar_Click(object sender, EventArgs e) {
            ValidarCampos validar = new ValidarCampos();
            if (SingletonSesion.getInstance.estaLogged) {
                if (validar.validarMayor0(dgvVentasNoF.Rows.Count)) {
                    try {
                        DataGridViewRow selectedRow = dgvVentasNoF.SelectedRows[0];
                        Venta ventaAFacturar = (Venta)selectedRow.DataBoundItem;
                        manejaVenta.facturarVenta(ventaAFacturar);
                        mensajeria.mostrarMensaje("Se ha generado una factura con id: " + ventaAFacturar.id);
                        Close();
                    } catch (ArgumentOutOfRangeException ex) {
                        mensajeria.mostrarMensaje("Se debe seleccionar una fila de la lista");
                    }
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }            
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            gbVentasNoF.Text = Lang.gbVentasNoF;
            btnFacturar.Text = Lang.btnFacturar;
        }
    }
}
