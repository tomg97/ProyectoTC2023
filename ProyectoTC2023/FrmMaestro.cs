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
using System.Xml.Serialization;
using System.IO;

namespace ProyectoTC2023 {
    public partial class FrmMaestro : Form {
        ManejaMaestro manejaMaestro;
        DataTable dt = new DataTable();
        Mensajeria mensajeria = new Mensajeria();
        SerializadorXML serializadorXML = new SerializadorXML();
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
                    btnSerialize.Visible = true;
                    btnDeserialize.Visible = true;
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
            btnSerialize.Visible = false;
            btnDeserialize.Visible = false;
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            DataRow dataRow = dt.Rows[dt.Rows.Count - 1];
            switch (tipo) {
                case "Producto":
                    Producto producto = crearProducto(dataRow);
                    manejaMaestro.guardarProductoNuevo(producto);
                    break;
                case "Usuarios":
                    Usuario usuario = crearUsuario(dataRow);
                    string input = Interaction.InputBox("Contraseña?", "Ingrese Contraseña", "1234");
                    usuario.pass = input;
                    manejaMaestro.guardarUsuario(usuario);
                    break;
                case "Cliente":
                    Cliente cliente = crearCliente(dataRow);
                    manejaMaestro.crearCliente(cliente);
                    break;
                case "Proveedor":
                    break;
            }
            settearSegunTipo();
            resettearBotones();
        }

        private static Cliente crearCliente(DataRow dataRow) {
            return new Cliente {
                nombre = dataRow["Nombre"].ToString(),
                apellido = dataRow["Apellido"].ToString(),
                domicilio = dataRow["Domicilio"].ToString(),
                telefono = dataRow["Teléfono"].ToString(),
                id = dataRow["Id"].ToString()
            };
        }

        private static Usuario crearUsuario(DataRow dataRow) {
            return new Usuario {
                nomUsu = dataRow["Nombre Usuario"].ToString(),
                nombre = dataRow["Nombre"].ToString(),
                apellido = dataRow["Apellido"].ToString(),
                dni = dataRow["DNI"].ToString(),
                email = dataRow["Email"].ToString(),
                telefono = dataRow["Teléfono"].ToString()
            };
        }

        private static Producto crearProducto(DataRow dataRow) {
            return new Producto {

                nombreProducto = dataRow["Nombre Producto"].ToString(),
                marcaProducto = dataRow["Marca Producto"].ToString(),
                cantidad = Int32.Parse(dataRow["Cantidad"].ToString()),
                precio = dataRow["Precio"].ToString(),
                id = dataRow["Id"].ToString()
            };
        }

        private void btnModMaestro_Click(object sender, EventArgs e) {
            if (dgvMaestro.SelectedRows.Count == 1) {
                btnAppMaestro.Visible = true;
                btnCancMaestro.Visible = true;
                btnModMaestro.Visible = false;
                btnElimMaestro.Visible = false;
                btnAddMaestro.Visible = false;
                DataRow dataRow = ((DataRowView)dgvMaestro.SelectedRows[0].DataBoundItem).Row;
                switch (tipo) {
                    case "Producto":
                        Producto productoOg = crearProducto(dataRow);
                        cargarProducto(productoOg);
                        break;
                    case "Usuarios":
                        Usuario usuarioOg = crearUsuario(dataRow);
                        cargarUsuario(usuarioOg);

                        break;
                    case "Cliente":
                        Cliente clienteOg = crearCliente(dataRow);
                        cargarCliente(clienteOg);
                        break;
                    case "Proveedor":
                        break;
                }
                limpiarTextBoxes();
            }            
        }

        private void cargarCliente(Cliente clienteOg) {
            clienteOgg = clienteOg;
            txtNomC.Text = clienteOg.nombre;
            txtApeC.Text = clienteOg.apellido;
            txtDomC.Text = clienteOg.domicilio;
            txtTelC.Text = clienteOg.telefono;
            txtIdC.Text = clienteOg.id;
        }

        private void cargarUsuario(Usuario usuarioOg) {
            usuarioOgg = usuarioOg;
            txtNomUsu.Text = usuarioOg.nomUsu;
            txtNombUsu.Text = usuarioOg.nombre;
            txtApeUsu.Text = usuarioOg.apellido;
            txtDni.Text = usuarioOg.dni;
            txtTelefono.Text = usuarioOg.telefono;
            txtEmail.Text = usuarioOg.email;
        }

        private void cargarProducto(Producto productoOg) {
            productoOgg = productoOg;
            txtNomProd.Text = productoOg.nombreProducto;
            txtMarProd.Text = productoOg.marcaProducto;
            txtCant.Text = productoOg.cantidad.ToString();
            txtPrecio.Text = productoOg.precio;
            txtId.Text = productoOg.id;
        }

