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
    public partial class FrmBR : Form {
        public FrmBR() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog.FileName;
                string resultado = manejaBR.realizarBackup(filePath);
                if (resultado == "Backup exitoso.") {
                    mensajeria.mostrarMensaje(resultado + "Guardado en la ubicación " + filePath);
                } else {
                    mensajeria.mostrarMensaje(resultado);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e) {
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = openFileDialog.FileName;
                string resultado = manejaBR.realizarRestore(filePath);
                if (resultado == "Restore exitoso.") {
                    mensajeria.mostrarMensaje(resultado + "Importado de la ubicación " + filePath);
                } else {
                    mensajeria.mostrarMensaje(resultado);
                }
            }
        }

        private void FrmBR_Load(object sender, EventArgs e) {

        }
    }
}
