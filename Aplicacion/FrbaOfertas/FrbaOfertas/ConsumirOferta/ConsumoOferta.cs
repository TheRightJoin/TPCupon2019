using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace FrbaOfertas.ConsumirOferta
{
    public partial class ConsumoOferta : Form
    {
        public ConsumoOferta()
        {
            InitializeComponent();
        }

        int dniElegido;
        int codigoCupon;
        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        private void ConsumoOferta_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = AdmClientes.obtenerClientesNyA().Tables[0];
            this.Controls.Add(Form1.MainMenu);
        }


        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvClientes.Rows[selectedrowindex];
                dniElegido = Convert.ToInt32(selectedRow.Cells["Cli_Dni"].Value);
                
                dgvCupon.DataSource = admCupon.obtenerCuponesXCliente(dniElegido).Tables[0];
            }
        }

        private void btnConsumir_Click(object sender, EventArgs e)
        {
            int filas = admCupon.consumirOferta(dniElegido, fechaActual, codigoCupon);
            if (filas > 0)
            {
                MessageBox.Show("Oferta consumida");

                dgvClientes.DataSource = AdmClientes.obtenerClientesNyA().Tables[0];

            }
            else
            {
                MessageBox.Show("Error al consumir oferta");
            }
        }

        private void dgvCupon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCupon.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCupon.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCupon.Rows[selectedrowindex];
                if (selectedRow.Cells["idCupon"].Value != DBNull.Value)
                {
                    codigoCupon = Convert.ToInt32(selectedRow.Cells["idCupon"].Value);
                }
            }
        }
    }
}
