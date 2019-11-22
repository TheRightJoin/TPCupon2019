namespace FrbaOfertas
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarCreditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofertasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publicarOfertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comprarOfertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resgristroDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.proveedorToolStripMenuItem,
            this.cargarCreditoToolStripMenuItem,
            this.ofertasToolStripMenuItem,
            this.comprarOfertaToolStripMenuItem,
            this.resgristroDeUsuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(819, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearClienteToolStripMenuItem,
            this.verClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // crearClienteToolStripMenuItem
            // 
            this.crearClienteToolStripMenuItem.Name = "crearClienteToolStripMenuItem";
            this.crearClienteToolStripMenuItem.Size = new System.Drawing.Size(183, 30);
            this.crearClienteToolStripMenuItem.Text = "Crear Cliente";
            this.crearClienteToolStripMenuItem.Click += new System.EventHandler(this.crearClienteToolStripMenuItem_Click);
            // 
            // verClientesToolStripMenuItem
            // 
            this.verClientesToolStripMenuItem.Name = "verClientesToolStripMenuItem";
            this.verClientesToolStripMenuItem.Size = new System.Drawing.Size(183, 30);
            this.verClientesToolStripMenuItem.Text = "Ver Clientes";
            this.verClientesToolStripMenuItem.Click += new System.EventHandler(this.verClientesToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearProveedorToolStripMenuItem,
            this.verProveedoresToolStripMenuItem});
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(106, 29);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            // 
            // crearProveedorToolStripMenuItem
            // 
            this.crearProveedorToolStripMenuItem.Name = "crearProveedorToolStripMenuItem";
            this.crearProveedorToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.crearProveedorToolStripMenuItem.Text = "Crear Proveedor";
            this.crearProveedorToolStripMenuItem.Click += new System.EventHandler(this.crearProveedorToolStripMenuItem_Click);
            // 
            // verProveedoresToolStripMenuItem
            // 
            this.verProveedoresToolStripMenuItem.Name = "verProveedoresToolStripMenuItem";
            this.verProveedoresToolStripMenuItem.Size = new System.Drawing.Size(213, 30);
            this.verProveedoresToolStripMenuItem.Text = "Ver Proveedores";
            this.verProveedoresToolStripMenuItem.Click += new System.EventHandler(this.verProveedoresToolStripMenuItem_Click);
            // 
            // cargarCreditoToolStripMenuItem
            // 
            this.cargarCreditoToolStripMenuItem.Name = "cargarCreditoToolStripMenuItem";
            this.cargarCreditoToolStripMenuItem.Size = new System.Drawing.Size(139, 29);
            this.cargarCreditoToolStripMenuItem.Text = "Cargar Credito";
            this.cargarCreditoToolStripMenuItem.Click += new System.EventHandler(this.cargarCreditoToolStripMenuItem_Click);
            // 
            // ofertasToolStripMenuItem
            // 
            this.ofertasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publicarOfertaToolStripMenuItem});
            this.ofertasToolStripMenuItem.Name = "ofertasToolStripMenuItem";
            this.ofertasToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.ofertasToolStripMenuItem.Text = "Ofertas";
            // 
            // publicarOfertaToolStripMenuItem
            // 
            this.publicarOfertaToolStripMenuItem.Name = "publicarOfertaToolStripMenuItem";
            this.publicarOfertaToolStripMenuItem.Size = new System.Drawing.Size(180, 30);
            this.publicarOfertaToolStripMenuItem.Text = "Crear Oferta";
            this.publicarOfertaToolStripMenuItem.Click += new System.EventHandler(this.publicarOfertaToolStripMenuItem_Click);
            // 
            // comprarOfertaToolStripMenuItem
            // 
            this.comprarOfertaToolStripMenuItem.Name = "comprarOfertaToolStripMenuItem";
            this.comprarOfertaToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            this.comprarOfertaToolStripMenuItem.Text = "Comprar Ofertas";
            this.comprarOfertaToolStripMenuItem.Click += new System.EventHandler(this.comprarOfertaToolStripMenuItem_Click);
            // 
            // resgristroDeUsuarioToolStripMenuItem
            // 
            this.resgristroDeUsuarioToolStripMenuItem.Name = "resgristroDeUsuarioToolStripMenuItem";
            this.resgristroDeUsuarioToolStripMenuItem.Size = new System.Drawing.Size(191, 29);
            this.resgristroDeUsuarioToolStripMenuItem.Text = "Resgristro de usuario";
            this.resgristroDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.resgristroDeUsuarioToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 402);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verProveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarCreditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ofertasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publicarOfertaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comprarOfertaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resgristroDeUsuarioToolStripMenuItem;
    }
}

