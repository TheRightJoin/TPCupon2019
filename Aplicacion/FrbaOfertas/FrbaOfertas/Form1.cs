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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
        }


        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaCliente fac = new AltaCliente();
            fac.Show();
        }

        private void crearProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProveedor formAltaProveedor = new AltaProveedor();
            formAltaProveedor.Show();
            this.Hide();
        }
    }
}
