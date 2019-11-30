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
        String cuit = "";
        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        private void ConsumoOferta_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
            if (AdmRol.rolDerivaDe(ElegirRol.rolElegido) == 1)
            {
                dgvClientes.DataSource = AdmClientes.obtenerClientesNyA().Tables[0];
            }
            else
            {
                cuit = AdmProveedores.obtenerCuitDelUsuario(Login.username);

                dgvClientes.DataSource = AdmClientes.clientesDelProv(cuit).Tables[0];
            }
        }


        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvClientes.Rows[selectedrowindex];
                if (selectedRow.Cells["Cli_Dni"].Value != DBNull.Value) {
                    dniElegido = Convert.ToInt32(selectedRow.Cells["Cli_Dni"].Value);
                    if (ElegirRol.rolElegido == 1)
                    {
                        dgvCupon.DataSource = admCupon.obtenerCuponesXCliente(dniElegido).Tables[0];
                    }
                    else
                    {
                        dgvCupon.DataSource = admCupon.obtenerCuponesXClienteYProv(dniElegido, cuit).Tables[0];
                    }
                    textBox1.Text = dniElegido.ToString();
                }
                
            }
        }

        private void btnConsumir_Click(object sender, EventArgs e)
        {
            int filas = admCupon.consumirOferta(Convert.ToInt32( textBox1.Text), fechaActual, codigoCupon);
            if (filas > 0)
            {
                MessageBox.Show("Oferta consumida");

                if (AdmRol.rolDerivaDe(ElegirRol.rolElegido) == 1)
                {
                    dgvClientes.DataSource = AdmClientes.obtenerClientesNyA().Tables[0];
                }
                else
                {
                    cuit = AdmProveedores.obtenerCuitDelUsuario(Login.username);

                    dgvClientes.DataSource = AdmClientes.clientesDelProv(cuit).Tables[0];
                }

            }
            else
            {
                if (filas < 0)
                {
                    MessageBox.Show("El usuario no existe");
                }
                else
                {
                    MessageBox.Show("Error al consumir oferta");
                }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
