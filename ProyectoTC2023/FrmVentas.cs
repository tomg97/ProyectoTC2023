﻿using BLL.Metodos;
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
            dgvExistencias.DataSource = null;
            dgvExistencias.DataSource = manejaVenta.getListaProductosEnStock();

        }

        private void btnSelectVentas_Click(object sender, EventArgs e) {
            if (validarCampos.validarMayor0(dgvExistencias.Rows.Count)
               && validarCampos.validarNoNuloNoVacio(txtCantidadVentas.Text)
               && validarCampos.validarSoloNumero(txtCantidadVentas.Text)) {
                DataGridViewRow selectedRow = dgvExistencias.SelectedRows[0];
                Producto producto = (Producto)selectedRow.DataBoundItem;
                int stockActual = producto.cantidad;
                int cantidadDeseada = Convert.ToInt32(txtCantidadVentas.Text);
                if (validarCampos.validarMayor0(cantidadDeseada) && cantidadDeseada <= stockActual) {
                    Producto productoCarrito = new Producto(producto.nombreProducto, producto.marcaProducto, producto.id, txtCantidadVentas.Text, producto.precio);
                    manejaVenta.llenarCarrito(productoCarrito);
                    dgvCarrito.DataSource = null;
                    dgvCarrito.DataSource = SingletonCarrito.getInstance.getListaProductos("carrito");
                } else {
                    MessageBox.Show("La cantidad deseada es inválida. Debe ser mayor a 0 y menor al stock actual (" + stockActual + ").");
                }
            } else if(!validarCampos.validarMayor0(dgvExistencias.SelectedRows.Count)){
                MessageBox.Show("Se debe seleccionar una fila de la lista");
            } else {
                MessageBox.Show("La cantidad deseada es inválida. Sólo números.");
            }
        }

        private void btnRemoverCarrito_Click(object sender, EventArgs e) {
            if (validarCampos.validarMayor0(dgvCarrito.Rows.Count) && validarCampos.validarMayor0()
        }
    }
}
