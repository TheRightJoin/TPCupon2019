using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas;

namespace FrbaOfertas
{
    public partial class Perfil : Form
    {
        public Perfil()
        {
            InitializeComponent();
        }

        string userNameElegido;

        private void Perfil_Load(object sender, EventArgs e)
        {
            txtBienvenido.Text = "Bienvenido " + Login.username + " !!";
            dataGridView1.DataSource = AdmUsuario.obtenerUsuarios().Tables[0];
            this.Controls.Add(Form1.MainMenu);

            if (ElegirRol.rolElegido == 1)
            {

                dataGridView1.Show();
                btnEliminarAdm.Show();
                btnModificarPassAdm.Show();
                btnLogoutAdm.Show();

                txtBienvenido.Hide();
                btnLogOUt.Hide();
                btnModificarPass.Hide();
            }
            else {
                dataGridView1.Hide();
                btnEliminarAdm.Hide();
                btnModificarPassAdm.Hide();
                btnLogoutAdm.Hide();

                txtBienvenido.Show();
                btnLogOUt.Show();
                btnModificarPass.Show();
            }
        }

        private void btnModificarPass_Click(object sender, EventArgs e)
        {
            CambiarPass cp = new CambiarPass();
            cp.Show();
            this.Hide();
        }

        private void btnLogOUt_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                userNameElegido = (selectedRow.Cells["Usuari_Username"].Value).ToString();

            }
        }

        private void btnModificarPassAdm_Click(object sender, EventArgs e)
        {
            Login.username = userNameElegido;
            CambiarPass cp = new CambiarPass();
            cp.Show();
            this.Hide();

        }

        private void btnLogoutAdm_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnEliminarAdm_Click(object sender, EventArgs e)
        {
            AdmUsuario.eliminarUsuario(userNameElegido);
            MessageBox.Show("usuario eliminado");
            dataGridView1.DataSource = AdmUsuario.obtenerUsuarios().Tables[0];
        }
    }
}
