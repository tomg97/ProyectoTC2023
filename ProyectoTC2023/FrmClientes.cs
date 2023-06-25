using BLL.Metodos;
using CUL.Entidades;
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
    public partial class FrmClientes : Form {
        ManejaVenta manejaVenta = new ManejaVenta();
        ManejaCliente manejaCliente = new ManejaCliente();
        public FrmClientes(string proposito) {
            InitializeComponent();
            if (proposito == "Registro Cliente") {
                gbDatosPago.Visible = false;
            } else if (proposito == "Datos Pago") {
                gbRegistroCliente.Visible = false;
                lblCuotas.Visible = false;
                txtCuotas.Visible = false;
                lblSubtotalVenta.Text = "Subtotal: $" + manejaVenta.getSubtotalCarrito();
            }
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e) {
            ValidarCampos validarCampos = new ValidarCampos();
            string id = txtIdCliente.Text;
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string domicilio = txtDomicilioCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            if (validarCampos.validarNoNuloNoVacio(id, nombre, apellido, domicilio, telefono)) {
                Cliente nuevoCliente = new Cliente(id, nombre, apellido, domicilio, telefono);
                MessageBox.Show(manejaCliente.crearCliente(nuevoCliente));
                Close();
            }
        }

        private void dbRegistroCliente_Enter(object sender, EventArgs e) {

        }

        private void FrmClientes_Load(object sender, EventArgs e) {

        }
        private void eventoDropDownTarjeta(object sender, EventArgs e) {
            if(cbTipoTarjeta.SelectedItem.ToString() == "Crédito") {
                lblCuotas.Visible = true;
                txtCuotas.Visible = true;
            }
        }
        private void validacionTxtBoxCuotas(object sender, EventArgs e) {
            ValidarCampos validar = new ValidarCampos();
            string cuotas = txtCuotas.Text;
            if (validar.validarSoloNumero(cuotas) && validar.validarMayor0(Convert.ToInt32(cuotas)) && validar.validarCuotas(cuotas)) {
                lblSubtotalCuotas.Text = "Cada cuota: $" + manejaVenta.getSubtotalCuotas(cuotas);
            } else if (!validar.validarNoNuloNoVacio(cuotas)) {
                resetSubtotalCuotas();
                txtCuotas.Clear();
            } else {
                MessageBox.Show("El valor de las cuotas debe ser sólo numérico, múltiplo de 3 y entre 1 y 12 cuotas");
                resetSubtotalCuotas();
                txtCuotas.Clear();
            }
        }
        private void resetSubtotal() {
            lblSubtotalVenta.Text = "Subtotal: ";
        }
        private void resetSubtotalCuotas() {
            lblSubtotalCuotas.Text = "Cada cuota: ";
        }

        private void btnVenta_Click(object sender, EventArgs e) {

        }
    }
}
