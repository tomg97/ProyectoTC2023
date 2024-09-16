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
            this.lblTablaBit = new System.Windows.Forms.Label();
            this.lblCriticidadBit = new System.Windows.Forms.Label();
            this.lblFechaDesdeBit = new System.Windows.Forms.Label();
            this.lblFechaHastaBit = new System.Windows.Forms.Label();
            this.btnRollback = new System.Windows.Forms.Button();
            this.btnLookBit = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.lblNombreBit = new System.Windows.Forms.Label();
            this.lblApellidoBit = new System.Windows.Forms.Label();
            this.txtNombreBit = new System.Windows.Forms.TextBox();
            this.txtApellidoBit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(12, 117);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.Size = new System.Drawing.Size(787, 321);
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
            this.cbTipoBit.Location = new System.Drawing.Point(12, 29);
            this.cbTipoBit.Name = "cbTipoBit";
            this.cbTipoBit.Size = new System.Drawing.Size(121, 21);
            this.cbTipoBit.TabIndex = 1;
            // 
            // cbNomUsuBit
            // 
            this.cbNomUsuBit.FormattingEnabled = true;
            this.cbNomUsuBit.Location = new System.Drawing.Point(12, 80);
            this.cbNomUsuBit.Name = "cbNomUsuBit";
            this.cbNomUsuBit.Size = new System.Drawing.Size(121, 21);
            this.cbNomUsuBit.TabIndex = 2;
            // 
            // cbCriticidadBit
            // 
            this.cbCriticidadBit.FormattingEnabled = true;
            this.cbCriticidadBit.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbCriticidadBit.Location = new System.Drawing.Point(266, 80);
            this.cbCriticidadBit.Name = "cbCriticidadBit";
            this.cbCriticidadBit.Size = new System.Drawing.Size(121, 21);
            this.cbCriticidadBit.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(599, 81);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(393, 81);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 6;
            // 
            // lblTipoBit
            // 
            this.lblTipoBit.AutoSize = true;
            this.lblTipoBit.Location = new System.Drawing.Point(9, 13);
            this.lblTipoBit.Name = "lblTipoBit";
            this.lblTipoBit.Size = new System.Drawing.Size(84, 13);
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
            this.cbModuloBit.Location = new System.Drawing.Point(139, 80);
            this.cbModuloBit.Name = "cbModuloBit";
            this.cbModuloBit.Size = new System.Drawing.Size(121, 21);
            this.cbModuloBit.TabIndex = 3;
            // 
            // lblNomUsuBit
            // 
            this.lblNomUsuBit.AutoSize = true;
            this.lblNomUsuBit.Location = new System.Drawing.Point(12, 64);
            this.lblNomUsuBit.Name = "lblNomUsuBit";
            this.lblNomUsuBit.Size = new System.Drawing.Size(96, 13);
            this.lblNomUsuBit.TabIndex = 8;
            this.lblNomUsuBit.Text = "Nombre de usuario";
            // 
            // lblTablaBit
            // 
            this.lblTablaBit.AutoSize = true;
            this.lblTablaBit.Location = new System.Drawing.Point(136, 64);
            this.lblTablaBit.Name = "lblTablaBit";
            this.lblTablaBit.Size = new System.Drawing.Size(42, 13);
            this.lblTablaBit.TabIndex = 9;
            this.lblTablaBit.Text = "Modulo";
            // 
            // lblCriticidadBit
            // 
            this.lblCriticidadBit.AutoSize = true;
            this.lblCriticidadBit.Location = new System.Drawing.Point(263, 64);
            this.lblCriticidadBit.Name = "lblCriticidadBit";
            this.lblCriticidadBit.Size = new System.Drawing.Size(50, 13);
            this.lblCriticidadBit.TabIndex = 10;
            this.lblCriticidadBit.Text = "Criticidad";
            // 
            // lblFechaDesdeBit
            // 
            this.lblFechaDesdeBit.AutoSize = true;
            this.lblFechaDesdeBit.Location = new System.Drawing.Point(390, 65);
            this.lblFechaDesdeBit.Name = "lblFechaDesdeBit";
            this.lblFechaDesdeBit.Size = new System.Drawing.Size(38, 13);
            this.lblFechaDesdeBit.TabIndex = 11;
            this.lblFechaDesdeBit.Text = "Desde";
            // 
            // lblFechaHastaBit
            // 
            this.lblFechaHastaBit.AutoSize = true;
            this.lblFechaHastaBit.Location = new System.Drawing.Point(596, 64);
            this.lblFechaHastaBit.Name = "lblFechaHastaBit";
            this.lblFechaHastaBit.Size = new System.Drawing.Size(35, 13);
            this.lblFechaHastaBit.TabIndex = 12;
            this.lblFechaHastaBit.Text = "Hasta";
            // 
            // btnRollback
            // 
            this.btnRollback.Location = new System.Drawing.Point(805, 415);
            this.btnRollback.Name = "btnRollback";
            this.btnRollback.Size = new System.Drawing.Size(75, 23);
            this.btnRollback.TabIndex = 13;
            this.btnRollback.Text = "Rollback";
            this.btnRollback.UseVisualStyleBackColor = true;
            // 
            // btnLookBit
            // 
            this.btnLookBit.Location = new System.Drawing.Point(805, 78);
            this.btnLookBit.Name = "btnLookBit";
            this.btnLookBit.Size = new System.Drawing.Size(75, 23);
            this.btnLookBit.TabIndex = 14;
            this.btnLookBit.Text = "Buscar";
            this.btnLookBit.UseVisualStyleBackColor = true;
            this.btnLookBit.Click += new System.EventHandler(this.btnLookBit_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(139, 27);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 15;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // lblNombreBit
            // 
            this.lblNombreBit.AutoSize = true;
            this.lblNombreBit.Location = new System.Drawing.Point(802, 117);
            this.lblNombreBit.Name = "lblNombreBit";
            this.lblNombreBit.Size = new System.Drawing.Size(44, 13);
            this.lblNombreBit.TabIndex = 16;
            this.lblNombreBit.Text = "Nombre";
            // 
            // lblApellidoBit
            // 
            this.lblApellidoBit.AutoSize = true;
            this.lblApellidoBit.Location = new System.Drawing.Point(801, 180);
            this.lblApellidoBit.Name = "lblApellidoBit";
            this.lblApellidoBit.Size = new System.Drawing.Size(44, 13);
            this.lblApellidoBit.TabIndex = 17;
            this.lblApellidoBit.Text = "Apellido";
            // 
            // txtNombreBit
            // 
            this.txtNombreBit.Location = new System.Drawing.Point(805, 133);
            this.txtNombreBit.Name = "txtNombreBit";
            this.txtNombreBit.ReadOnly = true;
            this.txtNombreBit.Size = new System.Drawing.Size(188, 20);
            this.txtNombreBit.TabIndex = 18;
            // 
            // txtApellidoBit
            // 
            this.txtApellidoBit.Location = new System.Drawing.Point(804, 196);
            this.txtApellidoBit.Name = "txtApellidoBit";
            this.txtApellidoBit.ReadOnly = true;
            this.txtApellidoBit.Size = new System.Drawing.Size(188, 20);
            this.txtApellidoBit.TabIndex = 19;
            // 
            // FrmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 450);
            this.Controls.Add(this.txtApellidoBit);
            this.Controls.Add(this.txtNombreBit);
            this.Controls.Add(this.lblApellidoBit);
            this.Controls.Add(this.lblNombreBit);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnLookBit);
            this.Controls.Add(this.btnRollback);
            this.Controls.Add(this.lblFechaHastaBit);
            this.Controls.Add(this.lblFechaDesdeBit);
            this.Controls.Add(this.lblCriticidadBit);
            this.Controls.Add(this.lblTablaBit);
            this.Controls.Add(this.lblNomUsuBit);
            this.Controls.Add(this.lblTipoBit);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.cbModuloBit);
            this.Controls.Add(this.cbCriticidadBit);
            this.Controls.Add(this.cbNomUsuBit);
            this.Controls.Add(this.cbTipoBit);
            this.Controls.Add(this.dgvBitacora);
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
        private System.Windows.Forms.Label lblTablaBit;
        private System.Windows.Forms.Label lblCriticidadBit;
        private System.Windows.Forms.Label lblFechaDesdeBit;
        private System.Windows.Forms.Label lblFechaHastaBit;
        private System.Windows.Forms.Button btnRollback;
        private System.Windows.Forms.Button btnLookBit;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Label lblNombreBit;
        private System.Windows.Forms.Label lblApellidoBit;
        private System.Windows.Forms.TextBox txtNombreBit;
        private System.Windows.Forms.TextBox txtApellidoBit;
    }
}