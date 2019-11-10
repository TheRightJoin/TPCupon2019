using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaOfertas
{
    public partial class formListadoClientes : Form
    {
        public Decimal dniSeleccionado;
        public formListadoClientes()
        {
            InitializeComponent();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            String dni, nombre, apellido;
            dni = txtDni.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text ;
            if (dni == "" && nombre == "" && apellido == "")
            {
                dgvClientes.DataSource = AdmClientes.obtenerClientes().Tables[0];
            }
            else
            {
                dgvClientes.DataSource = AdmClientes.generarQuerys(dni, nombre, apellido).Tables[0];
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el cliente de dni " + dniSeleccionado.ToString() +  "?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                AdmClientes.bajaCliente(dniSeleccionado);
            }
                      
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvClientes.Rows[selectedrowindex];
                dniSeleccionado = Convert.ToDecimal(selectedRow.Cells["Cli_Dni"].Value);
            }
        }
    }
}
