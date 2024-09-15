using BLL.Metodos;
using CUL.Entidades;
using Servicios.Interfaces;
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
    public partial class FrmBitacora : Form, IObserver {
        BitacoraBLL manejaBitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        public FrmBitacora() {
            InitializeComponent();
        }

        private void btnLookBit_Click(object sender, EventArgs e) {
            dgvBitacora.DataSource = null;

            Dictionary<string, string> parameters = new Dictionary<string, string> {
                { "@usuario", cbNomUsuBit.Text },
                { "@modulo", cbModuloBit.Text },
                { "@criticidad", cbCriticidadBit.Text },
                { "@FromDate", dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss") },
                { "@ToDate", dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            DataTable dataTable = manejaBitacora.lookupBitacoraParametros(parameters);

            dgvBitacora.DataSource = dataTable;
        }

        private void btnAplicar_Click(object sender, EventArgs e) {
            if (cbTipoBit.SelectedIndex != -1) {
                if (cbTipoBit.Text == "Cambios")
                    settearSegunTipo(true);
                else
                    settearSegunTipo(false);
            } else
                mensajeria.mostrarMensaje("Se debe seleccionar un tipo de bitácora");
        }
        private void settearSegunTipo(Boolean variable) {
            // cbModuloBit.Visible = !variable;
            dgvBitacora.DataSource = null;
            btnRollback.Visible = variable;
            if (!variable) {
                DataTable dataTable = manejaBitacora.traerTodaBitacoraEventos();

                dgvBitacora.DataSource = dataTable;

                dgvBitacora.CurrentCell = null;

                dgvBitacora.Columns["Fecha"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            } else {
                dgvBitacora.DataSource = null;
            }
        }

        public void actualizarIdioma() {
            
        }

        private void FrmBitacora_Load(object sender, EventArgs e) {
            settearSegunTipo(false);
            cbNomUsuBit.DataSource = resultadosDb.traerTodosUsuarios();
            cbNomUsuBit.DisplayMember = "nomUsu";
            Array enums = Enum.GetValues(typeof(Modulo));
            foreach (Modulo modulo in enums) {
                cbModuloBit.Items.Add(modulo.ToString());
            }
            cbNomUsuBit.SelectedIndex = 0;
            Array enumsCrit = Enum.GetValues(typeof(Criticidad));
            foreach (Criticidad criticidad in enumsCrit) {
                cbCriticidadBit.Items.Add(criticidad.ToString());
            }
        }

        private void dgvBitacora_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }

        private void dgvBitacora_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0 && dgvBitacora.Columns[e.ColumnIndex].Name == "Nombre de Usuario") {
                txtNombreBit.Clear();
                txtApellidoBit.Clear();
                // Get the username from the clicked cell
                string username = dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Fetch and display the name and surname
                mostrarDetallesUsuario(username);
            }
        }

        private void mostrarDetallesUsuario(string username) {
            Usuario usuario = manejaBitacora.lookupUsuario(username);
            txtNombreBit.Text = usuario.nombre;
            txtApellidoBit.Text = usuario.apellido;
        }
    }
}
