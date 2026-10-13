using BLL.Metodos;
using CUL.Entidades;
using Servicios.Metodos;
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

namespace ProyectoTC2023 {
    public partial class FormDV : Form {
        Mensajeria mensajeria = new Mensajeria();
        private ManejaDV manejaDv;
        private List<string> resultados;
        public FormDV() {
            InitializeComponent();
            mensajeria.mostrarMensaje("Se ha detectado una inconsistencia en la base de datos. Por favor realice un restore.");

            manejaDv = new ManejaDV();

            dgvDVRestore.AllowUserToAddRows = false;
            dgvDVRestore.AllowUserToDeleteRows = false;
            dgvDVRestore.AllowUserToResizeRows = false;
            dgvDVRestore.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvDVRestore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDVRestore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDVRestore.ReadOnly = true;
            dgvDVRestore.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDVRestore.RowHeadersVisible = false;

            resultados = manejaDv.check();
            dgvDVRestore.DataSource = resultados.Select(x => new { error = x }).ToList();
            if (dgvDVRestore.CurrentCell != null) dgvDVRestore.CurrentCell.Selected = false;

            actualizarIdioma();
        }

        private void btnRecalcularDV_Click(object sender, EventArgs e) {
            try {
                manejaDv.recalcularDV();
                resultados = manejaDv.check();
                dgvDVRestore.DataSource = resultados.Select(x => new { error = x }).ToList();
                if (dgvDVRestore.CurrentCell != null) dgvDVRestore.CurrentCell.Selected = false;
                mensajeria.mostrarMensaje("Se han recalculado los DV's correctamente.");
                this.Close();

            } catch (Exception ex) {
                mensajeria.mostrarMensaje("Error al recalcular los DV's: " + ex.Message);
            }
        }

        private void FormDV_Load(object sender, EventArgs e) {

        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FormDV", typeof(FormDV), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FormDV", typeof(FormDV).Assembly);
            this.Text = _resourceManager.GetString("FormDV");
        }
    }
}
