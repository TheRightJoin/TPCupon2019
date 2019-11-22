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
            comboBox1.DataSource = AdmRubro.obtenerRubros().Tables[0];
            comboBox1.DisplayMember = "Rubro_Descripcion";
            comboBox1.ValueMember = "idRubro";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaProveedores miProveedor = new AltaProveedores(textBox1.Text, textBox2.Text, Convert.ToDecimal(textBox3.Text), textBox4.Text, textBox5.Text,
                                                  textBox6.Text, textBox7.Text, textBox9.Text, textBox10.Text, comboBox1.SelectedIndex,
                                                  textBox12.Text, textBox8.Text);
           
            AdmProveedores.AltaProveedor(miProveedor);
        }

    }
}
