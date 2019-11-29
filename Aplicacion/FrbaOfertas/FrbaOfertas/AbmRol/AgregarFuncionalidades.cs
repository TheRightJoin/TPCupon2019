﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmRol
{
    public partial class AgregarFuncionalidades : Form
    {
        public AgregarFuncionalidades()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VerRoles verRoles = new VerRoles();
            verRoles.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AdmRol.obtenerRolesPorUsuario(comboBox1.Text);
        }
    }
}