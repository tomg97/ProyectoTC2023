using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using Servicios.Idioma;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmPerfiles : Form, IObserver {
        PerfilBLL manejaPerfil = new PerfilBLL();
        Familia seleccion;

        public FrmPerfiles() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }

        private void llenarPatentesFamilias() {
            cbPatentes.DataSource = manejaPerfil.GetAllPatentes();
            cbPatentes.DisplayMember = "nombre";
            cbFamilias.DataSource = manejaPerfil.GetAllFamilias();
            cbFamilias.DisplayMember = "nombre";
        }

        private void FrmPerfiles_Load(object sender, EventArgs e) {
            llenarPatentesFamilias();
        }

        void mostrarFamilia(bool init) {
            if (seleccion == null) return;

            if (init) {
                manejaPerfil.FillFamilyComponents(seleccion);
            }

            tvConfigFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(seleccion.nombre) {
                Tag = seleccion
            };
            tvConfigFamilia.Nodes.Add(root);

            foreach (var item in seleccion.hijos) {
                mostrarEnTreeView(root, item);
            }

            tvConfigFamilia.ExpandAll();
        }

        void mostrarEnTreeView(TreeNode tn, Componente c) {
            TreeNode n = new TreeNode(c.nombre) {
                Tag = c
            };
            tn.Nodes.Add(n);

            if (c.hijos != null) {
                foreach (var item in c.hijos) {
                    mostrarEnTreeView(n, item);
                }
            }
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e) {
            if (seleccion == null) {
                MessageBox.Show("Primero debe configurar un perfil", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Permiso patente = (Permiso)cbPatentes.SelectedItem;
            if (patente == null) return;

            if (manejaPerfil.Existe(seleccion, patente.id)) {
                MessageBox.Show("El perfil ya contiene el permiso indicado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                seleccion.agregar(patente);
                mostrarFamilia(false);
                MessageBox.Show("Permiso agregado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e) {
            Familia tmp = (Familia)this.cbFamilias.SelectedItem;
            if (tmp == null) {
                MessageBox.Show("Seleccione un perfil", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            seleccion = new Familia();
            seleccion.id = tmp.id;
            seleccion.nombre = tmp.nombre;

            mostrarFamilia(true);
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e) {
            if (seleccion == null) {
                MessageBox.Show("Primero debe configurar un perfil", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Familia familia = (Familia)cbFamilias.SelectedItem;
            if (familia == null) return;

            if (familia.id == seleccion.id) {
                MessageBox.Show("No puede agregar un perfil a sí mismo", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (manejaPerfil.Existe(seleccion, familia.id)) {
                MessageBox.Show("El perfil ya contiene la familia indicada", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else {
                manejaPerfil.FillFamilyComponents(familia);
                seleccion.agregar(familia);
                mostrarFamilia(false);
                MessageBox.Show("Perfil agregado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardarNuevaF_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtNombreFamilia.Text)) {
                MessageBox.Show("Ingrese un nombre para el perfil", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                Familia nuevoPerfil = new Familia();
                nuevoPerfil.nombre = txtNombreFamilia.Text.Trim();
                manejaPerfil.GuardarComponente(nuevoPerfil, true);
                MessageBox.Show("Perfil creado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombreFamilia.Clear();
                llenarPatentesFamilias();
            } catch (Exception ex) {
                MessageBox.Show($"Error al crear perfil: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e) {
            if (seleccion == null) {
                MessageBox.Show("No hay un perfil configurado para guardar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                manejaPerfil.GuardarFamilia(seleccion);
                MessageBox.Show("Perfil guardado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show($"Error al guardar perfil: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmPerfiles", typeof(FrmPerfiles));

            foreach (Control control in this.Controls) {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmPerfiles", typeof(FrmPerfiles).Assembly);
            this.Text = _resourceManager.GetString("FrmPerfiles");
        }
    }
}
