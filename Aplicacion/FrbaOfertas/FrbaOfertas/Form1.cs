using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.AbmProveedor;
using System.Configuration;
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
            this.Hide();
        }

        private void crearProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProveedor formAltaProveedor = new AltaProveedor();
            formAltaProveedor.Show();
            this.Hide();
        }

        private void verProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerProveedores formVerProveedores = new VerProveedores();
            formVerProveedores.Show();
            this.Hide();
        }

        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaCredito fcc = new CargaCredito();
            fcc.Show();
            this.Hide();
        }

        private void publicarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarOferta fpo = new PublicarOferta();
            fpo.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateFormat"]);
        }

    }
}
