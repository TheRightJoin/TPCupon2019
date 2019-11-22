using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class VerProveedores : Form
    {
        public static String cuitSeleccionado = "felofelipe";

        public VerProveedores()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string RS, cuit, email;
            RS = txtRS.Text;
            cuit = txtCUIT.Text;
            email = txtEmail.Text;

            if (RS == "" && cuit == "" && email == ""){
                dgvProveedores.DataSource = AdmProveedores.obtenerProveedores().Tables[0];
            }
            else {
                dgvProveedores.DataSource = AdmProveedores.generarQuerys(RS, cuit, email).Tables[0];
            }

        }


        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvProveedores.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProveedores.Rows[selectedrowindex];
                cuitSeleccionado = (selectedRow.Cells["Provee_CUIT"].Value).ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el Proveedor de CUIT " + cuitSeleccionado + "?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                AdmProveedores.bajaProveedor(cuitSeleccionado);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            ModificarProveedor mp = new ModificarProveedor();
            this.Hide();
            mp.Show();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                int selectedrowindex = dgvProveedores.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProveedores.Rows[selectedrowindex];
                cuitSeleccionado = (selectedRow.Cells["Provee_CUIT"].Value).ToString();
            }
        }
    }
}
