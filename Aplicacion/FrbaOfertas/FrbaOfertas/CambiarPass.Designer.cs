namespace FrbaOfertas
{
    partial class CambiarPass
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
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtConf = new System.Windows.Forms.TextBox();
            this.btnConf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(694, 82);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(181, 26);
            this.txtpass.TabIndex = 0;
            // 
            // txtConf
            // 
            this.txtConf.Location = new System.Drawing.Point(694, 149);
            this.txtConf.Name = "txtConf";
            this.txtConf.Size = new System.Drawing.Size(181, 26);
            this.txtConf.TabIndex = 1;
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(694, 249);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(182, 49);
            this.btnConf.TabIndex = 2;
            this.btnConf.Text = "Confirmar";
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraña nueva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirmar Contraña";
            // 
            // CambiarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1516, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.txtConf);
            this.Controls.Add(this.txtpass);
            this.Name = "CambiarPass";
            this.Text = "CambiarPass";
            this.Load += new System.EventHandler(this.CambiarPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtConf;
        private System.Windows.Forms.Button btnConf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}