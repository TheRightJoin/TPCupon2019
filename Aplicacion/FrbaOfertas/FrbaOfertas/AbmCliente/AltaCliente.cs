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
            String direccion = txtCalle.Text + " " + txtPiso.Text + " " + txtDepto.Text + " " + txtLocalidad.Text;
            Cliente cli = new Cliente(Convert.ToDecimal(txtDni.Text),
                txtNombre.Text, txtApellido.Text, txtMail.Text, direccion, txtCiudad.Text, dtpNacimiento.Value.Date, Convert.ToDecimal(txtTelefono.Text));
            AdmClientes.altaCliente(cli);
            limpiarCampos();
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
            txtCalle.Text = "";
            txtPiso.Text = "";
            txtCiudad.Text = "";
            txtLocalidad.Text = "";
            txtTelefono.Text = "";
            txtDepto.Text = "";
            txtCodPost.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        
    }
}
