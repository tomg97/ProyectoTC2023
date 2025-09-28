using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using Servicios.Idioma;
using Servicios.Interfaces;
using Servicios.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmBitacora : Form, IObserver {
        BitacoraBLL manejaBitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        string tipoOperacion;
        string lenguajeActual;
        public FrmBitacora() {
            InitializeComponent();
            dtpDesde.ValueChanged += DtpDesde_ValueChanged;
            dtpHasta.ValueChanged += DtpHasta_ValueChanged;

            dtpDesde.MaxDate = dtpHasta.Value;
            dtpHasta.MinDate = dtpDesde.Value;

            tipoOperacion = "Eventos";

            LenguajeActual.Attach(this);
            actualizarIdioma();

            /* para entrega 1*/
            lblTipoBit.Visible = false;
            cbTipoBit.Visible = false;
            btnAplicar.Visible = false;
        }

        private void DtpHasta_ValueChanged(object sender, EventArgs e) {
            dtpDesde.MaxDate = dtpHasta.Value;
        }

        private void DtpDesde_ValueChanged(object sender, EventArgs e) {
            dtpHasta.MinDate = dtpDesde.Value;            
        }

        private void btnLookBit_Click(object sender, EventArgs e) {
            dgvBitacora.DataSource = null;

            Dictionary<string, string> parameters;

            DataTable dataTable;

            if (tipoOperacion == "Eventos" || tipoOperacion == "Events") {
                parameters = new Dictionary<string, string> {
                    { "@usuario", cbNomUsuBit.Text },
                    { "@modulo", cbModuloBit.Text },
                    { "@criticidad", cbCriticidadBit.Text },
                    { "@FromDate", dtpDesde.Value.ToString("yyyy-MM-dd") },
                    { "@ToDate", dtpHasta.Value.AddDays(1).ToString("yyyy-MM-dd") }
                };
                dataTable = manejaBitacora.lookupBitacoraEventosParametros(parameters);
            } else {
                var activo = cbCriticidadBit.Text == "Si" ? "1" : "0";
                parameters = new Dictionary<string, string> {
                    { "@usuMod", cbNomUsuBit.Text },
                    { "@tipoOp", cbModuloBit.Text },
                    { "@activo", activo },
                    { "@marcaProducto", cbMarcaProductoBit.Text },
                    { "@FromDate", dtpDesde.Value.ToString("yyyy-MM-dd") },
                    { "@ToDate", dtpHasta.Value.ToString("yyyy-MM-dd") }
                };
                dataTable = manejaBitacora.lookupBitacoraCambiosParametros(parameters);
            }

            dgvBitacora.DataSource = dataTable;
        }

        private void btnAplicar_Click(object sender, EventArgs e) {
            if (cbTipoBit.SelectedIndex != -1) {
                if (cbTipoBit.Text == "Cambios")
                    tipoOperacion = "Cambios";
                else
                    tipoOperacion = "Eventos";
            } else
                mensajeria.mostrarMensaje("Se debe seleccionar un tipo de bitácora");

            settearSegunTipo();
        }
        private void settearSegunTipo() {
            // cbModuloBit.Visible = !variable;
            dgvBitacora.DataSource = null;
            DataTable dataTable;
            if (tipoOperacion == "Eventos" || tipoOperacion == "Events") {
                prepararParaEventos();
                dataTable = manejaBitacora.traerTodaBitacoraEventos();
            } else {
                prepararParaCambios();
                dataTable = manejaBitacora.traerTodaBitacoraCambios();
            }

            dgvBitacora.DataSource = dataTable;

            dgvBitacora.CurrentCell = null;

            dgvBitacora.ReadOnly = true;

            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            string date = codigoIdioma == "es-AR" ? "Fecha" : "Date";

            dgvBitacora.Columns[date].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmBitacora", typeof(FrmBitacora), codigoIdioma);

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
        }

        private void FrmBitacora_Load(object sender, EventArgs e) {
            settearSegunTipo();
        }

        private void prepararParaEventos() {
            cbMarcaProductoBit.Visible = false;
            lblMarcaProdBit.Visible = false;

            cbNomUsuBit.DataSource = resultadosDb.traerTodosUsuarios();
            cbNomUsuBit.DisplayMember = "nomUsu";
            cbNomUsuBit.SelectedIndex = 0;

            lblMBit.Text = lenguajeActual == "es-AR" ? "Modulo" : "Module";
            Array enums = Enum.GetValues(typeof(Modulo));
            cbModuloBit.Items.Clear();
            foreach (Modulo modulo in enums) {
                cbModuloBit.Items.Add(modulo.ToString());
            }
            lblCABit.Text = lenguajeActual == "es-AR" ? "Criticidad" : "Severity";
            Array enumsCrit = Enum.GetValues(typeof(Criticidad));
            cbCriticidadBit.Items.Clear();
            foreach (Criticidad criticidad in enumsCrit) {
                cbCriticidadBit.Items.Add(criticidad.ToString());
            }
        }
        private void prepararParaCambios() {
            cbMarcaProductoBit.Visible = false;
            lblMarcaProdBit.Visible = false;
            btnRollback.Visible = true;

            cbNomUsuBit.DataSource = resultadosDb.traerTodosUsuarios();
            cbNomUsuBit.DisplayMember = "nomUsu";
            cbNomUsuBit.SelectedIndex = 0;

            lblMBit.Text = "Tipo Operacion";
            Array enums = Enum.GetValues(typeof(MensajeCambio.TipoOperacion));
            cbModuloBit.Items.Clear();
            foreach (MensajeCambio.TipoOperacion tipoOp in enums) {
                cbModuloBit.Items.Add(tipoOp.ToString());
            }

            lblCABit.Text = "Activo";
            cbCriticidadBit.Items.Clear();
            cbCriticidadBit.Items.Add("Si");
            cbCriticidadBit.Items.Add("No");

            Array enumMarca = Enum.GetValues(typeof(MarcaProducto));
            cbMarcaProductoBit.Visible = true;
            cbMarcaProductoBit.Items.Clear();
            lblMarcaProdBit.Visible = true;
            foreach (MarcaProducto marca in enumMarca) {
                cbMarcaProductoBit.Items.Add(marca.ToString());
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
            } else if (e.RowIndex >= 0 && dgvBitacora.Columns[e.ColumnIndex].Name == "Contenido") {
                mensajeria.mostrarMensaje(dgvBitacora.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void mostrarDetallesUsuario(string username) {
            Usuario usuario = manejaBitacora.lookupUsuario(username);
            txtNombreBit.Text = usuario.nombre;
            txtApellidoBit.Text = usuario.apellido;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            cbNomUsuBit.SelectedIndex = 0;
            cbModuloBit.SelectedIndex = -1;
            cbCriticidadBit.SelectedIndex = -1;
            dtpDesde.Value = DateTime.Now.AddDays(-1);
            dtpHasta.Value = DateTime.Now;
            dgvBitacora.DataSource = null;
            txtNombreBit.Clear();
            txtApellidoBit.Clear();
        }

        private void btnImprimir_Click(object sender, EventArgs e) {
            // Create a SaveFileDialog to allow the user to choose the storage location and name
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF Document";

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog.FileName;

                // Create a new PDF document
                Document document = new Document();

                try {
                    // Create a new PDF writer
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                    // Open the PDF document
                    document.Open();

                    // Create a new PDF table with the same number of columns as the DataGridView
                    PdfPTable table = new PdfPTable(dgvBitacora.Columns.Count);

                    // Add the column headers to the table
                    foreach (DataGridViewColumn column in dgvBitacora.Columns) {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        table.AddCell(cell);
                    }

                    // Add the data rows to the table
                    foreach (DataGridViewRow row in dgvBitacora.Rows) {
                        foreach (DataGridViewCell cell in row.Cells) {
                            table.AddCell(cell.Value != null ? cell.Value.ToString() : "");
                        }
                    }

                    // Add the table to the document
                    document.Add(table);
                } catch (Exception ex) {
                    // Handle any exceptions that occur during PDF generation
                    MessageBox.Show("Error al generar PDF: " + ex.Message);
                } finally {
                    // Close the PDF document
                    mensajeria.mostrarMensaje("El documento fue creado exitosamente en " + filePath);
                    document.Close();
                }
            }
        }

        private void btnRollback_Click(object sender, EventArgs e) {
            if (dgvBitacora.SelectedRows.Count == 1) {
                DataRow dataRow = ((DataRowView)dgvBitacora.SelectedRows[0].DataBoundItem).Row;
                if (dataRow != null) {
                    Producto producto = new Producto();
                    producto.id = dataRow["Id Producto"].ToString();
                    producto.cantidad = (int)dataRow["Cantidad"];
                    producto.marcaProducto = dataRow["Marca Producto"].ToString();
                    producto.nombreProducto = dataRow["Nombre Producto"].ToString();
                    producto.precio = dataRow["Precio"].ToString();
                    manejaBitacora.rollbackCambio(producto, producto.id);
                }
                
            }
        }
    }
}