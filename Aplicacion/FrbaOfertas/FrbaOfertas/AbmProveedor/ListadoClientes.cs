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
    public partial class formListadoClientes : Form
    {
        public formListadoClientes()
        {
            InitializeComponent();
        }

        private void ListadoClientes_Load(object sender, EventArgs e)
        {
            

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            String dni, nombre, apellido;
            dni = txtDni.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text ;
            if (dni == "" && nombre == "" && apellido == "")
            {
                dgvClientes.DataSource = AdmClientes.obtenerClientes().Tables[0];
            }
            else
            {
                dgvClientes.DataSource = AdmClientes.generarQuerys(dni, nombre, apellido).Tables[0];
            }
        }
    }
}
