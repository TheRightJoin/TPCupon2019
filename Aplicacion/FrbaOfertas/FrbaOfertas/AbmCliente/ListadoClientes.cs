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
            dgvClientes.DataSource = AdmClientes.obtenerClientes().Tables[0];

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
