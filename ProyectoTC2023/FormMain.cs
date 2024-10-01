﻿using System;
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
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            invocarForm(frmUsuarios);
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
            invocarForm(frmVentas);
        }

        private void tmiFacturar_Click(object sender, EventArgs e) {
            FrmFacturas frmFacturas = new FrmFacturas();
            invocarForm(frmFacturas);
        }

        private void tmiDespachar_Click(object sender, EventArgs e) {
            FrmDespacho frmDespacho = new FrmDespacho(); 
            invocarForm(frmDespacho);
        }

        private void FormMain_Load(object sender, EventArgs e) {
            foreach (Control control in this.Controls) {
                if (control is MdiClient mdiClient) {
                    mdiClient.BackColor = Color.LightBlue; // Set your desired color here
                }
            }
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPerfiles frmPerfiles = new FrmPerfiles();
            invocarForm(frmPerfiles);
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

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmBitacora frmBitacora = new FrmBitacora();
            invocarForm(frmBitacora);
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmReportes frm = new FrmReportes();
            invocarForm(frm);
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmBR frm = new FrmBR();
            invocarForm(frm);
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
    }
}
