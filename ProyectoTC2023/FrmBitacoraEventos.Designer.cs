namespace ProyectoTC2023 {
    partial class FrmBitacoraEventos {
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
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.cbNomUsuBit = new System.Windows.Forms.ComboBox();
            this.cbCriticidadBit = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cbModuloBit = new System.Windows.Forms.ComboBox();
            this.lblNomUsuBit = new System.Windows.Forms.Label();
            this.lblMBit = new System.Windows.Forms.Label();
            this.lblCABit = new System.Windows.Forms.Label();
            this.lblFechaDesdeBit = new System.Windows.Forms.Label();
            this.lblFechaHastaBit = new System.Windows.Forms.Label();
            this.btnLookBit = new System.Windows.Forms.Button();
            this.lblNombreBit = new System.Windows.Forms.Label();
            this.lblApellidoBit = new System.Windows.Forms.Label();
            this.txtNombreBit = new System.Windows.Forms.TextBox();
            this.txtApellidoBit = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbMarcaProductoBit = new System.Windows.Forms.ComboBox();
            this.lblEvento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(15, 61);
            this.dgvBitacora.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.RowHeadersWidth = 51;
            this.dgvBitacora.Size = new System.Drawing.Size(1048, 485);
            this.dgvBitacora.TabIndex = 0;
            this.dgvBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellClick);
            this.dgvBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellContentClick);
            // 
            // cbNomUsuBit
            // 
            this.cbNomUsuBit.FormattingEnabled = true;
            this.cbNomUsuBit.Location = new System.Drawing.Point(14, 29);
            this.cbNomUsuBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbNomUsuBit.Name = "cbNomUsuBit";
            this.cbNomUsuBit.Size = new System.Drawing.Size(160, 24);
            this.cbNomUsuBit.TabIndex = 2;
            // 
            // cbCriticidadBit
            // 
            this.cbCriticidadBit.FormattingEnabled = true;
            this.cbCriticidadBit.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbCriticidadBit.Location = new System.Drawing.Point(485, 29);
            this.cbCriticidadBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbCriticidadBit.Name = "cbCriticidadBit";
            this.cbCriticidadBit.Size = new System.Drawing.Size(113, 24);
            this.cbCriticidadBit.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(839, 31);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(224, 22);
            this.dtpHasta.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(606, 31);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(225, 22);
            this.dtpDesde.TabIndex = 6;
            // 
            // cbModuloBit
            // 
            this.cbModuloBit.FormattingEnabled = true;
            this.cbModuloBit.Items.AddRange(new object[] {
            "Cliente",
            "Factura",
            "Producto",
            "Usuarios",
            "Venta"});
            this.cbModuloBit.Location = new System.Drawing.Point(183, 29);
            this.cbModuloBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbModuloBit.Name = "cbModuloBit";
            this.cbModuloBit.Size = new System.Drawing.Size(133, 24);
            this.cbModuloBit.TabIndex = 3;
            // 
            // lblNomUsuBit
            // 
            this.lblNomUsuBit.AutoSize = true;
            this.lblNomUsuBit.Location = new System.Drawing.Point(14, 10);
            this.lblNomUsuBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUsuBit.Name = "lblNomUsuBit";
            this.lblNomUsuBit.Size = new System.Drawing.Size(122, 16);
            this.lblNomUsuBit.TabIndex = 8;
            this.lblNomUsuBit.Text = "Nombre de usuario";
            // 
            // lblMBit
            // 
            this.lblMBit.AutoSize = true;
            this.lblMBit.Location = new System.Drawing.Point(179, 10);
            this.lblMBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMBit.Name = "lblMBit";
            this.lblMBit.Size = new System.Drawing.Size(52, 16);
            this.lblMBit.TabIndex = 9;
            this.lblMBit.Text = "Modulo";
            // 
            // lblCABit
            // 
            this.lblCABit.AutoSize = true;
            this.lblCABit.Location = new System.Drawing.Point(482, 10);
            this.lblCABit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCABit.Name = "lblCABit";
            this.lblCABit.Size = new System.Drawing.Size(63, 16);
            this.lblCABit.TabIndex = 10;
            this.lblCABit.Text = "Criticidad";
            // 
            // lblFechaDesdeBit
            // 
            this.lblFechaDesdeBit.AutoSize = true;
            this.lblFechaDesdeBit.Location = new System.Drawing.Point(603, 10);
            this.lblFechaDesdeBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDesdeBit.Name = "lblFechaDesdeBit";
            this.lblFechaDesdeBit.Size = new System.Drawing.Size(48, 16);
            this.lblFechaDesdeBit.TabIndex = 11;
            this.lblFechaDesdeBit.Text = "Desde";
            // 
            // lblFechaHastaBit
            // 
            this.lblFechaHastaBit.AutoSize = true;
            this.lblFechaHastaBit.Location = new System.Drawing.Point(836, 10);
            this.lblFechaHastaBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHastaBit.Name = "lblFechaHastaBit";
            this.lblFechaHastaBit.Size = new System.Drawing.Size(43, 16);
            this.lblFechaHastaBit.TabIndex = 12;
            this.lblFechaHastaBit.Text = "Hasta";
            // 
            // btnLookBit
            // 
            this.btnLookBit.Location = new System.Drawing.Point(1071, 27);
            this.btnLookBit.Margin = new System.Windows.Forms.Padding(4);
            this.btnLookBit.Name = "btnLookBit";
            this.btnLookBit.Size = new System.Drawing.Size(100, 28);
            this.btnLookBit.TabIndex = 14;
            this.btnLookBit.Text = "Buscar";
            this.btnLookBit.UseVisualStyleBackColor = true;
            this.btnLookBit.Click += new System.EventHandler(this.btnLookBit_Click);
            // 
            // lblNombreBit
            // 
            this.lblNombreBit.AutoSize = true;
            this.lblNombreBit.Location = new System.Drawing.Point(1069, 384);
            this.lblNombreBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreBit.Name = "lblNombreBit";
            this.lblNombreBit.Size = new System.Drawing.Size(56, 16);
            this.lblNombreBit.TabIndex = 16;
            this.lblNombreBit.Text = "Nombre";
            // 
            // lblApellidoBit
            // 
            this.lblApellidoBit.AutoSize = true;
            this.lblApellidoBit.Location = new System.Drawing.Point(1067, 462);
            this.lblApellidoBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellidoBit.Name = "lblApellidoBit";
            this.lblApellidoBit.Size = new System.Drawing.Size(57, 16);
            this.lblApellidoBit.TabIndex = 17;
            this.lblApellidoBit.Text = "Apellido";
            // 
            // txtNombreBit
            // 
            this.txtNombreBit.Location = new System.Drawing.Point(1072, 404);
            this.txtNombreBit.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreBit.Name = "txtNombreBit";
            this.txtNombreBit.ReadOnly = true;
            this.txtNombreBit.Size = new System.Drawing.Size(249, 22);
            this.txtNombreBit.TabIndex = 18;
            // 
            // txtApellidoBit
            // 
            this.txtApellidoBit.Location = new System.Drawing.Point(1071, 481);
            this.txtApellidoBit.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidoBit.Name = "txtApellidoBit";
            this.txtApellidoBit.ReadOnly = true;
            this.txtApellidoBit.Size = new System.Drawing.Size(249, 22);
            this.txtApellidoBit.TabIndex = 19;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1224, 511);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 28);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1217, 27);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbMarcaProductoBit
            // 
            this.cbMarcaProductoBit.FormattingEnabled = true;
            this.cbMarcaProductoBit.Items.AddRange(new object[] {
            "Cliente",
            "Factura",
            "Producto",
            "Usuarios",
            "Venta"});
            this.cbMarcaProductoBit.Location = new System.Drawing.Point(334, 29);
            this.cbMarcaProductoBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbMarcaProductoBit.Name = "cbMarcaProductoBit";
            this.cbMarcaProductoBit.Size = new System.Drawing.Size(133, 24);
            this.cbMarcaProductoBit.TabIndex = 22;
            this.cbMarcaProductoBit.TabStop = false;
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Location = new System.Drawing.Point(331, 11);
            this.lblEvento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(49, 16);
            this.lblEvento.TabIndex = 23;
            this.lblEvento.Text = "Evento";
            this.lblEvento.Visible = false;
            // 
            // FrmBitacoraEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 554);
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.cbMarcaProductoBit);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtApellidoBit);
            this.Controls.Add(this.txtNombreBit);
            this.Controls.Add(this.lblApellidoBit);
            this.Controls.Add(this.lblNombreBit);
            this.Controls.Add(this.btnLookBit);
            this.Controls.Add(this.lblFechaHastaBit);
            this.Controls.Add(this.lblFechaDesdeBit);
            this.Controls.Add(this.lblCABit);
            this.Controls.Add(this.lblMBit);
            this.Controls.Add(this.lblNomUsuBit);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.cbModuloBit);
            this.Controls.Add(this.cbCriticidadBit);
            this.Controls.Add(this.cbNomUsuBit);
            this.Controls.Add(this.dgvBitacora);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBitacoraEventos";
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.ComboBox cbNomUsuBit;
        private System.Windows.Forms.ComboBox cbCriticidadBit;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ComboBox cbModuloBit;
        private System.Windows.Forms.Label lblNomUsuBit;
        private System.Windows.Forms.Label lblMBit;
        private System.Windows.Forms.Label lblCABit;
        private System.Windows.Forms.Label lblFechaDesdeBit;
        private System.Windows.Forms.Label lblFechaHastaBit;
        private System.Windows.Forms.Button btnLookBit;
        private System.Windows.Forms.Label lblNombreBit;
        private System.Windows.Forms.Label lblApellidoBit;
        private System.Windows.Forms.TextBox txtNombreBit;
        private System.Windows.Forms.TextBox txtApellidoBit;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbMarcaProductoBit;
        private System.Windows.Forms.Label lblEvento;
    }
}