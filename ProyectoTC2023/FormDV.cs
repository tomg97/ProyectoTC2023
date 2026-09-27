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
    }
}
