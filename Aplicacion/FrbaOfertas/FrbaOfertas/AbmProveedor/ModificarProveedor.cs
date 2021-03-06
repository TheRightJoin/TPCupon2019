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
        public int idRubroPosta;
        public String rubroQueYaTiene;

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
    //        CUIT = "felofelipe";

            txtCUIT.Text = CUIT;

            cbxRubro.DataSource = AdmRubro.obtenerRubros().Tables[0];
            cbxRubro.DisplayMember = "Rubro_Descripcion";
            cbxRubro.ValueMember = "idRubro";

            Proveedor proveedor = AdmProveedores.obtenerProveedor(CUIT);

            txtRS.Text = proveedor.razon_social;
            txtTelefono.Text = proveedor.telefono.ToString();
            txtEmail.Text = proveedor.email;
            txtCiudad.Text = proveedor.ciudad;
            txtContacto.Text = proveedor.contacto;
            txtPostal.Text = proveedor.postal;
            cbxRubro.Text = proveedor.rubro;
            idRubroPosta = proveedor.idRubro;
            parseoDireccion(proveedor.direccion);

            this.Controls.Add(Form1.MainMenu);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtRS.Text != "")
            {
                String direccionTotal = txtCalle.Text + "; " + txtPiso.Text + "; " + txtDepto.Text + "; " + txtLocalidad.Text;
                Proveedor miProve = new Proveedor(txtRS.Text,
                                                           txtEmail.Text,
                                                           Convert.ToDecimal(txtTelefono.Text),
                                                           direccionTotal,
                                                           txtCiudad.Text,
                                                           txtCUIT.Text,
                                                           cbxRubro.Text,
                                                           idRubroPosta,
                                                           txtContacto.Text,
                                                           txtPostal.Text);
                AdmProveedores.modificarProveedor(miProve);
                limpiarCampos();
                this.Hide();
                VerProveedores vp = new VerProveedores();
                vp.Show();
            }
            else {
                MessageBox.Show("Complete los campos obligatorios");
            }
            
        }


        private void parseoDireccion(String direccion)
        {
            String calle = "";
            String piso = "";
            String depto = "";
            String localidad = "";
            int contComas = 0;

            for (int i = 0; i < direccion.Length; i++)
            {
                if (direccion[i] != ';')
                {

                    switch (contComas)
                    {
                        case 0:
                            calle += direccion[i];
                            break;
                        case 1:
                            piso += direccion[i];
                            break;
                        case 2:
                            depto += direccion[i];
                            break;
                        case 3:
                            localidad += direccion[i];
                            break;
                    }

                }
                else
                {
                    contComas++;
                }


            }

            txtCalle.Text = calle;
            txtDepto.Text = depto;
            txtPiso.Text = piso;
            txtLocalidad.Text = localidad;

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cbxRubro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}

