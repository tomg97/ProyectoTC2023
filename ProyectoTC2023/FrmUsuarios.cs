using BLL.Metodos;
using CUL.Entidades;
using CUL.Métodos;
using Servicios.Idioma;
using Servicios.Interfaces;
using Servicios.Metodos;
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

namespace ProyectoTC2023
{
    public partial class FrmUsuarios : Form, IObserver
    {
        ValidarCampos validar = new ValidarCampos();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        Mensajeria mensajeria = new Mensajeria();
        PerfilBLL manejaPerfil = new PerfilBLL();
        Usuario seleccionado;
        Usuario temp;

        public FrmUsuarios()
        {
            InitializeComponent();
            LenguajeActual.Attach(this);
            cargarDatos();
            actualizarIdioma();
        }

        private void cargarDatos()
        {
            cbUsuarios.DataSource = resultadosDb.traerTodosUsuarios();
            cbUsuarios.DisplayMember = "nomUsu";
            cbFamilias.DataSource = manejaPerfil.GetAllFamilias();
            cbFamilias.DisplayMember = "nombre";
            cbPatentes.DataSource = manejaPerfil.GetAllPatentes();
            cbPatentes.DisplayMember = "nombre";
        }

        void llenarTreeView(TreeNode padre, Componente c)
        {
            TreeNode hijo = new TreeNode(c.nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.hijos)
            {
                llenarTreeView(hijo, item);
            }
        }

        void mostrarPermisos(Usuario u)
        {
            tvPerfil.Nodes.Clear();
            TreeNode root = new TreeNode(u.nomUsu);
            foreach (var item in u.permisos)
            {
                llenarTreeView(root, item);
            }
            tvPerfil.Nodes.Add(root);
            tvPerfil.ExpandAll();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            string passActual = txtPassActual.Text;
            string passNueva = txtPassNueva.Text;
            string mensaje;

            if (SingletonSesion.getInstance.estaLogged)
            {
                if (validar.validarNoNuloNoVacio(passActual, passNueva))
                {
                    mensaje = resultadosDb.cambioContraseña(passActual, passNueva);
                    mensajeria.mostrarMensaje(mensaje);
                    if (mensaje == "Contraseña Equivocada")
                    {
                        txtPassNueva.Clear();
                        txtPassActual.Clear();
                    }
                }
            }
            else
            {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (SingletonSesion.getInstance.estaLogged)
            {
                SingletonSesion.getInstance.logOut();
                mensajeria.mostrarMensaje("Logout exitoso");
                Close();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            grpbLogout.Visible = false;
            if (SingletonSesion.getInstance.estaLogged)
            {
                grpbLogout.Visible = true;
            }
        }

        private void grpbLogout_Enter(object sender, EventArgs e)
        {
            btnLogout_Click(sender, e);
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            seleccionado = (Usuario)cbUsuarios.SelectedItem;

            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            temp = new Usuario();
            temp.nomUsu = seleccionado.nomUsu;
            manejaPerfil.FillUserComponents(temp);
            mostrarPermisos(temp);
        }

        private void btnAddPatente_Click(object sender, EventArgs e)
        {
            if (temp == null)
            {
                MessageBox.Show("Seleccione un usuario primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Permiso patente = (Permiso)cbPatentes.SelectedItem;
            if (patente == null)
            {
                MessageBox.Show("Seleccione un permiso", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existe = temp.permisos.Any(p => p.contieneId(patente.id));

            if (existe)
            {
                MessageBox.Show("El usuario ya tiene el permiso indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                temp.permisos.Add(patente);
                mostrarPermisos(temp);
                MessageBox.Show("Permiso agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            if (temp == null)
            {
                MessageBox.Show("Seleccione un usuario primero", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Familia familia = (Familia)cbFamilias.SelectedItem;
            if (familia == null)
            {
                MessageBox.Show("Seleccione un perfil", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool existe = temp.permisos.Any(p => p.contieneId(familia.id));

            if (existe)
            {
                MessageBox.Show("El usuario ya tiene el perfil indicado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                manejaPerfil.FillFamilyComponents(familia);
                temp.permisos.Add(familia);
                mostrarPermisos(temp);
                MessageBox.Show("Perfil agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e)
        {
            if (temp == null)
            {
                MessageBox.Show("No hay cambios para guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                resultadosDb.guardarPermisos(temp);
                MessageBox.Show("Permisos de usuario guardados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void actualizarIdioma()
        {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();
            Traductor traductor = new Traductor("ProyectoTC2023.FrmUsuarios", typeof(FrmUsuarios));

            foreach (Control control in this.Controls)
            {
                traductor.ActualizarIdioma(control);
            }
            var _resourceManager = new ResourceManager("ProyectoTC2023.FrmUsuarios", typeof(FrmUsuarios).Assembly);
            this.Text = _resourceManager.GetString("FrmUsuarios");
        }
    }
}
