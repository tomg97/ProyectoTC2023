using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using DAL.Metodos;
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
                if(message == "Exito") {
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                } else {
                    mensajeria.mostrarMensaje(message);
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
            Traductor traductor = new Traductor("ProyectoTC2023.LoginForm", typeof(LoginForm), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }

            int selectedIndex = cbIdioma.SelectedIndex;
            actualizandoIdioma = true;
            try {
                cbIdioma.Items.Clear();
                cbIdioma.Items.Add(Lang.Español);
                cbIdioma.Items.Add(Lang.Inglés);

                if (selectedIndex >= 0 && selectedIndex < cbIdioma.Items.Count) {
                    cbIdioma.SelectedIndex = selectedIndex;
                }
            } finally {
                actualizandoIdioma = false;
            }

            var _resourceManager = new ResourceManager("ProyectoTC2023.LoginForm", typeof(LoginForm).Assembly);
            this.Text = _resourceManager.GetString("LoginForm");
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
        }
        public Idiomas miIdioma = new Idiomas();
        private bool formLoaded;
        private bool actualizandoIdioma;

        private void cbIdioma_SelectedIndexChanged(object sender, EventArgs e) {
            if (!formLoaded || actualizandoIdioma) {
                return;
            }

            int selectedIndex = cbIdioma.SelectedIndex;

            if (Enum.IsDefined(typeof(Idiomas), selectedIndex)) {
                miIdioma = (Idiomas)selectedIndex;
                // Aquí puedes realizar alguna acción con el idioma seleccionado.
                // Por ejemplo, imprimir el idioma seleccionado:
                mensajeria.mostrarMensaje("Idioma seleccionado: " + miIdioma);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e) {
            actualizarIdioma();

            if (cbIdioma.SelectedIndex < 0) {
                cbIdioma.SelectedIndex = 0; // Selecciona el primer idioma (Español) por defecto
            }

            formLoaded = true;
        }
    }
    public enum Idiomas {
        Español,
        Ingles
    }
}
