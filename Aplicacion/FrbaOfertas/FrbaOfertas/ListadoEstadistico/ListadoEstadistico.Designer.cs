namespace FrbaOfertas
{
    partial class ListadoEstadistico
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
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbSem1 = new System.Windows.Forms.RadioButton();
            this.rdbSem2 = new System.Windows.Forms.RadioButton();
            this.dgvEstadistica = new System.Windows.Forms.DataGridView();
            this.cmbTipoEst = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerEst = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAnio
            // 
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(96, 92);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(121, 21);
            this.cmbAnio.TabIndex = 0;
            this.cmbAnio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAnio_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione un año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el semestre";
            // 
            // rdbSem1
            // 
            this.rdbSem1.AutoSize = true;
            this.rdbSem1.Checked = true;
            this.rdbSem1.Location = new System.Drawing.Point(283, 96);
            this.rdbSem1.Name = "rdbSem1";
            this.rdbSem1.Size = new System.Drawing.Size(31, 17);
            this.rdbSem1.TabIndex = 3;
            this.rdbSem1.TabStop = true;
            this.rdbSem1.Text = "1";
            this.rdbSem1.UseVisualStyleBackColor = true;
            // 
            // rdbSem2
            // 
            this.rdbSem2.AutoSize = true;
            this.rdbSem2.Location = new System.Drawing.Point(333, 96);
            this.rdbSem2.Name = "rdbSem2";
            this.rdbSem2.Size = new System.Drawing.Size(31, 17);
            this.rdbSem2.TabIndex = 3;
            this.rdbSem2.Text = "2";
            this.rdbSem2.UseVisualStyleBackColor = true;
            // 
            // dgvEstadistica
            // 
            this.dgvEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstadistica.Location = new System.Drawing.Point(96, 189);
            this.dgvEstadistica.Name = "dgvEstadistica";
            this.dgvEstadistica.Size = new System.Drawing.Size(550, 180);
            this.dgvEstadistica.TabIndex = 4;
            // 
            // cmbTipoEst
            // 
            this.cmbTipoEst.FormattingEnabled = true;
            this.cmbTipoEst.Items.AddRange(new object[] {
            "Proveedores con mayor facturacion",
            "Proveedores con mayor descuento"});
            this.cmbTipoEst.Location = new System.Drawing.Point(434, 92);
            this.cmbTipoEst.Name = "cmbTipoEst";
            this.cmbTipoEst.Size = new System.Drawing.Size(196, 21);
            this.cmbTipoEst.TabIndex = 5;
            this.cmbTipoEst.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTipoEst_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo de estadistica";
            // 
            // btnVerEst
            // 
            this.btnVerEst.Location = new System.Drawing.Point(96, 131);
            this.btnVerEst.Name = "btnVerEst";
            this.btnVerEst.Size = new System.Drawing.Size(550, 39);
            this.btnVerEst.TabIndex = 7;
            this.btnVerEst.Text = "Ver Estadisticas";
            this.btnVerEst.UseVisualStyleBackColor = true;
            this.btnVerEst.Click += new System.EventHandler(this.btnVerEst_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 396);
            this.Controls.Add(this.btnVerEst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoEst);
            this.Controls.Add(this.dgvEstadistica);
            this.Controls.Add(this.rdbSem2);
            this.Controls.Add(this.rdbSem1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAnio);
            this.Name = "ListadoEstadistico";
            this.Text = "ListadoEstadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstadistica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbSem1;
        private System.Windows.Forms.RadioButton rdbSem2;
        private System.Windows.Forms.DataGridView dgvEstadistica;
        private System.Windows.Forms.ComboBox cmbTipoEst;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerEst;
    }
}