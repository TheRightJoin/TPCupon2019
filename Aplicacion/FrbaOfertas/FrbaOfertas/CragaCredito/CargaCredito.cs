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
    public partial class CargaCredito : Form
    {
        public CargaCredito()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private int cargarCredito(Decimal dni,String tipo, Decimal monto, Decimal numTarjeta,DateTime fechaVenc)
        {
            string connString = ConfigurationManager.ConnectionStrings["THE_RIGHT_JOIN"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            int filas=0;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("THE_RIGHT_JOIN.cargarCredito", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@dniCliente", SqlDbType.Decimal).Value = dni;
                    cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = tipo;
                    cmd.Parameters.Add("@monto", SqlDbType.Decimal).Value = monto;
                    cmd.Parameters.Add("@numTarjeta", SqlDbType.Decimal).Value = numTarjeta;
                    cmd.Parameters.Add("@fechaVen", SqlDbType.DateTime).Value = fechaVenc;
                    cmd.Parameters.Add("@filasAfectadas", SqlDbType.Int).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    filas = Convert.ToInt32(cmd.Parameters["@filasAfectadas"].Value);
                    conn.Close();
                }
            }
            return filas;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //FALTA OBTENER LA FECHA DEL ARCHIVO DE CONFIGURACION
            //FALTA OBTENER EL DNI DEL CLIENTE DEL LOGIN
            if (txtDni.Text != "" && txtMonto.Text != "" && txtCodigo.Text != "" && txtNumero.Text != "" && cmbTipo.Text != "")
            {
                int filas=cargarCredito(Convert.ToDecimal(txtDni.Text), cmbTipo.Text, Convert.ToDecimal(txtMonto.Text), Convert.ToDecimal(txtNumero.Text),dtpVenc.Value.Date);
                if (filas > 0)
                {
                    MessageBox.Show("Se ha cargado el credito correctamente");
                }
                else {
                    MessageBox.Show("Error en la carga de credito");
                }

                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios");
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
