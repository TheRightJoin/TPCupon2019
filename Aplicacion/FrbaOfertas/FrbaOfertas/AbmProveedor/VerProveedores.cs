using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class VerProveedores : Form
    {
        public VerProveedores()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            string RS, cuit, email;
            RS = txtRS.Text;
            cuit = txtCUIT.Text;
            email = txtEmail.Text;

            if (RS == "" && cuit == "" && email == ""){
                dgvProveedores.DataSource = AdmProveedores.obtenerProveedores().Tables[0];
            }
            else {
                dgvProveedores.DataSource = AdmProveedores.generarQuerys(RS, cuit, email).Tables[0];
            }

        }

        private void VerProveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
