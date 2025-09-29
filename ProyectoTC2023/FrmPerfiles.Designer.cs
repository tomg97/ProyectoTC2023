namespace ProyectoTC2023 {
    partial class FrmPerfiles {
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
            this.gbConfigFamilia = new System.Windows.Forms.GroupBox();
            this.tvConfigFamilia = new System.Windows.Forms.TreeView();
            this.btnGuardarFamilia2 = new System.Windows.Forms.Button();
            this.gbFamilias = new System.Windows.Forms.GroupBox();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.gbNuevaFamilia = new System.Windows.Forms.GroupBox();
            this.btnGuardarNuevaF = new System.Windows.Forms.Button();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cbFamilias = new System.Windows.Forms.ComboBox();
            this.lblFamilias = new System.Windows.Forms.Label();
            this.gbPatentes = new System.Windows.Forms.GroupBox();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.cbPatentes = new System.Windows.Forms.ComboBox();
            this.lblTodasPatentes = new System.Windows.Forms.Label();
            this.gbConfigFamilia.SuspendLayout();
            this.gbFamilias.SuspendLayout();
            this.gbNuevaFamilia.SuspendLayout();
            this.gbPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfigFamilia
            // 
            this.gbConfigFamilia.Controls.Add(this.tvConfigFamilia);
            this.gbConfigFamilia.Location = new System.Drawing.Point(359, 14);
            this.gbConfigFamilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbConfigFamilia.Name = "gbConfigFamilia";
            this.gbConfigFamilia.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbConfigFamilia.Size = new System.Drawing.Size(693, 559);
            this.gbConfigFamilia.TabIndex = 9;
            this.gbConfigFamilia.TabStop = false;
            this.gbConfigFamilia.Text = "Configurar Familia";
            // 
            // tvConfigFamilia
            // 
            this.tvConfigFamilia.Location = new System.Drawing.Point(5, 21);
            this.tvConfigFamilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvConfigFamilia.Name = "tvConfigFamilia";
            this.tvConfigFamilia.Size = new System.Drawing.Size(681, 532);
            this.tvConfigFamilia.TabIndex = 0;
            // 
            // btnGuardarFamilia2
            // 
            this.btnGuardarFamilia2.Location = new System.Drawing.Point(207, 404);
            this.btnGuardarFamilia2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarFamilia2.Name = "btnGuardarFamilia2";
            this.btnGuardarFamilia2.Size = new System.Drawing.Size(147, 44);
            this.btnGuardarFamilia2.TabIndex = 1;
            this.btnGuardarFamilia2.Text = "Guardar familia";
            this.btnGuardarFamilia2.UseVisualStyleBackColor = true;
            this.btnGuardarFamilia2.Click += new System.EventHandler(this.btnGuardarFamilia_Click);
            // 
            // gbFamilias
            // 
            this.gbFamilias.Controls.Add(this.btnConfigurar);
            this.gbFamilias.Controls.Add(this.btnAgregarFamilia);
            this.gbFamilias.Controls.Add(this.gbNuevaFamilia);
            this.gbFamilias.Controls.Add(this.cbFamilias);
            this.gbFamilias.Controls.Add(this.lblFamilias);
            this.gbFamilias.Location = new System.Drawing.Point(9, 148);
            this.gbFamilias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFamilias.Name = "gbFamilias";
            this.gbFamilias.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFamilias.Size = new System.Drawing.Size(344, 251);
            this.gbFamilias.TabIndex = 8;
            this.gbFamilias.TabStop = false;
            this.gbFamilias.Text = "Familias";
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Location = new System.Drawing.Point(19, 78);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(131, 39);
            this.btnConfigurar.TabIndex = 11;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.Location = new System.Drawing.Point(201, 78);
            this.btnAgregarFamilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarFamilia.TabIndex = 10;
            this.btnAgregarFamilia.Text = "Agregar >> ";
            this.btnAgregarFamilia.UseVisualStyleBackColor = true;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // gbNuevaFamilia
            // 
            this.gbNuevaFamilia.Controls.Add(this.btnGuardarNuevaF);
            this.gbNuevaFamilia.Controls.Add(this.txtNombreFamilia);
            this.gbNuevaFamilia.Controls.Add(this.lblNombre);
            this.gbNuevaFamilia.Location = new System.Drawing.Point(20, 122);
            this.gbNuevaFamilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNuevaFamilia.Name = "gbNuevaFamilia";
            this.gbNuevaFamilia.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbNuevaFamilia.Size = new System.Drawing.Size(309, 114);
            this.gbNuevaFamilia.TabIndex = 9;
            this.gbNuevaFamilia.TabStop = false;
            this.gbNuevaFamilia.Text = "Nueva";
            // 
            // btnGuardarNuevaF
            // 
            this.btnGuardarNuevaF.Location = new System.Drawing.Point(15, 75);
            this.btnGuardarNuevaF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarNuevaF.Name = "btnGuardarNuevaF";
            this.btnGuardarNuevaF.Size = new System.Drawing.Size(75, 34);
            this.btnGuardarNuevaF.TabIndex = 4;
            this.btnGuardarNuevaF.Text = "Guardar";
            this.btnGuardarNuevaF.UseVisualStyleBackColor = true;
            this.btnGuardarNuevaF.Click += new System.EventHandler(this.btnGuardarNuevaF_Click);
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(15, 46);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(231, 22);
            this.txtNombreFamilia.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // cbFamilias
            // 
            this.cbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamilias.FormattingEnabled = true;
            this.cbFamilias.Location = new System.Drawing.Point(19, 37);
            this.cbFamilias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbFamilias.Name = "cbFamilias";
            this.cbFamilias.Size = new System.Drawing.Size(311, 24);
            this.cbFamilias.TabIndex = 8;
            // 
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Location = new System.Drawing.Point(16, 18);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(117, 16);
            this.lblFamilias.TabIndex = 7;
            this.lblFamilias.Text = "Todas las familias";
            // 
            // gbPatentes
            // 
            this.gbPatentes.Controls.Add(this.btnAgregarPatente);
            this.gbPatentes.Controls.Add(this.cbPatentes);
            this.gbPatentes.Controls.Add(this.lblTodasPatentes);
            this.gbPatentes.Location = new System.Drawing.Point(9, 10);
            this.gbPatentes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbPatentes.Name = "gbPatentes";
            this.gbPatentes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbPatentes.Size = new System.Drawing.Size(341, 133);
            this.gbPatentes.TabIndex = 7;
            this.gbPatentes.TabStop = false;
            this.gbPatentes.Text = "Patentes";
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.Location = new System.Drawing.Point(15, 79);
            this.btnAgregarPatente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(131, 39);
            this.btnAgregarPatente.TabIndex = 8;
            this.btnAgregarPatente.Text = "Agregar >>";
            this.btnAgregarPatente.UseVisualStyleBackColor = true;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // cbPatentes
            // 
            this.cbPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatentes.FormattingEnabled = true;
            this.cbPatentes.Location = new System.Drawing.Point(15, 48);
            this.cbPatentes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbPatentes.Name = "cbPatentes";
            this.cbPatentes.Size = new System.Drawing.Size(311, 24);
            this.cbPatentes.TabIndex = 6;
            // 
            // lblTodasPatentes
            // 
            this.lblTodasPatentes.AutoSize = true;
            this.lblTodasPatentes.Location = new System.Drawing.Point(12, 28);
            this.lblTodasPatentes.Name = "lblTodasPatentes";
            this.lblTodasPatentes.Size = new System.Drawing.Size(123, 16);
            this.lblTodasPatentes.TabIndex = 5;
            this.lblTodasPatentes.Text = "Todas las patentes";
            // 
            // FrmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 576);
            this.Controls.Add(this.btnGuardarFamilia2);
            this.Controls.Add(this.gbConfigFamilia);
            this.Controls.Add(this.gbFamilias);
            this.Controls.Add(this.gbPatentes);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPerfiles";
            this.Text = "FrmPerfiles";
            this.Load += new System.EventHandler(this.FrmPerfiles_Load);
            this.gbConfigFamilia.ResumeLayout(false);
            this.gbFamilias.ResumeLayout(false);
            this.gbFamilias.PerformLayout();
            this.gbNuevaFamilia.ResumeLayout(false);
            this.gbNuevaFamilia.PerformLayout();
            this.gbPatentes.ResumeLayout(false);
            this.gbPatentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfigFamilia;
        private System.Windows.Forms.Button btnGuardarFamilia2;
        private System.Windows.Forms.TreeView tvConfigFamilia;
        private System.Windows.Forms.GroupBox gbFamilias;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Button btnAgregarFamilia;
        private System.Windows.Forms.GroupBox gbNuevaFamilia;
        private System.Windows.Forms.Button btnGuardarNuevaF;
        private System.Windows.Forms.TextBox txtNombreFamilia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cbFamilias;
        private System.Windows.Forms.Label lblFamilias;
        private System.Windows.Forms.GroupBox gbPatentes;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.ComboBox cbPatentes;
        private System.Windows.Forms.Label lblTodasPatentes;
    }
}