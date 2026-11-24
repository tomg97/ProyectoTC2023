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
using System.Resources;
using Servicios.Idioma;

namespace ProyectoTC2023 {
    public partial class FrmRegistroProveedor : Form {
        string etapaRegistro;
        ValidarCampos validar = new ValidarCampos();
        public FrmRegistroProveedor() {
            InitializeComponent();
            actualizarIdioma();
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            try {
                string cuit = txtCUIT.Text;
                string email = txtEmail.Text;
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string domicilio = txtDomicilio.Text;
                string banco = txtBanco.Text;
                    if (validar.validarNoNuloNoVacio(cuit, email, nombre, telefono, domicilio, banco)) {
                        if (validar.validarSoloNumero(cuit)) {
                            ProveedorBLL proveedorBLL = new ProveedorBLL();
                            proveedorBLL.agregarProveedorCompleto(cuit, email, nombre, telefono, domicilio, banco);
                            Mensajeria mensajeria = new Mensajeria();
                            mensajeria.mostrarMensaje("Proveedor agregado con éxito.");
                            this.Close();
                        } else {
                            Mensajeria mensajeria = new Mensajeria();
                            mensajeria.mostrarMensaje("El CUIT debe contener sólo números.");
                        }

                    } else {
                        Mensajeria mensajeria = new Mensajeria();
                        mensajeria.mostrarMensaje("Todos los campos deben ser completados.");
                    }
            } catch (Exception ex) {
                Mensajeria mensajeria = new Mensajeria();
                mensajeria.mostrarMensaje("Error al agregar el proveedor: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmRegistroProveedor", typeof(FrmRegistroProveedor), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmRegistroProveedor", typeof(FrmRegistroProveedor).Assembly);
            this.Text = _resourceManager.GetString("FrmRegistroProveedor");
        }

        private void gbProveedor_Enter(object sender, EventArgs e) {

        }
    }
}
