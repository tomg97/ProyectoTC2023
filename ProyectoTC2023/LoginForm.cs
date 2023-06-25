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

namespace ProyectoTC2023 {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            ValidarCampos validarCampos = new ValidarCampos();
            string nomUsu = txtUsu.Text;
            string pass = txtPass.Text;
            if (validarCampos.validarNoNuloNoVacio(nomUsu, pass)) {
                Usuario usuario = new Usuario() { nomUsu = nomUsu, pass = pass };
                ManejaUsuarios stepAuth = new ManejaUsuarios();
                string message = stepAuth.loginProcedimiento(usuario);
                MessageBox.Show(message);
                if(message == "Exito") {
                    FormMain formMain = new FormMain();
                    formMain.Show();
                    this.Hide();
                }
            } else {
                MessageBox.Show("Se debe proporcionar nomre de usuario y/o contraseña");
            }
        }

        private void btnSinSesion_Click(object sender, EventArgs e) {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Hide();
        }
    }
}
