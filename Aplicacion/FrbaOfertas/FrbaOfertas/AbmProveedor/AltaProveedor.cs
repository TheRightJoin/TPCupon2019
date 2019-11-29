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
            this.Controls.Add(Form1.MainMenu);
        }

        private void limpiarcampos() {
            txtCalle.Text = "";
            txtCiudad.Text = "";
            txtContacto.Text = "";
            txtCUIT.Text = "";
            txtDepto.Text = "";
            txtEmail.Text = "";
            txtLocalidad.Text = "";
            txtPiso.Text = "";
            txtPostal.Text = "";
            txtRS.Text = "";
            txtTelefono.Text = "";
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
                                                  Convert.ToInt32(cbxRubro.SelectedValue),
                                                  txtContacto.Text, 
                                                  txtPostal.Text);
           
            int resultado =  AdmProveedores.AltaProveedor(miProveedor);
            if (resultado == -1)
            {
                MessageBox.Show("Ya existe un proveedor con este CUIT: " + txtCUIT.Text);
            }
            limpiarcampos();
        }



    }
}
