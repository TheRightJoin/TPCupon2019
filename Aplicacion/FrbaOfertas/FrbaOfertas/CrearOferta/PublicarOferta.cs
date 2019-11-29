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
        public string ProveSeleccionado="";
        public PublicarOferta()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Oferta of;
            if (ProveSeleccionado != "")
            {
                of = new Oferta(txtCodigo.Text, Convert.ToDecimal(txtPrecioOferta.Text), Convert.ToDecimal(txtPrecioLista.Text),
                dtpFechaPub.Value.Date, dtpFechaVec.Value.Date, Convert.ToDecimal(txtCantidad.Text), txtDesc.Text,
                1, ProveSeleccionado, Convert.ToDecimal(txtCantxCli.Text));
            }
            else
            {
                of = new Oferta(txtCodigo.Text, Convert.ToDecimal(txtPrecioOferta.Text), Convert.ToDecimal(txtPrecioLista.Text),
                dtpFechaPub.Value.Date, dtpFechaVec.Value.Date, Convert.ToDecimal(txtCantidad.Text), txtDesc.Text,
                1, AdmProveedores.obtenerCuitDelUsuario(Login.username), Convert.ToDecimal(txtCantxCli.Text));
            }
            
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

        private void PublicarOferta_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
            if (ElegirRol.rolElegido == 3)
            {
                dgvProve.Hide();
                lblSeleccioneProv.Hide();
            }
            dgvProve.DataSource =  AdmProveedores.obtenerProveedoresRS().Tables[0];
        }

        private void dgvProve_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProve.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvProve.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProve.Rows[selectedrowindex];
                ProveSeleccionado = selectedRow.Cells["Provee_CUIT"].Value.ToString();
            }
        }

    }
}
