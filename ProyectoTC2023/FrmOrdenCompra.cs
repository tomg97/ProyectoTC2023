using BLL.Metodos;
using CUL.Entidades;
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
    public partial class FrmOrdenCompra : Form {
        SolicitudCotizacionBLL solicitudCotizacionBLL = new SolicitudCotizacionBLL();
        OrdenCompra orden = new OrdenCompra();
        ProveedorBLL proveedorBLL = new ProveedorBLL(); 
        OrdenCompraBLL ordenCompraBLL = new OrdenCompraBLL();   
        Mensajeria mensajeria = new Mensajeria();
        string lenguajeActual = SingletonSesion.getInstance.getIdiomaActual();
        public FrmOrdenCompra() {
            InitializeComponent();
            btnRegistroProveedor.Hide();
            actualizarIdioma();
        }
        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmOrdenCompra", typeof(FrmOrdenCompra));

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmOrdenCompra", typeof(FrmOrdenCompra).Assembly);
            this.Text = _resourceManager.GetString("FrmOrdenCompra");
        }

        private void FrmOrdenCompra_Load(object sender, EventArgs e) {
            cargarCotizaciones();
        }

        private void cargarCotizaciones() {
            cbCotizaciones.DataSource = null;
            cbCotizaciones.DataSource = solicitudCotizacionBLL.traerTodasSolicitudesCotizacion();
            cbCotizaciones.DisplayMember = "id"; // Asegura que se muestre solo el Id
            cbCotizaciones.SelectedIndex = -1;
        }

        private void cbCotizaciones_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                SolicitudCotizacion solicitud = cbCotizaciones.SelectedItem as SolicitudCotizacion;
                orden.productos.Clear();
                lblMonto.Text = "$0";
                orden.cuitProveedor = solicitud.proveedor.CUIT;
                                
                foreach (Producto p in solicitud.productos) {
                    Random r = new Random();
                    var p_inicial = Int32.Parse(p.precio);
                    var p_modificado = p_inicial * r.Next(95, 120) / 100; // Simula variación de precios entre 95% y 120%
                    var p_final = p_modificado * p.cantidad;
                    p.precio = p_final.ToString();
                    orden.productos.Add(p);
                }
                refrescarDgv();
                actualizarSubtotal();
                var proveedor = proveedorBLL.getProveedor(orden.cuitProveedor);
                if (!ordenCompraBLL.registroCompleto(proveedor)) {
                    btnRegistroProveedor.Enabled = true;
                    btnRegistroProveedor.Show();
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void actualizarSubtotal() {
            orden.total = "0";
            lblMonto.Text = "$";
            if (orden.productos.Count > 0) {
                foreach (Producto p in orden.productos) {
                    var p_individual = Int32.Parse(p.precio);
                    var total_aux = Int32.Parse(orden.total);
                    orden.total = (total_aux + p_individual).ToString();
                }
            }
            var montoAux = "$" + orden.total;
            lblMonto.Text = montoAux;
        }

        private void refrescarDgv() {
            dgvOrdenCompra.DataSource = null;
            if(orden.productos != null || orden.productos.Count == 0) {
                dgvOrdenCompra.DataSource = orden.productos;
                foreach (DataGridViewColumn co in dgvOrdenCompra.Columns) { co.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e) {
            try {
                if (dgvOrdenCompra.Rows.Count > 1) {
                    Producto p = dgvOrdenCompra.SelectedRows[0].DataBoundItem as Producto;
                    orden.productos.Remove(p);
                    actualizarSubtotal();
                    refrescarDgv();
                } else {
                    var result = MessageBox.Show(
                        lenguajeActual == "es-AR" 
                            ? "¿Desea eliminar la solicitud de cotización completa?" 
                            : "Do you want to delete the entire quotation request?",
                        lenguajeActual == "es-AR" 
                            ? "Confirmar eliminación" 
                            : "Confirm deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (result == DialogResult.Yes) {
                        SolicitudCotizacion solicitud = cbCotizaciones.SelectedItem as SolicitudCotizacion;
                        if (solicitud != null) {
                            solicitudCotizacionBLL.eliminarSolicitudCotizacion(solicitud.id);
                            cargarCotizaciones();
                            orden.productos.Clear();
                            refrescarDgv();
                            actualizarSubtotal();
                        }
                    }
                    // Si el usuario rechaza, no se realiza ninguna acción adicional.
                }
            } catch(Exception ex) {
                mensajeria.mostrarMensaje($"{ex.Message}");
            }
        }

        private void btnRegistroProveedor_Click(object sender, EventArgs e) {
            var proveedor = proveedorBLL.getProveedor(orden.cuitProveedor);
            if (proveedor != null && ordenCompraBLL.estaRegistradoProveedor(orden.cuitProveedor)) {
                if (ordenCompraBLL.registroCompleto(proveedor)) {
                    mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "El proveedor seleccionado ya se encuentra registrado. Prosiga con la generacion de la orden." : "The selected provider's registration is already complete. Please move on with the order creation.");
                    btnRegistroProveedor.Enabled = false;
                    btnRegistroProveedor.Hide();    
                } else {
                    FrmRegistroProveedor frmRegistroProveedor = new FrmRegistroProveedor(proveedor, "Completar Registro");
                    frmRegistroProveedor.ShowDialog();
                    mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Registro de proveedor completado con éxito." : "Provider registration completed successfully.");
                }
            } else {
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "El proveedor seleccionado no se encuentra registrado. Por favor, complete su registro a continuación." : "The selected provider is not registered. Please complete their registration on the following screen.");
                FrmRegistroProveedor frmRegistroProveedor = new FrmRegistroProveedor(proveedor, "Registro");
                frmRegistroProveedor.ShowDialog();
                mensajeria.mostrarMensaje(lenguajeActual == "es-AR" ? "Registro de proveedor completado con éxito." : "Provider registration completed successfully.");
            }
        }

        private void btnGenerarOrden_Click(object sender, EventArgs e) {
            try {
                ordenCompraBLL.generarOrden(orden);
            } catch (ConstraintException ex) {
                var result = MessageBox.Show(
                        lenguajeActual == "es-AR"
                            ? "Ya existe una orden de compra asociada a esta solicitud de cotización. ¿Desea reemplazar la orden existente?"
                            : "There is already a purchase order associated to that quote request. Do you want to replace the existing purchase order?",
                        lenguajeActual == "es-AR"
                            ? "Confirmar reemplazo"
                            : "Confirm replacement",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                if (result == DialogResult.Yes) {
                    SolicitudCotizacion solicitud = cbCotizaciones.SelectedItem as SolicitudCotizacion;
                    if (solicitud != null) {
                        solicitudCotizacionBLL.eliminarSolicitudCotizacion(solicitud.id);
                        cargarCotizaciones();
                        orden.productos.Clear();
                        refrescarDgv();
                        actualizarSubtotal();
                    }
                }
            }
        }
    }
}
