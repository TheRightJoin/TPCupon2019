﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.AbmProveedor;

namespace FrbaOfertas
{
    public partial class ModificarProveedor : Form
    {

        public String CUIT;
        public ModificarProveedor()
        {
            InitializeComponent();
        }

        private void limpiarCampos()
        {
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
       
        private void ModificarProveedor_Load(object sender, EventArgs e)
        {
            CUIT = VerProveedores.cuitSeleccionado;
            txtCUIT.Text = CUIT;

            VerProveedor proveedor = AdmProveedores.obtenerProveedor(CUIT);

            txtRS.Text = proveedor.razon_social;
            txtTelefono.Text = proveedor.telefono.ToString();
            txtEmail.Text = proveedor.email;
            txtCiudad.Text = proveedor.ciudad;
            txtContacto.Text = proveedor.contacto;
            txtPostal.Text = proveedor.postal;
            cbxRubro.Text = proveedor.rubro;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            VerProveedor miProve = new VerProveedor(txtRS.Text,
                                                        txtEmail.Text,
                                                        Convert.ToDecimal(txtTelefono.Text),
                                                        txtCalle.Text,
                                                        txtPiso.Text,
                                                        txtDepto.Text,
                                                        txtLocalidad.Text,
                                                        txtCiudad.Text,
                                                        txtCUIT.Text,
                                                        cbxRubro.Text,
                                                        txtContacto.Text,
                                                        txtPostal.Text);
            AdmProveedores.modificarProveedor(miProve);
            limpiarCampos();
            this.Hide();
            VerProveedores vp = new VerProveedores();
            vp.Show();
        }
    }
}
