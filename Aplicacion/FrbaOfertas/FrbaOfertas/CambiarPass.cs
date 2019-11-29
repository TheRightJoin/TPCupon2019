using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas;

namespace FrbaOfertas
{
    public partial class CambiarPass : Form
    {
        public CambiarPass()
        {
            InitializeComponent();
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            if (txtConf.Text != "" && txtpass.Text != "")
            {
                if (txtConf.Text == txtpass.Text)
                {
                    String usuario = Login.username;
                    AdmUsuario.cambiarContrasenia(usuario, txtpass.Text);
                    MessageBox.Show("Su Contraña fue cambiada con exito");
                    this.Hide();
                    Form1 f = new Form1();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Los campos no coinciden");
                }
            }
            else {
                MessageBox.Show("No puede ingresar una contrasenia vacia");
            }
           
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }
    }
}
