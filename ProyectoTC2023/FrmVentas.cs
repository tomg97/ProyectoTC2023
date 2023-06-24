using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmVentas : Form {
        public FrmVentas() {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dataSetProductos.Producto' table. You can move, or remove it, as needed.
            this.productoTableAdapter.Fill(this.dataSetProductos.Producto);

        }
    }
}
