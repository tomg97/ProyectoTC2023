﻿namespace ProyectoTC2023 {
    partial class LoginForm {
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsu = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSinSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Español",
            "Inglés"});
            this.comboBox1.Location = new System.Drawing.Point(311, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Location = new System.Drawing.Point(308, 9);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(38, 13);
            this.lblLang.TabIndex = 13;
            this.lblLang.Text = "Idioma";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(15, 88);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(61, 13);
            this.lblPass.TabIndex = 12;
            this.lblPass.Text = "Contraseña";
            // 
            // lblUsu
            // 
            this.lblUsu.AutoSize = true;
            this.lblUsu.Location = new System.Drawing.Point(12, 9);
            this.lblUsu.Name = "lblUsu";
            this.lblUsu.Size = new System.Drawing.Size(98, 13);
            this.lblUsu.TabIndex = 11;
            this.lblUsu.Text = "Nombre de Usuario";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(15, 104);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(170, 20);
            this.txtPass.TabIndex = 10;
            // 
            // txtUsu
            // 
            this.txtUsu.Location = new System.Drawing.Point(15, 25);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(170, 20);
            this.txtUsu.TabIndex = 9;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(191, 76);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(112, 48);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSinSesion
            // 
            this.btnSinSesion.Location = new System.Drawing.Point(311, 76);
            this.btnSinSesion.Name = "btnSinSesion";
            this.btnSinSesion.Size = new System.Drawing.Size(112, 48);
            this.btnSinSesion.TabIndex = 15;
            this.btnSinSesion.Text = "Continuar sin sesión";
            this.btnSinSesion.UseVisualStyleBackColor = true;
            this.btnSinSesion.Click += new System.EventHandler(this.btnSinSesion_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 150);
            this.Controls.Add(this.btnSinSesion);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUsu);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.btnLogin);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsu;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSinSesion;
    }
}