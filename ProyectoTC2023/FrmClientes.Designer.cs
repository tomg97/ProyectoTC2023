﻿namespace ProyectoTC2023 {
    partial class FrmClientes {
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
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.txtDomicilioCliente = new System.Windows.Forms.TextBox();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblApellidoCliente = new System.Windows.Forms.Label();
            this.lblDomicilioCliente = new System.Windows.Forms.Label();
            this.lblTelefonoCliente = new System.Windows.Forms.Label();
            this.btnRegistrarCliente = new System.Windows.Forms.Button();
            this.gbRegistroCliente = new System.Windows.Forms.GroupBox();
            this.gbDatosPago = new System.Windows.Forms.GroupBox();
            this.lblSubtotalCuotas = new System.Windows.Forms.Label();
            this.lblSubtotalVenta = new System.Windows.Forms.Label();
            this.cbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.txtAñoTarjeta = new System.Windows.Forms.TextBox();
            this.btnVenta = new System.Windows.Forms.Button();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.lblCuotas = new System.Windows.Forms.Label();
            this.txtMesTarjeta = new System.Windows.Forms.TextBox();
            this.lblTipoTarjeta = new System.Windows.Forms.Label();
            this.txtCCV = new System.Windows.Forms.TextBox();
            this.lblCCV = new System.Windows.Forms.Label();
            this.lblMesYAñoVenc = new System.Windows.Forms.Label();
            this.txtCuotas = new System.Windows.Forms.TextBox();
            this.lblNumTarjeta = new System.Windows.Forms.Label();
            this.gbRegistroCliente.SuspendLayout();
            this.gbDatosPago.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(6, 33);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(100, 20);
            this.txtIdCliente.TabIndex = 7;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(6, 79);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCliente.TabIndex = 8;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(6, 127);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoCliente.TabIndex = 9;
            // 
            // txtDomicilioCliente
            // 
            this.txtDomicilioCliente.Location = new System.Drawing.Point(6, 171);
            this.txtDomicilioCliente.Name = "txtDomicilioCliente";
            this.txtDomicilioCliente.Size = new System.Drawing.Size(100, 20);
            this.txtDomicilioCliente.TabIndex = 10;
            // 
            // txtTelefonoCliente
            // 
            this.txtTelefonoCliente.Location = new System.Drawing.Point(6, 220);
            this.txtTelefonoCliente.Name = "txtTelefonoCliente";
            this.txtTelefonoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtTelefonoCliente.TabIndex = 11;
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Location = new System.Drawing.Point(6, 17);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(26, 13);
            this.lblIdCliente.TabIndex = 5;
            this.lblIdCliente.Text = "DNI";
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(6, 63);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(44, 13);
            this.lblNombreCliente.TabIndex = 6;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // lblApellidoCliente
            // 
            this.lblApellidoCliente.AutoSize = true;
            this.lblApellidoCliente.Location = new System.Drawing.Point(6, 111);
            this.lblApellidoCliente.Name = "lblApellidoCliente";
            this.lblApellidoCliente.Size = new System.Drawing.Size(44, 13);
            this.lblApellidoCliente.TabIndex = 7;
            this.lblApellidoCliente.Text = "Apellido";
            // 
            // lblDomicilioCliente
            // 
            this.lblDomicilioCliente.AutoSize = true;
            this.lblDomicilioCliente.Location = new System.Drawing.Point(6, 155);
            this.lblDomicilioCliente.Name = "lblDomicilioCliente";
            this.lblDomicilioCliente.Size = new System.Drawing.Size(49, 13);
            this.lblDomicilioCliente.TabIndex = 8;
            this.lblDomicilioCliente.Text = "Domicilio";
            // 
            // lblTelefonoCliente
            // 
            this.lblTelefonoCliente.AutoSize = true;
            this.lblTelefonoCliente.Location = new System.Drawing.Point(6, 204);
            this.lblTelefonoCliente.Name = "lblTelefonoCliente";
            this.lblTelefonoCliente.Size = new System.Drawing.Size(49, 13);
            this.lblTelefonoCliente.TabIndex = 9;
            this.lblTelefonoCliente.Text = "Telefono";
            // 
            // btnRegistrarCliente
            // 
            this.btnRegistrarCliente.Location = new System.Drawing.Point(6, 261);
            this.btnRegistrarCliente.Name = "btnRegistrarCliente";
            this.btnRegistrarCliente.Size = new System.Drawing.Size(100, 23);
            this.btnRegistrarCliente.TabIndex = 12;
            this.btnRegistrarCliente.Text = "Registro";
            this.btnRegistrarCliente.UseVisualStyleBackColor = true;
            this.btnRegistrarCliente.Click += new System.EventHandler(this.btnRegistrarCliente_Click);
            // 
            // gbRegistroCliente
            // 
            this.gbRegistroCliente.Controls.Add(this.btnRegistrarCliente);
            this.gbRegistroCliente.Controls.Add(this.txtIdCliente);
            this.gbRegistroCliente.Controls.Add(this.lblTelefonoCliente);
            this.gbRegistroCliente.Controls.Add(this.txtNombreCliente);
            this.gbRegistroCliente.Controls.Add(this.lblDomicilioCliente);
            this.gbRegistroCliente.Controls.Add(this.txtApellidoCliente);
            this.gbRegistroCliente.Controls.Add(this.lblApellidoCliente);
            this.gbRegistroCliente.Controls.Add(this.txtDomicilioCliente);
            this.gbRegistroCliente.Controls.Add(this.lblNombreCliente);
            this.gbRegistroCliente.Controls.Add(this.txtTelefonoCliente);
            this.gbRegistroCliente.Controls.Add(this.lblIdCliente);
            this.gbRegistroCliente.Location = new System.Drawing.Point(12, 12);
            this.gbRegistroCliente.Name = "gbRegistroCliente";
            this.gbRegistroCliente.Size = new System.Drawing.Size(112, 290);
            this.gbRegistroCliente.TabIndex = 11;
            this.gbRegistroCliente.TabStop = false;
            this.gbRegistroCliente.Text = "Registrar Cliente";
            this.gbRegistroCliente.Enter += new System.EventHandler(this.dbRegistroCliente_Enter);
            // 
            // gbDatosPago
            // 
            this.gbDatosPago.Controls.Add(this.lblSubtotalCuotas);
            this.gbDatosPago.Controls.Add(this.lblSubtotalVenta);
            this.gbDatosPago.Controls.Add(this.cbTipoTarjeta);
            this.gbDatosPago.Controls.Add(this.txtAñoTarjeta);
            this.gbDatosPago.Controls.Add(this.btnVenta);
            this.gbDatosPago.Controls.Add(this.txtNumeroTarjeta);
            this.gbDatosPago.Controls.Add(this.lblCuotas);
            this.gbDatosPago.Controls.Add(this.txtMesTarjeta);
            this.gbDatosPago.Controls.Add(this.lblTipoTarjeta);
            this.gbDatosPago.Controls.Add(this.txtCCV);
            this.gbDatosPago.Controls.Add(this.lblCCV);
            this.gbDatosPago.Controls.Add(this.lblMesYAñoVenc);
            this.gbDatosPago.Controls.Add(this.txtCuotas);
            this.gbDatosPago.Controls.Add(this.lblNumTarjeta);
            this.gbDatosPago.Location = new System.Drawing.Point(130, 12);
            this.gbDatosPago.Name = "gbDatosPago";
            this.gbDatosPago.Size = new System.Drawing.Size(272, 290);
            this.gbDatosPago.TabIndex = 12;
            this.gbDatosPago.TabStop = false;
            this.gbDatosPago.Text = "Ingresar Datos Pago";
            // 
            // lblSubtotalCuotas
            // 
            this.lblSubtotalCuotas.AutoSize = true;
            this.lblSubtotalCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalCuotas.Location = new System.Drawing.Point(1, 233);
            this.lblSubtotalCuotas.Name = "lblSubtotalCuotas";
            this.lblSubtotalCuotas.Size = new System.Drawing.Size(134, 25);
            this.lblSubtotalCuotas.TabIndex = 14;
            this.lblSubtotalCuotas.Text = "Cada cuota: ";
            // 
            // lblSubtotalVenta
            // 
            this.lblSubtotalVenta.AutoSize = true;
            this.lblSubtotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotalVenta.Location = new System.Drawing.Point(1, 192);
            this.lblSubtotalVenta.Name = "lblSubtotalVenta";
            this.lblSubtotalVenta.Size = new System.Drawing.Size(97, 25);
            this.lblSubtotalVenta.TabIndex = 13;
            this.lblSubtotalVenta.Text = "Subtotal:";
            // 
            // cbTipoTarjeta
            // 
            this.cbTipoTarjeta.FormattingEnabled = true;
            this.cbTipoTarjeta.Items.AddRange(new object[] {
            "Débito",
            "Crédito"});
            this.cbTipoTarjeta.Location = new System.Drawing.Point(6, 170);
            this.cbTipoTarjeta.Name = "cbTipoTarjeta";
            this.cbTipoTarjeta.Size = new System.Drawing.Size(110, 21);
            this.cbTipoTarjeta.TabIndex = 4;
            this.cbTipoTarjeta.SelectedIndexChanged += new System.EventHandler(this.eventoDropDownTarjeta);
            // 
            // txtAñoTarjeta
            // 
            this.txtAñoTarjeta.Location = new System.Drawing.Point(74, 79);
            this.txtAñoTarjeta.Name = "txtAñoTarjeta";
            this.txtAñoTarjeta.Size = new System.Drawing.Size(42, 20);
            this.txtAñoTarjeta.TabIndex = 2;
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(6, 261);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(100, 23);
            this.btnVenta.TabIndex = 6;
            this.btnVenta.Text = "Venta";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(6, 33);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(253, 20);
            this.txtNumeroTarjeta.TabIndex = 0;
            // 
            // lblCuotas
            // 
            this.lblCuotas.AutoSize = true;
            this.lblCuotas.Location = new System.Drawing.Point(122, 155);
            this.lblCuotas.Name = "lblCuotas";
            this.lblCuotas.Size = new System.Drawing.Size(40, 13);
            this.lblCuotas.TabIndex = 9;
            this.lblCuotas.Text = "Cuotas";
            // 
            // txtMesTarjeta
            // 
            this.txtMesTarjeta.Location = new System.Drawing.Point(6, 79);
            this.txtMesTarjeta.Name = "txtMesTarjeta";
            this.txtMesTarjeta.Size = new System.Drawing.Size(42, 20);
            this.txtMesTarjeta.TabIndex = 1;
            this.txtMesTarjeta.TextChanged += new System.EventHandler(this.validarTxtFecha);
            // 
            // lblTipoTarjeta
            // 
            this.lblTipoTarjeta.AutoSize = true;
            this.lblTipoTarjeta.Location = new System.Drawing.Point(3, 155);
            this.lblTipoTarjeta.Name = "lblTipoTarjeta";
            this.lblTipoTarjeta.Size = new System.Drawing.Size(28, 13);
            this.lblTipoTarjeta.TabIndex = 8;
            this.lblTipoTarjeta.Text = "Tipo";
            // 
            // txtCCV
            // 
            this.txtCCV.Location = new System.Drawing.Point(6, 127);
            this.txtCCV.Name = "txtCCV";
            this.txtCCV.Size = new System.Drawing.Size(42, 20);
            this.txtCCV.TabIndex = 3;
            // 
            // lblCCV
            // 
            this.lblCCV.AutoSize = true;
            this.lblCCV.Location = new System.Drawing.Point(3, 111);
            this.lblCCV.Name = "lblCCV";
            this.lblCCV.Size = new System.Drawing.Size(28, 13);
            this.lblCCV.TabIndex = 7;
            this.lblCCV.Text = "CCV";
            // 
            // lblMesYAñoVenc
            // 
            this.lblMesYAñoVenc.AutoSize = true;
            this.lblMesYAñoVenc.Location = new System.Drawing.Point(3, 63);
            this.lblMesYAñoVenc.Name = "lblMesYAñoVenc";
            this.lblMesYAñoVenc.Size = new System.Drawing.Size(110, 13);
            this.lblMesYAñoVenc.TabIndex = 6;
            this.lblMesYAñoVenc.Text = "Mes Y Año expiración";
            // 
            // txtCuotas
            // 
            this.txtCuotas.Location = new System.Drawing.Point(125, 171);
            this.txtCuotas.Name = "txtCuotas";
            this.txtCuotas.Size = new System.Drawing.Size(134, 20);
            this.txtCuotas.TabIndex = 5;
            this.txtCuotas.TextChanged += new System.EventHandler(this.validacionTxtBoxCuotas);
            // 
            // lblNumTarjeta
            // 
            this.lblNumTarjeta.AutoSize = true;
            this.lblNumTarjeta.Location = new System.Drawing.Point(3, 17);
            this.lblNumTarjeta.Name = "lblNumTarjeta";
            this.lblNumTarjeta.Size = new System.Drawing.Size(80, 13);
            this.lblNumTarjeta.TabIndex = 5;
            this.lblNumTarjeta.Text = "Número Tarjeta";
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 308);
            this.Controls.Add(this.gbDatosPago);
            this.Controls.Add(this.gbRegistroCliente);
            this.Name = "FrmClientes";
            this.Text = "FrmClientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.gbRegistroCliente.ResumeLayout(false);
            this.gbRegistroCliente.PerformLayout();
            this.gbDatosPago.ResumeLayout(false);
            this.gbDatosPago.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtApellidoCliente;
        private System.Windows.Forms.TextBox txtDomicilioCliente;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblApellidoCliente;
        private System.Windows.Forms.Label lblDomicilioCliente;
        private System.Windows.Forms.Label lblTelefonoCliente;
        private System.Windows.Forms.Button btnRegistrarCliente;
        private System.Windows.Forms.GroupBox gbRegistroCliente;
        private System.Windows.Forms.GroupBox gbDatosPago;
        private System.Windows.Forms.Label lblSubtotalVenta;
        private System.Windows.Forms.ComboBox cbTipoTarjeta;
        private System.Windows.Forms.TextBox txtAñoTarjeta;
        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.Label lblCuotas;
        private System.Windows.Forms.TextBox txtMesTarjeta;
        private System.Windows.Forms.Label lblTipoTarjeta;
        private System.Windows.Forms.TextBox txtCCV;
        private System.Windows.Forms.Label lblCCV;
        private System.Windows.Forms.Label lblMesYAñoVenc;
        private System.Windows.Forms.TextBox txtCuotas;
        private System.Windows.Forms.Label lblNumTarjeta;
        private System.Windows.Forms.Label lblSubtotalCuotas;
    }
}