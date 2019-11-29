namespace FrbaOfertas
{
    partial class ListadoOfertas
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
            this.dgvOfertas = new System.Windows.Forms.DataGridView();
            this.btnComprar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOfertas
            // 
            this.dgvOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertas.Location = new System.Drawing.Point(70, 87);
            this.dgvOfertas.Name = "dgvOfertas";
            this.dgvOfertas.Size = new System.Drawing.Size(604, 268);
            this.dgvOfertas.TabIndex = 0;
            this.dgvOfertas.SelectionChanged += new System.EventHandler(this.dgvOfertas_SelectionChanged);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(485, 374);
            this.btnComprar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(189, 51);
            this.btnComprar.TabIndex = 1;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(144, 398);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(153, 20);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(787, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione un proveedor";
            // 
            // dgvCliente
            // 
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.Location = new System.Drawing.Point(707, 87);
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.Size = new System.Drawing.Size(273, 268);
            this.dgvCliente.TabIndex = 5;
            this.dgvCliente.SelectionChanged += new System.EventHandler(this.dgvCliente_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 401);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantidad";
            // 
            // ListadoOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 433);
            this.Controls.Add(this.dgvCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.dgvOfertas);
            this.Name = "ListadoOfertas";
            this.Text = "ListadoOfertas";
            this.Load += new System.EventHandler(this.ListadoOfertas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOfertas;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.Label label1;
    }
}