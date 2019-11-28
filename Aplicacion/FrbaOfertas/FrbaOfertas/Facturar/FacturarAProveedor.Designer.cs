namespace FrbaOfertas.Facturar
{
    partial class FacturarAProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateMin = new System.Windows.Forms.DateTimePicker();
            this.dateMax = new System.Windows.Forms.DateTimePicker();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.dgvOfertas = new System.Windows.Forms.DataGridView();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).BeginInit();
            this.SuspendLayout();
            // 
            // dateMin
            // 
            this.dateMin.Location = new System.Drawing.Point(131, 122);
            this.dateMin.Name = "dateMin";
            this.dateMin.Size = new System.Drawing.Size(200, 26);
            this.dateMin.TabIndex = 0;
            // 
            // dateMax
            // 
            this.dateMax.Location = new System.Drawing.Point(642, 122);
            this.dateMax.Name = "dateMax";
            this.dateMax.Size = new System.Drawing.Size(200, 26);
            this.dateMax.TabIndex = 1;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(131, 199);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.RowTemplate.Height = 28;
            this.dgvProveedores.Size = new System.Drawing.Size(711, 370);
            this.dgvProveedores.TabIndex = 2;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // dgvOfertas
            // 
            this.dgvOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertas.Location = new System.Drawing.Point(131, 625);
            this.dgvOfertas.Name = "dgvOfertas";
            this.dgvOfertas.RowTemplate.Height = 28;
            this.dgvOfertas.Size = new System.Drawing.Size(711, 150);
            this.dgvOfertas.TabIndex = 3;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(131, 797);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(166, 83);
            this.btnFacturar.TabIndex = 4;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fecha minima";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(638, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha maxima";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Proveedores";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 602);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ofertas";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(398, 797);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(0, 20);
            this.lblImporte.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 20);
            this.label5.TabIndex = 10;
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(398, 847);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(0, 20);
            this.lblNumero.TabIndex = 11;
            // 
            // FacturarAProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 922);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.dgvOfertas);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.dateMax);
            this.Controls.Add(this.dateMin);
            this.Name = "FacturarAProveedor";
            this.Text = "FacturarAProveedor";
            this.Load += new System.EventHandler(this.FacturarAProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateMin;
        private System.Windows.Forms.DateTimePicker dateMax;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridView dgvOfertas;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNumero;
    }
}