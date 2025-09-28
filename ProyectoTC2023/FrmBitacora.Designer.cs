namespace ProyectoTC2023 {
    partial class FrmBitacora {
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
            this.cbTipoBit = new System.Windows.Forms.ComboBox();
            this.cbNomUsuBit = new System.Windows.Forms.ComboBox();
            this.cbCriticidadBit = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblTipoBit = new System.Windows.Forms.Label();
            this.cbModuloBit = new System.Windows.Forms.ComboBox();
            this.lblNomUsuBit = new System.Windows.Forms.Label();
            this.lblMBit = new System.Windows.Forms.Label();
            this.lblCABit = new System.Windows.Forms.Label();
            this.lblFechaDesdeBit = new System.Windows.Forms.Label();
            this.lblFechaHastaBit = new System.Windows.Forms.Label();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnLookBit = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblNombreBit = new System.Windows.Forms.Label();
            this.lblApellidoBit = new System.Windows.Forms.Label();
            this.txtNombreBit = new System.Windows.Forms.TextBox();
            this.txtApellidoBit = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cbMarcaProductoBit = new System.Windows.Forms.ComboBox();
            this.lblMarcaProdBit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(16, 144);
            this.dgvBitacora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.RowHeadersWidth = 51;
            this.dgvBitacora.Size = new System.Drawing.Size(1049, 395);
            this.dgvBitacora.TabIndex = 0;
            this.dgvBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellClick);
            this.dgvBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellContentClick);
            // 
            // cbTipoBit
            // 
            this.cbTipoBit.FormattingEnabled = true;
            this.cbTipoBit.Items.AddRange(new object[] {
            "Cambios",
            "Eventos"});
            this.cbTipoBit.Location = new System.Drawing.Point(16, 36);
            this.cbTipoBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTipoBit.Name = "cbTipoBit";
            this.cbTipoBit.Size = new System.Drawing.Size(160, 24);
            this.cbTipoBit.TabIndex = 1;
            // 
            // cbNomUsuBit
            // 
            this.cbNomUsuBit.FormattingEnabled = true;
            this.cbNomUsuBit.Location = new System.Drawing.Point(16, 98);
            this.cbNomUsuBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.cbCriticidadBit.Location = new System.Drawing.Point(487, 98);
            this.cbCriticidadBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCriticidadBit.Name = "cbCriticidadBit";
            this.cbCriticidadBit.Size = new System.Drawing.Size(113, 24);
            this.cbCriticidadBit.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(841, 100);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(224, 22);
            this.dtpHasta.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(608, 100);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(225, 22);
            this.dtpDesde.TabIndex = 6;
            // 
            // lblTipoBit
            // 
            this.lblTipoBit.AutoSize = true;
            this.lblTipoBit.Location = new System.Drawing.Point(12, 16);
            this.lblTipoBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBit.Name = "lblTipoBit";
            this.lblTipoBit.Size = new System.Drawing.Size(106, 16);
            this.lblTipoBit.TabIndex = 7;
            this.lblTipoBit.Text = "Tipo de bitácora";
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
            this.cbModuloBit.Location = new System.Drawing.Point(185, 98);
            this.cbModuloBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbModuloBit.Name = "cbModuloBit";
            this.cbModuloBit.Size = new System.Drawing.Size(133, 24);
            this.cbModuloBit.TabIndex = 3;
            // 
            // lblNomUsuBit
            // 
            this.lblNomUsuBit.AutoSize = true;
            this.lblNomUsuBit.Location = new System.Drawing.Point(16, 79);
            this.lblNomUsuBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUsuBit.Name = "lblNomUsuBit";
            this.lblNomUsuBit.Size = new System.Drawing.Size(122, 16);
            this.lblNomUsuBit.TabIndex = 8;
            this.lblNomUsuBit.Text = "Nombre de usuario";
            // 
            // lblMBit
            // 
            this.lblMBit.AutoSize = true;
            this.lblMBit.Location = new System.Drawing.Point(181, 79);
            this.lblMBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMBit.Name = "lblMBit";
            this.lblMBit.Size = new System.Drawing.Size(52, 16);
            this.lblMBit.TabIndex = 9;
            this.lblMBit.Text = "Modulo";
            // 
            // lblCABit
            // 
            this.lblCABit.AutoSize = true;
            this.lblCABit.Location = new System.Drawing.Point(484, 79);
            this.lblCABit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCABit.Name = "lblCABit";
            this.lblCABit.Size = new System.Drawing.Size(63, 16);
            this.lblCABit.TabIndex = 10;
            this.lblCABit.Text = "Criticidad";
            // 
            // lblFechaDesdeBit
            // 
            this.lblFechaDesdeBit.AutoSize = true;
            this.lblFechaDesdeBit.Location = new System.Drawing.Point(605, 79);
            this.lblFechaDesdeBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDesdeBit.Name = "lblFechaDesdeBit";
            this.lblFechaDesdeBit.Size = new System.Drawing.Size(48, 16);
            this.lblFechaDesdeBit.TabIndex = 11;
            this.lblFechaDesdeBit.Text = "Desde";
            // 
            // lblFechaHastaBit
            // 
            this.lblFechaHastaBit.AutoSize = true;
            this.lblFechaHastaBit.Location = new System.Drawing.Point(838, 79);
            this.lblFechaHastaBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHastaBit.Name = "lblFechaHastaBit";
            this.lblFechaHastaBit.Size = new System.Drawing.Size(43, 16);
            this.lblFechaHastaBit.TabIndex = 12;
            this.lblFechaHastaBit.Text = "Hasta";
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(1073, 511);
            this.btnRollback.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(100, 28);
            this.btnRollback.TabIndex = 13;
            this.btnRollback.Text = "Rollback";
            this.btnRollback.UseVisualStyleBackColor = true;
            this.btnRollback.Visible = false;
            this.btnRollback.Click += new System.EventHandler(this.btnRollback_Click);
            // 
            // btnLookBit
            // 
            this.btnLookBit.Location = new System.Drawing.Point(1073, 96);
            this.btnLookBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLookBit.Name = "btnLookBit";
            this.btnLookBit.Size = new System.Drawing.Size(100, 28);
            this.btnLookBit.TabIndex = 14;
            this.btnLookBit.Text = "Buscar";
            this.btnLookBit.UseVisualStyleBackColor = true;
            this.btnLookBit.Click += new System.EventHandler(this.btnLookBit_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(185, 33);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(100, 28);
            this.btnAplicar.TabIndex = 15;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lblNombreBit
            // 
            this.lblNombreBit.AutoSize = true;
            this.lblNombreBit.Location = new System.Drawing.Point(1069, 144);
            this.lblNombreBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreBit.Name = "lblNombreBit";
            this.lblNombreBit.Size = new System.Drawing.Size(56, 16);
            this.lblNombreBit.TabIndex = 16;
            this.lblNombreBit.Text = "Nombre";
            // 
            // lblApellidoBit
            // 
            this.lblApellidoBit.AutoSize = true;
            this.lblApellidoBit.Location = new System.Drawing.Point(1068, 222);
            this.lblApellidoBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellidoBit.Name = "lblApellidoBit";
            this.lblApellidoBit.Size = new System.Drawing.Size(57, 16);
            this.lblApellidoBit.TabIndex = 17;
            this.lblApellidoBit.Text = "Apellido";
            // 
            // txtNombreBit
            // 
            this.txtNombreBit.Location = new System.Drawing.Point(1073, 164);
            this.txtNombreBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreBit.Name = "txtNombreBit";
            this.txtNombreBit.ReadOnly = true;
            this.txtNombreBit.Size = new System.Drawing.Size(249, 22);
            this.txtNombreBit.TabIndex = 18;
            // 
            // txtApellidoBit
            // 
            this.txtApellidoBit.Location = new System.Drawing.Point(1072, 241);
            this.txtApellidoBit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApellidoBit.Name = "txtApellidoBit";
            this.txtApellidoBit.ReadOnly = true;
            this.txtApellidoBit.Size = new System.Drawing.Size(249, 22);
            this.txtApellidoBit.TabIndex = 19;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(1224, 511);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 28);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1219, 96);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.cbMarcaProductoBit.Location = new System.Drawing.Point(336, 98);
            this.cbMarcaProductoBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbMarcaProductoBit.Name = "cbMarcaProductoBit";
            this.cbMarcaProductoBit.Size = new System.Drawing.Size(133, 24);
            this.cbMarcaProductoBit.TabIndex = 22;
            this.cbMarcaProductoBit.TabStop = false;
            // 
            // lblMarcaProdBit
            // 
            this.lblMarcaProdBit.AutoSize = true;
            this.lblMarcaProdBit.Location = new System.Drawing.Point(333, 80);
            this.lblMarcaProdBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarcaProdBit.Name = "lblMarcaProdBit";
            this.lblMarcaProdBit.Size = new System.Drawing.Size(102, 16);
            this.lblMarcaProdBit.TabIndex = 23;
            this.lblMarcaProdBit.Text = "Marca Producto";
            this.lblMarcaProdBit.Visible = false;
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 554);
            this.Controls.Add(this.lblMarcaProdBit);
            this.Controls.Add(this.cbMarcaProductoBit);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtApellidoBit);
            this.Controls.Add(this.txtNombreBit);
            this.Controls.Add(this.lblApellidoBit);
            this.Controls.Add(this.lblNombreBit);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnLookBit);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.lblFechaHastaBit);
            this.Controls.Add(this.lblFechaDesdeBit);
            this.Controls.Add(this.lblCABit);
            this.Controls.Add(this.lblMBit);
            this.Controls.Add(this.lblNomUsuBit);
            this.Controls.Add(this.lblTipoBit);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.cbModuloBit);
            this.Controls.Add(this.cbCriticidadBit);
            this.Controls.Add(this.cbNomUsuBit);
            this.Controls.Add(this.cbTipoBit);
            this.Controls.Add(this.dgvBitacora);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBitacora";
            this.Text = "FrmBitacora";
            this.Load += new System.EventHandler(this.FrmBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.ComboBox cbTipoBit;
        private System.Windows.Forms.ComboBox cbNomUsuBit;
        private System.Windows.Forms.ComboBox cbCriticidadBit;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblTipoBit;
        private System.Windows.Forms.ComboBox cbModuloBit;
        private System.Windows.Forms.Label lblNomUsuBit;
        private System.Windows.Forms.Label lblMBit;
        private System.Windows.Forms.Label lblCABit;
        private System.Windows.Forms.Label lblFechaDesdeBit;
        private System.Windows.Forms.Label lblFechaHastaBit;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnLookBit;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label lblNombreBit;
        private System.Windows.Forms.Label lblApellidoBit;
        private System.Windows.Forms.TextBox txtNombreBit;
        private System.Windows.Forms.TextBox txtApellidoBit;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cbMarcaProductoBit;
        private System.Windows.Forms.Label lblMarcaProdBit;
    }
}