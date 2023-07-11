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
    public partial class FrmUsuarios : Form {
        ValidarCampos validar = new ValidarCampos();
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        Mensajeria mensajeria = new Mensajeria();
        ManejaPermisos manejaPerfil = new ManejaPermisos();
        Usuario seleccionado;
        Usuario temp;
        public FrmUsuarios() {
            InitializeComponent();
            cbUsuarios.DataSource = resultadosDb.traerTodosUsuarios();
            cbUsuarios.DisplayMember = "nomUsu";
            cbFamilias.DataSource = manejaPerfil.GetAllFamilias();
            cbFamilias.DisplayMember = "nombre";
            cbPatentes.DataSource = manejaPerfil.GetAllPatentes();
            cbPatentes.DisplayMember = "nombre";
        }
        void llenarTreeView(TreeNode padre, Componente c) {
            TreeNode hijo = new TreeNode(c.nombre);
            hijo.Tag = c;
            padre.Nodes.Add(hijo);

            foreach (var item in c.hijos) {
                llenarTreeView(hijo, item);
            }
        }

        void mostrarPermisos(Usuario u) {
            tvPerfil.Nodes.Clear();
            TreeNode root = new TreeNode(u.nomUsu);
            foreach (var item in u.permisos) {
                llenarTreeView(root, item);
            }
            tvPerfil.Nodes.Add(root);
            tvPerfil.ExpandAll();
        }


        private void btnCambiar_Click(object sender, EventArgs e) {
            string passActual = txtPassActual.Text;
            string passNueva = txtPassNueva.Text;
            string mensaje;
            if (SingletonSesion.getInstance.estaLogged) {
                if (validar.validarNoNuloNoVacio(passActual, passNueva)) {
                    mensaje = resultadosDb.cambioContraseña(passActual, passNueva);
                    mensajeria.mostrarMensaje(mensaje);
                    if(mensaje == "Contraseña Equivocada") {
                        txtPassNueva.Clear();
                        txtPassActual.Clear();
                    }
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                SingletonSesion.getInstance.logOut();
                mensajeria.mostrarMensaje("Logout exitoso");
                Close();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e) {
            grpbLogout.Visible = false;
            if (SingletonSesion.getInstance.estaLogged) {
                grpbLogout.Visible = true;
            }
        }

        private void grpbLogout_Enter(object sender, EventArgs e) {
            btnLogout_Click(sender, e);
        }

        private void btnConfigurar_Click(object sender, EventArgs e) {
            seleccionado = (Usuario)cbUsuarios.SelectedItem;

            temp = new Usuario();
            temp.nomUsu = seleccionado.nomUsu;
            manejaPerfil.FillUserComponents(temp);
            mostrarPermisos(temp);
        }

        private void btnAddPatente_Click(object sender, EventArgs e) {
            if (temp != null) {
                var patente = (Permiso)cbPatentes.SelectedItem;
                if (patente != null) {
                    var esta = false;
                    foreach (var item in temp.permisos) {
                        if (manejaPerfil.Existe(item, patente.id)) {
                            esta = true;
                            break;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la patente indicada");
                    else {
                        {
                            temp.permisos.Add(patente);
                            mostrarPermisos(temp);
                        }
                    }
                }
            } else
                MessageBox.Show("Seleccione un usuario");
        }

        private void btnAgregarFamilia_Click(object sender, EventArgs e) {
            if (temp != null) {
                var flia = (Familia)cbFamilias.SelectedItem;
                if (flia != null) {
                    var esta = false;
                    //verifico que ya no tenga el permiso. TODO: Esto debe ser parte de otra capa.
                    foreach (var item in temp.permisos) {
                        if (manejaPerfil.Existe(item, flia.id)) {
                            esta = true;
                        }
                    }
                    if (esta)
                        MessageBox.Show("El usuario ya tiene la familia indicada");
                    else {
                        manejaPerfil.FillFamilyComponents(flia);
                        temp.permisos.Add(flia);
                        mostrarPermisos(temp);
                    }
                }
            } else
                MessageBox.Show("Seleccione un usuario");
        }

        private void btnGuardarFamilia_Click(object sender, EventArgs e) {
            try {
                resultadosDb.GuardarPermisos(temp);
                MessageBox.Show("Usuario guardado correctamente");
            } catch (Exception) {
                MessageBox.Show("Error al guardar el usuario");
            }
        }
    }
}
