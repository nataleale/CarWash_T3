using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carwash_T3
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;
            InitializeComponent();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantenedorCliente frm = new MantenedorCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vehículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantenedorVehiculo frm = new MantenedorVehiculo();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
