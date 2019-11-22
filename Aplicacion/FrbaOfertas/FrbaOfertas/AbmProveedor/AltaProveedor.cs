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
    public partial class AltaProveedor : Form
    {

        AdmProveedores adm = new AdmProveedores();

        public AltaProveedor()
        {
            InitializeComponent();
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            cbxRubro.DataSource = AdmRubro.obtenerRubros().Tables[0];
            cbxRubro.DisplayMember = "Rubro_Descripcion";
            cbxRubro.ValueMember = "idRubro";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String direccionTotal = txtCalle.Text + "; " + txtPiso.Text + "; " + txtDepto.Text + "; " + txtLocalidad.Text;
            Proveedor miProveedor = new Proveedor(txtRS.Text, 
                                                  txtEmail.Text, 
                                                  Convert.ToDecimal(txtTelefono.Text), 
                                                  direccionTotal , 
                                                  txtCiudad.Text, 
                                                  txtCUIT.Text,
                                                  cbxRubro.Text,
                                                  cbxRubro.SelectedIndex,
                                                  txtContacto.Text, 
                                                  txtPostal.Text);
           
            AdmProveedores.AltaProveedor(miProveedor);
        }

    }
}
