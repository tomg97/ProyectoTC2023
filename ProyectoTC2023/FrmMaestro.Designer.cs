﻿namespace ProyectoTC2023 {
    partial class FrmMaestro {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgvMaestro = new System.Windows.Forms.DataGridView();
            this.btnAddMaestro = new System.Windows.Forms.Button();
            this.btnCancMaestro = new System.Windows.Forms.Button();
            this.btnAppMaestro = new System.Windows.Forms.Button();
            this.btnElimMaestro = new System.Windows.Forms.Button();
            this.btnModMaestro = new System.Windows.Forms.Button();
            this.btnSalirMaestro = new System.Windows.Forms.Button();
            this.grpEditMaestro = new System.Windows.Forms.GroupBox();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.lblNomC = new System.Windows.Forms.Label();
            this.lblApeC = new System.Windows.Forms.Label();
            this.lblDomC = new System.Windows.Forms.Label();
            this.lblTelC = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomC = new System.Windows.Forms.TextBox();
            this.txtApeC = new System.Windows.Forms.TextBox();
            this.txtDomC = new System.Windows.Forms.TextBox();
            this.txtTelC = new System.Windows.Forms.TextBox();
            this.txtIdC = new System.Windows.Forms.TextBox();
            this.txtNomCN = new System.Windows.Forms.TextBox();
            this.txtApeCN = new System.Windows.Forms.TextBox();
            this.txtDomCN = new System.Windows.Forms.TextBox();
            this.txtIdCN = new System.Windows.Forms.TextBox();
            this.txtTelCN = new System.Windows.Forms.TextBox();
            this.grpUsuario = new System.Windows.Forms.GroupBox();
            this.lblNomUsu = new System.Windows.Forms.Label();
            this.lblNombUsu = new System.Windows.Forms.Label();
            this.txtTelefonoN = new System.Windows.Forms.TextBox();
            this.lblApeUsu = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDniN = new System.Windows.Forms.TextBox();
            this.txtNomUsu = new System.Windows.Forms.TextBox();
            this.txtEmailN = new System.Windows.Forms.TextBox();
            this.txtNombUsu = new System.Windows.Forms.TextBox();
            this.txtApeUsuN = new System.Windows.Forms.TextBox();
            this.txtApeUsu = new System.Windows.Forms.TextBox();
            this.txtNombUsuN = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtNomUsuN = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpProducto = new System.Windows.Forms.GroupBox();
            this.lblNomProd = new System.Windows.Forms.Label();
            this.lblMarProd = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtNomProd = new System.Windows.Forms.TextBox();
            this.txtMarProd = new System.Windows.Forms.TextBox();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNomProdN = new System.Windows.Forms.TextBox();
            this.txtMarProdN = new System.Windows.Forms.TextBox();
            this.txtCantN = new System.Windows.Forms.TextBox();
            this.txtIdN = new System.Windows.Forms.TextBox();
            this.txtPrecioN = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnSerialize = new System.Windows.Forms.Button();
            this.btnDeserialize = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaestro)).BeginInit();
            this.grpEditMaestro.SuspendLayout();
            this.grpCliente.SuspendLayout();
            this.grpUsuario.SuspendLayout();
            this.grpProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMaestro
            // 
            this.dgvMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaestro.Location = new System.Drawing.Point(12, 12);
            this.dgvMaestro.Name = "dgvMaestro";
            this.dgvMaestro.Size = new System.Drawing.Size(1056, 321);
            this.dgvMaestro.TabIndex = 1;
            // 
            // btnAddMaestro
            // 
            this.btnAddMaestro.Location = new System.Drawing.Point(1074, 12);
            this.btnAddMaestro.Name = "btnAddMaestro";
            this.btnAddMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnAddMaestro.TabIndex = 15;
            this.btnAddMaestro.Text = "Añadir";
            this.btnAddMaestro.UseVisualStyleBackColor = true;
            this.btnAddMaestro.Click += new System.EventHandler(this.btnAddMaestro_Click);
            // 
            // btnCancMaestro
            // 
            this.btnCancMaestro.Location = new System.Drawing.Point(1074, 580);
            this.btnCancMaestro.Name = "btnCancMaestro";
            this.btnCancMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnCancMaestro.TabIndex = 16;
            this.btnCancMaestro.Text = "Cancelar";
            this.btnCancMaestro.UseVisualStyleBackColor = true;
            this.btnCancMaestro.Visible = false;
            this.btnCancMaestro.Click += new System.EventHandler(this.btnCancMaestro_Click);
            // 
            // btnAppMaestro
            // 
            this.btnAppMaestro.Location = new System.Drawing.Point(1074, 532);
            this.btnAppMaestro.Name = "btnAppMaestro";
            this.btnAppMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnAppMaestro.TabIndex = 17;
            this.btnAppMaestro.Text = "Aplicar";
            this.btnAppMaestro.UseVisualStyleBackColor = true;
            this.btnAppMaestro.Visible = false;
            this.btnAppMaestro.Click += new System.EventHandler(this.btnAppMaestro_Click);
            // 
            // btnElimMaestro
            // 
            this.btnElimMaestro.Location = new System.Drawing.Point(1074, 99);
            this.btnElimMaestro.Name = "btnElimMaestro";
            this.btnElimMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnElimMaestro.TabIndex = 18;
            this.btnElimMaestro.Text = "Eliminar";
            this.btnElimMaestro.UseVisualStyleBackColor = true;
            this.btnElimMaestro.Click += new System.EventHandler(this.btnElimMaestro_Click);
            // 
            // btnModMaestro
            // 
            this.btnModMaestro.Location = new System.Drawing.Point(1074, 70);
            this.btnModMaestro.Name = "btnModMaestro";
            this.btnModMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnModMaestro.TabIndex = 19;
            this.btnModMaestro.Text = "Modificar";
            this.btnModMaestro.UseVisualStyleBackColor = true;
            this.btnModMaestro.Click += new System.EventHandler(this.btnModMaestro_Click);
            // 
            // btnSalirMaestro
            // 
            this.btnSalirMaestro.Location = new System.Drawing.Point(1074, 633);
            this.btnSalirMaestro.Name = "btnSalirMaestro";
            this.btnSalirMaestro.Size = new System.Drawing.Size(75, 23);
            this.btnSalirMaestro.TabIndex = 20;
            this.btnSalirMaestro.Text = "Salir";
            this.btnSalirMaestro.UseVisualStyleBackColor = true;
            this.btnSalirMaestro.Click += new System.EventHandler(this.btnSalirMaestro_Click);
            // 
            // grpEditMaestro
            // 
            this.grpEditMaestro.Controls.Add(this.grpCliente);
            this.grpEditMaestro.Controls.Add(this.grpUsuario);
            this.grpEditMaestro.Controls.Add(this.grpProducto);
            this.grpEditMaestro.Location = new System.Drawing.Point(12, 339);
            this.grpEditMaestro.Name = "grpEditMaestro";
            this.grpEditMaestro.Size = new System.Drawing.Size(1056, 317);
            this.grpEditMaestro.TabIndex = 21;
            this.grpEditMaestro.TabStop = false;
            this.grpEditMaestro.Text = "Editar";
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.lblNomC);
            this.grpCliente.Controls.Add(this.lblApeC);
            this.grpCliente.Controls.Add(this.lblDomC);
            this.grpCliente.Controls.Add(this.lblTelC);
            this.grpCliente.Controls.Add(this.label5);
            this.grpCliente.Controls.Add(this.txtNomC);
            this.grpCliente.Controls.Add(this.txtApeC);
            this.grpCliente.Controls.Add(this.txtDomC);
            this.grpCliente.Controls.Add(this.txtTelC);
            this.grpCliente.Controls.Add(this.txtIdC);
            this.grpCliente.Controls.Add(this.txtNomCN);
            this.grpCliente.Controls.Add(this.txtApeCN);
            this.grpCliente.Controls.Add(this.txtDomCN);
            this.grpCliente.Controls.Add(this.txtIdCN);
            this.grpCliente.Controls.Add(this.txtTelCN);
            this.grpCliente.Location = new System.Drawing.Point(463, 19);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(222, 263);
            this.grpCliente.TabIndex = 68;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            this.grpCliente.Visible = false;
            this.grpCliente.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblNomC
            // 
            this.lblNomC.AutoSize = true;
            this.lblNomC.Location = new System.Drawing.Point(6, 18);
            this.lblNomC.Name = "lblNomC";
            this.lblNomC.Size = new System.Drawing.Size(47, 13);
            this.lblNomC.TabIndex = 0;
            this.lblNomC.Text = "Nombre:";
            // 
            // lblApeC
            // 
            this.lblApeC.AutoSize = true;
            this.lblApeC.Location = new System.Drawing.Point(6, 76);
            this.lblApeC.Name = "lblApeC";
            this.lblApeC.Size = new System.Drawing.Size(47, 13);
            this.lblApeC.TabIndex = 1;
            this.lblApeC.Text = "Apellido:";
            // 
            // lblDomC
            // 
            this.lblDomC.AutoSize = true;
            this.lblDomC.Location = new System.Drawing.Point(6, 130);
            this.lblDomC.Name = "lblDomC";
            this.lblDomC.Size = new System.Drawing.Size(52, 13);
            this.lblDomC.TabIndex = 2;
            this.lblDomC.Text = "Domicilio:";
            // 
            // lblTelC
            // 
            this.lblTelC.AutoSize = true;
            this.lblTelC.Location = new System.Drawing.Point(6, 177);
            this.lblTelC.Name = "lblTelC";
            this.lblTelC.Size = new System.Drawing.Size(52, 13);
            this.lblTelC.TabIndex = 3;
            this.lblTelC.Text = "Telefono:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Id:";
            // 
            // txtNomC
            // 
            this.txtNomC.Location = new System.Drawing.Point(9, 34);
            this.txtNomC.Name = "txtNomC";
            this.txtNomC.ReadOnly = true;
            this.txtNomC.Size = new System.Drawing.Size(100, 20);
            this.txtNomC.TabIndex = 5;
            // 
            // txtApeC
            // 
            this.txtApeC.Location = new System.Drawing.Point(9, 92);
            this.txtApeC.Name = "txtApeC";
            this.txtApeC.ReadOnly = true;
            this.txtApeC.Size = new System.Drawing.Size(100, 20);
            this.txtApeC.TabIndex = 6;
            // 
            // txtDomC
            // 
            this.txtDomC.Location = new System.Drawing.Point(9, 146);
            this.txtDomC.Name = "txtDomC";
            this.txtDomC.ReadOnly = true;
            this.txtDomC.Size = new System.Drawing.Size(100, 20);
            this.txtDomC.TabIndex = 7;
            // 
            // txtTelC
            // 
            this.txtTelC.Location = new System.Drawing.Point(9, 193);
            this.txtTelC.Name = "txtTelC";
            this.txtTelC.ReadOnly = true;
            this.txtTelC.Size = new System.Drawing.Size(100, 20);
            this.txtTelC.TabIndex = 8;
            // 
            // txtIdC
            // 
            this.txtIdC.Location = new System.Drawing.Point(9, 238);
            this.txtIdC.Name = "txtIdC";
            this.txtIdC.ReadOnly = true;
            this.txtIdC.Size = new System.Drawing.Size(100, 20);
            this.txtIdC.TabIndex = 9;
            // 
            // txtNomCN
            // 
            this.txtNomCN.Location = new System.Drawing.Point(115, 34);
            this.txtNomCN.Name = "txtNomCN";
            this.txtNomCN.Size = new System.Drawing.Size(100, 20);
            this.txtNomCN.TabIndex = 10;
            // 
            // txtApeCN
            // 
            this.txtApeCN.Location = new System.Drawing.Point(115, 92);
            this.txtApeCN.Name = "txtApeCN";
            this.txtApeCN.Size = new System.Drawing.Size(100, 20);
            this.txtApeCN.TabIndex = 11;
            // 
            // txtDomCN
            // 
            this.txtDomCN.Location = new System.Drawing.Point(115, 146);
            this.txtDomCN.Name = "txtDomCN";
            this.txtDomCN.Size = new System.Drawing.Size(100, 20);
            this.txtDomCN.TabIndex = 12;
            // 
            // txtIdCN
            // 
            this.txtIdCN.Location = new System.Drawing.Point(115, 238);
            this.txtIdCN.Name = "txtIdCN";
            this.txtIdCN.Size = new System.Drawing.Size(100, 20);
            this.txtIdCN.TabIndex = 13;
            // 
            // txtTelCN
            // 
            this.txtTelCN.Location = new System.Drawing.Point(115, 193);
            this.txtTelCN.Name = "txtTelCN";
            this.txtTelCN.Size = new System.Drawing.Size(100, 20);
            this.txtTelCN.TabIndex = 14;
            // 
            // grpUsuario
            // 
            this.grpUsuario.Controls.Add(this.lblNomUsu);
            this.grpUsuario.Controls.Add(this.lblNombUsu);
            this.grpUsuario.Controls.Add(this.txtTelefonoN);
            this.grpUsuario.Controls.Add(this.lblApeUsu);
            this.grpUsuario.Controls.Add(this.txtTelefono);
            this.grpUsuario.Controls.Add(this.lblDni);
            this.grpUsuario.Controls.Add(this.lblTelefono);
            this.grpUsuario.Controls.Add(this.lblEmail);
            this.grpUsuario.Controls.Add(this.txtDniN);
            this.grpUsuario.Controls.Add(this.txtNomUsu);
            this.grpUsuario.Controls.Add(this.txtEmailN);
            this.grpUsuario.Controls.Add(this.txtNombUsu);
            this.grpUsuario.Controls.Add(this.txtApeUsuN);
            this.grpUsuario.Controls.Add(this.txtApeUsu);
            this.grpUsuario.Controls.Add(this.txtNombUsuN);
            this.grpUsuario.Controls.Add(this.txtDni);
            this.grpUsuario.Controls.Add(this.txtNomUsuN);
            this.grpUsuario.Controls.Add(this.txtEmail);
            this.grpUsuario.Location = new System.Drawing.Point(234, 19);
            this.grpUsuario.Name = "grpUsuario";
            this.grpUsuario.Size = new System.Drawing.Size(223, 292);
            this.grpUsuario.TabIndex = 68;
            this.grpUsuario.TabStop = false;
            this.grpUsuario.Text = "Usuario";
            this.grpUsuario.Visible = false;
            // 
            // lblNomUsu
            // 
            this.lblNomUsu.AutoSize = true;
            this.lblNomUsu.Location = new System.Drawing.Point(6, 16);
            this.lblNomUsu.Name = "lblNomUsu";
            this.lblNomUsu.Size = new System.Drawing.Size(89, 13);
            this.lblNomUsu.TabIndex = 16;
            this.lblNomUsu.Text = "Nombre Usuario: ";
            // 
            // lblNombUsu
            // 
            this.lblNombUsu.AutoSize = true;
            this.lblNombUsu.Location = new System.Drawing.Point(6, 58);
            this.lblNombUsu.Name = "lblNombUsu";
            this.lblNombUsu.Size = new System.Drawing.Size(47, 13);
            this.lblNombUsu.TabIndex = 17;
            this.lblNombUsu.Text = "Nombre:";
            // 
            // txtTelefonoN
            // 
            this.txtTelefonoN.Location = new System.Drawing.Point(117, 260);
            this.txtTelefonoN.Name = "txtTelefonoN";
            this.txtTelefonoN.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonoN.TabIndex = 66;
            // 
            // lblApeUsu
            // 
            this.lblApeUsu.AutoSize = true;
            this.lblApeUsu.Location = new System.Drawing.Point(7, 104);
            this.lblApeUsu.Name = "lblApeUsu";
            this.lblApeUsu.Size = new System.Drawing.Size(47, 13);
            this.lblApeUsu.TabIndex = 18;
            this.lblApeUsu.Text = "Apellido:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(10, 260);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 65;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(6, 144);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 19;
            this.lblDni.Text = "DNI:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(7, 244);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 64;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(7, 191);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 20;
            this.lblEmail.Text = "Email:";
            // 
            // txtDniN
            // 
            this.txtDniN.Location = new System.Drawing.Point(115, 160);
            this.txtDniN.Name = "txtDniN";
            this.txtDniN.Size = new System.Drawing.Size(100, 20);
            this.txtDniN.TabIndex = 30;
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(9, 32);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.ReadOnly = true;
            this.txtNomUsu.Size = new System.Drawing.Size(100, 20);
            this.txtNomUsu.TabIndex = 21;
            // 
            // txtEmailN
            // 
            this.txtEmailN.Location = new System.Drawing.Point(117, 207);
            this.txtEmailN.Name = "txtEmailN";
            this.txtEmailN.Size = new System.Drawing.Size(100, 20);
            this.txtEmailN.TabIndex = 29;
            // 
            // txtNombUsu
            // 
            this.txtNombUsu.Location = new System.Drawing.Point(9, 74);
            this.txtNombUsu.Name = "txtNombUsu";
            this.txtNombUsu.ReadOnly = true;
            this.txtNombUsu.Size = new System.Drawing.Size(100, 20);
            this.txtNombUsu.TabIndex = 22;
            // 
            // txtApeUsuN
            // 
            this.txtApeUsuN.Location = new System.Drawing.Point(116, 120);
            this.txtApeUsuN.Name = "txtApeUsuN";
            this.txtApeUsuN.Size = new System.Drawing.Size(100, 20);
            this.txtApeUsuN.TabIndex = 28;
            // 
            // txtApeUsu
            // 
            this.txtApeUsu.Location = new System.Drawing.Point(10, 120);
            this.txtApeUsu.Name = "txtApeUsu";
            this.txtApeUsu.ReadOnly = true;
            this.txtApeUsu.Size = new System.Drawing.Size(100, 20);
            this.txtApeUsu.TabIndex = 23;
            // 
            // txtNombUsuN
            // 
            this.txtNombUsuN.Location = new System.Drawing.Point(115, 74);
            this.txtNombUsuN.Name = "txtNombUsuN";
            this.txtNombUsuN.Size = new System.Drawing.Size(100, 20);
            this.txtNombUsuN.TabIndex = 27;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(9, 160);
            this.txtDni.Name = "txtDni";
            this.txtDni.ReadOnly = true;
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 24;
            // 
            // txtNomUsuN
            // 
            this.txtNomUsuN.Location = new System.Drawing.Point(115, 32);
            this.txtNomUsuN.Name = "txtNomUsuN";
            this.txtNomUsuN.Size = new System.Drawing.Size(100, 20);
            this.txtNomUsuN.TabIndex = 26;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(10, 207);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 25;
            // 
            // grpProducto
            // 
            this.grpProducto.Controls.Add(this.lblNomProd);
            this.grpProducto.Controls.Add(this.lblMarProd);
            this.grpProducto.Controls.Add(this.lblCant);
            this.grpProducto.Controls.Add(this.lblPrecio);
            this.grpProducto.Controls.Add(this.lblId);
            this.grpProducto.Controls.Add(this.txtNomProd);
            this.grpProducto.Controls.Add(this.txtMarProd);
            this.grpProducto.Controls.Add(this.txtCant);
            this.grpProducto.Controls.Add(this.txtPrecio);
            this.grpProducto.Controls.Add(this.txtId);
            this.grpProducto.Controls.Add(this.txtNomProdN);
            this.grpProducto.Controls.Add(this.txtMarProdN);
            this.grpProducto.Controls.Add(this.txtCantN);
            this.grpProducto.Controls.Add(this.txtIdN);
            this.grpProducto.Controls.Add(this.txtPrecioN);
            this.grpProducto.Location = new System.Drawing.Point(6, 16);
            this.grpProducto.Name = "grpProducto";
            this.grpProducto.Size = new System.Drawing.Size(222, 281);
            this.grpProducto.TabIndex = 67;
            this.grpProducto.TabStop = false;
            this.grpProducto.Text = "Producto";
            this.grpProducto.Visible = false;
            // 
            // lblNomProd
            // 
            this.lblNomProd.AutoSize = true;
            this.lblNomProd.Location = new System.Drawing.Point(6, 18);
            this.lblNomProd.Name = "lblNomProd";
            this.lblNomProd.Size = new System.Drawing.Size(96, 13);
            this.lblNomProd.TabIndex = 0;
            this.lblNomProd.Text = "Nombre Producto: ";
            // 
            // lblMarProd
            // 
            this.lblMarProd.AutoSize = true;
            this.lblMarProd.Location = new System.Drawing.Point(6, 76);
            this.lblMarProd.Name = "lblMarProd";
            this.lblMarProd.Size = new System.Drawing.Size(89, 13);
            this.lblMarProd.TabIndex = 1;
            this.lblMarProd.Text = "Marca Producto: ";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(6, 130);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(55, 13);
            this.lblCant.TabIndex = 2;
            this.lblCant.Text = "Cantidad: ";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(6, 177);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(43, 13);
            this.lblPrecio.TabIndex = 3;
            this.lblPrecio.Text = "Precio: ";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(6, 230);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 13);
            this.lblId.TabIndex = 4;
            this.lblId.Text = "Id:";
            // 
            // txtNomProd
            // 
            this.txtNomProd.Location = new System.Drawing.Point(9, 34);
            this.txtNomProd.Name = "txtNomProd";
            this.txtNomProd.ReadOnly = true;
            this.txtNomProd.Size = new System.Drawing.Size(100, 20);
            this.txtNomProd.TabIndex = 5;
            // 
            // txtMarProd
            // 
            this.txtMarProd.Location = new System.Drawing.Point(9, 92);
            this.txtMarProd.Name = "txtMarProd";
            this.txtMarProd.ReadOnly = true;
            this.txtMarProd.Size = new System.Drawing.Size(100, 20);
            this.txtMarProd.TabIndex = 6;
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(9, 146);
            this.txtCant.Name = "txtCant";
            this.txtCant.ReadOnly = true;
            this.txtCant.Size = new System.Drawing.Size(100, 20);
            this.txtCant.TabIndex = 7;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(9, 193);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 8;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(9, 246);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 9;
            // 
            // txtNomProdN
            // 
            this.txtNomProdN.Location = new System.Drawing.Point(115, 34);
            this.txtNomProdN.Name = "txtNomProdN";
            this.txtNomProdN.Size = new System.Drawing.Size(100, 20);
            this.txtNomProdN.TabIndex = 10;
            // 
            // txtMarProdN
            // 
            this.txtMarProdN.Location = new System.Drawing.Point(115, 92);
            this.txtMarProdN.Name = "txtMarProdN";
            this.txtMarProdN.Size = new System.Drawing.Size(100, 20);
            this.txtMarProdN.TabIndex = 11;
            // 
            // txtCantN
            // 
            this.txtCantN.Location = new System.Drawing.Point(115, 146);
            this.txtCantN.Name = "txtCantN";
            this.txtCantN.Size = new System.Drawing.Size(100, 20);
            this.txtCantN.TabIndex = 12;
            // 
            // txtIdN
            // 
            this.txtIdN.Location = new System.Drawing.Point(115, 246);
            this.txtIdN.Name = "txtIdN";
            this.txtIdN.Size = new System.Drawing.Size(100, 20);
            this.txtIdN.TabIndex = 13;
            // 
            // txtPrecioN
            // 
            this.txtPrecioN.Location = new System.Drawing.Point(115, 193);
            this.txtPrecioN.Name = "txtPrecioN";
            this.txtPrecioN.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioN.TabIndex = 14;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(1074, 41);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 22;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Visible = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(1074, 250);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(75, 23);
            this.btnSerialize.TabIndex = 23;
            this.btnSerialize.Text = "Serializar";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Visible = false;
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // btnDeserialize
            // 
            this.btnDeserialize.Location = new System.Drawing.Point(1074, 280);
            this.btnDeserialize.Name = "btnDeserialize";
            this.btnDeserialize.Size = new System.Drawing.Size(75, 23);
            this.btnDeserialize.TabIndex = 24;
            this.btnDeserialize.Text = "Desserializar";
            this.btnDeserialize.UseVisualStyleBackColor = true;
            this.btnDeserialize.Visible = false;
            this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1074, 310);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 25;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Visible = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FrmMaestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 665);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnDeserialize);
            this.Controls.Add(this.btnSerialize);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grpEditMaestro);
            this.Controls.Add(this.btnSalirMaestro);
            this.Controls.Add(this.btnModMaestro);
            this.Controls.Add(this.btnElimMaestro);
            this.Controls.Add(this.btnAppMaestro);
            this.Controls.Add(this.btnCancMaestro);
            this.Controls.Add(this.btnAddMaestro);
            this.Controls.Add(this.dgvMaestro);
            this.Name = "FrmMaestro";
            this.Text = "FrmMaestro";
            this.Load += new System.EventHandler(this.FrmMaestro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaestro)).EndInit();
            this.grpEditMaestro.ResumeLayout(false);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            this.grpUsuario.ResumeLayout(false);
            this.grpUsuario.PerformLayout();
            this.grpProducto.ResumeLayout(false);
            this.grpProducto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaestro;
        private System.Windows.Forms.Button btnAddMaestro;
        private System.Windows.Forms.Button btnCancMaestro;
        private System.Windows.Forms.Button btnAppMaestro;
        private System.Windows.Forms.Button btnElimMaestro;
        private System.Windows.Forms.Button btnModMaestro;
        private System.Windows.Forms.Button btnSalirMaestro;
        private System.Windows.Forms.GroupBox grpEditMaestro;
        private System.Windows.Forms.TextBox txtDniN;
        private System.Windows.Forms.TextBox txtEmailN;
        private System.Windows.Forms.TextBox txtApeUsuN;
        private System.Windows.Forms.TextBox txtNombUsuN;
        private System.Windows.Forms.TextBox txtNomUsuN;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtApeUsu;
        private System.Windows.Forms.TextBox txtNombUsu;
        private System.Windows.Forms.TextBox txtNomUsu;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblApeUsu;
        private System.Windows.Forms.Label lblNombUsu;
        private System.Windows.Forms.Label lblNomUsu;
        private System.Windows.Forms.TextBox txtPrecioN;
        private System.Windows.Forms.TextBox txtIdN;
        private System.Windows.Forms.TextBox txtCantN;
        private System.Windows.Forms.TextBox txtMarProdN;
        private System.Windows.Forms.TextBox txtNomProdN;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.TextBox txtMarProd;
        private System.Windows.Forms.TextBox txtNomProd;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Label lblMarProd;
        private System.Windows.Forms.Label lblNomProd;
        private System.Windows.Forms.TextBox txtTelefonoN;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.Label lblNomC;
        private System.Windows.Forms.Label lblApeC;
        private System.Windows.Forms.Label lblDomC;
        private System.Windows.Forms.Label lblTelC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomC;
        private System.Windows.Forms.TextBox txtApeC;
        private System.Windows.Forms.TextBox txtDomC;
        private System.Windows.Forms.TextBox txtTelC;
        private System.Windows.Forms.TextBox txtIdC;
        private System.Windows.Forms.TextBox txtNomCN;
        private System.Windows.Forms.TextBox txtApeCN;
        private System.Windows.Forms.TextBox txtDomCN;
        private System.Windows.Forms.TextBox txtIdCN;
        private System.Windows.Forms.TextBox txtTelCN;
        private System.Windows.Forms.GroupBox grpUsuario;
        private System.Windows.Forms.GroupBox grpProducto;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.Button btnDeserialize;
        private System.Windows.Forms.Button btnLimpiar;
    }
}