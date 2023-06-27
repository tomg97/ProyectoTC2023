namespace ProyectoTC2023 {
    partial class FrmDespacho {
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
            this.gbIdFacturas = new System.Windows.Forms.GroupBox();
            this.lblDniFactura = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.lblIdFactura = new System.Windows.Forms.Label();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.btnDespachar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.trvFactura = new System.Windows.Forms.TreeView();
            this.gbIdFacturas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbIdFacturas
            // 
            this.gbIdFacturas.Controls.Add(this.lblDniFactura);
            this.gbIdFacturas.Controls.Add(this.txtIdCliente);
            this.gbIdFacturas.Controls.Add(this.lblIdFactura);
            this.gbIdFacturas.Controls.Add(this.txtIdFactura);
            this.gbIdFacturas.Controls.Add(this.btnDespachar);
            this.gbIdFacturas.Location = new System.Drawing.Point(12, 12);
            this.gbIdFacturas.Name = "gbIdFacturas";
            this.gbIdFacturas.Size = new System.Drawing.Size(133, 137);
            this.gbIdFacturas.TabIndex = 0;
            this.gbIdFacturas.TabStop = false;
            this.gbIdFacturas.Text = "Identificador Facturas";
            // 
            // lblDniFactura
            // 
            this.lblDniFactura.AutoSize = true;
            this.lblDniFactura.Location = new System.Drawing.Point(6, 55);
            this.lblDniFactura.Name = "lblDniFactura";
            this.lblDniFactura.Size = new System.Drawing.Size(61, 13);
            this.lblDniFactura.TabIndex = 4;
            this.lblDniFactura.Text = "DNI Cliente";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(6, 71);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(115, 20);
            this.txtIdCliente.TabIndex = 3;
            // 
            // lblIdFactura
            // 
            this.lblIdFactura.AutoSize = true;
            this.lblIdFactura.Location = new System.Drawing.Point(6, 16);
            this.lblIdFactura.Name = "lblIdFactura";
            this.lblIdFactura.Size = new System.Drawing.Size(55, 13);
            this.lblIdFactura.TabIndex = 2;
            this.lblIdFactura.Text = "Id Factura";
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(6, 32);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(115, 20);
            this.txtIdFactura.TabIndex = 1;
            // 
            // btnDespachar
            // 
            this.btnDespachar.Location = new System.Drawing.Point(6, 103);
            this.btnDespachar.Name = "btnDespachar";
            this.btnDespachar.Size = new System.Drawing.Size(115, 23);
            this.btnDespachar.TabIndex = 0;
            this.btnDespachar.Text = "Despachar";
            this.btnDespachar.UseVisualStyleBackColor = true;
            this.btnDespachar.Click += new System.EventHandler(this.btnDespachar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvFactura);
            this.groupBox1.Location = new System.Drawing.Point(151, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 426);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualizador facturas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Location = new System.Drawing.Point(12, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionador Facturas";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 31);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(115, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Seleccionar";
            this.btnSelect.UseMnemonic = false;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // trvFactura
            // 
            this.trvFactura.Location = new System.Drawing.Point(6, 19);
            this.trvFactura.Name = "trvFactura";
            this.trvFactura.Size = new System.Drawing.Size(631, 401);
            this.trvFactura.TabIndex = 0;
            this.trvFactura.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trvJson_KeyDown);
            // 
            // FrmDespacho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbIdFacturas);
            this.Name = "FrmDespacho";
            this.Text = "FrmDespacho";
            this.gbIdFacturas.ResumeLayout(false);
            this.gbIdFacturas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbIdFacturas;
        private System.Windows.Forms.Label lblDniFactura;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label lblIdFactura;
        private System.Windows.Forms.TextBox txtIdFactura;
        private System.Windows.Forms.Button btnDespachar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TreeView trvFactura;
    }
}