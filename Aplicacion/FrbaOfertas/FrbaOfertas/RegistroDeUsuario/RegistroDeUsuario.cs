﻿using System;
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
    public partial class RegistroDeUsuario : Form
    {
        public RegistroDeUsuario()
        {
            InitializeComponent();
        }

        private void RegistroDeUsuario_Load(object sender, EventArgs e)
        {
            cbxRol.DataSource = AdmRol.cargarComboBoxRoles().Tables[0];
            cbxRol.DisplayMember = "rol_Name";
            cbxRol.ValueMember = "id_rol";

            cbxRubro.DataSource = AdmRubro.obtenerRubros().Tables[0];
            cbxRubro.DisplayMember = "Rubro_Descripcion";
            cbxRubro.ValueMember = "idRubro";

            this.Controls.Add(Form1.MainMenu);
        }

        private void mostrarCliente()
        {
            lblCiu.Show();
            lblDir.Show();
            lblDNI.Show();
            lblEmail.Show();
            lblFEcha.Show();
            lblLoc.Show();
            lblNombre.Show();
            label12.Show();
            lblTelefono.Show();
            lblApellido.Show();

            txtApellido.Show();
            txtCiudad.Show();
            txtDireccion.Show();
            txtDNI.Show();
            txtEmail.Show();
            txtLocalidad.Show();
            txtNombre.Show();
            txtPostal.Show();
            txtTelefono.Show();
            dtpNacimiento.Show();
        }

        private void esconderCliente() {
            lblCiu.Hide();
            lblDir.Hide();
            lblDNI.Hide();
            lblEmail.Hide();
            lblFEcha.Hide();
            lblLoc.Hide();
            lblNombre.Hide();
            label12.Hide();
            lblTelefono.Hide();
            lblApellido.Hide();

            txtApellido.Hide();
            txtCiudad.Hide();
            txtDireccion.Hide();
            txtDNI.Hide();
            txtEmail.Hide();
            txtLocalidad.Hide();
            txtNombre.Hide();
            txtPostal.Hide();
            txtTelefono.Hide();
            dtpNacimiento.Hide();
        }

        private void mostrarProveedor(){
            lblRS.Show();
            lblCUIT.Show();
            lblEmail2.Show();
            lblContacto.Show();
            lbltelefono2.Show();
            lblRubro.Show();
            lblCalle.Show();
            lblPiso.Show();
            lblDEpto.Show();
            lblCiu2.Show();
            lblLocalidad.Show();
            lblPostal2.Show();

            txtRS.Show();
            txtCUIT.Show();
            txtEmailP.Show();
            txtContacto.Show();
            txtTelefonoP.Show();
            cbxRubro.Show();
            txtCalleP.Show();
            txtPisoP.Show();
            txtDeptoP.Show();
            txtCiuP.Show();
            txtLocalidadP.Show();
            txtPostalP.Show();
        }

        private void esconderProveedor() {
            lblRS.Hide();
            lblCUIT.Hide();
            lblEmail2.Hide();
            lblContacto.Hide();
            lbltelefono2.Hide();
            lblRubro.Hide();
            lblCalle.Hide();
            lblPiso.Hide();
            lblDEpto.Hide();
            lblCiu2.Hide();
            lblLocalidad.Hide();
            lblPostal2.Hide();

            txtRS.Hide();
            txtCUIT.Hide();
            txtEmailP.Hide();
            txtContacto.Hide();
            txtTelefonoP.Hide();
            cbxRubro.Hide();
            txtCalleP.Hide();
            txtPisoP.Hide();
            txtDeptoP.Hide();
            txtCiuP.Hide();
            txtLocalidadP.Hide();
            txtPostalP.Hide();
        }

        private void vaciarTxt(){
            txtApellido.Text = "";
            txtCalleP.Text = "";
            txtCiudad.Text = "";
            txtCiuP.Text = "";
            txtContacto.Text = "";
            txtContrasenia.Text = "";
            txtCUIT.Text = "";
            txtDeptoP.Text = "";
            txtDireccion.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtEmailP.Text = "";
            txtLocalidad.Text = "";
            txtLocalidadP.Text = "";
            txtNombre.Text = "";
            txtPisoP.Text = "";
            txtPostal.Text = "";
            txtPostalP.Text = "";
            txtRS.Text = "";
            txtTelefono.Text = "";
            txtTelefonoP.Text = "";
            txtUsuario.Text = "";
        }

        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows.Count != 0)
            {
                switch (AdmRol.rolDerivaDe(Convert.ToInt32(AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows[0]["id_Rol"].ToString())))
                {
                    case 2:
                        mostrarCliente();
                        esconderProveedor();
                        break;
                    case 3:
                        mostrarProveedor();
                        esconderCliente();
                        break;
                    case 1:
                        esconderCliente();
                        esconderProveedor();
                        break;
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int retorno;
            Usuario miUser;
            switch (AdmRol.rolDerivaDe(Convert.ToInt32(AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows[0]["id_Rol"].ToString())))
            {     
                case 2:
                    if (txtApellido.Text != "" && txtDNI.Text != "" && txtNombre.Text != "")
                    {
                        miUser = new Usuario(txtUsuario.Text, txtContrasenia.Text, Convert.ToDecimal(txtDNI.Text), null);
                        Cliente miClie = new Cliente(Convert.ToDecimal(txtDNI.Text),
                                                     txtNombre.Text,
                                                     txtApellido.Text,
                                                     (txtEmail.Text  ?? " "),
                                                     txtDireccion.Text ?? " ",
                                                     txtCiudad.Text ?? " ",
                                                     Convert.ToDateTime(dtpNacimiento.Text ?? ""),
                                                     Convert.ToDecimal(txtTelefono.Text ?? "0"),
                                                     txtPostal.Text ?? " ",
                                                     txtLocalidad.Text ?? " ");

                        int filas = AdmClientes.altaCliente(miClie);
                        if (filas > 0)
                        {

                            retorno = AdmUsuario.altaUsuario(miUser, (Convert.ToInt32(AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows[0]["id_Rol"].ToString())));
                            if (retorno == -1)
                            {
                                MessageBox.Show("Ya existe el usuario: " + txtUsuario.Text);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error en la creacion del cliente");
                        }
                    }
                    else {
                        MessageBox.Show("Complete todos los campos obligatorios");
                    }
                    

                    break;
                case 3:
                    String direccionTotal = txtPisoP.Text + "; " + txtPisoP.Text + "; " + txtDeptoP.Text + "; " + txtLocalidad.Text;
                    miUser = new Usuario(txtUsuario.Text, txtContrasenia.Text, Convert.ToDecimal(null), txtCUIT.Text);
                    Proveedor miProvee = new Proveedor(txtRS.Text,
                                                       txtEmailP.Text,
                                                       Convert.ToDecimal(txtTelefonoP.Text),
                                                       direccionTotal,
                                                       txtCiuP.Text,
                                                       txtCUIT.Text,
                                                       cbxRubro.Text,
                                                       Convert.ToInt32(cbxRubro.SelectedValue),
                                                       txtContacto.Text,
                                                       txtPostalP.Text);
                    AdmProveedores.AltaProveedor(miProvee);
                    retorno = AdmUsuario.altaUsuario(miUser, (Convert.ToInt32(AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows[0]["id_Rol"].ToString())));
                    if (retorno == -1)
                    {
                        MessageBox.Show("Ya existe el usuario: " + txtUsuario.Text);
                    }
                    break;
                case 1:
                    miUser = new Usuario(txtUsuario.Text, txtContrasenia.Text, Convert.ToDecimal(null), null);
                   retorno = AdmUsuario.altaUsuario(miUser, (Convert.ToInt32(AdmRol.obtenerRoles(cbxRol.Text).Tables[0].Rows[0]["id_Rol"].ToString())));
                   if (retorno == -1)
                   {
                       MessageBox.Show("Ya existe el usuario: " + txtUsuario.Text);
                   }
                    break;
            }

            vaciarTxt();
            Login fl = new Login();
            fl.Show();
            this.Hide();
        }

        private void cbxRol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}
