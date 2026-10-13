using BLL.Metodos;
using CUL.Entidades;
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
    public partial class FrmControlCambios : Form {
        BitacoraBLL bitacoraBLL;
        DataTable cambios;
        ManejaMaestro usuarioSvc = new ManejaMaestro();
        public FrmControlCambios() {
            InitializeComponent();
            bitacoraBLL = new BitacoraBLL();
            cambios = bitacoraBLL.traerTodaBitacoraCambios();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataRow dr in cambios.Rows) // search whole table
            {
                dr["fecha"] = new DateTime(long.Parse(dr["fecha"].ToString()));
            }

            DataGridViewButtonColumn restoreButton = new DataGridViewButtonColumn();
            restoreButton.Name = "restaurar";
            restoreButton.Text = "restaurar";
            restoreButton.UseColumnTextForButtonValue = true;

            int columnIndex = 0;
            if (dataGridView1.Columns["restaurar"] == null) {
                dataGridView1.Columns.Insert(columnIndex, restoreButton);
            }

            actualizarIdioma();
        }

        private void btnBuscarCambios_Click(object sender, EventArgs e) {
            StringBuilder sb = new StringBuilder();
            StringBuilder builder = new StringBuilder();
            if (txtNomUsu.Text.Length > 0) builder.Append($@"nomUsu = {txtNomUsu.Text}");
            if (txtDNI.Text.Length > 0) builder.Append($@"{(txtNomUsu.Text.Length > 0 ? " AND " : " ")} dni LIKE  '{txtDNI.Text}*' ");
            if (txtNombre.Text.Length > 0) builder.Append($@"{(txtDNI.Text.Length > 0 ? " AND " : " ")} nombre LIKE  '{txtNombre.Text}*' ");
            if (txtApellido.Text.Length > 0) builder.Append($@"{(txtNombre.Text.Length > 0 ? " AND " : " ")} apellido LIKE  '{txtApellido.Text}*' ");

            DataRow[] rows = cambios.Select(builder.ToString());
            dataGridView1.DataSource = (rows.Length > 0) ? rows.CopyToDataTable() : null;

        }

        private void FrmControlCambios_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = cambios;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == dataGridView1.Columns["restaurar"].Index && DialogResult.OK == MessageBox.Show("Esta seguro que desea continuar", "", MessageBoxButtons.OKCancel)) {
                //TODO restaurar usuario
                //userService.UpdateUser();
                string userID = ((string)dataGridView1.SelectedRows[0].Cells["nomUsu"]?.Value);
                Usuario user = new Usuario();

                user.nombre = (string)dataGridView1.SelectedRows[0].Cells["nombre"]?.Value;
                user.nomUsu = (string)dataGridView1.SelectedRows[0].Cells["nomUsu"]?.Value;
                user.email = (string)dataGridView1.SelectedRows[0].Cells["email"]?.Value;
                user.apellido = (string)dataGridView1.SelectedRows[0].Cells["apellido"]?.Value;
                user.telefono = (string)dataGridView1.SelectedRows[0].Cells["telefono"]?.Value;
                user.dni= (string)dataGridView1.SelectedRows[0].Cells["dni"]?.Value;

                usuarioSvc.modificaUsuario(user, userID);

            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmControlCambios", typeof(FrmControlCambios), codigoIdioma);
            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmControlCambios", typeof(FrmControlCambios).Assembly);
            this.Text = _resourceManager.GetString("FrmControlCambios");
        }
    }
}
