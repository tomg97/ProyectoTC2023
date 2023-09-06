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

namespace ProyectoTC2023 {
    public partial class FormMain : Form, IObserver {
        public FormMain() {
            InitializeComponent();
            ManejaPermisos maneja = new ManejaPermisos();
            maneja.FillUserComponents(SingletonSesion.getInstance.getUsuarioActual());
            validarPermisos();
            LenguajeActual.Attach(this);
            actualizarIdioma();
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

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPerfiles frmPerfiles = new FrmPerfiles();
            frmPerfiles.MdiParent = this;
            frmPerfiles.Show();
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            usuariosToolStripMenuItem.Text = Lang.usuariosToolStripMenuItem;
            bitacoraToolStripMenuItem.Text = Lang.bitacoraToolStripMenuItem;
            idiomasToolStripMenuItem.Text = Lang.idiomasToolStripMenuItem;
            perfilesToolStripMenuItem.Text = Lang.perfilesToolStripMenuItem;
            comprasToolStripMenuItem.Text = Lang.comprasToolStripMenuItem;
            productosToolStripMenuItem.Text = Lang.productosToolStripMenuItem;
            proveedoresToolStripMenuItem.Text = Lang.proveedoresToolStripMenuItem;
            clientesToolStripMenuItem.Text = Lang.clientesToolStripMenuItem;
            reportesToolStripMenuItem.Text = Lang.reportesToolStripMenuItem;
            usuarioToolStripMenuItem.Text = Lang.usuarioToolStripMenuItem;
            tmiFacturar.Text = Lang.tmiFacturar;
            tmiSeleccionYCarrito.Text = Lang.tmiSeleccionYCarrito;
            tmiDespachar.Text = Lang.tmiDespachar;
            tsmiArchivo.Text = Lang.tsmiArchivo;
            ayudaToolStripMenuItem.Text = Lang.ayudaToolStripMenuItem;
            ventasToolStripMenuItem.Text = Lang.ventasToolStripMenuItem;
            maestrosToolStripMenuItem.Text = Lang.maestrosToolStripMenuItem;
        }
    }
}
