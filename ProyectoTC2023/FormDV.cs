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
        ManejaDV manejaDV = new ManejaDV();
        string resultado;
        public FormDV() {
            InitializeComponent();
            mensajeria.mostrarMensaje("Se ha detectado una inconsistencia en la base de datos. Por favor realice un restore.");
        }

        private void btnRealizarRestore_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = new BackupRestore().Restore(openFileDialog.FileName);
                string resultadoDb = new ManejaBR().realizarRestore(filePath);
                if (resultadoDb == "Restore exitoso.") {
                    mensajeria.mostrarMensaje(resultadoDb + " Importado de la ubicación " + filePath);
                } else {
                    mensajeria.mostrarMensaje(resultadoDb);
                }
            }
            resultado = "Restore exitoso";
            btnRecalcularDV.Visible = true;
        }

        private void btnRecalcularDV_Click(object sender, EventArgs e) {            
            if (resultado == "Restore exitoso")
                manejaDV.almacenarDV();
                resultado = "Recalculo exitoso";
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            if (resultado == "Recalculo exitoso") {
                mensajeria.mostrarMensaje("Se ha realizado Restore y Recalculo de DV exitosamente. Se reiniciará la aplicación.");
                Application.Restart();
            } else if (resultado == "Restore exitoso") {
                mensajeria.mostrarMensaje("No se ha realizado recalculo de DV. Por favor, realice uno.");
            } else {
                DialogResult result = MessageBox.Show("No se ha realizado Restore. Desea salir de todos modos?", "Confirmacion", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) {
                    Application.Restart();
                } else {
                    return;
                }
            }
        }
    }
}
