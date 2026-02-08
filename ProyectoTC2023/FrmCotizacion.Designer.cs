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
            this.button2 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnAñadirProveedor = new System.Windows.Forms.Button();
            this.labelProveedores = new System.Windows.Forms.Label();
            this.btnPreRegistroProveedor = new System.Windows.Forms.Button();
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
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(13, 12);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 58);
            this.button2.TabIndex = 52;
            this.button2.Text = "❓";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnCancelar.Location = new System.Drawing.Point(1425, 539);
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
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnFinalizar.Location = new System.Drawing.Point(1425, 599);
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
            this.btnAñadirProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnAñadirProveedor.Location = new System.Drawing.Point(1425, 119);
            this.btnAñadirProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnAñadirProveedor.Name = "btnAñadirProveedor";
            this.btnAñadirProveedor.Size = new System.Drawing.Size(150, 53);
            this.btnAñadirProveedor.TabIndex = 49;
            this.btnAñadirProveedor.Text = "Añadir proveedor";
            this.btnAñadirProveedor.UseVisualStyleBackColor = false;
            this.btnAñadirProveedor.Click += new System.EventHandler(this.btnAñadirProveedor_Click);
            // 
            // labelProveedores
            // 
            this.labelProveedores.AutoSize = true;
            this.labelProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProveedores.Location = new System.Drawing.Point(1226, 41);
            this.labelProveedores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProveedores.Name = "labelProveedores";
            this.labelProveedores.Size = new System.Drawing.Size(164, 29);
            this.labelProveedores.TabIndex = 48;
            this.labelProveedores.Text = "Proveedores: ";
            // 
            // btnPreRegistroProveedor
            // 
            this.btnPreRegistroProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPreRegistroProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnPreRegistroProveedor.Location = new System.Drawing.Point(1425, 241);
            this.btnPreRegistroProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreRegistroProveedor.Name = "btnPreRegistroProveedor";
            this.btnPreRegistroProveedor.Size = new System.Drawing.Size(150, 52);
            this.btnPreRegistroProveedor.TabIndex = 47;
            this.btnPreRegistroProveedor.Text = "Pre-registro proveedor";
            this.btnPreRegistroProveedor.UseVisualStyleBackColor = false;
            this.btnPreRegistroProveedor.Click += new System.EventHandler(this.btnPreRegistroProveedor_Click);
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(1231, 74);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(352, 28);
            this.cmbProveedores.TabIndex = 46;
            // 
            // labelDetalleSolicitud
            // 
            this.labelDetalleSolicitud.AutoSize = true;
            this.labelDetalleSolicitud.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetalleSolicitud.Location = new System.Drawing.Point(818, 87);
            this.labelDetalleSolicitud.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDetalleSolicitud.Name = "labelDetalleSolicitud";
            this.labelDetalleSolicitud.Size = new System.Drawing.Size(230, 29);
            this.labelDetalleSolicitud.TabIndex = 45;
            this.labelDetalleSolicitud.Text = "Detalle de solicitud: ";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnModificar.Location = new System.Drawing.Point(1425, 422);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(150, 52);
            this.btnModificar.TabIndex = 44;
            this.btnModificar.Text = "Modificar cantidad";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnEliminar.Location = new System.Drawing.Point(1425, 482);
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
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnAgregar.Location = new System.Drawing.Point(700, 120);
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
            this.dgvSolicitud.Location = new System.Drawing.Point(823, 120);
            this.dgvSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSolicitud.Name = "dgvSolicitud";
            this.dgvSolicitud.RowHeadersWidth = 51;
            this.dgvSolicitud.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSolicitud.Size = new System.Drawing.Size(594, 531);
            this.dgvSolicitud.TabIndex = 41;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductos.Location = new System.Drawing.Point(13, 121);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(679, 530);
            this.dgvProductos.TabIndex = 38;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 29);
            this.label1.TabIndex = 53;
            this.label1.Text = "Productos bajos en existencias:";
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnRemover.Location = new System.Drawing.Point(1425, 180);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(150, 53);
            this.btnRemover.TabIndex = 54;
            this.btnRemover.Text = "Remover proveedor";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // FrmCotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 682);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnAñadirProveedor);
            this.Controls.Add(this.labelProveedores);
            this.Controls.Add(this.btnPreRegistroProveedor);
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

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnAñadirProveedor;
        private System.Windows.Forms.Label labelProveedores;
        private System.Windows.Forms.Button btnPreRegistroProveedor;
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