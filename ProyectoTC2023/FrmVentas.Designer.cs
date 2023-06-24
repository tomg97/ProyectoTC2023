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
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
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
            this.dgvExistencias.Location = new System.Drawing.Point(12, 12);
            this.dgvExistencias.Name = "dgvExistencias";
            this.dgvExistencias.Size = new System.Drawing.Size(546, 150);
            this.dgvExistencias.TabIndex = 0;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            this.nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.HeaderText = "nombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // marcaProductoDataGridViewTextBoxColumn
            // 
            this.marcaProductoDataGridViewTextBoxColumn.DataPropertyName = "marcaProducto";
            this.marcaProductoDataGridViewTextBoxColumn.HeaderText = "marcaProducto";
            this.marcaProductoDataGridViewTextBoxColumn.Name = "marcaProductoDataGridViewTextBoxColumn";
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
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
            this.txtCantidadVentas.Location = new System.Drawing.Point(564, 142);
            this.txtCantidadVentas.Name = "txtCantidadVentas";
            this.txtCantidadVentas.Size = new System.Drawing.Size(137, 20);
            this.txtCantidadVentas.TabIndex = 1;
            // 
            // btnSelectVentas
            // 
            this.btnSelectVentas.Location = new System.Drawing.Point(707, 140);
            this.btnSelectVentas.Name = "btnSelectVentas";
            this.btnSelectVentas.Size = new System.Drawing.Size(89, 23);
            this.btnSelectVentas.TabIndex = 2;
            this.btnSelectVentas.Text = "Seleccionar";
            this.btnSelectVentas.UseVisualStyleBackColor = true;
            this.btnSelectVentas.Click += new System.EventHandler(this.btnSelectVentas_Click);
            // 
            // lblCantidadVentas
            // 
            this.lblCantidadVentas.AutoSize = true;
            this.lblCantidadVentas.Location = new System.Drawing.Point(561, 126);
            this.lblCantidadVentas.Name = "lblCantidadVentas";
            this.lblCantidadVentas.Size = new System.Drawing.Size(52, 13);
            this.lblCantidadVentas.TabIndex = 3;
            this.lblCantidadVentas.Text = "Cantidad:";
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(12, 196);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(546, 150);
            this.dgvCarrito.TabIndex = 4;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblCantidadVentas);
            this.Controls.Add(this.btnSelectVentas);
            this.Controls.Add(this.txtCantidadVentas);
            this.Controls.Add(this.dgvExistencias);
            this.Name = "FrmVentas";
            this.Text = "FrmVentas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}