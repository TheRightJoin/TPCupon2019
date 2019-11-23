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
    public partial class ModificarCliente : Form
    {
        public Decimal dniCliente;
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            dniCliente = formListadoClientes.dniSeleccionado;
            txtDni.Text = dniCliente.ToString();
            Cliente cli = AdmClientes.obtenerCliente(dniCliente);
            txtNombre.Text = cli.nombre;
            txtApellido.Text = cli.apellido;
            txtMail.Text = cli.mail;
            txtCodPost.Text = cli.codPostal;
            txtCiudad.Text = cli.ciudad;
            txtTelefono.Text = cli.telefono.ToString();
            txtDireccion.Text = cli.direccion;
            txtLocalidad.Text = cli.localidad;

            this.Controls.Add(Form1.MainMenu);
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Decimal telefono = 0;
            if (txtTelefono.Text != "")
            {
                telefono = Convert.ToDecimal(txtTelefono.Text);
            }
            Cliente cli = new Cliente(dniCliente,
                txtNombre.Text, txtApellido.Text, txtMail.Text, txtDireccion.Text, txtCiudad.Text, dtpNacimiento.Value.Date, telefono, txtCodPost.Text, txtLocalidad.Text);
            AdmClientes.modificarCliente(cli);
            limpiarCampos();
            MessageBox.Show("Cliente modificado correctamente");
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
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

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valido que ingrese solo numeros
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
