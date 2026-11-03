using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using Servicios.Idioma;
using CUL.Entidades;
using BLL.Metodos;

namespace ProyectoTC2023 {
    public partial class FrmPagoProveedor : Form {
        OrdenCompraBLL ordenCompraBLL = new OrdenCompraBLL();
        public FrmPagoProveedor() {
            InitializeComponent();
            actualizarIdioma();
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmPagoProveedor", typeof(FrmPagoProveedor), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmPagoProveedor", typeof(FrmPagoProveedor).Assembly);
            this.Text = _resourceManager.GetString("FrmPagoProveedor");
        }

        private void btnPago_Click(object sender, EventArgs e) {
            if (cbOrdenesCompra.SelectedIndex != -1) {
                OrdenCompra orden = cbOrdenesCompra.SelectedItem as OrdenCompra;
                orden.estado = "Pagado";
                ordenCompraBLL.modificarOrdenCompra(orden);
                MessageBox.Show("El pago de la orden de compra se ha registrado correctamente.");
                cargarComboOrdenes();
            } else {
                MessageBox.Show("Seleccione una orden de compra para realizar el pago.");
            }
        }

        private void FrmPagoProveedor_Load(object sender, EventArgs e) {
            cargarComboOrdenes();
        }
        private void cargarComboOrdenes() {
            cbOrdenesCompra.DataSource = null;
            cbOrdenesCompra.DataSource = ordenCompraBLL.traerOrdenesCompraPendientes();
            cbOrdenesCompra.DisplayMember = "id"; // Asegura que se muestre solo el Id
            //cbOrdenesCompra.SelectedIndex = 0;
        }

        private void cbOrdenesCompra_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbOrdenesCompra.SelectedIndex != -1) {
                OrdenCompra orden = cbOrdenesCompra.SelectedItem as OrdenCompra;
                List<Producto> productos = orden.productos;
                dgvOrdenCompra.DataSource = null;
                dgvOrdenCompra.DataSource = productos;
            }
        }
    }
}
