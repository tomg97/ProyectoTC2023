namespace ProyectoTC2023 {
    partial class FrmFacturas {
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
            this.dgvVentasNoF = new System.Windows.Forms.DataGridView();
            this.gbVentasNoF = new System.Windows.Forms.GroupBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasNoF)).BeginInit();
            this.gbVentasNoF.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVentasNoF
            // 
            this.dgvVentasNoF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentasNoF.Location = new System.Drawing.Point(6, 19);
            this.dgvVentasNoF.Name = "dgvVentasNoF";
            this.dgvVentasNoF.Size = new System.Drawing.Size(451, 150);
            this.dgvVentasNoF.TabIndex = 0;
            // 
            // gbVentasNoF
            // 
            this.gbVentasNoF.Controls.Add(this.btnFacturar);
            this.gbVentasNoF.Controls.Add(this.dgvVentasNoF);
            this.gbVentasNoF.Location = new System.Drawing.Point(12, 12);
            this.gbVentasNoF.Name = "gbVentasNoF";
            this.gbVentasNoF.Size = new System.Drawing.Size(599, 179);
            this.gbVentasNoF.TabIndex = 1;
            this.gbVentasNoF.TabStop = false;
            this.gbVentasNoF.Text = "Ventas no facturadas";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(463, 146);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(130, 23);
            this.btnFacturar.TabIndex = 11;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbVentasNoF);
            this.Name = "FrmFacturas";
            this.Text = "FrmFacturas";
            this.Load += new System.EventHandler(this.FrmFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentasNoF)).EndInit();
            this.gbVentasNoF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbVentasNoF;
        private System.Windows.Forms.DataGridView dgvVentasNoF;
        private System.Windows.Forms.Button btnFacturar;
    }
}