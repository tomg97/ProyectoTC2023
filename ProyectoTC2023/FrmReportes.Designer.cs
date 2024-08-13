namespace ProyectoTC2023 {
    partial class FrmReportes {
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
            this.cbReportes = new System.Windows.Forms.ComboBox();
            this.rvReportes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbReportes
            // 
            this.cbReportes.FormattingEnabled = true;
            this.cbReportes.Items.AddRange(new object[] {
            "Reporte 1",
            "Reporte 2",
            "Reporte Inteligente"});
            this.cbReportes.Location = new System.Drawing.Point(13, 13);
            this.cbReportes.Name = "cbReportes";
            this.cbReportes.Size = new System.Drawing.Size(201, 21);
            this.cbReportes.TabIndex = 0;
            // 
            // rvReportes
            // 
            this.rvReportes.Location = new System.Drawing.Point(13, 41);
            this.rvReportes.Name = "rvReportes";
            this.rvReportes.ServerReport.BearerToken = null;
            this.rvReportes.Size = new System.Drawing.Size(775, 397);
            this.rvReportes.TabIndex = 1;
            this.rvReportes.Load += new System.EventHandler(this.rvReportes_Load);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(221, 13);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(102, 23);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(329, 13);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.rvReportes);
            this.Controls.Add(this.cbReportes);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbReportes;
        private DataSetVenta dataSetVentas;
        private Microsoft.Reporting.WinForms.ReportViewer rvReportes;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnReset;
    }
}