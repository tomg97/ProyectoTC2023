using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using Microsoft.VisualBasic;
using Servicios.Idioma;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoTC2023 {
    public partial class FrmCotizacion : Form, Servicios.Interfaces.IObserver {
        ValidarCampos validarCampos = new ValidarCampos();
        Mensajeria mensajeria = new Mensajeria();
        ProductoBLL productoBLL = new ProductoBLL();
        List<Producto> solicitudCotizacionAux = new List<Producto>();
        string lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();
        SolicitudCotizacion solicitudCotizacion = new SolicitudCotizacion();
        SolicitudCotizacionBLL solicitudCotizacionBLL = new SolicitudCotizacionBLL();   
        public FrmCotizacion() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmCotizacion", typeof(FrmCotizacion));

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmCotizacion", typeof(FrmCotizacion).Assembly);
            this.Text = _resourceManager.GetString("FrmCotizacion");
        }

        private void FrmCotizacion_Load(object sender, EventArgs e) {
            setDataGridViewExistencias();
            setComboProveedores();
            btnRemover.Hide();
            btnRemover.Enabled = false;
            btnAgregar.Show();
            btnAgregar.Enabled = true;
        }

        private void setComboProveedores() {
            ProveedorBLL proveedorBLL = new ProveedorBLL();
            cmbProveedores.DataSource = proveedorBLL.getProveedores();
            cmbProveedores.SelectedIndex = -1;
        }

        private void setDataGridViewExistencias() {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productoBLL.getProductosBajoStock();
        }

        private void btnAgregar_Click(object sender, EventArgs e) {
            try {
                Producto p = dgvProductos.SelectedRows[0].DataBoundItem as Producto;
                if (solicitudCotizacionAux.Exists(x => x.id == p.id)) throw new Exception("El producto ya se encuentra en la solicitud de cotización.");
                string mensajeCantidad = lenguajeActual == "es-AR" ? "Ingrese la cantidad deseada" : "Input the desired amount";
                if (!int.TryParse(Interaction.InputBox(mensajeCantidad, "", "10"), out int cantidad)) throw new Exception("Cantidad inválida.");
                if (cantidad <= 5) throw new Exception("La cantidad debe ser mayor a 5.");

                p.cantidad = cantidad;
                solicitudCotizacionAux.Add(p);
                actualizarDgvSolicitud();
            } catch (Exception ex) {
                mensajeria.mostrarMensaje(ex.Message);
            }
        }

        private void actualizarDgvSolicitud() {
            dgvSolicitud.DataSource = null;
            dgvSolicitud.DataSource = solicitudCotizacionAux;
            foreach (DataGridViewColumn columna in dgvSolicitud.Columns) {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (dgvSolicitud.Rows.Count > 0) {
                    Producto p = dgvSolicitud.SelectedRows[0].DataBoundItem as Producto;
                    solicitudCotizacionAux.Remove(p);
                    actualizarDgvSolicitud();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) {
            try {
                if (dgvSolicitud.Rows.Count > 0) {
                    Producto p = dgvSolicitud.SelectedRows[0].DataBoundItem as Producto;
                    string mensajeCantidad = lenguajeActual == "es-AR" ? "Ingrese la cantidad deseada" : "Input the desired amount";
                    if (!int.TryParse(Interaction.InputBox(mensajeCantidad, "", $"{p.cantidad}"), out int cantidad)) throw new Exception("Cantidad inválida.");
                    if (cantidad < 5) throw new Exception("La cantidad debe ser mayor a 5.");
                    p.cantidad = cantidad;
                    actualizarDgvSolicitud();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            try {
                dgvSolicitud.DataSource = null;
                solicitudCotizacionAux.Clear();
                solicitudCotizacion = null;
                cmbProveedores.Enabled = true;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAñadirProveedor_Click(object sender, EventArgs e) {
            if (cmbProveedores.SelectedItem == null) {
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Debe seleccionar un proveedor." : "Please select a provider.");
                return;
            }
            solicitudCotizacion.proveedor = cmbProveedores.SelectedItem as Proveedor;
            cmbProveedores.Enabled = false;
            btnAgregar.Enabled = false;
            btnAgregar.Hide();
            btnRemover.Show();
            btnRemover.Enabled = true;
        }

        private void btnRemover_Click(object sender, EventArgs e) {
            solicitudCotizacion.proveedor = null;
            cmbProveedores.Enabled = true;
            btnAgregar.Enabled = true;
            btnAgregar.Show();
            btnRemover.Hide();
            btnRemover.Enabled = false;
        }

        private void btnFinalizar_Click(object sender, EventArgs e) {
            if (solicitudCotizacion.proveedor == null) {
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Debe seleccionar un proveedor." : "Please select a provider.");
                return;
            } else if (solicitudCotizacionAux.Count == 0) {
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Debe agregar al menos un producto a la solicitud de cotización." : "You must add at least one product to the quote request.");
                return;
            }
            solicitudCotizacion.productos = solicitudCotizacionAux;
            solicitudCotizacion.fecha = DateTime.Now;
            if (solicitudCotizacion.proveedor.telefono == "0") {
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "El proveedor seleccionado no cuenta con todos sus datos. Por favor, actualice su información a continuación." : "The selected provider's registration is not complete. Please update their information on the following screen.");
                FrmRegistroProveedor frmRegistroProveedor = new FrmRegistroProveedor(solicitudCotizacion.proveedor, "Completar Registro");
                ProveedorBLL proveedorBLL = new ProveedorBLL();
                solicitudCotizacion.proveedor = proveedorBLL.getProveedor(solicitudCotizacion.proveedor.CUIT);
            }
            solicitudCotizacionBLL.guardarSolicitudCotizacion(solicitudCotizacion);
            mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Solicitud de cotización guardada con éxito." : "Quote request saved successfully.");
        }

        private void btnPreRegistroProveedor_Click(object sender, EventArgs e) {
            try {
                FrmRegistroProveedor frmRegistroProveedor = new FrmRegistroProveedor("Pre Registro");
                frmRegistroProveedor.ShowDialog();
                setComboProveedores();
            } catch (Exception ex) {
                mensajeria.mostrarMensaje(ex.Message);
            }
        }
    }
}
