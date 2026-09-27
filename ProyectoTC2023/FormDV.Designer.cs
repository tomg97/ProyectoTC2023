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
            this.btnRecalcularDV = new System.Windows.Forms.Button();
            this.dgvDVRestore = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVRestore)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecalcularDV
            // 
            this.btnRecalcularDV.Location = new System.Drawing.Point(679, 209);
            this.btnRecalcularDV.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecalcularDV.Name = "btnRecalcularDV";
            this.btnRecalcularDV.Size = new System.Drawing.Size(100, 28);
            this.btnRecalcularDV.TabIndex = 1;
            this.btnRecalcularDV.Text = "Recalcular";
            this.btnRecalcularDV.UseVisualStyleBackColor = true;
            this.btnRecalcularDV.Click += new System.EventHandler(this.btnRecalcularDV_Click);
            // 
            // dgvDVRestore
            // 
            this.dgvDVRestore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDVRestore.Location = new System.Drawing.Point(13, 13);
            this.dgvDVRestore.Name = "dgvDVRestore";
            this.dgvDVRestore.RowHeadersWidth = 51;
            this.dgvDVRestore.RowTemplate.Height = 24;
            this.dgvDVRestore.Size = new System.Drawing.Size(659, 224);
            this.dgvDVRestore.TabIndex = 2;
            // 
            // FormDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 250);
            this.Controls.Add(this.dgvDVRestore);
            this.Controls.Add(this.btnRecalcularDV);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormDV";
            this.Text = "FormDV";
            this.Load += new System.EventHandler(this.FormDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDVRestore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRecalcularDV;
        private System.Windows.Forms.DataGridView dgvDVRestore;
    }
}