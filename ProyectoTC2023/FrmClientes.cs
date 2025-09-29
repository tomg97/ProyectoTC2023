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
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmClientes : Form, IObserver {
        ManejaVenta manejaVenta = new ManejaVenta();
        ManejaCliente manejaCliente = new ManejaCliente();
        ValidarCampos validar = new ValidarCampos();
        Cliente clienteVacio = new Cliente();
        public FrmClientes(Cliente cliente) {
            InitializeComponent();
            LenguajeActual.Attach(this);
            gbRegistroCliente.Visible = false;
            lblCuotas.Visible = false;
            txtCuotas.Visible = false;
            clienteVacio = cliente;
            actualizarIdioma();
        }
        public FrmClientes(string idClienteACrear) {
            InitializeComponent();
            gbDatosPago.Visible = false;
            clienteVacio.id = idClienteACrear;
            txtIdCliente.Text = idClienteACrear;
            txtIdCliente.ReadOnly = true;
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e) {
            ValidarCampos validarCampos = new ValidarCampos();
            string id = txtIdCliente.Text;
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string domicilio = txtDomicilioCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            if (validarCampos.validarNoNuloNoVacio(nombre, apellido, domicilio, telefono)) {
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
            string cuotas = txtCuotas.Text;
            if (validar.validarSoloNumero(cuotas) && validar.validarMayor0(Convert.ToInt32(cuotas)) && validar.validarCuotas(cuotas)) {
                updateCuotas(cuotas);
            } else if (!validar.validarNoNuloNoVacio(cuotas)) {
                resetSubtotalCuotas();
                txtCuotas.Clear();
            } else {
                MessageBox.Show("El valor de las cuotas debe ser sólo numérico, múltiplo de 3, entre 1 y 12 cuotas");
                resetSubtotalCuotas();
                txtCuotas.Clear();
            }
        }
        private void resetSubtotal() {
            lblSubtotalVenta.Text = "Subtotal: ";
        }
        private void resetSubtotalCuotas() {

            lblSubtotalCuotas.Text =  "Cada cuota: ";
        }

        private void btnVenta_Click(object sender, EventArgs e) {
            string numertoTarjeta = txtNumeroTarjeta.Text;
            string mes = txtMesTarjeta.Text;
            string año = txtAñoTarjeta.Text;
            string mesYAño = mes + año;
            string CCV = txtCCV.Text;
            if(validar.validarNoNuloNoVacio(numertoTarjeta, mesYAño, CCV)) {
                if(manejaVenta.commitCarrito(clienteVacio) == "éxito") {
                    MessageBox.Show("La transacción fue exitosa y será guardada");
                    Close();
                }
            } else if (!validar.validarNoNuloNoVacio(numertoTarjeta)) {
                MessageBox.Show("Se debe ingresar un número de tarjeta.");
            } else if (!validar.validarNoNuloNoVacio(mesYAño) || !validar.validarSoloMes(mes) || validar.validarFechaNoVencida(mesYAño)) {
                MessageBox.Show("Se debe ingresar un mes y año válidos.");
            } else if (!validar.validarNoNuloNoVacio(CCV) || !validar.validarCCV(CCV)) {
                MessageBox.Show("El CCV es inválido. Deben ser sólo 3 números.");
            }
        }
        private void validarTxtFecha(object sender, EventArgs e) {
            if(txtMesTarjeta.Text.Length > 2 || txtAñoTarjeta.Text.Length > 2) {
                MessageBox.Show("Se deben ingresar solo dos dígitos para el mes/año.");
                txtMesTarjeta.Clear();
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmClientes", typeof(FrmClientes), codigoIdioma);

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            lblSubtotalVenta.Text = lblSubtotalVenta.Text + " $" + manejaVenta.getSubtotalCarrito();
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmClientes", typeof(FrmClientes).Assembly);
            this.Text = _resourceManager.GetString("FrmClientes");
        }
        private void updateCuotas(string cuotas) {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            lblSubtotalCuotas.Text = (codigoIdioma == "es-AR" ? "Cada cuota: " : "Each installment: ") + " $" + manejaVenta.getSubtotalCuotas(cuotas);
        }
    }
}
