namespace ProyectoTC2023 {
    partial class FrmUsuarios {
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
            this.gbCambiarClave = new System.Windows.Forms.GroupBox();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.lblClaveNueva = new System.Windows.Forms.Label();
            this.lblClaveActual = new System.Windows.Forms.Label();
            this.txtPassNueva = new System.Windows.Forms.TextBox();
            this.txtPassActual = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpbLogout = new System.Windows.Forms.GroupBox();
            this.btnGuardarFamilia = new System.Windows.Forms.Button();
            this.tvPerfil = new System.Windows.Forms.TreeView();
            this.grpPatentes = new System.Windows.Forms.GroupBox();
            this.btnAgregarFamilia = new System.Windows.Forms.Button();
            this.cbFamilias = new System.Windows.Forms.ComboBox();
            this.lblAddFamilia = new System.Windows.Forms.Label();
            this.btnAddPatente = new System.Windows.Forms.Button();
            this.cbPatentes = new System.Windows.Forms.ComboBox();
            this.lblAddPatente = new System.Windows.Forms.Label();
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.cbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblCbUsuarios = new System.Windows.Forms.Label();
            this.gbCambiarClave.SuspendLayout();
            this.grpbLogout.SuspendLayout();
            this.grpPatentes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCambiarClave
            // 
            this.gbCambiarClave.Controls.Add(this.btnCambiar);
            this.gbCambiarClave.Controls.Add(this.lblClaveNueva);
            this.gbCambiarClave.Controls.Add(this.lblClaveActual);
            this.gbCambiarClave.Controls.Add(this.txtPassNueva);
            this.gbCambiarClave.Controls.Add(this.txtPassActual);
            this.gbCambiarClave.Location = new System.Drawing.Point(12, 12);
            this.gbCambiarClave.Name = "gbCambiarClave";
            this.gbCambiarClave.Size = new System.Drawing.Size(302, 136);
            this.gbCambiarClave.TabIndex = 0;
            this.gbCambiarClave.TabStop = false;
            this.gbCambiarClave.Text = "Cambiar Clave";
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(200, 94);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(85, 23);
            this.btnCambiar.TabIndex = 5;
            this.btnCambiar.Text = "Cambiar Clave";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // lblClaveNueva
            // 
            this.lblClaveNueva.AutoSize = true;
            this.lblClaveNueva.Location = new System.Drawing.Point(6, 81);
            this.lblClaveNueva.Name = "lblClaveNueva";
            this.lblClaveNueva.Size = new System.Drawing.Size(70, 13);
            this.lblClaveNueva.TabIndex = 3;
            this.lblClaveNueva.Text = "Clave nueva:";
            // 
            // lblClaveActual
            // 
            this.lblClaveActual.AutoSize = true;
            this.lblClaveActual.Location = new System.Drawing.Point(6, 27);
            this.lblClaveActual.Name = "lblClaveActual";
            this.lblClaveActual.Size = new System.Drawing.Size(69, 13);
            this.lblClaveActual.TabIndex = 2;
            this.lblClaveActual.Text = "Clave actual:";
            // 
            // txtPassNueva
            // 
            this.txtPassNueva.Location = new System.Drawing.Point(6, 97);
            this.txtPassNueva.Name = "txtPassNueva";
            this.txtPassNueva.Size = new System.Drawing.Size(188, 20);
            this.txtPassNueva.TabIndex = 1;
            // 
            // txtPassActual
            // 
            this.txtPassActual.Location = new System.Drawing.Point(6, 43);
            this.txtPassActual.Name = "txtPassActual";
            this.txtPassActual.Size = new System.Drawing.Size(188, 20);
            this.txtPassActual.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(6, 94);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // grpbLogout
            // 
            this.grpbLogout.Controls.Add(this.btnLogout);
            this.grpbLogout.Location = new System.Drawing.Point(320, 12);
            this.grpbLogout.Name = "grpbLogout";
            this.grpbLogout.Size = new System.Drawing.Size(99, 136);
            this.grpbLogout.TabIndex = 1;
            this.grpbLogout.TabStop = false;
            this.grpbLogout.Text = "Logout";
            this.grpbLogout.Enter += new System.EventHandler(this.grpbLogout_Enter);
            // 
            // btnGuardarFamilia
            // 
            this.btnGuardarFamilia.AccessibleDescription = "";
            this.btnGuardarFamilia.Location = new System.Drawing.Point(133, 195);
            this.btnGuardarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarFamilia.Name = "btnGuardarFamilia";
            this.btnGuardarFamilia.Size = new System.Drawing.Size(110, 25);
            this.btnGuardarFamilia.TabIndex = 10;
            this.btnGuardarFamilia.Text = "Guardar cambios";
            this.btnGuardarFamilia.UseVisualStyleBackColor = true;
            this.btnGuardarFamilia.Click += new System.EventHandler(this.btnGuardarFamilia_Click);
            // 
            // tvPerfil
            // 
            this.tvPerfil.Location = new System.Drawing.Point(272, 160);
            this.tvPerfil.Margin = new System.Windows.Forms.Padding(2);
            this.tvPerfil.Name = "tvPerfil";
            this.tvPerfil.Size = new System.Drawing.Size(276, 213);
            this.tvPerfil.TabIndex = 9;
            // 
            // grpPatentes
            // 
            this.grpPatentes.Controls.Add(this.btnGuardarFamilia);
            this.grpPatentes.Controls.Add(this.btnAgregarFamilia);
            this.grpPatentes.Controls.Add(this.cbFamilias);
            this.grpPatentes.Controls.Add(this.lblAddFamilia);
            this.grpPatentes.Controls.Add(this.btnAddPatente);
            this.grpPatentes.Controls.Add(this.cbPatentes);
            this.grpPatentes.Controls.Add(this.lblAddPatente);
            this.grpPatentes.Controls.Add(this.btnConfigurar);
            this.grpPatentes.Controls.Add(this.cbUsuarios);
            this.grpPatentes.Controls.Add(this.lblCbUsuarios);
            this.grpPatentes.Location = new System.Drawing.Point(12, 153);
            this.grpPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Name = "grpPatentes";
            this.grpPatentes.Padding = new System.Windows.Forms.Padding(2);
            this.grpPatentes.Size = new System.Drawing.Size(256, 223);
            this.grpPatentes.TabIndex = 8;
            this.grpPatentes.TabStop = false;
            this.grpPatentes.Text = "Usuarios";
            // 
            // btnAgregarFamilia
            // 
            this.btnAgregarFamilia.Location = new System.Drawing.Point(9, 194);
            this.btnAgregarFamilia.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarFamilia.Name = "btnAgregarFamilia";
            this.btnAgregarFamilia.Size = new System.Drawing.Size(83, 26);
            this.btnAgregarFamilia.TabIndex = 13;
            this.btnAgregarFamilia.Text = "Agregar >>";
            this.btnAgregarFamilia.UseVisualStyleBackColor = true;
            this.btnAgregarFamilia.Click += new System.EventHandler(this.btnAgregarFamilia_Click);
            // 
            // cbFamilias
            // 
            this.cbFamilias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamilias.FormattingEnabled = true;
            this.cbFamilias.Location = new System.Drawing.Point(9, 169);
            this.cbFamilias.Margin = new System.Windows.Forms.Padding(2);
            this.cbFamilias.Name = "cbFamilias";
            this.cbFamilias.Size = new System.Drawing.Size(234, 21);
            this.cbFamilias.TabIndex = 12;
            // 
            // lblAddFamilia
            // 
            this.lblAddFamilia.AutoSize = true;
            this.lblAddFamilia.Location = new System.Drawing.Point(7, 153);
            this.lblAddFamilia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddFamilia.Name = "lblAddFamilia";
            this.lblAddFamilia.Size = new System.Drawing.Size(84, 13);
            this.lblAddFamilia.TabIndex = 11;
            this.lblAddFamilia.Text = "Agregar Familias";
            // 
            // btnAddPatente
            // 
            this.btnAddPatente.Location = new System.Drawing.Point(9, 126);
            this.btnAddPatente.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPatente.Name = "btnAddPatente";
            this.btnAddPatente.Size = new System.Drawing.Size(83, 25);
            this.btnAddPatente.TabIndex = 10;
            this.btnAddPatente.Text = "Agregar >>";
            this.btnAddPatente.UseVisualStyleBackColor = true;
            this.btnAddPatente.Click += new System.EventHandler(this.btnAddPatente_Click);
            // 
            // cbPatentes
            // 
            this.cbPatentes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatentes.FormattingEnabled = true;
            this.cbPatentes.Location = new System.Drawing.Point(9, 102);
            this.cbPatentes.Margin = new System.Windows.Forms.Padding(2);
            this.cbPatentes.Name = "cbPatentes";
            this.cbPatentes.Size = new System.Drawing.Size(234, 21);
            this.cbPatentes.TabIndex = 9;
            // 
            // lblAddPatente
            // 
            this.lblAddPatente.AutoSize = true;
            this.lblAddPatente.Location = new System.Drawing.Point(7, 85);
            this.lblAddPatente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddPatente.Name = "lblAddPatente";
            this.lblAddPatente.Size = new System.Drawing.Size(88, 13);
            this.lblAddPatente.TabIndex = 8;
            this.lblAddPatente.Text = "Agregar patentes";
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.Location = new System.Drawing.Point(8, 55);
            this.btnConfigurar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(83, 25);
            this.btnConfigurar.TabIndex = 7;
            this.btnConfigurar.Text = "Configurar";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // cbUsuarios
            // 
            this.cbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuarios.FormattingEnabled = true;
            this.cbUsuarios.Location = new System.Drawing.Point(8, 31);
            this.cbUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.cbUsuarios.Name = "cbUsuarios";
            this.cbUsuarios.Size = new System.Drawing.Size(234, 21);
            this.cbUsuarios.TabIndex = 6;
            // 
            // lblCbUsuarios
            // 
            this.lblCbUsuarios.AutoSize = true;
            this.lblCbUsuarios.Location = new System.Drawing.Point(6, 15);
            this.lblCbUsuarios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCbUsuarios.Name = "lblCbUsuarios";
            this.lblCbUsuarios.Size = new System.Drawing.Size(95, 13);
            this.lblCbUsuarios.TabIndex = 5;
            this.lblCbUsuarios.Text = "Todos los usuarios";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 389);
            this.Controls.Add(this.tvPerfil);
            this.Controls.Add(this.grpPatentes);
            this.Controls.Add(this.grpbLogout);
            this.Controls.Add(this.gbCambiarClave);
            this.Name = "FrmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.gbCambiarClave.ResumeLayout(false);
            this.gbCambiarClave.PerformLayout();
            this.grpbLogout.ResumeLayout(false);
            this.grpPatentes.ResumeLayout(false);
            this.grpPatentes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCambiarClave;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Label lblClaveNueva;
        private System.Windows.Forms.Label lblClaveActual;
        private System.Windows.Forms.TextBox txtPassNueva;
        private System.Windows.Forms.TextBox txtPassActual;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox grpbLogout;
        private System.Windows.Forms.Button btnGuardarFamilia;
        private System.Windows.Forms.TreeView tvPerfil;
        private System.Windows.Forms.GroupBox grpPatentes;
        private System.Windows.Forms.Button btnAgregarFamilia;
        private System.Windows.Forms.ComboBox cbFamilias;
        private System.Windows.Forms.Label lblAddFamilia;
        private System.Windows.Forms.Button btnAddPatente;
        private System.Windows.Forms.ComboBox cbPatentes;
        private System.Windows.Forms.Label lblAddPatente;
        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.ComboBox cbUsuarios;
        private System.Windows.Forms.Label lblCbUsuarios;
    }
}