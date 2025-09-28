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
using Servicios.Interfaces;
using CUL.Métodos;
using Servicios.Idioma;
using Servicios.Metodos;

namespace ProyectoTC2023 {
    public partial class FormMain : Form, IObserver {
        Mensajeria mensajeria = new Mensajeria();
        public FormMain() {
            InitializeComponent();
            ManejaPermisos maneja = new ManejaPermisos();
            maneja.FillUserComponents(SingletonSesion.getInstance.getUsuarioActual());
            validarPermisos();
            LenguajeActual.Attach(this);
            actualizarIdioma();
            ManejaDV manejaDV = new ManejaDV();
            if (!manejaDV.loginStep()) {
                if (SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_backup)) {
                    invocarForm(new FormDV());
                } else {
                    MessageBox.Show("Se ha detectado un error de arranque. Por favor contacte al administrador.");
                    Application.Exit();
                }
            }
        }
        void validarPermisos() {
            if (SingletonSesion.getInstance.estaLogged) {
                usuariosToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_usuarios);
                bitacoraToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_bitacora);
                idiomasToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_idiomas);
                perfilesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_perfiles);
                backupToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_backup);
                comprasToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.compras);
                productosToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_productos);
                proveedoresToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_proveedores);
                clientesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_clientes);
                reportesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.reportes);
                usuarioToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.usuario);
                tmiFacturar.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_facturar);
                tmiSeleccionYCarrito.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_select);
                tmiDespachar.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_despachar);
            }
        }
        void invocarForm(Form form) {
            form.MdiParent = this;
            form.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            AdminUsuarios adminUsuarios = new AdminUsuarios();
            invocarForm(adminUsuarios);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e) {
            invocarForm(new FrmUsuarios());
        }

        private void tsmiLogin_Click(object sender, EventArgs e) {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
            
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e) {
            
        }

        private void tmiSeleccionYCarrito_Click(object sender, EventArgs e) {
            invocarForm(new FrmVentas());
        }

        private void tmiFacturar_Click(object sender, EventArgs e) {
            invocarForm(new FrmFacturas());
        }

        private void tmiDespachar_Click(object sender, EventArgs e) {
            invocarForm(new FrmDespacho());
        }

        private void FormMain_Load(object sender, EventArgs e) {
            foreach (Control control in this.Controls) {
                if (control is MdiClient mdiClient) {
                    mdiClient.BackColor = Color.LightBlue;
                }
            }
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            invocarForm(new FrmPerfiles());
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FormMain", typeof(FormMain), codigoIdioma);

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e) {
            invocarForm(new FrmBitacora());
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e) {
            invocarForm(new FrmReportes());
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e) {
            invocarForm(new FrmBR());
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmMaestro frm = new FrmMaestro("Producto");
            invocarForm(frm);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmMaestro frm = new FrmMaestro("Cliente");
            invocarForm(frm);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmMaestro frm = new FrmMaestro("Proveedor");
            invocarForm(frm);
        }

        private void tsmUsuMaestro_Click(object sender, EventArgs e) {
            FrmMaestro frm = new FrmMaestro("Usuarios");
            invocarForm(frm);
        }

        private void tsmiArchivo_Click(object sender, EventArgs e) {

        }
    }
}
