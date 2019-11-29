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
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Decimal telefono = 0;
            if (txtTelefono.Text != "")
            {
                telefono = Convert.ToDecimal(txtTelefono.Text);
            }
            if (txtDni.Text != "" && txtApellido.Text != "" && txtNombre.Text != "")
            {
                Cliente cli = new Cliente(Convert.ToDecimal(txtDni.Text),
                txtNombre.Text, txtApellido.Text, txtMail.Text, txtDireccion.Text, txtCiudad.Text, dtpNacimiento.Value.Date, telefono, txtCodPost.Text, txtLocalidad.Text);
                int filas = AdmClientes.altaCliente(cli);
                if (filas > 0)
                {

                    limpiarCampos();
                    MessageBox.Show("Cliente creado correctamente", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formListadoClientes flc = new formListadoClientes();
                    flc.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ya existe un Cliente con este DNI: " + txtDni.Text);
                }
            }
            else {
                MessageBox.Show("Complete todos los campos obligatorios", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtDireccion.Text = "";
            txtCiudad.Text = "";
            txtLocalidad.Text = "";
            txtTelefono.Text = "";
            txtCodPost.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Form1.MainMenu);
        }


        
    }
}
