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
using CUL.Métodos;
using Servicios.Interfaces;
using CUL.Entidades;
using Servicios.Idioma;

namespace ProyectoTC2023 {
    public partial class FrmBR : Form, IObserver {
        ManejaBR manejaBR = new ManejaBR();
        Mensajeria mensajeria = new Mensajeria();
        BackupRestore backupRestore = new BackupRestore();
        public FrmBR() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }

        private void button1_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK) {
                string filePath = backupRestore.Backup(dialog.SelectedPath);
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

                foreach (Form form in Application.OpenForms.Cast<Form>().ToList()) {
                    if (form is FormMain || form is LoginForm) { }
                        else form.Close();
                }
            }
        }

        private void FrmBR_Load(object sender, EventArgs e) {

        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmBR", typeof(FrmBR), codigoIdioma);

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
        }
    }
}
