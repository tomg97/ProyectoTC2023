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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmPerfiles : Form, IObserver {
        ManejaPermisos manejaPermisos = new ManejaPermisos();
        Familia seleccion;
        public FrmPerfiles() {
            InitializeComponent();
            LenguajeActual.Attach(this);
        }
        private void llenarPatentesFamilias() {
            cbPatentes.DataSource = manejaPermisos.GetAllPatentes();
            cbFamilias.DisplayMember = "nombre";
            cbFamilias.DataSource = manejaPermisos.GetAllFamilias();
            cbPatentes.DisplayMember = "nombre";
        }

        private void FrmPerfiles_Load(object sender, EventArgs e) {
            llenarPatentesFamilias();
        }
        void mostrarFamilia(bool init) {
            if (seleccion == null) return;
            List<Componente> flia = null;
            if (init) {
                //traigo los hijos de la base
                flia = manejaPermisos.GetAll("=" + seleccion.id);
                foreach (var i in flia)
                    seleccion.agregar(i);
            } else {
                flia = seleccion.hijos;
            }
            tvConfigFamilia.Nodes.Clear();
            TreeNode root = new TreeNode(seleccion.nombre);
            root.Tag = seleccion;
            tvConfigFamilia.Nodes.Add(root);
            foreach (var item in flia) {
                mostrarEnTreeView(root, item);
            }
            tvConfigFamilia.ExpandAll();
        }
        void mostrarEnTreeView(TreeNode tn, Componente c) {
            TreeNode n = new TreeNode(c.nombre);
            tn.Tag = c;
            tn.Nodes.Add(n);
            if (c.hijos != null)
                foreach (var item in c.hijos) {
                    mostrarEnTreeView(n, item);
                }
        }

        private void btnAgregarPatente_Click(object sender, EventArgs e) {
            if (seleccion != null) {
                var patente = (Permiso)cbPatentes.SelectedItem;
                if (patente != null) {
                    var esta = manejaPermisos.Existe(seleccion, patente.id);
                    if (esta)
                        MessageBox.Show("ya exsite la patente indicada");
                    else {
                        seleccion.agregar(patente);
                        mostrarFamilia(false);
                    }
                }
            }
        }

        private void btnConfigurar_Click(object sender, EventArgs e) {
            var tmp = (Familia)this.cbFamilias.SelectedItem;
            seleccion = new Familia();
            seleccion.id = tmp.id;
            seleccion.nombre = tmp.nombre;

            mostrarFamilia(true);
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e) {
            if (seleccion != null) {
                var familia = (Familia)cbFamilias.SelectedItem;
                if (familia != null) {

                    var esta = manejaPermisos.Existe(seleccion, familia.id);
                    if (esta)
                        MessageBox.Show("ya exsite la familia indicada");
                    else {
                        manejaPermisos.FillFamilyComponents(familia);
                        seleccion.agregar(familia);
                        mostrarFamilia(false);
                    }
                }
            }
        }

        private void btnGuardarNuevaF_Click(object sender, EventArgs e) {
            Familia p = new Familia() {
                nombre = txtNombreFamilia.Text
            };
            manejaPermisos.GuardarComponente(p, true);
            llenarPatentesFamilias();
            MessageBox.Show("Familia guardada correctamente");
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e) {
            try {
                manejaPermisos.GuardarFamilia(seleccion);
                MessageBox.Show("Familia guardada correctamente");
            } catch (Exception) {
                MessageBox.Show("Error al guardar la familia");
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            gbPatentes.Text = Lang.gbPatentes;
            lblTodasPatentes.Text = Lang.lblTodasPatentes;
            btnAgregarPatente.Text = Lang.btnAgregarPatente;
            gbFamilias.Text = Lang.gbFamilias;
            lblFamilias.Text = Lang.lblFamilias;
            btnConfigurar.Text = Lang.btnConfigurar;
            btnAgregarFamilia.Text = Lang.btnAgregarFamilia;
            gbNuevaFamilia.Text = Lang.gbNuevaFamilia;
            lblNombre.Text = Lang.lblNombre;
            btnGuardarNuevaF.Text = Lang.btnGuardarNuevaF;
            btnGuardarFamilia2.Text = Lang.btnGuardarFamilia2;
            gbConfigFamilia.Text = Lang.gbConfigFamilia;
        }
    }
}
