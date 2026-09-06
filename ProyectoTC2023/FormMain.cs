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
        PerfilBLL perfilBLL = new PerfilBLL();

        public FormMain() {
            InitializeComponent();
            cargarPermisosUsuario();
            validarPermisos();
            LenguajeActual.Attach(this);
            actualizarIdioma();
            validarIntegridadBaseDatos();
        }

        private void cargarPermisosUsuario() {
            try {
                Usuario usuarioActual = SingletonSesion.getInstance.getUsuarioActual();
                if (usuarioActual != null) {
                    perfilBLL.FillUserComponents(usuarioActual);
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al cargar permisos del usuario: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validarIntegridadBaseDatos() {
            try {
                ManejaDV manejaDV = new ManejaDV();
                if (!manejaDV.loginStep()) {
                    if (SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_backup)) {
                        invocarForm(new FormDV());
                    } else {
                        MessageBox.Show("Se ha detectado un error de arranque. Por favor contacte al administrador.",
                            "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al validar integridad de la base de datos: {ex.Message}",
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        void validarPermisos() {
            if (SingletonSesion.getInstance.estaLogged) {
                // Menú Administración
                usuariosToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_usuarios);
                bitacoraToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_bitacora);
                idiomasToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_idiomas);
                perfilesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_perfiles);
                backupToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.admin_backup);

                // Menú Compras
                comprasToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.compras);

                // Menú Maestros
                productosToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_productos);
                proveedoresToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_proveedores);
                clientesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.maestros_clientes);

                // Menú Reportes
                reportesToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.reportes);

                // Menú Usuario
                usuarioToolStripMenuItem.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.usuario);

                // Menú Ventas
                tmiFacturar.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_facturar);
                tmiSeleccionYCarrito.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_select);
                tmiDespachar.Visible = SingletonSesion.getInstance.tienePermiso(TipoPermiso.ventas_despachar);
            } else {
                ocultarTodosLosMenus();
            }
        }

        private void ocultarTodosLosMenus() {
            // Ocultar todos los menús si el usuario no está logueado
            usuariosToolStripMenuItem.Visible = false;
            bitacoraToolStripMenuItem.Visible = false;
            idiomasToolStripMenuItem.Visible = false;
            perfilesToolStripMenuItem.Visible = false;
            backupToolStripMenuItem.Visible = false;
            comprasToolStripMenuItem.Visible = false;
            productosToolStripMenuItem.Visible = false;
            proveedoresToolStripMenuItem.Visible = false;
            clientesToolStripMenuItem.Visible = false;
            reportesToolStripMenuItem.Visible = false;
            usuarioToolStripMenuItem.Visible = false;
            tmiFacturar.Visible = false;
            tmiSeleccionYCarrito.Visible = false;
            tmiDespachar.Visible = false;
        }
        void invocarForm(Form form) {
            form.MdiParent = this;
            form.Show();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            foreach (Control control in this.Controls) {
                if (control is MdiClient mdiClient) {
                    mdiClient.BackColor = Color.LightBlue;
                }
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FormMain", typeof(FormMain));

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
        }

        #region Event Handlers - Menú Archivo

        private void tsmiArchivo_Click(object sender, EventArgs e) {
            // Evento del menú archivo (si se necesita)
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        #endregion

        #region Event Handlers - Menú Administración

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.admin_usuarios)) {
                invocarForm(new AdminUsuarios());
            }
        }

        private void bitacoraToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.admin_bitacora)) {
                invocarForm(new FrmBitacora());
            }
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.admin_perfiles)) {
                invocarForm(new FrmPerfiles());
            }
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.admin_backup)) {
                invocarForm(new FrmBR());
            }
        }

        #endregion

        #region Event Handlers - Menú Usuario

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.usuario)) {
                invocarForm(new FrmUsuarios());
            }
        }

        private void tsmiLogin_Click(object sender, EventArgs e) {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        #endregion

        #region Event Handlers - Menú Maestros

        private void productosToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.maestros_productos)) {
                FrmMaestro frm = new FrmMaestro("Producto");
                invocarForm(frm);
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.maestros_clientes)) {
                FrmMaestro frm = new FrmMaestro("Cliente");
                invocarForm(frm);
            }
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.maestros_proveedores)) {
                FrmMaestro frm = new FrmMaestro("Proveedor");
                invocarForm(frm);
            }
        }

        private void tsmUsuMaestro_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.admin_usuarios)) {
                FrmMaestro frm = new FrmMaestro("Usuarios");
                invocarForm(frm);
            }
        }

        #endregion

        #region Event Handlers - Menú Ventas

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e) {
            // Evento del menú ventas (si se necesita)
        }

        private void tmiSeleccionYCarrito_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.ventas_select)) {
                invocarForm(new FrmVentas());
            }
        }

        private void tmiFacturar_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.ventas_facturar)) {
                invocarForm(new FrmFacturas());
            }
        }

        private void tmiDespachar_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.ventas_despachar)) {
                invocarForm(new FrmDespacho());
            }
        }

        #endregion

        #region Event Handlers - Menú Compras

        private void tsmiRegistroProveedor_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.compras)) {
                FrmRegistroProveedor frm = new FrmRegistroProveedor("Registro");
                invocarForm(frm);
            }
        }

        private void tsmiSolicitudCotizacion_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.compras)) {
                FrmCotizacion frmCotizacion = new FrmCotizacion();
                invocarForm(frmCotizacion);
            }
        }

        private void tsmiOrdenCompra_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.compras)) {
                FrmOrdenCompra frmOrdenCompra = new FrmOrdenCompra();
                invocarForm(frmOrdenCompra);
            }
        }

        private void tsmiPagarOrdenCompra_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.compras)) {
                FrmPagoProveedor frmPagoProveedor = new FrmPagoProveedor();
                invocarForm(frmPagoProveedor);
            }
        }

        private void tsmiRecepcionProductos_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.compras)) {
                FrmRecepcion frmRecepcion = new FrmRecepcion();
                invocarForm(frmRecepcion);
            }
        }

        #endregion

        #region Event Handlers - Menú Reportes

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (validarPermiso(TipoPermiso.reportes)) {
                invocarForm(new FrmReportes());
            }
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Valida si el usuario tiene el permiso especificado y muestra mensaje si no lo tiene
        /// </summary>
        private bool validarPermiso(TipoPermiso permiso) {
            if (!SingletonSesion.getInstance.estaLogged) {
                MessageBox.Show("Debe iniciar sesión para acceder a esta funcionalidad",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!SingletonSesion.getInstance.tienePermiso(permiso)) {
                MessageBox.Show("No tiene permisos suficientes para acceder a esta funcionalidad",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion
    }
}
