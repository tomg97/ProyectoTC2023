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
        ProductoBLL productoBLL = new ProductoBLL();
        Mensajeria mensajeria = new Mensajeria();
        string lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();
        public FrmRecepcion() {
            InitializeComponent();
        }
        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmRecepcion", typeof(FrmCotizacion), codigoIdioma);

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
                    orden.estado = "Recibido";
                    compraBLL.modificarOrdenCompra(orden);
                    foreach (Producto p in orden.productos) {
                        Producto existente = productoBLL.getProducto(p.id);
                        existente.cantidad += p.cantidad;
                        productoBLL.modificaProducto(existente, existente.id);
                    }
                }
                recargarDgvPagas();
                mensajeria.mostrarMensaje("Orden de compra recibida y productos actualizados correctamente.");  
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
            }
        }

        private void FrmRecepcion_Load(object sender, EventArgs e) {
            actualizarIdioma();
            recargarDgvPagas();

            //dgvProductos.Hide();
        }

        private void recargarDgvPagas() {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = compraBLL.traerOrdenesCompraPagas();
            foreach (DataGridViewColumn column in dgvOrdenesCompra.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            // Ocultar la columna correspondiente a la propiedad "dvh"
            if (dgvOrdenesCompra.Columns.Contains("dvh")) {
                dgvOrdenesCompra.Columns["dvh"].Visible = false;
            }
        }
        private void recargarDgvRechazadas() {
            dgvOrdenesCompra.DataSource = null;
            dgvOrdenesCompra.DataSource = compraBLL.traerOrdenesCompraRechazadas();
            foreach (DataGridViewColumn column in dgvOrdenesCompra.Columns) {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            btnComentar.Hide();
            //btnRechazar.Hide();
        }


        private void dgvOrdenesCompra_CellClick(object sender, DataGridViewCellEventArgs e) {
            //dgvProductos.DataSource = null;
            if (e.RowIndex >= 0) {
                OrdenCompra orden = dgvOrdenesCompra.SelectedRows[e.RowIndex].DataBoundItem as OrdenCompra;
                //dgvProductos.DataSource = orden.productos;

            }
        }

        private void btnComentar_Click(object sender, EventArgs e) {
            try {
                if (dgvOrdenesCompra.SelectedRows.Count == 0) {
                    mensajeria.mostrarMensaje("Seleccione una orden de compra.");
                    return;
                }

                OrdenCompra orden = dgvOrdenesCompra.SelectedRows[0].DataBoundItem as OrdenCompra;
                if (orden == null) {
                    mensajeria.mostrarMensaje("No se pudo obtener la orden seleccionada.");
                    return;
                }

                string comentario = Interaction.InputBox(
                    "Ingrese un comentario para la orden de compra seleccionada:",
                    "Comentar orden de compra",
                    orden.comentario ?? string.Empty
                );

                // Si cancela o deja vacío, no actualiza
                if (string.IsNullOrWhiteSpace(comentario)) {
                    return;
                }

                orden.comentario = comentario.Trim();
                compraBLL.modificarOrdenCompra(orden);

                mensajeria.mostrarMensaje("Comentario guardado correctamente.");
                recargarDgvPagas();
            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error: " + ex.Message);
            }
        }
    }
}
