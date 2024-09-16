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
using static ProyectoTC2023.DataSetProductos;
using Microsoft.VisualBasic;

namespace ProyectoTC2023 {
    public partial class FrmMaestro : Form {
        ManejaMaestro manejaMaestro;
        DataTable dt = new DataTable();
        Mensajeria mensajeria = new Mensajeria();
        string tipo;

        Usuario usuarioOgg;
        Cliente clienteOgg;
        Producto productoOgg;
        
        public FrmMaestro(string tipo) {
            InitializeComponent();
            this.tipo = tipo;
            manejaMaestro = new ManejaMaestro(tipo);
            settearSegunTipo();
        }

        private void settearSegunTipo() {
            dgvMaestro.DataSource = null;
            dt = manejaMaestro.pedirYTraerDatos();
            switch (tipo) {
                case "Producto":
                    grpProducto.Visible = true;
                    break;
                case "Usuarios":
                    grpUsuario.Visible = true;
                    break;
                case "Cliente":
                    grpCliente.Visible = true;
                    break;
                case "Proveedor":
                    break;
                default:
                    break;
            }
            dgvMaestro.DataSource = dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void FrmMaestro_Load(object sender, EventArgs e) {

        }

        private void btnAddMaestro_Click(object sender, EventArgs e) {
            DataRow dataRow = dt.NewRow();
            dt.Rows.Add(dataRow);

            int indiceNuevo = dgvMaestro.Rows.Count - 1;
            dgvMaestro.CurrentCell = dgvMaestro.Rows[indiceNuevo].Cells[0];
            dgvMaestro.BeginEdit(true);

            btnConfirm.Visible = true;
            btnModMaestro.Visible = false;
            btnElimMaestro.Visible = false;
            btnAddMaestro.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            DataRow dataRow = dt.Rows[dt.Rows.Count - 1];
            switch (tipo) {
                case "Producto":
                    Producto producto = new Producto {

                        nombreProducto = dataRow["Nombre Producto"].ToString(),
                        marcaProducto = dataRow["Marca Producto"].ToString(),
                        cantidad = Int32.Parse(dataRow["Cantidad"].ToString()),
                        precio = dataRow["Precio"].ToString(),
                        id = dataRow["Id"].ToString()
                    };
                    manejaMaestro.guardarProductoNuevo(producto);
                    break;
                case "Usuarios":
                    Usuario usuario = new Usuario {
                        nomUsu = dataRow["Nombre Usuario"].ToString(),
                        nombre = dataRow["Nombre"].ToString(),
                        apellido = dataRow["Apellido"].ToString(),
                        dni = dataRow["DNI"].ToString(),
                        email = dataRow["Email"].ToString(),
                        telefono = dataRow["Teléfono"].ToString()
                    };
                    string input = Interaction.InputBox("Contraseña?", "Ingrese Contraseña", "1234");
                    usuario.pass = input;
                    manejaMaestro.guardarUsuario(usuario);
                    break;
                case "Cliente":
                    Cliente cliente = new Cliente {
                        nombre = dataRow["Nombre"].ToString(),
                        apellido = dataRow["Apellido"].ToString(),
                        domicilio = dataRow["Domicilio"].ToString(),
                        telefono = dataRow["Teléfono"].ToString(),
                        id = dataRow["Id"].ToString()
                    };
                    manejaMaestro.crearCliente(cliente);
                    break;
                case "Proveedor":
                    break;
            }
            settearSegunTipo();
            resettearBotones();
        }

        private void btnModMaestro_Click(object sender, EventArgs e) {
            if (dgvMaestro.SelectedRows.Count == 1) {
                btnAppMaestro.Visible = true;
                btnCancMaestro.Visible = true;
                btnModMaestro.Visible = false;
                btnElimMaestro.Visible = false;
                btnAddMaestro.Visible = false;
                DataGridViewRow dataRow = dgvMaestro.SelectedRows[0];
            switch (tipo) {
                    case "Producto":
                        Producto productoOg = new Producto {
                            nombreProducto = dataRow.Cells["Nombre Producto"].Value.ToString(),
                            marcaProducto = dataRow.Cells["Marca Producto"].Value.ToString(),
                            cantidad = Int32.Parse(dataRow.Cells["Cantidad"].Value.ToString()),
                            precio = dataRow.Cells["Precio"].Value.ToString(),
                            id = dataRow.Cells["Id"].Value.ToString()
                        };
                        productoOgg = productoOg;
                        txtNomProd.Text = productoOg.nombreProducto;
                        txtMarProd.Text = productoOg.marcaProducto;
                        txtCant.Text = productoOg.cantidad.ToString();
                        txtPrecio.Text = productoOg.precio;
                        txtId.Text = productoOg.id;
                        break;
                    case "Usuarios":
                        Usuario usuarioOg = new Usuario {
                            nomUsu = dataRow.Cells["Nombre Usuario"].Value.ToString(),
                            nombre = dataRow.Cells["Nombre"].Value.ToString(),
                            apellido = dataRow.Cells["Apellido"].Value.ToString(),
                            dni = dataRow.Cells["DNI"].Value.ToString(),
                            email = dataRow.Cells["Email"].Value.ToString(),
                            telefono = dataRow.Cells["Teléfono"].Value.ToString()
                        };
                        usuarioOgg = usuarioOg;
                        txtNomUsu.Text = usuarioOg.nomUsu;
                        txtNombUsu.Text = usuarioOg.nombre;
                        txtApeUsu.Text = usuarioOg.apellido;
                        txtDni.Text = usuarioOg.dni;
                        txtTelefono.Text = usuarioOg.telefono;
                        txtEmail.Text = usuarioOg.email;

                        break;
                    case "Cliente":
                        Cliente clienteOg = new Cliente {
                            nombre = dataRow.Cells["Nombre"].Value.ToString(),
                            apellido = dataRow.Cells["Apellido"].Value.ToString(),
                            domicilio = dataRow.Cells["Domicilio"].Value.ToString(),
                            telefono = dataRow.Cells["Teléfono"].Value.ToString(),
                            id = dataRow.Cells["Id"].Value.ToString()
                        };
                        clienteOgg = clienteOg;
                        txtNomC.Text = clienteOg.nombre;
                        txtApeC.Text = clienteOg.apellido;
                        txtDomC.Text = clienteOg.domicilio;
                        txtTelC.Text = clienteOg.telefono;
                        txtIdC.Text = clienteOg.id;

                        break;
                    case "Proveedor":
                        break;
                }
                limpiarTextBoxes();
            }            
        }
        private void limpiarTextBoxes() {
            foreach (Control control in grpEditMaestro.Controls) {
                if(control is TextBox text) {
                    text.Clear();
                }
            }
        }
        private void resettearBotones() {
            btnAddMaestro.Visible = true;
            btnModMaestro.Visible = true;
            btnElimMaestro.Visible = true;
            btnAppMaestro.Visible = false;
            btnConfirm.Visible = false;
            btnCancMaestro.Visible = false;
        }

        private void btnSalirMaestro_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnCancMaestro_Click(object sender, EventArgs e) {
            mensajeria.mostrarMensaje("Se canceló la modificación. ");
            limpiarTextBoxes();
            btnAppMaestro.Visible = false;
            btnCancMaestro.Visible = false;
        }

        private void btnElimMaestro_Click(object sender, EventArgs e) {
            if (dgvMaestro.SelectedRows.Count == 1) {
                
                btnAddMaestro.Visible = false;
                btnModMaestro.Visible = false;
                string key;
                DataGridViewRow selectedRow = dgvMaestro.Rows[dgvMaestro.SelectedCells[0].RowIndex];
                switch (tipo) {
                    case "Producto":
                        key = selectedRow.Cells["Id"].Value.ToString();
                        break;
                    case "Usuarios":
                        key = selectedRow.Cells["Nombre Usuario"].Value.ToString();
                        break;
                    case "Cliente":
                        key = selectedRow.Cells["Id"].Value.ToString();
                        break;
                    case "Proveedor":
                        key = "dummy";
                        break;
                    default:
                        key = "dummy";
                        break;
                }
                if(aceptarOCancelar(key) == DialogResult.Yes) {
                    manejaMaestro.eliminarEntrada(key);
                } else {
                    mensajeria.mostrarMensaje("Se canceló la operación.");
                }
                limpiarTextBoxes();
                resettearBotones();
            }
        }
        private DialogResult aceptarOCancelar(string key) {
            string modificado = string.Equals(tipo, "Usuarios") ? tipo.Substring(0, tipo.Length - 1).ToLower() : tipo.ToLower();
            string id = string.Equals(tipo, "Usuarios") ? "Nombre de Usuario" : "Id";
            DialogResult dialogResult = MessageBox.Show($"Desea eliminar el {modificado}, {id}: {key}?", "Confirma eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dialogResult;
        }

        private void btnAppMaestro_Click(object sender, EventArgs e) {
            switch (tipo) {
                case "Producto":
                    Producto productoN = new Producto {
                        nombreProducto = String.IsNullOrEmpty(txtNomProdN.Text) ? productoOgg.nombreProducto : txtNomProdN.Text,
                        marcaProducto = String.IsNullOrEmpty(txtMarProdN.Text) ? productoOgg.marcaProducto : txtMarProdN.Text,
                        cantidad = String.IsNullOrEmpty(txtCantN.Text) ? productoOgg.cantidad : Int32.Parse(txtCantN.Text),
                        precio = String.IsNullOrEmpty(txtPrecioN.Text) ? productoOgg.precio : txtPrecioN.Text,
                        id = String.IsNullOrEmpty(txtIdN.Text) ? productoOgg.id : txtIdN.Text
                    };
                    manejaMaestro.modificaProducto(productoN, productoOgg.id);
                    break;
                case "Usuarios":
                    Usuario usuarioN = new Usuario {
                        nomUsu = String.IsNullOrEmpty(txtNomUsuN.Text) ? usuarioOgg.nomUsu : txtNomUsuN.Text,
                        nombre = String.IsNullOrEmpty(txtNombUsuN.Text) ? usuarioOgg.nombre : txtNombUsuN.Text,
                        apellido = String.IsNullOrEmpty(txtApeUsuN.Text) ? usuarioOgg.apellido : txtApeUsuN.Text,
                        dni = String.IsNullOrEmpty(txtDniN.Text) ? usuarioOgg.dni : txtDniN.Text,
                        email = String.IsNullOrEmpty(txtEmailN.Text) ? usuarioOgg.email : txtEmailN.Text,
                        telefono = String.IsNullOrEmpty(txtTelefonoN.Text) ? usuarioOgg.telefono : txtTelefonoN.Text
                    };
                    manejaMaestro.modificaUsuario(usuarioN, usuarioOgg.nomUsu);
                    break;
                case "Cliente":
                    Cliente clienteN = new Cliente {
                        nombre = String.IsNullOrEmpty(txtNomCN.Text) ? clienteOgg.nombre : txtNomCN.Text,
                        apellido = String.IsNullOrEmpty(txtApeCN.Text) ? clienteOgg.apellido : txtApeCN.Text,
                        domicilio = String.IsNullOrEmpty(txtDomCN.Text) ? clienteOgg.domicilio : txtDomCN.Text,
                        telefono = String.IsNullOrEmpty(txtTelCN.Text) ? clienteOgg.telefono : txtTelCN.Text,
                        id = String.IsNullOrEmpty(txtIdCN.Text) ? clienteOgg.id : txtIdCN.Text
                    };
                    manejaMaestro.modificaCliente(clienteN, clienteOgg.id);
                    break;
            }
            limpiarTextBoxes();
            limpiarOggs();
            resettearBotones();
        }

        private void limpiarOggs() {
            clienteOgg = null;
            productoOgg = null;
            usuarioOgg = null;
        }
    }
}
