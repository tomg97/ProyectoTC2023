using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using DAL.Metodos;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Asn1.X500;
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

namespace ProyectoTC2023 {
    public partial class FrmRecepcion : Form {
        OrdenCompraBLL compraBLL = new OrdenCompraBLL();
        ManejaMaestro maestroBLL = new ManejaMaestro("Producto");
        ProductoBLL productoBLL = new ProductoBLL();
        Mensajeria mensajeria = new Mensajeria();
        string lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();
        public FrmRecepcion() {
            InitializeComponent();
        }
        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmRecepcion", typeof(FrmCotizacion));

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmRecepcion", typeof(FrmRecepcion).Assembly);
            this.Text = _resourceManager.GetString("FrmRecepcion");
        }

        private void btnRecibido_Click(object sender, EventArgs e) {
            try {
                if(dgvOrdenesCompra.Rows.Count > 0) {
                    OrdenCompra orden = dgvOrdenesCompra.SelectedRows[0].DataBoundItem as OrdenCompra;
                    orden.fechaRecepcion = DateTime.Now;
                    orden.estado = "Recibido";
                    compraBLL.modificarOrdenCompra(orden);
                    foreach (Producto p in orden.productos) {
                        Producto existente = productoBLL.getProducto(p.id);
                        existente.cantidad += p.cantidad;
                        maestroBLL.modificaProducto(existente, existente.id);
                    }
                }
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
            }
        }

        private void FrmRecepcion_Load(object sender, EventArgs e) {
            actualizarIdioma();
            recargarDgvPendientes();
            btnRecibido.Hide();
            dgvProductos.Hide();
        }

        private void recargarDgvPendientes() {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = compraBLL.traerOrdenesCompraPendientes();
            foreach (DataGridViewColumn column in dgvOrdenesCompra.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            // Ocultar la columna correspondiente a la propiedad "fechaRecepcion"
            if (dgvOrdenesCompra.Columns.Contains("fechaRecepcion") && dgvOrdenesCompra.Columns.Contains("Motivo")) {
                dgvOrdenesCompra.Columns["fechaRecepcion"].Visible = false;
                dgvOrdenesCompra.Columns["Motivo"].Visible = false; 
            }
        }
        private void recargarDgvRechazadas() {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = compraBLL.traerOrdenesCompraRechazadas();
            foreach (DataGridViewColumn column in dgvOrdenesCompra.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            btnAceptar.Hide();
            btnRechazar.Hide();
        }

        private void btnRechazadas_Click(object sender, EventArgs e) {
            recargarDgvRechazadas();
        }

        private void btnPendientes_Click(object sender, EventArgs e) {
            recargarDgvPendientes();
        }

        private void btnAceptar_Click(object sender, EventArgs e) {
            var result = MessageBox.Show(
                        lenguajeActual == "es-AR"
                            ? "¿Desea confirmar la recepción de productos?"
                            : "Do you want to confirm the reception of the products?",
                        lenguajeActual == "es-AR"
                            ? "Confirmar recepción"
                            : "Confirm reception",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
            if (result == DialogResult.Yes) {
                btnRecibido.Show();
                btnRechazar.Hide();
            }
        }

        private void btnRechazar_Click(object sender, EventArgs e) {
            var motivo = "";
            var result = MessageBox.Show(
                        lenguajeActual == "es-AR"
                            ? "¿Desea confirmar el rechazo de la recepción de productos?"
                            : "Do you want to confirm the rejection of the purchase order?",
                        lenguajeActual == "es-AR"
                            ? "Confirmar rechazo"
                            : "Confirm rejection",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
            if (result == DialogResult.Yes) {
                btnAceptar.Hide();
                motivo = Interaction.InputBox(
                    lenguajeActual == "es-AR"
                        ? "Ingrese el motivo del rechazo"
                        : "Enter the reason for rejection",
                    lenguajeActual == "es-AR"
                        ? "Motivo de rechazo"
                        : "Rejection reason",
                    ""
                );
                compraBLL.rechazarOrdenCompra(dgvOrdenesCompra.SelectedRows[0].DataBoundItem as OrdenCompra, motivo);
            }            
        }

        private void dgvOrdenesCompra_CellClick(object sender, DataGridViewCellEventArgs e) {
            dgvProductos.DataSource = null;
            if (e.RowIndex >= 0) {
                OrdenCompra orden = dgvOrdenesCompra.SelectedRows[e.RowIndex].DataBoundItem as OrdenCompra;
                dgvProductos.DataSource = orden.productos;

            }
        }
    }
}
