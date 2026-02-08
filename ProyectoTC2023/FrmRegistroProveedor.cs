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
    public partial class FrmRegistroProveedor : Form {
        string etapaRegistro;
        ValidarCampos validar = new ValidarCampos();
        public FrmRegistroProveedor(string etapa) {
            InitializeComponent();
            etapaRegistro = etapa;
            cargarTextBoxes();
        }
        public FrmRegistroProveedor(Proveedor proveedor, string etapa) {
            InitializeComponent();
            etapaRegistro = etapa;
            cargarTextBoxes(proveedor);
        }

        private void cargarTextBoxes() {
            if (etapaRegistro == "Registro") {
                txtBanco.Enabled = true;
                txtBanco.Show();
                lblBanco.Visible = true;
                txtTelefono.Enabled = true;
                txtTelefono.Show();
                lblTelefono.Visible = true;
                txtDomicilio.Enabled = true;
                txtDomicilio.Show();
                lblDomicilio.Visible = true;
            } else {
                txtBanco.Enabled = false;
                txtBanco.Hide();
                lblBanco.Visible = false;
                txtTelefono.Enabled = false;
                txtTelefono.Hide();
                lblTelefono.Visible = false;
                txtDomicilio.Enabled = false;
                txtDomicilio.Hide();
                lblDomicilio.Visible = false;
            }
        }
        private void cargarTextBoxes(Proveedor proveedor) {
            txtCUIT.Text = proveedor.CUIT;
            txtCUIT.Enabled = false;
            txtEmail.Text = proveedor.email;
            txtEmail.Enabled = false;
            txtNombre.Text = proveedor.nombre;
            txtNombre.Enabled = false;
            txtBanco.Enabled = true;
            txtBanco.Show();
            lblBanco.Visible = true;
            txtTelefono.Enabled = true;
            txtTelefono.Show();
            lblTelefono.Visible = true;
            txtDomicilio.Enabled = true;
            txtDomicilio.Show();
            lblDomicilio.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            try {
                string cuit = txtCUIT.Text;
                string email = txtEmail.Text;
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string domicilio = txtDomicilio.Text;
                string banco = txtBanco.Text;
                if (etapaRegistro == "Registro") {
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
                } else if (etapaRegistro == "Pre Registro") {
                    if (validar.validarNoNuloNoVacio(cuit, email, nombre)) {
                        if (validar.validarSoloNumero(cuit)) {
                            ProveedorBLL proveedorBLL = new ProveedorBLL();
                            proveedorBLL.agregarProveedorBasico(cuit, email, nombre);
                            Mensajeria mensajeria = new Mensajeria();
                            mensajeria.mostrarMensaje("Proveedor agregado con éxito.");
                            this.Close();
                        } else {
                            Mensajeria mensajeria = new Mensajeria();
                            mensajeria.mostrarMensaje("El CUIT debe contener sólo números.");
                        }
                    } else {
                        Mensajeria mensajeria = new Mensajeria();
                        mensajeria.mostrarMensaje("Los campos CUIT, Email y Nombre deben ser completados.");
                    }
                } else {
                    if (validar.validarNoNuloNoVacio(telefono, domicilio, banco)) {
                        ProveedorBLL proveedorBLL = new ProveedorBLL();
                        proveedorBLL.completarRegistroProveedor(cuit, email, nombre, telefono, domicilio, banco);
                        Mensajeria mensajeria = new Mensajeria();
                        mensajeria.mostrarMensaje("Proveedor actualizado con éxito.");
                        this.Close();
                    } else {
                        Mensajeria mensajeria = new Mensajeria();
                        mensajeria.mostrarMensaje("Todos los campos deben ser completados.");
                    }
                }
            } catch (Exception ex) {
                Mensajeria mensajeria = new Mensajeria();
                mensajeria.mostrarMensaje("Error al agregar el proveedor: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
