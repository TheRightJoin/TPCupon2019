namespace FrbaOfertas
{
    partial class PublicarOferta
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
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaPub = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaVec = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioLista = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrecioOferta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblSeleccioneProv = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.dgvProve = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProve)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(7, 119);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(321, 72);
            this.txtDesc.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripcion de la oferta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de publicacion";
            // 
            // dtpFechaPub
            // 
            this.dtpFechaPub.Location = new System.Drawing.Point(128, 223);
            this.dtpFechaPub.Name = "dtpFechaPub";
            this.dtpFechaPub.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaPub.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de vencimiento";
            // 
            // dtpFechaVec
            // 
            this.dtpFechaVec.Location = new System.Drawing.Point(128, 272);
            this.dtpFechaVec.Name = "dtpFechaVec";
            this.dtpFechaVec.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVec.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Precio de Lista";
            // 
            // txtPrecioLista
            // 
            this.txtPrecioLista.Location = new System.Drawing.Point(471, 180);
            this.txtPrecioLista.Name = "txtPrecioLista";
            this.txtPrecioLista.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioLista.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precio de Oferta";
            // 
            // txtPrecioOferta
            // 
            this.txtPrecioOferta.Location = new System.Drawing.Point(471, 226);
            this.txtPrecioOferta.Name = "txtPrecioOferta";
            this.txtPrecioOferta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioOferta.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(385, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(471, 272);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 6;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(133, 325);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(383, 43);
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblSeleccioneProv
            // 
            this.lblSeleccioneProv.AutoSize = true;
            this.lblSeleccioneProv.Location = new System.Drawing.Point(668, 94);
            this.lblSeleccioneProv.Name = "lblSeleccioneProv";
            this.lblSeleccioneProv.Size = new System.Drawing.Size(126, 13);
            this.lblSeleccioneProv.TabIndex = 5;
            this.lblSeleccioneProv.Text = "Seleccione un proveedor";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(471, 119);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 6;
            // 
            // dgvProve
            // 
            this.dgvProve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProve.Location = new System.Drawing.Point(597, 119);
            this.dgvProve.Name = "dgvProve";
            this.dgvProve.Size = new System.Drawing.Size(273, 214);
            this.dgvProve.TabIndex = 11;
            this.dgvProve.SelectionChanged += new System.EventHandler(this.dgvProve_SelectionChanged);
            // 
            // PublicarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 392);
            this.Controls.Add(this.dgvProve);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecioOferta);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtPrecioLista);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSeleccioneProv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFechaVec);
            this.Controls.Add(this.dtpFechaPub);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesc);
            this.Name = "PublicarOferta";
            this.Text = "PublicarOferta";
            this.Load += new System.EventHandler(this.PublicarOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaPub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaVec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioLista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrecioOferta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblSeleccioneProv;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.DataGridView dgvProve;
    }
}