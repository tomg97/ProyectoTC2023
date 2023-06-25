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
    public partial class FrmClientes : Form {
        public FrmClientes() {
            InitializeComponent();
        }
        ManejaCliente manejaCliente = new ManejaCliente();

        private void btnRegistrarCliente_Click(object sender, EventArgs e) {
            ValidarCampos validarCampos = new ValidarCampos();
            string id = txtIdCliente.Text;
            string nombre = txtNombreCliente.Text;
            string apellido = txtApellidoCliente.Text;
            string domicilio = txtDomicilioCliente.Text;
            string telefono = txtTelefonoCliente.Text;
            if (validarCampos.validarNoNuloNoVacio(id, nombre, apellido, domicilio, telefono)) {
                Cliente nuevoCliente = new Cliente(id, nombre, apellido, domicilio, telefono);
                MessageBox.Show(manejaCliente.crearCliente(nuevoCliente));
            }
        }
    }
}
