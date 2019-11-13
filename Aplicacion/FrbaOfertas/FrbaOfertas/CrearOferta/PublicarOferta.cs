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
    public partial class PublicarOferta : Form
    {
        public PublicarOferta()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Oferta of;
            of = new Oferta(txtCodigo.Text, Convert.ToDecimal(txtPrecioOferta.Text), Convert.ToDecimal(txtPrecioLista.Text),
                dtpFechaPub.Value.Date, dtpFechaVec.Value.Date, Convert.ToDecimal(txtCantidad.Text), txtDesc.Text,
                1, txtProv.Text);
            int filas = AdmOfertas.altaOferta(of);
            if (filas > 0)
            {
                MessageBox.Show("Oferta creada correctamente");
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Error en la creacion");
            }
        }

    }
}
