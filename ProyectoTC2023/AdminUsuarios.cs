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
    public partial class AdminUsuarios : Form, IObserver {
        public AdminUsuarios() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }
        private void AdminUsuarios_Load(object sender, EventArgs e) {
            tbxModPass.Visible = false;
            btnModUsu.Visible = false;
            lblABMPUsu.Visible = false;
            cmbUsusBloq.SelectedIndex = -1;
            List<Usuario> usuariosBloqueados = resultadosDb.getUsuariosBloqueados();
            if (validar.validarListaNoNulaNoVacia(usuariosBloqueados)) {
                cmbUsusBloq.DataSource = usuariosBloqueados;
                cmbUsusBloq.DisplayMember = "nomUsu";
            }
        }
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        ValidarCampos validar = new ValidarCampos();
        Mensajeria mensajeria = new Mensajeria();

        private void btnVerif_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                string nomUsu = tbxModUsu.Text;
                if (validar.validarNoNuloNoVacio(nomUsu)) {
                    if (resultadosDb.lookupUsuario(nomUsu) == "Usuario Encontrado") {
                        btnModUsu.Visible = true;
                        tbxModPass.Visible = true;
                        lblABMPUsu.Visible = true;
                    } else if (resultadosDb.lookupUsuario(nomUsu) == "Usuario No Encontrado") {
                        mensajeria.mostrarMensaje("El nombre de usuario no existe.");
                    } else {
                        mensajeria.mostrarMensaje("Error inesperado");
                        tbxNombre.Clear();
                    }
                } else {
                    mensajeria.mostrarMensaje("Nombre de Usuario vacío. Reingresar");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private void btnEnterABM_Click(object sender, EventArgs e) {
            // TODO: rework para añadir un email para los usuarios. es necesario para completar la bitácora
            string nombre = tbxNombre.Text;
            string apellido = tbxApellido.Text;
            string email = tbxEmail.Text;
            string contraseña = txtCreaContraseña.Text;
            string dni = txtDni.Text;
            string telefono = txtTelefono.Text;
            if (SingletonSesion.getInstance.estaLogged) {
                if (validar.validarNoNuloNoVacio(nombre,apellido,email,contraseña)) {
                       string nomUsuCompuesto = crearNomUsuCompuesto(nombre, apellido);
                       Usuario usuario = new Usuario() 
                       { nomUsu = nomUsuCompuesto, pass = contraseña, apellido = apellido, email = email, nombre = nombre, dni = dni, telefono = telefono };
                       tbxNombre.Clear();
                       txtCreaContraseña.Clear();
                       mensajeria.mostrarMensaje(resultadosDb.crearUsuario(usuario) + " El nombre de usuario es: " + nomUsuCompuesto + ".");
                } else {
                    mensajeria.mostrarMensaje("Uno o más campos están vacíos. Por favor, complete.");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private string crearNomUsuCompuesto(string nombre, string apellido) {
            string porcionApellido = apellido.Length >= 4 ? apellido.Substring(0, 4) : apellido;
            string porcionNombre = nombre.Substring(0, 1);
            Random random = new Random();
            string numero = random.Next(0, 1000).ToString("D3");
            return porcionApellido + porcionNombre + numero;
        }

        private void btnDesbloquear_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                if (cmbUsusBloq.SelectedIndex != -1) {
                    Usuario usuarioADesbloquear = (Usuario)cmbUsusBloq.SelectedItem;
                    resultadosDb.desbloquearUsuario(usuarioADesbloquear.nomUsu);
                    cmbUsusBloq.SelectedIndex = -1;
                    mensajeria.mostrarMensaje("El usuario " + usuarioADesbloquear.nomUsu + " ha sido desbloqueado.");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            grpbxCMUsu.Text = Lang.grpbxCMUsu;
            lblABMNUsu.Text = Lang.lblABMNUsu;
            btnVerif.Text = Lang.btnVerif;
            lblCrearPass.Text = Lang.lblABMPUsu;
            btnEnterABM.Text = Lang.btnEnterABM;
            gbDesbloquearUsuarios.Text = Lang.gbDesbloquearUsuarios;
            btnDesbloquear.Text = Lang.btnDesbloquear;
        }

        private void btnModUsu_Click(object sender, EventArgs e) {
            string nombre = tbxModUsu.Text;
            string contraseña = tbxModPass.Text;
            string mensaje = resultadosDb.modificarNombreUsuario(nombre, contraseña);
            if (mensaje == "Exito") {
                mensajeria.mostrarMensaje("Usuario " + nombre + " modificado");
                tbxModUsu.Clear();
                tbxModPass.Clear();
                tbxModPass.Visible = false;
                btnModUsu.Visible = false;
                lblABMPUsu.Visible = false;
            } else if (mensaje == "Usuario Existente") {
                mensajeria.mostrarMensaje("Usuario " + nombre + " ya existe. Utilice uno distinto.");
                txtCreaContraseña.Clear();
            }
        }

        private void grpbxCMUsu_Enter(object sender, EventArgs e) {

        }

        private void lblTelefono_Click(object sender, EventArgs e) {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e) {

        }
    }
}
