using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void cmbAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnVerEst_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String query="";
            if (cmbAnio.Text != "" && cmbTipoEst.Text != "")
            {
                DateTime fecha = generarFecha(cmbAnio.Text,rdbSem1.Checked);
                if (cmbTipoEst.Text == "Proveedores con mayor facturacion")
                {
                    query = "SELECT * FROM [GD2C2019].[THE_RIGHT_JOIN].[provMaxFact]('" + fecha.ToString() +"')";
                }
                else
                {
                    query = "SELECT * FROM [GD2C2019].[THE_RIGHT_JOIN].[provMaxDesc]('" + fecha.ToString() + "')";
                }
               
                SqlCommand cmd = new SqlCommand(query, conn);                
                dgvEstadistica.DataSource = ConectorBDD.cargarDataSet(conn, cmd).Tables[0];
            }
            
            

            
        }

        private DateTime generarFecha(String anio,bool sem1)
        {
            
            if (sem1)
            {
                return Convert.ToDateTime("01/01/" + anio);
            }
            else
            {
                return Convert.ToDateTime("01-07-" + anio);
            }
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("select distinct year(Factura_fecha) as Anio from THE_RIGHT_JOIN.Factura", conn);
            cmbAnio.DataSource = ConectorBDD.cargarDataSet(conn, cmd).Tables[0];
            cmbAnio.DisplayMember = "Anio";

            this.Controls.Add(Form1.MainMenu);
        }

        private void cmbTipoEst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
