namespace ProyectoTC2023 {
    partial class FrmPagoProveedor {
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
            this.cbOrdenesCompra = new System.Windows.Forms.ComboBox();
            this.lblOrdenes = new System.Windows.Forms.Label();
            this.dgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // cbOrdenesCompra
            // 
            this.cbOrdenesCompra.BackColor = System.Drawing.SystemColors.Window;
            this.cbOrdenesCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbOrdenesCompra.FormattingEnabled = true;
            this.cbOrdenesCompra.Location = new System.Drawing.Point(12, 33);
            this.cbOrdenesCompra.Name = "cbOrdenesCompra";
            this.cbOrdenesCompra.Size = new System.Drawing.Size(399, 33);
            this.cbOrdenesCompra.TabIndex = 0;
            // 
            // lblOrdenes
            // 
            this.lblOrdenes.AutoSize = true;
            this.lblOrdenes.Location = new System.Drawing.Point(9, 14);
            this.lblOrdenes.Name = "lblOrdenes";
            this.lblOrdenes.Size = new System.Drawing.Size(118, 16);
            this.lblOrdenes.TabIndex = 1;
            this.lblOrdenes.Text = "Órdenes sin pagar";
            // 
            // dgvOrdenCompra
            // 
            this.dgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenCompra.Location = new System.Drawing.Point(12, 72);
            this.dgvOrdenCompra.Name = "dgvOrdenCompra";
            this.dgvOrdenCompra.RowHeadersWidth = 51;
            this.dgvOrdenCompra.RowTemplate.Height = 24;
            this.dgvOrdenCompra.Size = new System.Drawing.Size(750, 430);
            this.dgvOrdenCompra.TabIndex = 2;
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(768, 387);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(98, 51);
            this.btnRechazar.TabIndex = 3;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(768, 451);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(98, 51);
            this.btnPago.TabIndex = 4;
            this.btnPago.Text = "Realizar Pago";
            this.btnPago.UseVisualStyleBackColor = true;
            // 
            // FrmPagoProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 518);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.dgvOrdenCompra);
            this.Controls.Add(this.lblOrdenes);
            this.Controls.Add(this.cbOrdenesCompra);
            this.Name = "FrmPagoProveedor";
            this.Text = "FrmPagoProveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbOrdenesCompra;
        private System.Windows.Forms.Label lblOrdenes;
        private System.Windows.Forms.DataGridView dgvOrdenCompra;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnPago;
    }
}