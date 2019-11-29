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
            this.txtCantxCli = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
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
            this.txtPrecioLista.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioLista_KeyPress);
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
            this.txtPrecioOferta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioOferta_KeyPress);
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
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(135, 340);
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
            this.txtCodigo.Location = new System.Drawing.Point(471, 136);
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
            // txtCantxCli
            // 
            this.txtCantxCli.Location = new System.Drawing.Point(471, 316);
            this.txtCantxCli.Name = "txtCantxCli";
            this.txtCantxCli.Size = new System.Drawing.Size(100, 20);
            this.txtCantxCli.TabIndex = 12;
            this.txtCantxCli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantxCli_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Codigo de oferta";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cantidad por Cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(124, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(329, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 57;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(329, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 57;
            this.label11.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(576, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 57;
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(577, 226);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 57;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(577, 274);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 20);
            this.label14.TabIndex = 57;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(576, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 57;
            this.label15.Text = "*";
            // 
            // PublicarOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 392);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCantxCli);
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
        private System.Windows.Forms.TextBox txtCantxCli;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}