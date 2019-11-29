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
            this.txtpass.Location = new System.Drawing.Point(463, 53);
            this.txtpass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(122, 20);
            this.txtpass.TabIndex = 0;
            // 
            // txtConf
            // 
            this.txtConf.Location = new System.Drawing.Point(463, 97);
            this.txtConf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtConf.Name = "txtConf";
            this.txtConf.Size = new System.Drawing.Size(122, 20);
            this.txtConf.TabIndex = 1;
            // 
            // btnConf
            // 
            this.btnConf.Location = new System.Drawing.Point(463, 162);
            this.btnConf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(121, 32);
            this.btnConf.TabIndex = 2;
            this.btnConf.Text = "Confirmar";
            this.btnConf.UseVisualStyleBackColor = true;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Contraña nueva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Confirmar Contraña";
            // 
            // CambiarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 227);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.txtConf);
            this.Controls.Add(this.txtpass);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CambiarPass";
            this.Text = "CambiarPass";
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