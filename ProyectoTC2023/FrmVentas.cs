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
    public partial class FrmVentas : Form {
        ManejaVenta manejaVenta = new ManejaVenta();
        ValidarCampos validarCampos = new ValidarCampos();
        public FrmVentas() {
            InitializeComponent();
        }

        private void FrmVentas_Load(object sender, EventArgs e) {
            setDataGridViewExistencias();
        }

        private void btnSelectVentas_Click(object sender, EventArgs e) {
            if (validarCampos.validarMayor0(dgvExistencias.Rows.Count)
               && validarCampos.validarNoNuloNoVacio(txtCantidadVentas.Text)
               && validarCampos.validarSoloNumero(txtCantidadVentas.Text)) {
                try {
                    DataGridViewRow selectedRow = dgvExistencias.SelectedRows[0];
                    Producto producto = (Producto)selectedRow.DataBoundItem;
                    int stockActual = producto.cantidad;
                    int cantidadDeseada = Convert.ToInt32(txtCantidadVentas.Text);
                    if (validarCampos.validarMayor0(cantidadDeseada) && cantidadDeseada <= stockActual) {
                        Producto productoCarrito = new Producto(producto.nombreProducto, producto.marcaProducto, producto.id, txtCantidadVentas.Text, producto.precio);
                        manejaVenta.llenarCarrito(productoCarrito);
                        setDataGridViewCarrito();
                    } else {
                        MessageBox.Show("La cantidad deseada es inválida. Debe ser mayor a 0 y menor al stock actual (" + stockActual + ").");
                    }
                } catch (ArgumentOutOfRangeException ex) {
                    MessageBox.Show("Se debe seleccionar una fila de la lista");
                }
            } else {
                MessageBox.Show("La cantidad deseada es inválida. Sólo números.");
            }
        }

        private void btnRemoverCarrito_Click(object sender, EventArgs e) {
            if (validarCampos.validarMayor0(dgvCarrito.Rows.Count)){
                try {
                    DataGridViewRow selectedRow = dgvCarrito.SelectedRows[0];
                    Producto producto = (Producto)selectedRow.DataBoundItem;
                    manejaVenta.removerDelCarrito(producto);
                    setDataGridViewCarrito();
                } catch (ArgumentOutOfRangeException ex) {
                    MessageBox.Show("Se debe seleccionar una fila de la lista");
                }
            }
            MessageBox.Show("No hay elementos en el carrito.");
        }
        private void setDataGridViewCarrito() {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = manejaVenta.devolverCarrito();
        }
        private void setDataGridViewExistencias() {
            dgvExistencias.DataSource = null;
            dgvExistencias.DataSource = manejaVenta.getListaProductosEnStock();
        }

        private void btnVaciar_Click(object sender, EventArgs e) {
            manejaVenta.vaciarCarrito();
            setDataGridViewCarrito();
        }
        private void mostrarFrmClientes(string proposito) {
            FrmClientes frmClientes = new FrmClientes(proposito);
            frmClientes.Show();
        }
        private void mostrarFrmClientes(Cliente cliente) {
            FrmClientes frmClientes = new FrmClientes(cliente);
            frmClientes.Show();
        }

        private void btnAsignarCliente_Click(object sender, EventArgs e) {
            string idCliente = txtClienteVenta.Text;
            if (validarCampos.validarMayor0(dgvCarrito.Rows.Count) && validarCampos.validarNoNuloNoVacio(idCliente)) {
                ManejaCliente manejaCliente = new ManejaCliente();
                string mensajeVuelta = manejaCliente.lookupCliente(idCliente);
                if (mensajeVuelta == "Cliente encontrado") {
                    MessageBox.Show(mensajeVuelta + ", se procederá a introducir los datos de pago.");
                    mostrarFrmClientes(new Cliente(idCliente));
                } else {
                    MessageBox.Show("No se ha encontrado el cliente. Se procederá a la pantalla de alta de cliente.");
                    mostrarFrmClientes(idCliente);
                }
            } else if(!validarCampos.validarNoNuloNoVacio(idCliente)) {
                MessageBox.Show("Se debe introducir un número de cliente");
            } else if (!validarCampos.validarMayor0(dgvCarrito.Rows.Count)) {
                MessageBox.Show("No hay productos en el carrito.");
            }
        }
    }
}
