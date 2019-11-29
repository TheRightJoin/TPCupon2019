using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AdmRol.altaRol(textBox1.Text) == 1)
            {
                MessageBox.Show("Alta realizada con exito");
                AgregarFuncionalidades agregarFuncionalidades = new AgregarFuncionalidades();
                agregarFuncionalidades.Show();
                this.Hide();
            }
            else { MessageBox.Show("No se pudo realizar el alta del rol","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error); }
        }

        private void AltaRol_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }
    }
}
