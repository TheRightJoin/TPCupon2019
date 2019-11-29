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
    public partial class AgregarFuncionalidades : Form
    {
        int idSeleccionado;
        public AgregarFuncionalidades()
        {
            InitializeComponent();
            int derivado = AdmRol.rolDerivaDe(VerRoles.idSeleccionado);
            if (derivado != 0)
            {
                comboBox1.Hide();
                label1.Hide();
                dataGridView1.DataSource = AdmRol.obtenerFuncionalidadesRol(derivado).Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerRoles verRoles = new VerRoles();
            verRoles.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

                dataGridView1.DataSource = AdmRol.obtenerFuncionalidadesRol(Convert.ToInt32(AdmRol.obtenerRoles(comboBox1.Text.ToUpper()).Tables[0].Rows[0]["id_rol"].ToString())).Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            comboBox1.Enabled = false;
            DialogResult result = MessageBox.Show("Esta seguro que desea agregar la funcionalidad" + idSeleccionado + "?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                flag = AdmRol.asignarFuncionalidad(VerRoles.idSeleccionado,idSeleccionado);
            }
            if(flag == 0)
            {
                MessageBox.Show("El rol ya posee esta funcionalidad","Atencion",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                idSeleccionado = Convert.ToInt32((selectedRow.Cells["idFunc"].Value).ToString());
            }
        }

        private void AgregarFuncionalidades_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }
    }
}