        private void limpiarTextBoxes() {
            foreach (Control control in grpEditMaestro.Controls) {
                if(control is GroupBox groupBox) {
                    foreach (Control control2 in groupBox.Controls) {
                        if (control2 is TextBox text) {
                            text.Clear();
                        }
                    }
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
                        nombreProducto = devolverStringOriginalIfNullOrEmpty(productoOgg.nombreProducto, txtNomProdN.Text),
                        marcaProducto = devolverStringOriginalIfNullOrEmpty(productoOgg.marcaProducto, txtMarProdN.Text),
                        cantidad = Int32.Parse(devolverStringOriginalIfNullOrEmpty(productoOgg.cantidad.ToString(), txtCantN.Text)),
                        precio = devolverStringOriginalIfNullOrEmpty(productoOgg.precio, txtPrecioN.Text),
                        id = devolverStringOriginalIfNullOrEmpty(productoOgg.id, txtIdN.Text)
                    };
                    manejaMaestro.modificaProducto(productoN, productoOgg.id);
                    break;
                case "Usuarios":
                    Usuario usuarioN = new Usuario {
                        nomUsu = devolverStringOriginalIfNullOrEmpty(usuarioOgg.nomUsu, txtNomUsuN.Text),
                        nombre = devolverStringOriginalIfNullOrEmpty(usuarioOgg.nombre, txtNombUsuN.Text),
                        apellido = devolverStringOriginalIfNullOrEmpty(usuarioOgg.apellido, txtApeUsuN.Text),
                        dni = devolverStringOriginalIfNullOrEmpty(usuarioOgg.dni, txtDniN.Text),
                        email = devolverStringOriginalIfNullOrEmpty(usuarioOgg.email, txtEmailN.Text),
                        telefono = devolverStringOriginalIfNullOrEmpty(usuarioOgg.telefono, txtTelefonoN.Text)
                    };
                    manejaMaestro.modificaUsuario(usuarioN, usuarioOgg.nomUsu);
                    break;
                case "Cliente":
                    Cliente clienteN = new Cliente {
                        nombre = devolverStringOriginalIfNullOrEmpty(clienteOgg.nombre, txtNomCN.Text),
                        apellido = devolverStringOriginalIfNullOrEmpty(clienteOgg.apellido, txtApeCN.Text),
                        domicilio = devolverStringOriginalIfNullOrEmpty(clienteOgg.domicilio, txtDomCN.Text),
                        telefono = devolverStringOriginalIfNullOrEmpty(clienteOgg.telefono, txtTelCN.Text),
                        id = devolverStringOriginalIfNullOrEmpty(clienteOgg.id, txtIdCN.Text)
                    };
                    manejaMaestro.modificaCliente(clienteN, clienteOgg.id);
                    break;
            }
            limpiarTextBoxes();
            limpiarOggs();
            resettearBotones();
        }

        private string devolverStringOriginalIfNullOrEmpty(string original, string nuevo) {
            return String.IsNullOrEmpty(nuevo) ? original : nuevo;
        }

        private void limpiarOggs() {
            clienteOgg = null;
            productoOgg = null;
            usuarioOgg = null;
        }

        private void btnSerialize_Click(object sender, EventArgs e) {
            // Create an object based on the "tipo" value
            if (dgvMaestro.SelectedRows.Count == 1) {
                DataRow dataRow = ((DataRowView)dgvMaestro.SelectedRows[0].DataBoundItem).Row;
                switch (tipo) {
                    case "Producto":
                        Producto producto = crearProducto(dataRow);
                        serializadorXML.serializarObjetoConXML(producto);
                        break;
                    case "Usuarios":
                        Usuario usuario = crearUsuario(dataRow);
                        serializadorXML.serializarObjetoConXML(usuario);
                        break;
                    case "Cliente":
                        Cliente cliente = crearCliente(dataRow);
                        serializadorXML.serializarObjetoConXML(cliente);
                        break;
                    case "Proveedor":
                        // Create a Proveedor object
                        break;
                }
            } else {
                mensajeria.mostrarMensaje("Debe seleccionar una fila para serializar.");
            }
        }

        private void btnDeserialize_Click(object sender, EventArgs e) {
            switch (tipo) {
                case "Producto":
                    Producto producto = serializadorXML.deserializarObjetoDesdeXML<Producto>();
                    cargarProducto(producto);
                    break;
                case "Usuarios":
                    Usuario usuario = serializadorXML.deserializarObjetoDesdeXML<Usuario>();
                    cargarUsuario(usuario);
                    break;
                case "Cliente":
                    Cliente cliente = serializadorXML.deserializarObjetoDesdeXML<Cliente>();
                    cargarCliente(cliente);
                    break;
                case "Proveedor":
                    // Create a Proveedor object
                    break;
            }
            btnLimpiar.Visible = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            limpiarTextBoxes();
            btnLimpiar.Visible = false;
        }
    }
}
