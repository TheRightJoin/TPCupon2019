using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.AbmProveedor;
using System.Configuration;
namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public static MenuStrip MainMenu = new MenuStrip();
        public Form1()
        {
            InitializeComponent();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formListadoClientes flc = new formListadoClientes();
            flc.Show();
            this.Hide();
        }


        private void crearClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaCliente fac = new AltaCliente();
            fac.Show();
            this.Hide();
        }

        private void crearProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaProveedor formAltaProveedor = new AltaProveedor();
            formAltaProveedor.Show();
            this.Hide();
        }

        private void verProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerProveedores formVerProveedores = new VerProveedores();
            formVerProveedores.Show();
            this.Hide();
        }

        private void cargarCreditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargaCredito fcc = new CargaCredito();
            fcc.Show();
            this.Hide();
        }

        private void publicarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PublicarOferta fpo = new PublicarOferta();
            fpo.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateFormat"]);
            crearMenuStripPublico();
        }

        private void comprarOfertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoOfertas flo = new ListadoOfertas();
            flo.Show();
            this.Hide();

        }

        private void resgristroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroDeUsuario rg = new RegistroDeUsuario();
            rg.Show();
            this.Hide();
            
        }

        private void crearMenuStripPublico() 
        {
            MainMenu.ForeColor = Color.Black;
            MainMenu.Text = "Main Menu";
            this.MainMenuStrip = MainMenu;
            Controls.Add(MainMenu);
            MainMenu.Name = "MainMenu";
            MainMenu.Dock = DockStyle.Top; 
            //nombre de usuario hardcodeadisimo, hay que obtenerlo del login
            List<String> funcUsuario = AdmUsuario.funcionalidadesDelRol("");
            foreach (var menuItem in funcUsuario)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(menuItem);
                item.Text = menuItem;
                item.Click += new EventHandler(this.FileMenuItemClick);
                MainMenu.Items.Add(item);
                this.subItems(item);
            }
        }

        private void subItems(ToolStripMenuItem item)
        {
            switch (item.Text)
            {
                case "Clientes":
                    ToolStripMenuItem itemCli1 = new ToolStripMenuItem("Ver Clientes");
                    ToolStripMenuItem itemCli2 = new ToolStripMenuItem("Alta Cliente");
                    itemCli1.Text = "Ver Clientes";
                    itemCli2.Text = "Alta Cliente";
                    itemCli1.Click += new EventHandler(this.FileMenuItemClick);
                    itemCli2.Click += new EventHandler(this.FileMenuItemClick);
                    item.DropDownItems.Add(itemCli1);
                    item.DropDownItems.Add(itemCli2);
                    break;
                case "Proveedores":
                    ToolStripMenuItem itemProv1 = new ToolStripMenuItem("Ver Proveedores");
                    ToolStripMenuItem itemProv2 = new ToolStripMenuItem("Alta Proveedor");
                    itemProv1.Text = "Ver Proveedores";
                    itemProv2.Text = "Alta Proveedor";
                    itemProv1.Click += new EventHandler(this.FileMenuItemClick);
                    itemProv2.Click += new EventHandler(this.FileMenuItemClick);
                    item.DropDownItems.Add(itemProv1);
                    item.DropDownItems.Add(itemProv2);
                    break;
                case "Cargar Credito":
                    break;
                case "Comprar Ofertas":
                    break;
                case "Confeccionar Oferta":
                    break;
                case "Registro de Usuario":
                    break;
                default:
                    break;
            }
        }

        private void FileMenuItemClick(object sender, EventArgs e)
        {
            switch (sender.ToString())
            {
                case "Ver Clientes":
                    formListadoClientes flc = new formListadoClientes();
                    hideForms();
                    flc.Show();                   
                    break;
                case "Alta Cliente":
                    AltaCliente fac = new AltaCliente();
                    hideForms();
                    fac.Show();
                    break;
                case "Ver Proveedores":
                    VerProveedores fvp = new VerProveedores();
                    hideForms();
                    fvp.Show();
                    break;
                case "Alta Proveedor":
                    AltaProveedor fap = new AltaProveedor();
                    hideForms();
                    fap.Show();
                    break;
                case "Cargar Credito":
                    CargaCredito fcc = new CargaCredito();
                    hideForms();
                    fcc.Show();
                    break;
                case "Comprar Ofertas":  
                    ListadoOfertas flo = new ListadoOfertas();
                    hideForms();
                    flo.Show();
                    break;
                case "Confeccionar Oferta":
                    PublicarOferta fpc = new PublicarOferta();
                    hideForms();
                    fpc.Show();
                    break;
                case "Registro de Usuario":
                    RegistroDeUsuario fru = new RegistroDeUsuario();
                    hideForms();
                    fru.Show();
                    break;
                default:
                    break;
            }
        }
        public void hideForms()
        {
            foreach (Form f in Application.OpenForms)
            {
                f.Hide();
            }
        }
    }
}
