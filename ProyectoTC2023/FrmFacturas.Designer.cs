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
            this.dgvVentasNoF.Location = new System.Drawing.Point(8, 39);
            this.dgvVentasNoF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvVentasNoF.Name = "dgvVentasNoF";
            this.dgvVentasNoF.RowHeadersWidth = 51;
            this.dgvVentasNoF.Size = new System.Drawing.Size(717, 467);
            this.dgvVentasNoF.TabIndex = 0;
            // 
            // gbVentasNoF
            // 
            this.gbVentasNoF.Controls.Add(this.btnFacturar);
            this.gbVentasNoF.Controls.Add(this.dgvVentasNoF);
            this.gbVentasNoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVentasNoF.Location = new System.Drawing.Point(16, 15);
            this.gbVentasNoF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVentasNoF.Name = "gbVentasNoF";
            this.gbVentasNoF.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVentasNoF.Size = new System.Drawing.Size(914, 514);
            this.gbVentasNoF.TabIndex = 1;
            this.gbVentasNoF.TabStop = false;
            this.gbVentasNoF.Text = "Ventas no facturadas";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(733, 453);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(173, 53);
            this.btnFacturar.TabIndex = 11;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // FrmFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 535);
            this.Controls.Add(this.gbVentasNoF);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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