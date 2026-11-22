namespace ProyectoTC2023 {
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
            this.cbIdioma = new System.Windows.Forms.ComboBox();
            this.lblLang = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblUsu = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSinSesion = new System.Windows.Forms.Button();
            this.btnAplicarIdioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbIdioma
            // 
            this.cbIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdioma.FormattingEnabled = true;
            this.cbIdioma.Items.AddRange(new object[] {
            "Español",
            "Inglés"});
            this.cbIdioma.Location = new System.Drawing.Point(400, 40);
            this.cbIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbIdioma.Name = "cbIdioma";
            this.cbIdioma.Size = new System.Drawing.Size(191, 33);
            this.cbIdioma.TabIndex = 4;
            this.cbIdioma.SelectedIndexChanged += new System.EventHandler(this.cbIdioma_SelectedIndexChanged);
            // 
            // lblLang
            // 
            this.lblLang.AutoSize = true;
            this.lblLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLang.Location = new System.Drawing.Point(400, 11);
            this.lblLang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLang.Name = "lblLang";
            this.lblLang.Size = new System.Drawing.Size(70, 25);
            this.lblLang.TabIndex = 12;
            this.lblLang.Text = "Idioma";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.Location = new System.Drawing.Point(8, 83);
            this.lblPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(114, 25);
            this.lblPass.TabIndex = 11;
            this.lblPass.Text = "Contraseña";
            // 
            // lblUsu
            // 
            this.lblUsu.AutoSize = true;
            this.lblUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsu.Location = new System.Drawing.Point(8, 11);
            this.lblUsu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsu.Name = "lblUsu";
            this.lblUsu.Size = new System.Drawing.Size(180, 25);
            this.lblUsu.TabIndex = 10;
            this.lblUsu.Text = "Nombre de Usuario";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(13, 112);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(225, 30);
            this.txtPass.TabIndex = 2;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // txtUsu
            // 
            this.txtUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsu.Location = new System.Drawing.Point(13, 40);
            this.txtUsu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(225, 30);
            this.txtUsu.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(243, 40);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(149, 102);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSinSesion
            // 
            this.btnSinSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinSesion.Location = new System.Drawing.Point(13, 161);
            this.btnSinSesion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSinSesion.Name = "btnSinSesion";
            this.btnSinSesion.Size = new System.Drawing.Size(225, 59);
            this.btnSinSesion.TabIndex = 6;
            this.btnSinSesion.Text = "Continuar sin sesión";
            this.btnSinSesion.UseVisualStyleBackColor = true;
            this.btnSinSesion.Click += new System.EventHandler(this.btnSinSesion_Click);
            // 
            // btnAplicarIdioma
            // 
            this.btnAplicarIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarIdioma.Location = new System.Drawing.Point(400, 83);
            this.btnAplicarIdioma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicarIdioma.Name = "btnAplicarIdioma";
            this.btnAplicarIdioma.Size = new System.Drawing.Size(191, 59);
            this.btnAplicarIdioma.TabIndex = 5;
            this.btnAplicarIdioma.Text = "Aplicar";
            this.btnAplicarIdioma.UseVisualStyleBackColor = true;
            this.btnAplicarIdioma.Click += new System.EventHandler(this.btnAplicarIdioma_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 232);
            this.Controls.Add(this.btnAplicarIdioma);
            this.Controls.Add(this.btnSinSesion);
            this.Controls.Add(this.cbIdioma);
            this.Controls.Add(this.lblLang);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUsu);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsu);
            this.Controls.Add(this.btnLogin);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIdioma;
        private System.Windows.Forms.Label lblLang;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblUsu;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSinSesion;
        private System.Windows.Forms.Button btnAplicarIdioma;
    }
}