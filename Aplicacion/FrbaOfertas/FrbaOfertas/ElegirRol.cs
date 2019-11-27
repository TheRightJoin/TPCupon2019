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
    public partial class ElegirRol : Form
    {
        public static int rolElegido;
        public ElegirRol()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ElegirRol_Load(object sender, EventArgs e)
        {
            cmbRoles.DataSource = AdmRol.obtenerRolesPorUsuario(Login.username).Tables[0];
            cmbRoles.DisplayMember = "rol_Name";
            cmbRoles.ValueMember = "id_Rol";
            lblRol.Text = "Bienvenido " + Login.username + ". Elija el Rol con el que desea ingresar";
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            rolElegido =Convert.ToInt32(cmbRoles.SelectedValue);
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
