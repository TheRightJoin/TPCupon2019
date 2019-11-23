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
    public partial class ListadoOfertas : Form
    {
        public ListadoOfertas()
        {
            InitializeComponent();
        }

        private void ListadoOfertas_Load(object sender, EventArgs e)
        {
            dgvOfertas.DataSource = AdmOfertas.obtenerOfertasDisponibles().Tables[0];
            this.Controls.Add(Form1.MainMenu);
        }
    }
}
