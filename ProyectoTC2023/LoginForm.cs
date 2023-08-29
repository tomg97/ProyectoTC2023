using BLL.Metodos;
using CUL.Entidades;
using DAL.Metodos;
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
using Servicios.Idioma;
using Servicios.Interfaces;
using CUL.Métodos;

namespace ProyectoTC2023 {
    public partial class LoginForm : Form, IObserver {
        public LoginForm() {
            InitializeComponent();
            LenguajeActual.Attach(this);
        }
        Mensajeria mensajeria = new Mensajeria();

        private void btnLogin_Click(object sender, EventArgs e) {
            ValidarCampos validarCampos = new ValidarCampos();
            string nomUsu = txtUsu.Text;
            string pass = txtPass.Text;
            if (validarCampos.validarNoNuloNoVacio(nomUsu, pass)) {
                Usuario usuario = new Usuario() { nomUsu = nomUsu, pass = pass };
                ManejaUsuarios stepAuth = new ManejaUsuarios();
                string message = stepAuth.loginProcedimiento(usuario);
                mensajeria.mostrarMensaje(message);
                if(message == "Exito") {
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                }
            } else {
                mensajeria.mostrarMensaje("Se debe proporcionar nomre de usuario y/o contraseña");
            }
        }

        private void btnSinSesion_Click(object sender, EventArgs e) {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();            
            
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            cbIdioma.Items[0] = Lang.Español;
            cbIdioma.Items[1] = Lang.Inglés;

            lblUsu.Text = Lang.lblUsu;
            lblLang.Text = Lang.lblLang;
            lblPass.Text = Lang.lblPass;

            btnSinSesion.Text = Lang.btnSinSesion;
        }

        private void btnAplicarIdioma_Click(object sender, EventArgs e) {
            switch (miIdioma) {
                case Idiomas.Español:
                    LenguajeActual.lenguajeActual = "es-AR";
                    break;
                case Idiomas.Ingles:
                    LenguajeActual.lenguajeActual = "en-US";
                    break;
                default:
                    break;
            }
            SingletonSesion.idiomaActual(LenguajeActual.lenguajeActual);
            //UsuarioBLL usuarioBLL = new UsuarioBLL();
            //usuarioBLL.Actualizar(miUsuario);
        }
        public Idiomas miIdioma = new Idiomas();

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e) {
            int selectedIndex = cbIdioma.SelectedIndex;

            if (Enum.IsDefined(typeof(Idiomas), selectedIndex)) {
                miIdioma = (Idiomas)selectedIndex;
                // Aquí puedes realizar alguna acción con el idioma seleccionado.
                // Por ejemplo, imprimir el idioma seleccionado:
                mensajeria.mostrarMensaje("Idioma seleccionado: " + miIdioma);
            }
        }
    }
    public enum Idiomas {
        Español,
        Ingles
    }
}
