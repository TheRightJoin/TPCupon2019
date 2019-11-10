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
        public ModificarCliente()
        {
            InitializeComponent();
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            Decimal dniCliente = formListadoClientes.dniSeleccionado;
            txtDni.Text = dniCliente.ToString();
            Cliente cli = AdmClientes.obtenerCliente(dniCliente);
            txtNombre.Text = cli.nombre;
            txtApellido.Text = cli.apellido;
            txtMail.Text = cli.mail;
            txtCodPost.Text = cli.codPostal;
            txtCiudad.Text = cli.ciudad;
            txtTelefono.Text = cli.telefono.ToString();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
        }

        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaCliente fac = new AltaCliente();
            fac.Show();
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
    }
}
