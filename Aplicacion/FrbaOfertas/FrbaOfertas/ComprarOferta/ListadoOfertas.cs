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
namespace FrbaOfertas
{
    public partial class ListadoOfertas : Form
    {
        public ListadoOfertas()
        {
            InitializeComponent();
        }

        String codigoOferta;
        int dniAdmin;
        Decimal dni;
        int cantidad;
        int resultado;
        DateTime fecha = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);
        

        private void ListadoOfertas_Load(object sender, EventArgs e)
        {
            dgvCliente.Hide();
            dgvOfertas.DataSource = AdmOfertas.obtenerOfertasDisponibles().Tables[0];
            this.Controls.Add(Form1.MainMenu);

            dgvCliente.DataSource = AdmClientes.obtenerClientesNyA().Tables[0];

            if (ElegirRol.rolElegido == 1)
            {
                dgvCliente.Show();
            }
            else
            {
               dni = AdmClientes.obtenerDniDelUsuario(Login.username);
                label2.Hide();
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            cantidad = Convert.ToInt32(txtCantidad.Text);
            resultado = AdmOfertas.comprarOferta(dni, fecha, cantidad, codigoOferta);

            switch (resultado) { 
                case 0:
                    MessageBox.Show("Compra realizada");
                    break;
                case 1:
                    MessageBox.Show("Error en la compra. No hay saldo suficiente");
                    break;
                case 2:
                    MessageBox.Show("Error en la compra. No hay cantidad suficiente");
                    break;
                case 3:
                    MessageBox.Show("Error en la compra. La oferta no esta disponible");
                    break;
                case 4:
                    MessageBox.Show("Error en la compra. La cantidad supera a la maxima");
                    break;
            }
        }

        private void dgvOfertas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOfertas.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvOfertas.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvOfertas.Rows[selectedrowindex];
                codigoOferta = (selectedRow.Cells["Oferta_Codigo"].Value).ToString();

            }
        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCliente.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvCliente.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvCliente.Rows[selectedrowindex];
                dni = Convert.ToInt32((selectedRow.Cells["Cli_Dni"].Value));

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
