namespace ProyectoTC2023 {
    partial class FrmVentas {
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
            this.components = new System.ComponentModel.Container();
            this.dgvExistencias = new System.Windows.Forms.DataGridView();
            this.nombreProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetProductos = new ProyectoTC2023.DataSetProductos();
            this.productoTableAdapter = new ProyectoTC2023.DataSetProductosTableAdapters.ProductoTableAdapter();
            this.txtCantidadVentas = new System.Windows.Forms.TextBox();
            this.btnSelectVentas = new System.Windows.Forms.Button();
            this.lblCantidadVentas = new System.Windows.Forms.Label();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.grpStockVentas = new System.Windows.Forms.GroupBox();
            this.grpCarrito = new System.Windows.Forms.GroupBox();
            this.btnAsignarCliente = new System.Windows.Forms.Button();
            this.lblAsignarCliente = new System.Windows.Forms.Label();
            this.txtClienteVenta = new System.Windows.Forms.TextBox();
            this.btnVaciar = new System.Windows.Forms.Button();
            this.btnRemoverCarrito = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.grpStockVentas.SuspendLayout();
            this.grpCarrito.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExistencias
            // 
            this.dgvExistencias.AutoGenerateColumns = false;
            this.dgvExistencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExistencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreProductoDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.marcaProductoDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn});
            this.dgvExistencias.DataSource = this.productoBindingSource;
            this.dgvExistencias.Location = new System.Drawing.Point(8, 23);
            this.dgvExistencias.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvExistencias.Name = "dgvExistencias";
            this.dgvExistencias.ReadOnly = true;
            this.dgvExistencias.RowHeadersWidth = 51;
            this.dgvExistencias.Size = new System.Drawing.Size(728, 185);
            this.dgvExistencias.TabIndex = 0;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            this.nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.HeaderText = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            this.nombreProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // marcaProductoDataGridViewTextBoxColumn
            // 
            this.marcaProductoDataGridViewTextBoxColumn.DataPropertyName = "marcaProducto";
            this.marcaProductoDataGridViewTextBoxColumn.HeaderText = "marcaProducto";
            this.marcaProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.marcaProductoDataGridViewTextBoxColumn.Name = "marcaProductoDataGridViewTextBoxColumn";
            this.marcaProductoDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.cantidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "precio";
            this.precioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            this.precioDataGridViewTextBoxColumn.ReadOnly = true;
            this.precioDataGridViewTextBoxColumn.Width = 125;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "Producto";
            this.productoBindingSource.DataSource = this.dataSetProductos;
            // 
            // dataSetProductos
            // 
            this.dataSetProductos.DataSetName = "DataSetProductos";
            this.dataSetProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // txtCantidadVentas
            // 
            this.txtCantidadVentas.Location = new System.Drawing.Point(744, 183);
            this.txtCantidadVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidadVentas.Name = "txtCantidadVentas";
            this.txtCantidadVentas.Size = new System.Drawing.Size(181, 22);
            this.txtCantidadVentas.TabIndex = 1;
            // 
            // btnSelectVentas
            // 
            this.btnSelectVentas.Location = new System.Drawing.Point(935, 181);
            this.btnSelectVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectVentas.Name = "btnSelectVentas";
            this.btnSelectVentas.Size = new System.Drawing.Size(119, 28);
            this.btnSelectVentas.TabIndex = 2;
            this.btnSelectVentas.Text = "Seleccionar";
            this.btnSelectVentas.UseVisualStyleBackColor = true;
            this.btnSelectVentas.Click += new System.EventHandler(this.btnSelectVentas_Click);
            // 
            // lblCantidadVentas
            // 
            this.lblCantidadVentas.AutoSize = true;
            this.lblCantidadVentas.Location = new System.Drawing.Point(740, 164);
            this.lblCantidadVentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadVentas.Name = "lblCantidadVentas";
            this.lblCantidadVentas.Size = new System.Drawing.Size(64, 16);
            this.lblCantidadVentas.TabIndex = 3;
            this.lblCantidadVentas.Text = "Cantidad:";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(8, 23);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersWidth = 51;
            this.dgvCarrito.Size = new System.Drawing.Size(728, 185);
            this.dgvCarrito.TabIndex = 4;
            // 
            // grpStockVentas
            // 
            this.grpStockVentas.Controls.Add(this.dgvExistencias);
            this.grpStockVentas.Controls.Add(this.txtCantidadVentas);
            this.grpStockVentas.Controls.Add(this.lblCantidadVentas);
            this.grpStockVentas.Controls.Add(this.btnSelectVentas);
            this.grpStockVentas.Location = new System.Drawing.Point(-1, 2);
            this.grpStockVentas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStockVentas.Name = "grpStockVentas";
            this.grpStockVentas.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpStockVentas.Size = new System.Drawing.Size(1061, 282);
            this.grpStockVentas.TabIndex = 5;
            this.grpStockVentas.TabStop = false;
            this.grpStockVentas.Text = "Existencias";
            // 
            // grpCarrito
            // 
            this.grpCarrito.Controls.Add(this.btnAsignarCliente);
            this.grpCarrito.Controls.Add(this.lblAsignarCliente);
            this.grpCarrito.Controls.Add(this.txtClienteVenta);
            this.grpCarrito.Controls.Add(this.btnVaciar);
            this.grpCarrito.Controls.Add(this.btnRemoverCarrito);
            this.grpCarrito.Controls.Add(this.dgvCarrito);
            this.grpCarrito.Location = new System.Drawing.Point(-1, 292);
            this.grpCarrito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCarrito.Name = "grpCarrito";
            this.grpCarrito.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCarrito.Size = new System.Drawing.Size(1061, 230);
            this.grpCarrito.TabIndex = 6;
            this.grpCarrito.TabStop = false;
            this.grpCarrito.Text = "Carrito";
            // 
            // btnAsignarCliente
            // 
            this.btnAsignarCliente.Location = new System.Drawing.Point(949, 181);
            this.btnAsignarCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAsignarCliente.Name = "btnAsignarCliente";
            this.btnAsignarCliente.Size = new System.Drawing.Size(105, 28);
            this.btnAsignarCliente.TabIndex = 8;
            this.btnAsignarCliente.Text = "Realizar Pago";
            this.btnAsignarCliente.UseVisualStyleBackColor = true;
            this.btnAsignarCliente.Click += new System.EventHandler(this.btnAsignarCliente_Click);
            // 
            // lblAsignarCliente
            // 
            this.lblAsignarCliente.AutoSize = true;
            this.lblAsignarCliente.Location = new System.Drawing.Point(740, 164);
            this.lblAsignarCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAsignarCliente.Name = "lblAsignarCliente";
            this.lblAsignarCliente.Size = new System.Drawing.Size(194, 16);
            this.lblAsignarCliente.TabIndex = 7;
            this.lblAsignarCliente.Text = "Asignar DNI de cliente a carrito:";
            // 
            // txtClienteVenta
            // 
            this.txtClienteVenta.Location = new System.Drawing.Point(744, 183);
            this.txtClienteVenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClienteVenta.Name = "txtClienteVenta";
            this.txtClienteVenta.Size = new System.Drawing.Size(201, 22);
            this.txtClienteVenta.TabIndex = 6;
            // 
            // btnVaciar
            // 
            this.btnVaciar.Location = new System.Drawing.Point(744, 71);
            this.btnVaciar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVaciar.Name = "btnVaciar";
            this.btnVaciar.Size = new System.Drawing.Size(155, 28);
            this.btnVaciar.TabIndex = 5;
            this.btnVaciar.Text = "Vaciar";
            this.btnVaciar.UseVisualStyleBackColor = true;
            this.btnVaciar.Click += new System.EventHandler(this.btnVaciar_Click);
            // 
            // btnRemoverCarrito
            // 
            this.btnRemoverCarrito.Location = new System.Drawing.Point(744, 23);
            this.btnRemoverCarrito.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoverCarrito.Name = "btnRemoverCarrito";
            this.btnRemoverCarrito.Size = new System.Drawing.Size(155, 28);
            this.btnRemoverCarrito.TabIndex = 4;
            this.btnRemoverCarrito.Text = "Remover Selección";
            this.btnRemoverCarrito.UseVisualStyleBackColor = true;
            this.btnRemoverCarrito.Click += new System.EventHandler(this.btnRemoverCarrito_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 535);
            this.Controls.Add(this.grpCarrito);
            this.Controls.Add(this.grpStockVentas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmVentas";
            this.Text = "FrmVentas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.grpStockVentas.ResumeLayout(false);
            this.grpStockVentas.PerformLayout();
            this.grpCarrito.ResumeLayout(false);
            this.grpCarrito.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExistencias;
        private DataSetProductos dataSetProductos;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private DataSetProductosTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtCantidadVentas;
        private System.Windows.Forms.Button btnSelectVentas;
        private System.Windows.Forms.Label lblCantidadVentas;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.GroupBox grpStockVentas;
        private System.Windows.Forms.GroupBox grpCarrito;
        private System.Windows.Forms.Button btnVaciar;
        private System.Windows.Forms.Button btnRemoverCarrito;
        private System.Windows.Forms.TextBox txtClienteVenta;
        private System.Windows.Forms.Button btnAsignarCliente;
        private System.Windows.Forms.Label lblAsignarCliente;
    }
}