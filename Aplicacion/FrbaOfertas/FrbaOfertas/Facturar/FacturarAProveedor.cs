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

namespace FrbaOfertas.Facturar
{
    public partial class FacturarAProveedor : Form
    {
        public FacturarAProveedor()
        {
            InitializeComponent();
        }

        DateTime fechamin;
        DateTime fechamax;
        String CUIT;
        int importe;
        int numeroFactura;

        DateTime fechaActual = Convert.ToDateTime(ConfigurationManager.AppSettings["Fecha"]);

        private void FacturarAProveedor_Load(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = AdmProveedores.obtenerProveedores().Tables[0];
            this.Controls.Add(Form1.MainMenu);


        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedCells.Count > 0)
            {
                fechamin = dateMin.Value.Date;
                fechamax = dateMax.Value.Date;
                int selectedrowindex = dgvProveedores.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvProveedores.Rows[selectedrowindex];
                CUIT = (selectedRow.Cells["Provee_CUIT"].Value).ToString();

                dgvOfertas.DataSource = AdmOfertas.obtenerOfertasPorCliente(CUIT, fechamin, fechamax, fechaActual).Tables[0];

            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            facturar();
            lblImporte.Text = "El importe total de facturacion es: $" + importe;
            lblNumero.Text = "El numero de la factura es: " + numeroFactura;
        }


        private void facturar() {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.facturarAProv", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@cuit", SqlDbType.VarChar).Value = CUIT;
                    cmd.Parameters.Add("@fechaMin", SqlDbType.DateTime).Value = fechamin;
                    cmd.Parameters.Add("@fechaMax", SqlDbType.DateTime).Value = fechamax;
                    cmd.Parameters.Add("@fechaAct", SqlDbType.DateTime).Value = fechaActual;

                    cmd.Parameters.Add("@importe", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@numero", SqlDbType.Int).Direction = ParameterDirection.Output; 

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    importe = Convert.ToInt32(cmd.Parameters["@importe"].Value);
                    numeroFactura = Convert.ToInt32(cmd.Parameters["@numero"].Value);
                    conn.Close();
                }
            }
        }
    }
}
