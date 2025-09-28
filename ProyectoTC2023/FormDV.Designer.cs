namespace ProyectoTC2023 {
    partial class FormDV {
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
            this.btnRealizarRestore = new System.Windows.Forms.Button();
            this.btnRecalcularDV = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRealizarRestore
            // 
            this.btnRealizarRestore.Location = new System.Drawing.Point(51, 33);
            this.btnRealizarRestore.Name = "btnRealizarRestore";
            this.btnRealizarRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRealizarRestore.TabIndex = 0;
            this.btnRealizarRestore.Text = "Restore";
            this.btnRealizarRestore.UseVisualStyleBackColor = true;
            this.btnRealizarRestore.Click += new System.EventHandler(this.btnRealizarRestore_Click);
            // 
            // btnRecalcularDV
            // 
            this.btnRecalcularDV.Location = new System.Drawing.Point(51, 84);
            this.btnRecalcularDV.Name = "btnRecalcularDV";
            this.btnRecalcularDV.Size = new System.Drawing.Size(75, 23);
            this.btnRecalcularDV.TabIndex = 1;
            this.btnRecalcularDV.Text = "Recalcular";
            this.btnRecalcularDV.UseVisualStyleBackColor = true;
            this.btnRecalcularDV.Visible = false;
            this.btnRecalcularDV.Click += new System.EventHandler(this.btnRecalcularDV_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(51, 134);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 181);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRecalcularDV);
            this.Controls.Add(this.btnRealizarRestore);
            this.Name = "FormDV";
            this.Text = "FormDV";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRealizarRestore;
        private System.Windows.Forms.Button btnRecalcularDV;
        private System.Windows.Forms.Button btnSalir;
    }
}