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
    public partial class Login : Form
    {
        public static string username = "";
        int ret;
        public Login()
        {
            InitializeComponent();
        }
        //HAY UN lblRestantes PARA PONER LOS INTENTOS QUE QUEDAN
        private void btnLogin_Click(object sender, EventArgs e)
        {
            ret = AdmUsuario.logueo(txtUsuario.Text, txtPass.Text);
            switch(ret)
            {
                case 0:
                    MessageBox.Show("Datos Correctos");
                    username = txtUsuario.Text;
                    ElegirRol fer = new ElegirRol();
                    fer.Show();
                    this.Hide();
                    break;
                case 3:
                    MessageBox.Show("bloqueado");
                    string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connString);
                    SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.bloquearUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = txtUsuario.Text;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    break;
                case 1:
                case 2:
                    MessageBox.Show("mal");
                    break;
                default:
                    MessageBox.Show("Usuario bloqueado");
                    break;
            }
        }

        private void btnSingIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistroDeUsuario ru = new RegistroDeUsuario();
            ru.Show();
            
        }
    }
}
