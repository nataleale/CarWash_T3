namespace Carwash_T3
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.coreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehículosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodosDePagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salir = new System.Windows.Forms.ToolStripMenuItem();
            this.lavadoVehiculoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coreToolStripMenuItem,
            this.mantenedoresToolStripMenuItem,
            this.salir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menu";
            // 
            // coreToolStripMenuItem
            // 
            this.coreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lavadoVehiculoToolStripMenuItem,
            this.diagnosticoToolStripMenuItem});
            this.coreToolStripMenuItem.Name = "coreToolStripMenuItem";
            this.coreToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.coreToolStripMenuItem.Text = "Core";
            // 
            // mantenedoresToolStripMenuItem
            // 
            this.mantenedoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.vehículosToolStripMenuItem,
            this.empleadosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.materialesToolStripMenuItem,
            this.métodosDePagoToolStripMenuItem});
            this.mantenedoresToolStripMenuItem.Name = "mantenedoresToolStripMenuItem";
            this.mantenedoresToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.mantenedoresToolStripMenuItem.Text = "Mantenedores";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // vehículosToolStripMenuItem
            // 
            this.vehículosToolStripMenuItem.Name = "vehículosToolStripMenuItem";
            this.vehículosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vehículosToolStripMenuItem.Text = "Vehículos";
            this.vehículosToolStripMenuItem.Click += new System.EventHandler(this.vehículosToolStripMenuItem_Click);
            // 
            // empleadosToolStripMenuItem
            // 
            this.empleadosToolStripMenuItem.Name = "empleadosToolStripMenuItem";
            this.empleadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.empleadosToolStripMenuItem.Text = "Empleados";
            this.empleadosToolStripMenuItem.Click += new System.EventHandler(this.empleadosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.proveedoresToolStripMenuItem_Click);
            // 
            // materialesToolStripMenuItem
            // 
            this.materialesToolStripMenuItem.Name = "materialesToolStripMenuItem";
            this.materialesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.materialesToolStripMenuItem.Text = "Materiales";
            // 
            // métodosDePagoToolStripMenuItem
            // 
            this.métodosDePagoToolStripMenuItem.Name = "métodosDePagoToolStripMenuItem";
            this.métodosDePagoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.métodosDePagoToolStripMenuItem.Text = "Métodos de pago";
            // 
            // salir
            // 
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(41, 20);
            this.salir.Text = "Salir";
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // lavadoVehiculoToolStripMenuItem
            // 
            this.lavadoVehiculoToolStripMenuItem.Name = "lavadoVehiculoToolStripMenuItem";
            this.lavadoVehiculoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lavadoVehiculoToolStripMenuItem.Text = "Lavado Vehiculo";
            this.lavadoVehiculoToolStripMenuItem.Click += new System.EventHandler(this.lavadoVehiculoToolStripMenuItem_Click);
            // 
            // diagnosticoToolStripMenuItem
            // 
            this.diagnosticoToolStripMenuItem.Name = "diagnosticoToolStripMenuItem";
            this.diagnosticoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.diagnosticoToolStripMenuItem.Text = "Diagnostico";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem mantenedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salir;
        private System.Windows.Forms.ToolStripMenuItem coreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehículosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodosDePagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lavadoVehiculoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosticoToolStripMenuItem;
    }
}

