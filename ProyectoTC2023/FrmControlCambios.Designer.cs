namespace ProyectoTC2023 {
    partial class FrmControlCambios {
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblNomUsuCambios = new System.Windows.Forms.Label();
            this.lblDNICambios = new System.Windows.Forms.Label();
            this.lblNombreCambios = new System.Windows.Forms.Label();
            this.lblApellidoCambios = new System.Windows.Forms.Label();
            this.btnBuscarCambios = new System.Windows.Forms.Button();
            this.txtNomUsu = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1178, 470);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lblNomUsuCambios
            // 
            this.lblNomUsuCambios.AutoSize = true;
            this.lblNomUsuCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomUsuCambios.Location = new System.Drawing.Point(7, 17);
            this.lblNomUsuCambios.Name = "lblNomUsuCambios";
            this.lblNomUsuCambios.Size = new System.Drawing.Size(153, 25);
            this.lblNomUsuCambios.TabIndex = 1;
            this.lblNomUsuCambios.Text = "Nombre Usuario";
            // 
            // lblDNICambios
            // 
            this.lblDNICambios.AutoSize = true;
            this.lblDNICambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNICambios.Location = new System.Drawing.Point(7, 46);
            this.lblDNICambios.Name = "lblDNICambios";
            this.lblDNICambios.Size = new System.Drawing.Size(45, 25);
            this.lblDNICambios.TabIndex = 2;
            this.lblDNICambios.Text = "DNI";
            // 
            // lblNombreCambios
            // 
            this.lblNombreCambios.AutoSize = true;
            this.lblNombreCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCambios.Location = new System.Drawing.Point(7, 79);
            this.lblNombreCambios.Name = "lblNombreCambios";
            this.lblNombreCambios.Size = new System.Drawing.Size(81, 25);
            this.lblNombreCambios.TabIndex = 3;
            this.lblNombreCambios.Text = "Nombre";
            // 
            // lblApellidoCambios
            // 
            this.lblApellidoCambios.AutoSize = true;
            this.lblApellidoCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellidoCambios.Location = new System.Drawing.Point(7, 113);
            this.lblApellidoCambios.Name = "lblApellidoCambios";
            this.lblApellidoCambios.Size = new System.Drawing.Size(82, 25);
            this.lblApellidoCambios.TabIndex = 4;
            this.lblApellidoCambios.Text = "Apellido";
            // 
            // btnBuscarCambios
            // 
            this.btnBuscarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCambios.Location = new System.Drawing.Point(460, 12);
            this.btnBuscarCambios.Name = "btnBuscarCambios";
            this.btnBuscarCambios.Size = new System.Drawing.Size(159, 127);
            this.btnBuscarCambios.TabIndex = 5;
            this.btnBuscarCambios.Text = "Filtrar";
            this.btnBuscarCambios.UseVisualStyleBackColor = true;
            this.btnBuscarCambios.Click += new System.EventHandler(this.btnBuscarCambios_Click);
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomUsu.Location = new System.Drawing.Point(169, 12);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.Size = new System.Drawing.Size(285, 30);
            this.txtNomUsu.TabIndex = 6;
            // 
            // txtDNI
            // 
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(169, 43);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(285, 30);
            this.txtDNI.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(169, 76);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(285, 30);
            this.txtNombre.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.Location = new System.Drawing.Point(169, 108);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(285, 30);
            this.txtApellido.TabIndex = 9;
            // 
            // FrmControlCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 620);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.txtNomUsu);
            this.Controls.Add(this.btnBuscarCambios);
            this.Controls.Add(this.lblApellidoCambios);
            this.Controls.Add(this.lblNombreCambios);
            this.Controls.Add(this.lblDNICambios);
            this.Controls.Add(this.lblNomUsuCambios);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmControlCambios";
            this.Text = "FrmControlCambios";
            this.Load += new System.EventHandler(this.FrmControlCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblNomUsuCambios;
        private System.Windows.Forms.Label lblDNICambios;
        private System.Windows.Forms.Label lblNombreCambios;
        private System.Windows.Forms.Label lblApellidoCambios;
        private System.Windows.Forms.Button btnBuscarCambios;
        private System.Windows.Forms.TextBox txtNomUsu;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
    }
}