﻿using BLL.Metodos;
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
    public partial class FrmBitacora : Form, IObserver {
        BitacoraBLL manejaBitacora = new BitacoraBLL();
        Mensajeria mensajeria = new Mensajeria();
        public FrmBitacora() {
            InitializeComponent();
            settearSegunTipo(false);
        }

        private void btnLookBit_Click(object sender, EventArgs e) {
            dataGridView1.DataSource = null;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("@usuario", cbNomUsuBit.Text);
            parameters.Add("@tipo", cbTipoBit.Text);
            parameters.Add("@tabla", cbTablaBit.Text);
            parameters.Add("@criticidad", cbCriticidadBit.Text);
            parameters.Add("@FromDate", dtpDesde.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            parameters.Add("@ToDate", dtpHasta.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            dataGridView1.DataSource = manejaBitacora.lookupBitacoraParametros(parameters);
        }

        private void btnAplicar_Click(object sender, EventArgs e) {
            if (cbTipoBit.SelectedIndex != -1) {
                if (cbTipoBit.Text == "Cambios")
                    settearSegunTipo(true);
                else
                    settearSegunTipo(false);
            } else
                mensajeria.mostrarMensaje("Se debe seleccionar un tipo de bitácora");
        }
        private void settearSegunTipo(Boolean variable) {
            cbTablaBit.Visible = variable;
            btnRollback.Visible = variable;
        }

        public void actualizarIdioma() {
            
        }
    }
}
