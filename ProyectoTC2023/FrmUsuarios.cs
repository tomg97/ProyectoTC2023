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
    public partial class FrmUsuarios : Form {
        public FrmUsuarios() {
            InitializeComponent();
        }
        ValidarCampos validar = new ValidarCampos();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();

        private void btnCambiar_Click(object sender, EventArgs e) {
            string passActual = txtPassActual.Text;
            string passNueva = txtPassNueva.Text;
            string mensaje;
            if (SingletonSesion.getInstance.estaLogged) {
                if (validar.validarNoNuloNoVacio(passActual, passNueva)) {
                    mensaje = resultadosDb.cambioContraseña(passActual, passNueva);
                    MessageBox.Show(mensaje);
                    if(mensaje == "Contraseña Equivocada") {
                        txtPassNueva.Clear();
                        txtPassActual.Clear();
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                SingletonSesion.getInstance.logOut();
                MessageBox.Show("Logout exitoso");
                Close();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e) {
            grpbLogout.Visible = false;
            if (SingletonSesion.getInstance.estaLogged) {
                grpbLogout.Visible = true;
            }
        }
    }
}
