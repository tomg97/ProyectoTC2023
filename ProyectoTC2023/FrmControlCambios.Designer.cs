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
            this.dataGridView1.Location = new System.Drawing.Point(12, 136);
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
            this.lblNomUsuCambios.Location = new System.Drawing.Point(10, 16);
            this.lblNomUsuCambios.Name = "lblNomUsuCambios";
            this.lblNomUsuCambios.Size = new System.Drawing.Size(106, 16);
            this.lblNomUsuCambios.TabIndex = 1;
            this.lblNomUsuCambios.Text = "Nombre Usuario";
            this.lblNomUsuCambios.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDNICambios
            // 
            this.lblDNICambios.AutoSize = true;
            this.lblDNICambios.Location = new System.Drawing.Point(10, 46);
            this.lblDNICambios.Name = "lblDNICambios";
            this.lblDNICambios.Size = new System.Drawing.Size(30, 16);
            this.lblDNICambios.TabIndex = 2;
            this.lblDNICambios.Text = "DNI";
            // 
            // lblNombreCambios
            // 
            this.lblNombreCambios.AutoSize = true;
            this.lblNombreCambios.Location = new System.Drawing.Point(10, 79);
            this.lblNombreCambios.Name = "lblNombreCambios";
            this.lblNombreCambios.Size = new System.Drawing.Size(56, 16);
            this.lblNombreCambios.TabIndex = 3;
            this.lblNombreCambios.Text = "Nombre";
            // 
            // lblApellidoCambios
            // 
            this.lblApellidoCambios.AutoSize = true;
            this.lblApellidoCambios.Location = new System.Drawing.Point(12, 114);
            this.lblApellidoCambios.Name = "lblApellidoCambios";
            this.lblApellidoCambios.Size = new System.Drawing.Size(57, 16);
            this.lblApellidoCambios.TabIndex = 4;
            this.lblApellidoCambios.Text = "Apellido";
            // 
            // btnBuscarCambios
            // 
            this.btnBuscarCambios.Location = new System.Drawing.Point(414, 9);
            this.btnBuscarCambios.Name = "btnBuscarCambios";
            this.btnBuscarCambios.Size = new System.Drawing.Size(159, 121);
            this.btnBuscarCambios.TabIndex = 5;
            this.btnBuscarCambios.Text = "Filtrar";
            this.btnBuscarCambios.UseVisualStyleBackColor = true;
            this.btnBuscarCambios.Click += new System.EventHandler(this.btnBuscarCambios_Click);
            // 
            // txtNomUsu
            // 
            this.txtNomUsu.Location = new System.Drawing.Point(123, 9);
            this.txtNomUsu.Name = "txtNomUsu";
            this.txtNomUsu.Size = new System.Drawing.Size(285, 22);
            this.txtNomUsu.TabIndex = 6;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(123, 40);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(285, 22);
            this.txtDNI.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(123, 73);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(285, 22);
            this.txtNombre.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(123, 108);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(285, 22);
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