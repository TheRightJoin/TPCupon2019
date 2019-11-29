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
using FrbaOfertas.Facturar;
namespace FrbaOfertas
{
    public partial class Form1 : Form
    {
        public static MenuStrip MainMenu = new MenuStrip();
        public Form1()
        {
            InitializeComponent();
        }      

        private void crearMenuStripPublico() 
        {
            MainMenu.ForeColor = Color.Black;
            MainMenu.Text = "Main Menu";
            this.MainMenuStrip = MainMenu;
            Controls.Add(MainMenu);
            MainMenu.Name = "MainMenu";
            MainMenu.Font = new System.Drawing.Font("Arial",7f, FontStyle.Italic);
            MainMenu.Dock = DockStyle.Top; 
            //nombre de usuario hardcodeadisimo, hay que obtenerlo del login
            DataSet ds = AdmRol.obtenerFuncionalidadesRol(ElegirRol.rolElegido);
            List<String> funcUsuario = ds.Tables[0].AsEnumerable().Select(r => r.Field<String>("funcio_name")).ToList();
            foreach (var menuItem in funcUsuario)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(menuItem);
                item.Text = menuItem;
                item.Click += new EventHandler(this.FileMenuItemClick);
                MainMenu.Items.Add(item);
                this.subItems(item);
            }
            ToolStripMenuItem desloguear = new ToolStripMenuItem("PERFIL");
            desloguear.Text = "PERFIL";
            desloguear.Click += new EventHandler(this.FileMenuItemClick);
            MainMenu.Items.Add(desloguear);
        }

        private void subItems(ToolStripMenuItem item)
        {
            switch (item.Text)
            {
                case "ABM CLIENTE":
                    ToolStripMenuItem itemCli1 = new ToolStripMenuItem("Ver Clientes");
                    ToolStripMenuItem itemCli2 = new ToolStripMenuItem("Alta Cliente");
                    itemCli1.Text = "Ver Clientes";
                    itemCli2.Text = "Alta Cliente";
                    itemCli1.Click += new EventHandler(this.FileMenuItemClick);
                    itemCli2.Click += new EventHandler(this.FileMenuItemClick);
                    item.DropDownItems.Add(itemCli1);
                    item.DropDownItems.Add(itemCli2);
                    break;
                case "ABM PROVEEDOR":
                    ToolStripMenuItem itemProv1 = new ToolStripMenuItem("Ver Proveedores");
                    ToolStripMenuItem itemProv2 = new ToolStripMenuItem("Alta Proveedor");
                    itemProv1.Text = "Ver Proveedores";
                    itemProv2.Text = "Alta Proveedor";
                    itemProv1.Click += new EventHandler(this.FileMenuItemClick);
                    itemProv2.Click += new EventHandler(this.FileMenuItemClick);
                    item.DropDownItems.Add(itemProv1);
                    item.DropDownItems.Add(itemProv2);
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
                case "CARGAR CREDITO":
                    CargaCredito fcc = new CargaCredito();
                    hideForms();
                    fcc.Show();
                    break;
                case "COMPRAR OFERTA":  
                    ListadoOfertas flo = new ListadoOfertas();
                    hideForms();
                    flo.Show();
                    break;
                case "GENERAR OFERTA":
                    PublicarOferta fpc = new PublicarOferta();
                    hideForms();
                    fpc.Show();
                    break;
                case "REGISTRAR USUARIO":
                    RegistroDeUsuario fru = new RegistroDeUsuario();
                    hideForms();
                    fru.Show();
                    break;
                case "ESTADISTICA":
                    ListadoEstadistico fle = new ListadoEstadistico();
                    hideForms();
                    fle.Show();
                    break;
                case "FACTURACION":
                    FacturarAProveedor ffp = new FacturarAProveedor();
                    hideForms();
                    ffp.Show();
                    break;
                case "MODIFICAR PASSWORD":
                    CambiarPass fcp = new CambiarPass();
                    hideForms();
                    fcp.Show();
                    break;
                case "PERFIL":
                    Perfil flog = new Perfil();
                    hideForms();
                    flog.Show();
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

        private void Form1_Load_1(object sender, EventArgs e)
        {
            DateTime value = Convert.ToDateTime(ConfigurationManager.AppSettings["DateFormat"]);
            if (MainMenu.Items.Count.ToString() == "0")
            {
                crearMenuStripPublico();
            }
            else {
                this.Controls.Add(MainMenu);
            }
            
           
        
        }

       
    }
}
