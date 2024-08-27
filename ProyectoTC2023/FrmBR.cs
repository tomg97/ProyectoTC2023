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
using BLL.Metodos;
using System.IO;

namespace ProyectoTC2023 {
    public partial class FrmBR : Form {
        ManejaBR manejaBR = new ManejaBR();
        Mensajeria mensajeria = new Mensajeria();
        BackupRestore backupRestore = new BackupRestore();
        public FrmBR() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = backupRestore.Backup(saveFileDialog.SelectedPath);
                string resultado = manejaBR.realizarBackup(filePath);
                if (resultado == "Backup exitoso.") {
                    mensajeria.mostrarMensaje(resultado + " Guardado en la ubicación " + filePath);
                } else {
                    mensajeria.mostrarMensaje(resultado);
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e) {
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string filePath = backupRestore.Restore(openFileDialog.FileName);
                string resultado = manejaBR.realizarRestore(filePath);
                if (resultado == "Restore exitoso.") {
                    mensajeria.mostrarMensaje(resultado + " Importado de la ubicación " + filePath);
                } else {
                    mensajeria.mostrarMensaje(resultado);
                }
            }
        }

        private void FrmBR_Load(object sender, EventArgs e) {

        }
    }
}
