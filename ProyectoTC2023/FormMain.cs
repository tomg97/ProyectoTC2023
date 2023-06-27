using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Metodos;
using System.Windows.Forms;
using CUL.Entidades;
using DAL.Metodos;

namespace ProyectoTC2023 {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            adminUsuarios.MdiParent = this;
            adminUsuarios.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }

        private void tsmiLogin_Click(object sender, EventArgs e) {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
            
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e) {
            
        }

        private void tmiSeleccionYCarrito_Click(object sender, EventArgs e) {
            FrmVentas frmVentas = new FrmVentas();
            frmVentas.MdiParent = this;
            frmVentas.Show();
        }

        private void tmiFacturar_Click(object sender, EventArgs e) {
            FrmFacturas frmFacturas = new FrmFacturas();
            frmFacturas.MdiParent = this;
            frmFacturas.Show();
        }

        private void tmiDespachar_Click(object sender, EventArgs e) {
            FrmDespacho frmDespacho = new FrmDespacho();
            frmDespacho.MdiParent = this;
            frmDespacho.Show();
        }

        private void FormMain_Load(object sender, EventArgs e) {

        }
    }
}
