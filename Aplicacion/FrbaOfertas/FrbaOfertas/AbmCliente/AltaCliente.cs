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
            Cliente cli = new Cliente(Convert.ToDecimal(txtDni.Text),
                txtNombre.Text, txtApellido.Text, txtMail.Text, txtDireccion.Text, txtCiudad.Text, dtpNacimiento.Value.Date, Convert.ToDecimal(txtTelefono.Text),txtCodPost.Text,txtLocalidad.Text);
            AdmClientes.altaCliente(cli);
            limpiarCampos();
            MessageBox.Show("Cliente creado correctamente");
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
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



        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
        }


        
    }
}
