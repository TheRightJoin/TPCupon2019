namespace FrbaOfertas
{
    partial class Perfil
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
            this.txtBienvenido = new System.Windows.Forms.Label();
            this.btnModificarPass = new System.Windows.Forms.Button();
            this.btnLogOUt = new System.Windows.Forms.Button();
            this.btnLogoutAdm = new System.Windows.Forms.Button();
            this.btnModificarPassAdm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEliminarAdm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBienvenido
            // 
            this.txtBienvenido.AutoSize = true;
            this.txtBienvenido.Location = new System.Drawing.Point(55, 125);
            this.txtBienvenido.Name = "txtBienvenido";
            this.txtBienvenido.Size = new System.Drawing.Size(87, 20);
            this.txtBienvenido.TabIndex = 0;
            this.txtBienvenido.Text = "Bienvenido";
            // 
            // btnModificarPass
            // 
            this.btnModificarPass.Location = new System.Drawing.Point(39, 242);
            this.btnModificarPass.Name = "btnModificarPass";
            this.btnModificarPass.Size = new System.Drawing.Size(147, 73);
            this.btnModificarPass.TabIndex = 1;
            this.btnModificarPass.Text = "Modificar Contrasenia";
            this.btnModificarPass.UseVisualStyleBackColor = true;
            this.btnModificarPass.Click += new System.EventHandler(this.btnModificarPass_Click);
            // 
            // btnLogOUt
            // 
            this.btnLogOUt.Location = new System.Drawing.Point(265, 258);
            this.btnLogOUt.Name = "btnLogOUt";
            this.btnLogOUt.Size = new System.Drawing.Size(147, 73);
            this.btnLogOUt.TabIndex = 3;
            this.btnLogOUt.Text = "Log Out";
            this.btnLogOUt.UseVisualStyleBackColor = true;
            this.btnLogOUt.Click += new System.EventHandler(this.btnLogOUt_Click);
            // 
            // btnLogoutAdm
            // 
            this.btnLogoutAdm.Location = new System.Drawing.Point(478, 336);
            this.btnLogoutAdm.Name = "btnLogoutAdm";
            this.btnLogoutAdm.Size = new System.Drawing.Size(147, 73);
            this.btnLogoutAdm.TabIndex = 5;
            this.btnLogoutAdm.Text = "Log Out";
            this.btnLogoutAdm.UseVisualStyleBackColor = true;
            this.btnLogoutAdm.Click += new System.EventHandler(this.btnLogoutAdm_Click);
            // 
            // btnModificarPassAdm
            // 
            this.btnModificarPassAdm.Location = new System.Drawing.Point(478, 57);
            this.btnModificarPassAdm.Name = "btnModificarPassAdm";
            this.btnModificarPassAdm.Size = new System.Drawing.Size(147, 73);
            this.btnModificarPassAdm.TabIndex = 4;
            this.btnModificarPassAdm.Text = "Modificar Contrasenia";
            this.btnModificarPassAdm.UseVisualStyleBackColor = true;
            this.btnModificarPassAdm.Click += new System.EventHandler(this.btnModificarPassAdm_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(402, 353);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // btnEliminarAdm
            // 
            this.btnEliminarAdm.Location = new System.Drawing.Point(478, 173);
            this.btnEliminarAdm.Name = "btnEliminarAdm";
            this.btnEliminarAdm.Size = new System.Drawing.Size(147, 73);
            this.btnEliminarAdm.TabIndex = 7;
            this.btnEliminarAdm.Text = "Eliminar Usuario";
            this.btnEliminarAdm.UseVisualStyleBackColor = true;
            this.btnEliminarAdm.Click += new System.EventHandler(this.btnEliminarAdm_Click);
            // 
            // Perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 464);
            this.Controls.Add(this.btnEliminarAdm);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnLogoutAdm);
            this.Controls.Add(this.btnModificarPassAdm);
            this.Controls.Add(this.btnLogOUt);
            this.Controls.Add(this.btnModificarPass);
            this.Controls.Add(this.txtBienvenido);
            this.Name = "Perfil";
            this.Text = "Perfil";
            this.Load += new System.EventHandler(this.Perfil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtBienvenido;
        private System.Windows.Forms.Button btnModificarPass;
        private System.Windows.Forms.Button btnLogOUt;
        private System.Windows.Forms.Button btnLogoutAdm;
        private System.Windows.Forms.Button btnModificarPassAdm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEliminarAdm;
    }
}