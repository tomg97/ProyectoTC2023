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
    public partial class FrmFacturas : Form {
        ManejaVenta manejaVenta = new ManejaVenta();
        public FrmFacturas() {
            InitializeComponent();
            resetDgvView();
        }

        private void FrmFacturas_Load(object sender, EventArgs e) {

        }
        private void resetDgvView() {
            dgvVentasNoF.DataSource = null;
            dgvVentasNoF.DataSource = manejaVenta.getVentasNoFacturadas();
        }

        private void btnFacturar_Click(object sender, EventArgs e) {
            ValidarCampos validar = new ValidarCampos();
            if (validar.validarMayor0(dgvVentasNoF.Rows.Count)) {
                try {
                    DataGridViewRow selectedRow = dgvVentasNoF.SelectedRows[0];
                    Venta ventaAFacturar = (Venta)selectedRow.DataBoundItem;
                    manejaVenta.facturarVenta(ventaAFacturar);
                    MessageBox.Show("Se ha generado una factura con id: " + ventaAFacturar.id);
                    Close();
                } catch (ArgumentOutOfRangeException ex) {
                    MessageBox.Show("Se debe seleccionar una fila de la lista");
                }
            }
        }
    }
}
