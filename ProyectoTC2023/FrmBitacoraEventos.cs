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
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmBitacoraEventos : Form, IObserver {
        BitacoraBLL manejaBitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        string tipoOperacion;
        string lenguajeActual;
        public FrmBitacoraEventos() {
            InitializeComponent();
            dtpDesde.ValueChanged += DtpDesde_ValueChanged;
            dtpHasta.ValueChanged += DtpHasta_ValueChanged;

            dtpDesde.MaxDate = dtpHasta.Value;
            dtpHasta.MinDate = dtpDesde.Value;

            LenguajeActual.Attach(this);
            actualizarIdioma();
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

            var selectedItem = cbMarcaProductoBit.SelectedItem;
            var enumContenido = selectedItem.GetType().GetProperty("Value").GetValue(selectedItem, null).ToString();
            parameters = new Dictionary<string, string> {
                { "@usuario", cbNomUsuBit.Text },
                { "@modulo", cbModuloBit.Text },
                { "@criticidad", cbCriticidadBit.Text },
                { "@FromDate", dtpDesde.Value.ToString("yyyy-MM-dd") },
                { "@ToDate", dtpHasta.Value.AddDays(1).ToString("yyyy-MM-dd") },
                { "@evento", enumContenido }
               
            dataTable = manejaBitacora.lookupBitacoraEventosParametros(parameters);

            dgvBitacora.DataSource = dataTable;
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            lenguajeActual = codigoIdioma;
            Traductor traductor = new Traductor("ProyectoTC2023.FrmBitacora", typeof(FrmBitacoraEventos), codigoIdioma);

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmBitacora", typeof(FrmBitacoraEventos).Assembly);
            this.Text = _resourceManager.GetString("FrmBitacora");
        }

        private void FrmBitacora_Load(object sender, EventArgs e) {
            prepararParaEventos();
        }

        private void prepararParaEventos() {
            lblEvento.Text = lenguajeActual == "es-AR" ? "Evento" : "Event";
            lblEvento.Visible = true;

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
            var enumEventos = Enum.GetValues(typeof(EventoEnum))
                .Cast<EventoEnum>()
                .Select(texto => new {
                    Value = texto,
                    Display = texto.GetDescripcionTraducida()
                }).OrderBy(e => e.Display)
                .ToList();
            cbMarcaProductoBit.Items.Clear();
            cbMarcaProductoBit.DataSource = enumEventos;
            cbMarcaProductoBit.DisplayMember = "Display";
            cbMarcaProductoBit.ValueMember = "Value";
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
            cbMarcaProductoBit.SelectedIndex = -1;
            dtpDesde.Value = DateTime.Now.AddDays(-1);
            dtpHasta.Value = DateTime.Now;
            dgvBitacora.DataSource = null;
            txtNombreBit.Clear();
            txtApellidoBit.Clear();
            prepararParaEventos();
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
                            if (cell.Value != null && cell.OwningColumn.Name == "Módulo" || cell.OwningColumn.Name == "Module") {
                                // Convert the module number to its name  
                                if (int.TryParse(cell.Value.ToString(), out int moduloValue)) {
                                    Modulo modulo = (Modulo)moduloValue;
                                    table.AddCell(modulo.ToString());
                                } else {
                                    table.AddCell(cell.Value.ToString());
                                }
                            } else {
                                table.AddCell(cell.Value != null ? cell.Value.ToString() : "");
                            }
                        }
                    }

                    // Add the table to the document  
                    document.Add(table);

                    // Close the PDF document  
                    mensajeria.mostrarMensaje("El documento fue creado exitosamente en " + filePath);
                } catch (Exception ex) {
                    // Handle any exceptions that occur during PDF generation  
                    MessageBox.Show("Error al generar PDF: " + ex.Message);
                } finally {
                    document.Close();
                }
            }
        }
    }
}