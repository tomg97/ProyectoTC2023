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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTC2023 {
    public partial class FrmVentas : Form, IObserver {
        ManejaVenta manejaVenta = new ManejaVenta();
        ValidarCampos validarCampos = new ValidarCampos();
        Mensajeria mensajeria = new Mensajeria();
        public FrmVentas() {
            InitializeComponent();
            LenguajeActual.Attach(this);
        }

        private void FrmVentas_Load(object sender, EventArgs e) {
            setDataGridViewExistencias();
        }

        private void btnSelectVentas_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
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
                            txtCantidadVentas.Clear();
                        } else {
                            mensajeria.mostrarMensaje("La cantidad deseada es inválida. Debe ser mayor a 0 y menor al stock actual (" + stockActual + ").");
                            txtCantidadVentas.Clear();
                        }
                    } catch (ArgumentOutOfRangeException ex) {
                        mensajeria.mostrarMensaje("Se debe seleccionar una fila de la lista");
                    }
                } else {
                    mensajeria.mostrarMensaje("La cantidad deseada es inválida. Sólo números.");
                }
            } else {
                txtCantidadVentas.Clear();
                mensajeria.mostrarErrorNoLogged();
            }            
        }

        private void btnRemoverCarrito_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                if (validarCampos.validarMayor0(dgvCarrito.Rows.Count)) {
                    try {
                        DataGridViewRow selectedRow = dgvCarrito.SelectedRows[0];
                        Producto producto = (Producto)selectedRow.DataBoundItem;
                        manejaVenta.removerDelCarrito(producto);
                        setDataGridViewCarrito();
                    } catch (ArgumentOutOfRangeException ex) {
                        mensajeria.mostrarMensaje("Se debe seleccionar una fila de la lista");
                    }
                }
                mensajeria.mostrarMensaje("No hay elementos en el carrito.");
            } else {
                mensajeria.mostrarErrorNoLogged();
            }            
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
            if (SingletonSesion.getInstance.estaLogged) {
                manejaVenta.vaciarCarrito();
                setDataGridViewCarrito();
            } else {
                mensajeria.mostrarErrorNoLogged();
            }            
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
            if (SingletonSesion.getInstance.estaLogged) {
                if (validarCampos.validarMayor0(dgvCarrito.Rows.Count) && validarCampos.validarNoNuloNoVacio(idCliente)) {
                    ManejaCliente manejaCliente = new ManejaCliente();
                    string mensajeVuelta = manejaCliente.lookupCliente(idCliente);
                    if (mensajeVuelta == "Cliente encontrado") {
                        mensajeria.mostrarMensaje(mensajeVuelta + ", se procederá a introducir los datos de pago.");
                        mostrarFrmClientes(new Cliente(idCliente));
                        setDataGridViewExistencias();
                        setDataGridViewCarrito();
                        txtClienteVenta.Clear();
                    } else {
                        mensajeria.mostrarMensaje("No se ha encontrado el cliente. Se procederá a la pantalla de alta de cliente.");
                        mostrarFrmClientes(idCliente);
                    }
                } else if (!validarCampos.validarNoNuloNoVacio(idCliente)) {
                    mensajeria.mostrarMensaje("Se debe introducir un número de cliente");
                } else if (!validarCampos.validarMayor0(dgvCarrito.Rows.Count)) {
                    mensajeria.mostrarMensaje("No hay productos en el carrito.");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
                txtClienteVenta.Clear();
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            grpStockVentas.Text = Lang.grpStockVentas;
            lblCantidadVentas.Text = Lang.lblCantidadVentas;
            btnSelectVentas.Text = Lang.btnSelectVentas;
            grpCarrito.Text = Lang.grpCarrito;
            btnRemoverCarrito.Text = Lang.btnRemoverCarrito;
            btnVaciar.Text = Lang.btnVaciar;
            lblAsignarCliente.Text = Lang.lblAsignarCliente;
            btnAsignarCliente.Text = Lang.btnAsignarCliente;
        }
    }
}
