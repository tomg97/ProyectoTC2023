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
            this.btnGuardarFamilia = new System.Windows.Forms.Button();
            this.tvConfigFamilia = new System.Windows.Forms.TreeView();
            this.gbFamilias = new System.Windows.Forms.GroupBox();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.gbNuevaFamilia = new System.Windows.Forms.GroupBox();
            this.btnGuardarNuevaF = new System.Windows.Forms.Button();
            this.txtNombreFamilia = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cbFamilias = new System.Windows.Forms.ComboBox();
            this.lblFamilias = new System.Windows.Forms.Label();
            this.grpPatentes = new System.Windows.Forms.GroupBox();
            this.btnAgregarPatente = new System.Windows.Forms.Button();
            this.cbPatentes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbConfigFamilia.SuspendLayout();
            this.gbFamilias.SuspendLayout();
            this.gbNuevaFamilia.SuspendLayout();
            this.grpPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConfigFamilia
            // 
            this.gbConfigFamilia.Controls.Add(this.tvConfigFamilia);
            this.gbConfigFamilia.Location = new System.Drawing.Point(269, 11);
            this.gbConfigFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.gbConfigFamilia.Name = "gbConfigFamilia";
            this.gbConfigFamilia.Padding = new System.Windows.Forms.Padding(2);
            this.gbConfigFamilia.Size = new System.Drawing.Size(520, 454);
            this.gbConfigFamilia.TabIndex = 9;
            this.gbConfigFamilia.TabStop = false;
            this.gbConfigFamilia.Text = "Configurar Familia";
            // 
            // btnGuardarFamilia
            // 
            this.btnGuardarFamilia.Location = new System.Drawing.Point(155, 328);
            this.btnGuardarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarFamilia.Name = "btnGuardarFamilia";
            this.btnGuardarFamilia.Size = new System.Drawing.Size(110, 36);
            this.btnGuardarFamilia.TabIndex = 1;
            this.btnGuardarFamilia.Text = "Guardar familia";
            this.btnGuardarFamilia.UseVisualStyleBackColor = true;
            this.btnGuardarFamilia.Click += new System.EventHandler(this.btnGuardarFamilia_Click);
            // 
            // tvConfigFamilia
            // 
            this.tvConfigFamilia.Location = new System.Drawing.Point(4, 17);
            this.tvConfigFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.tvConfigFamilia.Name = "tvConfigFamilia";
            this.tvConfigFamilia.Size = new System.Drawing.Size(512, 433);
            this.tvConfigFamilia.TabIndex = 0;
            // 
            // gbFamilias
            // 
            this.gbFamilias.Controls.Add(this.btnConfigurar);
            this.gbFamilias.Controls.Add(this.btnAgregarFamilia);
            this.gbFamilias.Controls.Add(this.gbNuevaFamilia);
            this.gbFamilias.Controls.Add(this.cbFamilias);
            this.gbFamilias.Controls.Add(this.lblFamilias);
            this.gbFamilias.Location = new System.Drawing.Point(7, 120);
            this.gbFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.gbFamilias.Name = "gbFamilias";
            this.gbFamilias.Padding = new System.Windows.Forms.Padding(2);
            this.gbFamilias.Size = new System.Drawing.Size(258, 204);
            this.gbFamilias.TabIndex = 8;
            this.gbFamilias.TabStop = false;
            this.gbFamilias.Text = "Familias";
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Location = new System.Drawing.Point(14, 63);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(98, 32);
            this.btnConfigurar.TabIndex = 11;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.Location = new System.Drawing.Point(151, 63);
            this.btnAgregarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(98, 32);
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
            this.gbNuevaFamilia.Location = new System.Drawing.Point(15, 99);
            this.gbNuevaFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.gbNuevaFamilia.Name = "gbNuevaFamilia";
            this.gbNuevaFamilia.Padding = new System.Windows.Forms.Padding(2);
            this.gbNuevaFamilia.Size = new System.Drawing.Size(232, 93);
            this.gbNuevaFamilia.TabIndex = 9;
            this.gbNuevaFamilia.TabStop = false;
            this.gbNuevaFamilia.Text = "Nueva";
            // 
            // btnGuardarNuevaF
            // 
            this.btnGuardarNuevaF.Location = new System.Drawing.Point(11, 61);
            this.btnGuardarNuevaF.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarNuevaF.Name = "btnGuardarNuevaF";
            this.btnGuardarNuevaF.Size = new System.Drawing.Size(56, 28);
            this.btnGuardarNuevaF.TabIndex = 4;
            this.btnGuardarNuevaF.Text = "Guardar";
            this.btnGuardarNuevaF.UseVisualStyleBackColor = true;
            this.btnGuardarNuevaF.Click += new System.EventHandler(this.btnGuardarNuevaF_Click);
            // 
            // txtNombreFamilia
            // 
            this.txtNombreFamilia.Location = new System.Drawing.Point(11, 37);
            this.txtNombreFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreFamilia.Name = "txtNombreFamilia";
            this.txtNombreFamilia.Size = new System.Drawing.Size(174, 20);
            this.txtNombreFamilia.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(9, 20);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // cbFamilias
            // 
            this.cbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamilias.FormattingEnabled = true;
            this.cbFamilias.Location = new System.Drawing.Point(14, 30);
            this.cbFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cbFamilias.Name = "cbFamilias";
            this.cbFamilias.Size = new System.Drawing.Size(234, 21);
            this.cbFamilias.TabIndex = 8;
            // 
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Location = new System.Drawing.Point(12, 15);
            this.lblFamilias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(90, 13);
            this.lblFamilias.TabIndex = 7;
            this.lblFamilias.Text = "Todas las familias";
            // 
            // grpPatentes
            // 
            this.grpPatentes.Controls.Add(this.btnAgregarPatente);
            this.grpPatentes.Controls.Add(this.cbPatentes);
            this.grpPatentes.Controls.Add(this.label2);
            this.grpPatentes.Location = new System.Drawing.Point(7, 8);
            this.grpPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Size = new System.Drawing.Size(256, 108);
            this.grpPatentes.TabIndex = 7;
            this.grpPatentes.TabStop = false;
            this.grpPatentes.Text = "Patentes";
            // 
            // btnAgregarPatente
            // 
            this.btnAgregarPatente.Location = new System.Drawing.Point(11, 64);
            this.btnAgregarPatente.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarPatente.Name = "btnAgregarPatente";
            this.btnAgregarPatente.Size = new System.Drawing.Size(98, 32);
            this.btnAgregarPatente.TabIndex = 8;
            this.btnAgregarPatente.Text = "Agregar >> ";
            this.btnAgregarPatente.UseVisualStyleBackColor = true;
            this.btnAgregarPatente.Click += new System.EventHandler(this.btnAgregarPatente_Click);
            // 
            // cbPatentes
            // 
            this.cbPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatentes.FormattingEnabled = true;
            this.cbPatentes.Location = new System.Drawing.Point(11, 39);
            this.cbPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.cbPatentes.Name = "cbPatentes";
            this.cbPatentes.Size = new System.Drawing.Size(234, 21);
            this.cbPatentes.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Todas las patentes";
            // 
            // FrmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.btnGuardarFamilia);
            this.Controls.Add(this.gbConfigFamilia);
            this.Controls.Add(this.gbFamilias);
            this.Controls.Add(this.grpPatentes);
            this.Name = "FrmPerfiles";
            this.Text = "FrmPerfiles";
            this.Load += new System.EventHandler(this.FrmPerfiles_Load);
            this.gbConfigFamilia.ResumeLayout(false);
            this.gbFamilias.ResumeLayout(false);
            this.gbFamilias.PerformLayout();
            this.gbNuevaFamilia.ResumeLayout(false);
            this.gbNuevaFamilia.PerformLayout();
            this.grpPatentes.ResumeLayout(false);
            this.grpPatentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConfigFamilia;
        private System.Windows.Forms.Button btnGuardarFamilia;
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
        private System.Windows.Forms.GroupBox grpPatentes;
        private System.Windows.Forms.Button btnAgregarPatente;
        private System.Windows.Forms.ComboBox cbPatentes;
        private System.Windows.Forms.Label label2;
    }
}