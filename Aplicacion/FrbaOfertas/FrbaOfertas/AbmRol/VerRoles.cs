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
    public partial class VerRoles : Form
    {
        public static int idSeleccionado;
        public VerRoles()
        {
            InitializeComponent();
            dataGridView1.DataSource = AdmRol.obtenerRoles("").Tables[0];
        }

        public void VerRoles_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AdmRol.obtenerRoles(txtFiltro.Text).Tables[0];
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Esta seguro que desea eliminar el rol de id " + idSeleccionado + "?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                AdmRol.bajaRol(idSeleccionado);
            }
            dataGridView1.DataSource = AdmRol.obtenerRoles("").Tables[0];
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells.Count>0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                idSeleccionado = Convert.ToInt32((selectedRow.Cells["id_Rol"].Value).ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol();
            altaRol.Show();
            this.Hide();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            AgregarFuncionalidades agregarFuncionalidades = new AgregarFuncionalidades();
            agregarFuncionalidades.Show();
            this.Hide();
        }

        private void VerRoles_Load_1(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }
    }
}
