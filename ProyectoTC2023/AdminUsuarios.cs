﻿using BLL.Metodos;
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
    public partial class AdminUsuarios : Form, IObserver {
        public AdminUsuarios() {
            InitializeComponent();
            LenguajeActual.Attach(this);
            actualizarIdioma();
        }
        private void AdminUsuarios_Load(object sender, EventArgs e) {
            txtABMPUsu.Visible = false;
            btnEnterABM.Visible = false;
            lblABMPUsu.Visible = false;
            cmbUsusBloq.SelectedIndex = -1;
            List<Usuario> usuariosBloqueados = resultadosDb.getUsuariosBloqueados();
            if (validar.validarListaNoNulaNoVacia(usuariosBloqueados)) {
                cmbUsusBloq.DataSource = usuariosBloqueados;
                cmbUsusBloq.DisplayMember = "nomUsu";
            }
        }
        ManejaUsuarios resultadosDb = new ManejaUsuarios();
        ValidarCampos validar = new ValidarCampos();
        Mensajeria mensajeria = new Mensajeria();

        private void btnVerif_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                string nomUsu = txtABMUsu.Text;
                if (validar.validarNoNuloNoVacio(nomUsu)) {
                    if (resultadosDb.lookupUsuario(nomUsu) == "Usuario Encontrado") {
                        txtABMPUsu.Visible = true;
                        btnEnterABM.Visible = true;
                        lblABMPUsu.Visible = true;
                        lblABMPUsu.Text = "Modificar Nombre Usuario:";
                        btnEnterABM.Text = "Modificar";
                        grpbxCMUsu.Text = "Modificar Usuario";
                    } else if (resultadosDb.lookupUsuario(nomUsu) == "Usuario No Encontrado") {
                        txtABMPUsu.Visible = true;
                        btnEnterABM.Visible = true;
                        lblABMPUsu.Visible = true;
                        lblABMPUsu.Text = "Contraseña:";
                        btnEnterABM.Text = "Crear";
                        grpbxCMUsu.Text = "Crear Usuario";
                    } else {
                        mensajeria.mostrarMensaje("Error inesperado");
                        txtABMUsu.Clear();
                    }
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private void btnEnterABM_Click(object sender, EventArgs e) {
            // TODO: rework para añadir un email para los usuarios. es necesario para completar la bitácora
            string primerTxtBox = txtABMUsu.Text;
            string segundoTxtBox = txtABMPUsu.Text;
            if (SingletonSesion.getInstance.estaLogged) {
                if (validar.validarNoNuloNoVacio(segundoTxtBox)) {
                    if (btnEnterABM.Text == "Crear") {
                       Usuario usuario = new Usuario() { nomUsu = primerTxtBox, pass = segundoTxtBox };
                       txtABMUsu.Clear();
                       txtABMPUsu.Clear();
                       txtABMPUsu.Visible = false;
                       btnEnterABM.Visible = false;
                       lblABMPUsu.Visible = false;
                       grpbxCMUsu.Text = "Crear/Modificar Usuario";
                       mensajeria.mostrarMensaje(resultadosDb.crearUsuario(usuario));
                    } else {
                        string mensaje = resultadosDb.modificarNombreUsuario(primerTxtBox, segundoTxtBox);
                        if(mensaje == "Exito") {
                            mensajeria.mostrarMensaje("Usuario " + primerTxtBox + " modificado");
                            txtABMUsu.Clear();
                            txtABMPUsu.Clear();
                            txtABMPUsu.Visible = false;
                            btnEnterABM.Visible = false;
                            lblABMPUsu.Visible = false;
                            grpbxCMUsu.Text = "Crear/Modificar Usuario";
                        } else if (mensaje == "Usuario Existente") {
                            mensajeria.mostrarMensaje("Usuario " + segundoTxtBox + " ya existe. Utilice uno distinto.");
                            txtABMPUsu.Clear();
                        }
                    }
                } else {
                    mensajeria.mostrarMensaje("Se debe proporcionar una contraseña para poder crear al usuario");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        private void btnDesbloquear_Click(object sender, EventArgs e) {
            if (SingletonSesion.getInstance.estaLogged) {
                if (cmbUsusBloq.SelectedIndex != -1) {
                    Usuario usuarioADesbloquear = (Usuario)cmbUsusBloq.SelectedItem;
                    resultadosDb.desbloquearUsuario(usuarioADesbloquear.nomUsu);
                    cmbUsusBloq.SelectedIndex = -1;
                    mensajeria.mostrarMensaje("El usuario " + usuarioADesbloquear.nomUsu + " ha sido desbloqueado.");
                }
            } else {
                mensajeria.mostrarErrorNoLogged();
            }
        }

        public void actualizarIdioma() {
            string codigoIdioma = SingletonSesion.getInstance.getIdiomaActual();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(codigoIdioma);

            grpbxCMUsu.Text = Lang.grpbxCMUsu;
            lblABMNUsu.Text = Lang.lblABMNUsu;
            btnVerif.Text = Lang.btnVerif;
            lblABMPUsu.Text = Lang.lblABMPUsu;
            btnEnterABM.Text = Lang.btnEnterABM;
            gbDesbloquearUsuarios.Text = Lang.gbDesbloquearUsuarios;
            btnDesbloquear.Text = Lang.btnDesbloquear;
        }
    }
}
