namespace ProyectoTC2023 {
    partial class FrmOrdenCompra {
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnRegistroProveedor = new System.Windows.Forms.Button();
            this.btnGenerarOrden = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.labelCotizaciones = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dgvOrdenCompra = new System.Windows.Forms.DataGridView();
            this.cbCotizaciones = new System.Windows.Forms.ComboBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(667, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 58);
            this.button2.TabIndex = 47;
            this.button2.Text = "❓";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnRegistroProveedor
            // 
            this.btnRegistroProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRegistroProveedor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRegistroProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroProveedor.Location = new System.Drawing.Point(626, 419);
            this.btnRegistroProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistroProveedor.Name = "btnRegistroProveedor";
            this.btnRegistroProveedor.Size = new System.Drawing.Size(122, 50);
            this.btnRegistroProveedor.TabIndex = 46;
            this.btnRegistroProveedor.Text = "Registrar proveedor";
            this.btnRegistroProveedor.UseVisualStyleBackColor = false;
            this.btnRegistroProveedor.Click += new System.EventHandler(this.btnRegistroProveedor_Click);
            // 
            // btnGenerarOrden
            // 
            this.btnGenerarOrden.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGenerarOrden.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGenerarOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarOrden.Location = new System.Drawing.Point(626, 477);
            this.btnGenerarOrden.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarOrden.Name = "btnGenerarOrden";
            this.btnGenerarOrden.Size = new System.Drawing.Size(122, 50);
            this.btnGenerarOrden.TabIndex = 45;
            this.btnGenerarOrden.Text = "Generar Orden";
            this.btnGenerarOrden.UseVisualStyleBackColor = false;
            this.btnGenerarOrden.Click += new System.EventHandler(this.btnGenerarOrden_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Location = new System.Drawing.Point(625, 173);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(122, 50);
            this.btnEliminar.TabIndex = 44;
            this.btnEliminar.Text = "Eliminar producto";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // labelCotizaciones
            // 
            this.labelCotizaciones.AutoSize = true;
            this.labelCotizaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCotizaciones.Location = new System.Drawing.Point(8, 85);
            this.labelCotizaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCotizaciones.Name = "labelCotizaciones";
            this.labelCotizaciones.Size = new System.Drawing.Size(163, 29);
            this.labelCotizaciones.TabIndex = 43;
            this.labelCotizaciones.Text = "Cotizaciones: ";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitulo.Location = new System.Drawing.Point(7, 8);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(323, 31);
            this.labelTitulo.TabIndex = 42;
            this.labelTitulo.Text = "Generar orden de compra";
            // 
            // dgvOrdenCompra
            // 
            this.dgvOrdenCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenCompra.Location = new System.Drawing.Point(13, 173);
            this.dgvOrdenCompra.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrdenCompra.Name = "dgvOrdenCompra";
            this.dgvOrdenCompra.RowHeadersWidth = 51;
            this.dgvOrdenCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenCompra.Size = new System.Drawing.Size(605, 354);
            this.dgvOrdenCompra.TabIndex = 41;
            // 
            // cbCotizaciones
            // 
            this.cbCotizaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCotizaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCotizaciones.FormattingEnabled = true;
            this.cbCotizaciones.Location = new System.Drawing.Point(13, 118);
            this.cbCotizaciones.Margin = new System.Windows.Forms.Padding(4);
            this.cbCotizaciones.Name = "cbCotizaciones";
            this.cbCotizaciones.Size = new System.Drawing.Size(604, 33);
            this.cbCotizaciones.TabIndex = 40;
            this.cbCotizaciones.SelectedIndexChanged += new System.EventHandler(this.cbCotizaciones_SelectedIndexChanged);
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblSubtotal.Location = new System.Drawing.Point(621, 349);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(107, 29);
            this.lblSubtotal.TabIndex = 48;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMonto.Location = new System.Drawing.Point(620, 386);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(0, 29);
            this.lblMonto.TabIndex = 49;
            // 
            // FrmOrdenCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 547);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRegistroProveedor);
            this.Controls.Add(this.btnGenerarOrden);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.labelCotizaciones);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.dgvOrdenCompra);
            this.Controls.Add(this.cbCotizaciones);
            this.Name = "FrmOrdenCompra";
            this.Text = "FrmOrdenCompra";
            this.Load += new System.EventHandler(this.FrmOrdenCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnRegistroProveedor;
        private System.Windows.Forms.Button btnGenerarOrden;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label labelCotizaciones;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.DataGridView dgvOrdenCompra;
        private System.Windows.Forms.ComboBox cbCotizaciones;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblMonto;
    }
}