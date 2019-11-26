using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class Login : Form
    {
        int intento = 0;
        public Login()
        {
            InitializeComponent();
        }
        //HAY UN lblRestantes PARA PONER LOS INTENTOS QUE QUEDAN
        private void btnLogin_Click(object sender, EventArgs e)
        {
            intento = AdmUsuario.logueo(txtUsuario.Text, txtPass.Text, intento);
            switch(intento)
            {
                case 0:
                    MessageBox.Show("bien");
                    break;
                case 3:
                    MessageBox.Show("bloqueado");
                    intento = 0;
                    break;
                case 4:
                    MessageBox.Show("mal");
                    intento = 0;
                    break;
                default:
                    MessageBox.Show("mal");
                    break;
            }
        }
    }
}
