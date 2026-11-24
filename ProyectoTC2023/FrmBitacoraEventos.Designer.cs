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
            this.cbEventoEnum = new System.Windows.Forms.ComboBox();
            this.lblEvento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(13, 89);
            this.dgvBitacora.Margin = new System.Windows.Forms.Padding(4);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.RowHeadersWidth = 51;
            this.dgvBitacora.Size = new System.Drawing.Size(1052, 540);
            this.dgvBitacora.TabIndex = 0;
            this.dgvBitacora.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellClick);
            this.dgvBitacora.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBitacora_CellContentClick);
            // 
            // cbNomUsuBit
            // 
            this.cbNomUsuBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNomUsuBit.FormattingEnabled = true;
            this.cbNomUsuBit.Location = new System.Drawing.Point(15, 48);
            this.cbNomUsuBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbNomUsuBit.Name = "cbNomUsuBit";
            this.cbNomUsuBit.Size = new System.Drawing.Size(160, 33);
            this.cbNomUsuBit.TabIndex = 2;
            // 
            // cbCriticidadBit
            // 
            this.cbCriticidadBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCriticidadBit.FormattingEnabled = true;
            this.cbCriticidadBit.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbCriticidadBit.Location = new System.Drawing.Point(485, 48);
            this.cbCriticidadBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbCriticidadBit.Name = "cbCriticidadBit";
            this.cbCriticidadBit.Size = new System.Drawing.Size(113, 33);
            this.cbCriticidadBit.TabIndex = 3;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Location = new System.Drawing.Point(841, 46);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(224, 30);
            this.dtpHasta.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Location = new System.Drawing.Point(608, 46);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(225, 30);
            this.dtpDesde.TabIndex = 6;
            // 
            // cbModuloBit
            // 
            this.cbModuloBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModuloBit.FormattingEnabled = true;
            this.cbModuloBit.Items.AddRange(new object[] {
            "Cliente",
            "Factura",
            "Producto",
            "Usuarios",
            "Venta"});
            this.cbModuloBit.Location = new System.Drawing.Point(193, 48);
            this.cbModuloBit.Margin = new System.Windows.Forms.Padding(4);
            this.cbModuloBit.Name = "cbModuloBit";
            this.cbModuloBit.Size = new System.Drawing.Size(133, 33);
            this.cbModuloBit.TabIndex = 3;
            // 
            // lblNomUsuBit
            // 
            this.lblNomUsuBit.AutoSize = true;
            this.lblNomUsuBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUsuBit.Location = new System.Drawing.Point(13, 11);
            this.lblNomUsuBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomUsuBit.Name = "lblNomUsuBit";
            this.lblNomUsuBit.Size = new System.Drawing.Size(177, 25);
            this.lblNomUsuBit.TabIndex = 8;
            this.lblNomUsuBit.Text = "Nombre de usuario";
            // 
            // lblMBit
            // 
            this.lblMBit.AutoSize = true;
            this.lblMBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMBit.Location = new System.Drawing.Point(188, 11);
            this.lblMBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMBit.Name = "lblMBit";
            this.lblMBit.Size = new System.Drawing.Size(77, 25);
            this.lblMBit.TabIndex = 9;
            this.lblMBit.Text = "Modulo";
            // 
            // lblCABit
            // 
            this.lblCABit.AutoSize = true;
            this.lblCABit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCABit.Location = new System.Drawing.Point(480, 11);
            this.lblCABit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCABit.Name = "lblCABit";
            this.lblCABit.Size = new System.Drawing.Size(93, 25);
            this.lblCABit.TabIndex = 10;
            this.lblCABit.Text = "Criticidad";
            // 
            // lblFechaDesdeBit
            // 
            this.lblFechaDesdeBit.AutoSize = true;
            this.lblFechaDesdeBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesdeBit.Location = new System.Drawing.Point(603, 11);
            this.lblFechaDesdeBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaDesdeBit.Name = "lblFechaDesdeBit";
            this.lblFechaDesdeBit.Size = new System.Drawing.Size(69, 25);
            this.lblFechaDesdeBit.TabIndex = 11;
            this.lblFechaDesdeBit.Text = "Desde";
            // 
            // lblFechaHastaBit
            // 
            this.lblFechaHastaBit.AutoSize = true;
            this.lblFechaHastaBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHastaBit.Location = new System.Drawing.Point(836, 11);
            this.lblFechaHastaBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaHastaBit.Name = "lblFechaHastaBit";
            this.lblFechaHastaBit.Size = new System.Drawing.Size(63, 25);
            this.lblFechaHastaBit.TabIndex = 12;
            this.lblFechaHastaBit.Text = "Hasta";
            // 
            // btnLookBit
            // 
            this.btnLookBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLookBit.Location = new System.Drawing.Point(1073, 46);
            this.btnLookBit.Margin = new System.Windows.Forms.Padding(4);
            this.btnLookBit.Name = "btnLookBit";
            this.btnLookBit.Size = new System.Drawing.Size(101, 41);
            this.btnLookBit.TabIndex = 14;
            this.btnLookBit.Text = "Buscar";
            this.btnLookBit.UseVisualStyleBackColor = true;
            this.btnLookBit.Click += new System.EventHandler(this.btnLookBit_Click);
            // 
            // lblNombreBit
            // 
            this.lblNombreBit.AutoSize = true;
            this.lblNombreBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreBit.Location = new System.Drawing.Point(1073, 426);
            this.lblNombreBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreBit.Name = "lblNombreBit";
            this.lblNombreBit.Size = new System.Drawing.Size(81, 25);
            this.lblNombreBit.TabIndex = 16;
            this.lblNombreBit.Text = "Nombre";
            // 
            // lblApellidoBit
            // 
            this.lblApellidoBit.AutoSize = true;
            this.lblApellidoBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoBit.Location = new System.Drawing.Point(1073, 498);
            this.lblApellidoBit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellidoBit.Name = "lblApellidoBit";
            this.lblApellidoBit.Size = new System.Drawing.Size(82, 25);
            this.lblApellidoBit.TabIndex = 17;
            this.lblApellidoBit.Text = "Apellido";
            // 
            // txtNombreBit
            // 
            this.txtNombreBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreBit.Location = new System.Drawing.Point(1078, 455);
            this.txtNombreBit.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreBit.Name = "txtNombreBit";
            this.txtNombreBit.ReadOnly = true;
            this.txtNombreBit.Size = new System.Drawing.Size(249, 30);
            this.txtNombreBit.TabIndex = 18;
            // 
            // txtApellidoBit
            // 
            this.txtApellidoBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidoBit.Location = new System.Drawing.Point(1078, 527);
            this.txtApellidoBit.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellidoBit.Name = "txtApellidoBit";
            this.txtApellidoBit.ReadOnly = true;
            this.txtApellidoBit.Size = new System.Drawing.Size(249, 30);
            this.txtApellidoBit.TabIndex = 19;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Location = new System.Drawing.Point(1227, 588);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(100, 41);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(1182, 46);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(101, 41);
            this.btnLimpiar.TabIndex = 21;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cbEventoEnum
            // 
            this.cbEventoEnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEventoEnum.FormattingEnabled = true;
            this.cbEventoEnum.Items.AddRange(new object[] {
            "Cliente",
            "Factura",
            "Producto",
            "Usuarios",
            "Venta"});
            this.cbEventoEnum.Location = new System.Drawing.Point(336, 48);
            this.cbEventoEnum.Margin = new System.Windows.Forms.Padding(4);
            this.cbEventoEnum.Name = "cbEventoEnum";
            this.cbEventoEnum.Size = new System.Drawing.Size(133, 33);
            this.cbEventoEnum.TabIndex = 22;
            this.cbEventoEnum.TabStop = false;
            // 
            // lblEvento
            // 
            this.lblEvento.AutoSize = true;
            this.lblEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvento.Location = new System.Drawing.Point(331, 11);
            this.lblEvento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEvento.Name = "lblEvento";
            this.lblEvento.Size = new System.Drawing.Size(73, 25);
            this.lblEvento.TabIndex = 23;
            this.lblEvento.Text = "Evento";
            this.lblEvento.Visible = false;
            // 
            // FrmBitacoraEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 642);
            this.Controls.Add(this.lblEvento);
            this.Controls.Add(this.cbEventoEnum);
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
        private System.Windows.Forms.ComboBox cbEventoEnum;
        private System.Windows.Forms.Label lblEvento;
    }
}