namespace ProyectoTC2023 {
    partial class FrmRecepcion {
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnComentar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnRecibido = new System.Windows.Forms.Button();
            this.dgvOrdenesCompra = new System.Windows.Forms.DataGridView();
            this.labelTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(840, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 58);
            this.button2.TabIndex = 47;
            this.button2.Text = "❓";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnComentar
            // 
            this.btnComentar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnComentar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnComentar.Location = new System.Drawing.Point(746, 258);
            this.btnComentar.Margin = new System.Windows.Forms.Padding(4);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.Size = new System.Drawing.Size(175, 49);
            this.btnComentar.TabIndex = 46;
            this.btnComentar.Text = "Comentar";
            this.btnComentar.UseVisualStyleBackColor = false;
            this.btnComentar.Click += new System.EventHandler(this.btnComentar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnImprimir.Location = new System.Drawing.Point(746, 372);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(175, 49);
            this.btnImprimir.TabIndex = 45;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnRecibido
            // 
            this.btnRecibido.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecibido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnRecibido.Location = new System.Drawing.Point(746, 315);
            this.btnRecibido.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecibido.Name = "btnRecibido";
            this.btnRecibido.Size = new System.Drawing.Size(175, 49);
            this.btnRecibido.TabIndex = 44;
            this.btnRecibido.Text = "Recibir";
            this.btnRecibido.UseVisualStyleBackColor = false;
            this.btnRecibido.Click += new System.EventHandler(this.btnRecibido_Click);
            // 
            // dgvOrdenesCompra
            // 
            this.dgvOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesCompra.Location = new System.Drawing.Point(13, 78);
            this.dgvOrdenesCompra.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrdenesCompra.Name = "dgvOrdenesCompra";
            this.dgvOrdenesCompra.ReadOnly = true;
            this.dgvOrdenesCompra.RowHeadersWidth = 51;
            this.dgvOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdenesCompra.Size = new System.Drawing.Size(725, 343);
            this.dgvOrdenesCompra.TabIndex = 43;
            this.dgvOrdenesCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesCompra_CellClick);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelTitulo.Location = new System.Drawing.Point(13, 28);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(300, 29);
            this.labelTitulo.TabIndex = 42;
            this.labelTitulo.Text = "Ordenes de compra pagas";
            // 
            // FrmRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 439);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnRecibido);
            this.Controls.Add(this.dgvOrdenesCompra);
            this.Controls.Add(this.labelTitulo);
            this.Name = "FrmRecepcion";
            this.Text = "FrmRecepcion";
            this.Load += new System.EventHandler(this.FrmRecepcion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesCompra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnComentar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnRecibido;
        private System.Windows.Forms.DataGridView dgvOrdenesCompra;
        private System.Windows.Forms.Label labelTitulo;
    }
}