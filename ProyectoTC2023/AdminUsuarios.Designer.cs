namespace ProyectoTC2023 {
    partial class AdminUsuarios {
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
            this.grpbxCMUsu = new System.Windows.Forms.GroupBox();
            this.lblABMPUsu = new System.Windows.Forms.Label();
            this.txtABMPUsu = new System.Windows.Forms.TextBox();
            this.btnEnterABM = new System.Windows.Forms.Button();
            this.lblABMNUsu = new System.Windows.Forms.Label();
            this.txtABMUsu = new System.Windows.Forms.TextBox();
            this.btnVerif = new System.Windows.Forms.Button();
            this.gbDesbloquearUsuarios = new System.Windows.Forms.GroupBox();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.cmbUsusBloq = new System.Windows.Forms.ComboBox();
            this.grpbxCMUsu.SuspendLayout();
            this.gbDesbloquearUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxCMUsu
            // 
            this.grpbxCMUsu.Controls.Add(this.lblABMPUsu);
            this.grpbxCMUsu.Controls.Add(this.txtABMPUsu);
            this.grpbxCMUsu.Controls.Add(this.btnEnterABM);
            this.grpbxCMUsu.Controls.Add(this.lblABMNUsu);
            this.grpbxCMUsu.Controls.Add(this.txtABMUsu);
            this.grpbxCMUsu.Controls.Add(this.btnVerif);
            this.grpbxCMUsu.Location = new System.Drawing.Point(12, 12);
            this.grpbxCMUsu.Name = "grpbxCMUsu";
            this.grpbxCMUsu.Size = new System.Drawing.Size(240, 113);
            this.grpbxCMUsu.TabIndex = 0;
            this.grpbxCMUsu.TabStop = false;
            this.grpbxCMUsu.Text = "Crear/Modificar Usuario";
            // 
            // lblABMPUsu
            // 
            this.lblABMPUsu.AutoSize = true;
            this.lblABMPUsu.Location = new System.Drawing.Point(7, 63);
            this.lblABMPUsu.Name = "lblABMPUsu";
            this.lblABMPUsu.Size = new System.Drawing.Size(64, 13);
            this.lblABMPUsu.TabIndex = 5;
            this.lblABMPUsu.Text = "Contraseña:";
            // 
            // txtABMPUsu
            // 
            this.txtABMPUsu.Location = new System.Drawing.Point(7, 83);
            this.txtABMPUsu.Name = "txtABMPUsu";
            this.txtABMPUsu.Size = new System.Drawing.Size(139, 20);
            this.txtABMPUsu.TabIndex = 4;
            // 
            // btnEnterABM
            // 
            this.btnEnterABM.Location = new System.Drawing.Point(152, 81);
            this.btnEnterABM.Name = "btnEnterABM";
            this.btnEnterABM.Size = new System.Drawing.Size(75, 23);
            this.btnEnterABM.TabIndex = 3;
            this.btnEnterABM.Text = "Modificar";
            this.btnEnterABM.UseVisualStyleBackColor = true;
            this.btnEnterABM.Click += new System.EventHandler(this.btnEnterABM_Click);
            // 
            // lblABMNUsu
            // 
            this.lblABMNUsu.AutoSize = true;
            this.lblABMNUsu.Location = new System.Drawing.Point(7, 20);
            this.lblABMNUsu.Name = "lblABMNUsu";
            this.lblABMNUsu.Size = new System.Drawing.Size(86, 13);
            this.lblABMNUsu.TabIndex = 2;
            this.lblABMNUsu.Text = "Nombre Usuario:";
            // 
            // txtABMUsu
            // 
            this.txtABMUsu.Location = new System.Drawing.Point(7, 40);
            this.txtABMUsu.Name = "txtABMUsu";
            this.txtABMUsu.Size = new System.Drawing.Size(139, 20);
            this.txtABMUsu.TabIndex = 1;
            // 
            // btnVerif
            // 
            this.btnVerif.Location = new System.Drawing.Point(152, 38);
            this.btnVerif.Name = "btnVerif";
            this.btnVerif.Size = new System.Drawing.Size(75, 23);
            this.btnVerif.TabIndex = 0;
            this.btnVerif.Text = "Verificar";
            this.btnVerif.UseVisualStyleBackColor = true;
            this.btnVerif.Click += new System.EventHandler(this.btnVerif_Click);
            // 
            // gbDesbloquearUsuarios
            // 
            this.gbDesbloquearUsuarios.Controls.Add(this.btnDesbloquear);
            this.gbDesbloquearUsuarios.Controls.Add(this.cmbUsusBloq);
            this.gbDesbloquearUsuarios.Location = new System.Drawing.Point(12, 131);
            this.gbDesbloquearUsuarios.Name = "gbDesbloquearUsuarios";
            this.gbDesbloquearUsuarios.Size = new System.Drawing.Size(240, 78);
            this.gbDesbloquearUsuarios.TabIndex = 1;
            this.gbDesbloquearUsuarios.TabStop = false;
            this.gbDesbloquearUsuarios.Text = "Desbloquear Usuarios";
            // 
            // btnDesbloquear
            // 
            this.btnDesbloquear.Location = new System.Drawing.Point(152, 46);
            this.btnDesbloquear.Name = "btnDesbloquear";
            this.btnDesbloquear.Size = new System.Drawing.Size(75, 23);
            this.btnDesbloquear.TabIndex = 6;
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.UseVisualStyleBackColor = true;
            this.btnDesbloquear.Click += new System.EventHandler(this.btnDesbloquear_Click);
            // 
            // cmbUsusBloq
            // 
            this.cmbUsusBloq.FormattingEnabled = true;
            this.cmbUsusBloq.Location = new System.Drawing.Point(6, 19);
            this.cmbUsusBloq.Name = "cmbUsusBloq";
            this.cmbUsusBloq.Size = new System.Drawing.Size(221, 21);
            this.cmbUsusBloq.TabIndex = 0;
            // 
            // AdminUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 225);
            this.Controls.Add(this.gbDesbloquearUsuarios);
            this.Controls.Add(this.grpbxCMUsu);
            this.Name = "AdminUsuarios";
            this.Text = "Admin Usuarios";
            this.Load += new System.EventHandler(this.AdminUsuarios_Load);
            this.grpbxCMUsu.ResumeLayout(false);
            this.grpbxCMUsu.PerformLayout();
            this.gbDesbloquearUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxCMUsu;
        private System.Windows.Forms.TextBox txtABMUsu;
        private System.Windows.Forms.Button btnVerif;
        private System.Windows.Forms.Label lblABMPUsu;
        private System.Windows.Forms.TextBox txtABMPUsu;
        private System.Windows.Forms.Button btnEnterABM;
        private System.Windows.Forms.Label lblABMNUsu;
        private System.Windows.Forms.GroupBox gbDesbloquearUsuarios;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.ComboBox cmbUsusBloq;
    }
}