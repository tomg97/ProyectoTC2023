namespace ProyectoTC2023 {
    partial class FrmCotizacion {
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnAñadirProveedor = new System.Windows.Forms.Button();
            this.labelProveedores = new System.Windows.Forms.Label();
            this.btnRegistroProveedor = new System.Windows.Forms.Button();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.labelDetalleSolicitud = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvSolicitud = new System.Windows.Forms.DataGridView();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCancelar.Location = new System.Drawing.Point(1547, 165);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(150, 52);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnFinalizar.Location = new System.Drawing.Point(1548, 225);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(150, 52);
            this.btnFinalizar.TabIndex = 50;
            this.btnFinalizar.Text = "Finalizar ";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnAñadirProveedor
            // 
            this.btnAñadirProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAñadirProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAñadirProveedor.Location = new System.Drawing.Point(1183, 593);
            this.btnAñadirProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnAñadirProveedor.Name = "btnAñadirProveedor";
            this.btnAñadirProveedor.Size = new System.Drawing.Size(150, 65);
            this.btnAñadirProveedor.TabIndex = 49;
            this.btnAñadirProveedor.Text = "Añadir proveedor";
            this.btnAñadirProveedor.UseVisualStyleBackColor = false;
            this.btnAñadirProveedor.Click += new System.EventHandler(this.btnAñadirProveedor_Click);
            // 
            // labelProveedores
            // 
            this.labelProveedores.AutoSize = true;
            this.labelProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProveedores.Location = new System.Drawing.Point(818, 577);
            this.labelProveedores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProveedores.Name = "labelProveedores";
            this.labelProveedores.Size = new System.Drawing.Size(164, 29);
            this.labelProveedores.TabIndex = 48;
            this.labelProveedores.Text = "Proveedores: ";
            // 
            // btnRegistroProveedor
            // 
            this.btnRegistroProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRegistroProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRegistroProveedor.Location = new System.Drawing.Point(1499, 593);
            this.btnRegistroProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegistroProveedor.Name = "btnRegistroProveedor";
            this.btnRegistroProveedor.Size = new System.Drawing.Size(198, 65);
            this.btnRegistroProveedor.TabIndex = 47;
            this.btnRegistroProveedor.Text = "Registro proveedor";
            this.btnRegistroProveedor.UseVisualStyleBackColor = false;
            this.btnRegistroProveedor.Click += new System.EventHandler(this.btnPreRegistroProveedor_Click);
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(823, 618);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(352, 33);
            this.cmbProveedores.TabIndex = 46;
            // 
            // labelDetalleSolicitud
            // 
            this.labelDetalleSolicitud.AutoSize = true;
            this.labelDetalleSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalleSolicitud.Location = new System.Drawing.Point(818, 7);
            this.labelDetalleSolicitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetalleSolicitud.Name = "labelDetalleSolicitud";
            this.labelDetalleSolicitud.Size = new System.Drawing.Size(257, 31);
            this.labelDetalleSolicitud.TabIndex = 45;
            this.labelDetalleSolicitud.Text = "Detalle de solicitud: ";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnModificar.Location = new System.Drawing.Point(1547, 40);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 59);
            this.btnModificar.TabIndex = 44;
            this.btnModificar.Text = "Modificar cantidad";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEliminar.Location = new System.Drawing.Point(1547, 107);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 50);
            this.btnEliminar.TabIndex = 43;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAgregar.Location = new System.Drawing.Point(700, 40);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(115, 52);
            this.btnAgregar.TabIndex = 42;
            this.btnAgregar.Text = "Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvSolicitud
            // 
            this.dgvSolicitud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitud.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSolicitud.Location = new System.Drawing.Point(823, 42);
            this.dgvSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSolicitud.Name = "dgvSolicitud";
            this.dgvSolicitud.RowHeadersWidth = 51;
            this.dgvSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitud.Size = new System.Drawing.Size(716, 531);
            this.dgvSolicitud.TabIndex = 41;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductos.Location = new System.Drawing.Point(13, 41);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(679, 628);
            this.dgvProductos.TabIndex = 38;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 31);
            this.label1.TabIndex = 53;
            this.label1.Text = "Productos bajos en existencias:";
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRemover.Location = new System.Drawing.Point(1341, 593);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(150, 65);
            this.btnRemover.TabIndex = 54;
            this.btnRemover.Text = "Remover proveedor";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // FrmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 682);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnAñadirProveedor);
            this.Controls.Add(this.labelProveedores);
            this.Controls.Add(this.btnRegistroProveedor);
            this.Controls.Add(this.cmbProveedores);
            this.Controls.Add(this.labelDetalleSolicitud);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvSolicitud);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FrmCotizacion";
            this.Text = "FrmCotizacion";
            this.Load += new System.EventHandler(this.FrmCotizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnAñadirProveedor;
        private System.Windows.Forms.Label labelProveedores;
        private System.Windows.Forms.Button btnRegistroProveedor;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Label labelDetalleSolicitud;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvSolicitud;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemover;
    }
}