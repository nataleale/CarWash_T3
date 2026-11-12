using CapaEntidad;
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
    public partial class MantenedorVehiculo : Form
    {
        private bool esNuevo;
        public MantenedorVehiculo()
        {
            InitializeComponent();
        }
        private void ActualizarBotones(bool editando)
        {
            btnNuevo.Enabled = !editando;
            btnEditar.Enabled = !editando;
            btnDeshabilitar.Enabled = !editando;
            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;
            dgvVehiculo.Enabled = !editando;
        }

        private void Limpiar()
        {
            txtIdVehiculo.Text = "";
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtColor.Text = "";
            txtAnio.Text = "";
            cboTipoVehiculo.SelectedIndex = -1;
            cboIdCliente.SelectedIndex = -1;
            chkEstadoVehiculo.Checked = true;
        }
        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Limpiar();
            grpDatos.Enabled = true;
            ActualizarBotones(true);
            txtPlaca.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Limpiar();
            grpDatos.Enabled = true;
            ActualizarBotones(true);
            txtPlaca.Focus();
        }
        private void MostrarEnControles(entVehiculo o)
        {
            txtIdVehiculo.Text = o.idVehiculo.ToString();
            txtPlaca.Text = o.placa;
            txtMarca.Text = o.marca;
            txtModelo.Text = o.modelo;
            txtColor.Text = o.color;
            txtAnio.Text = o.anio.ToString();
            cboTipoVehiculo.SelectedItem = o.tipoVehiculo;
            cboIdCliente.SelectedValue = o.idCliente;
            chkEstadoVehiculo.Checked = o.estVehiculo;
        }

        private void dgvVehiculo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            entVehiculo o = dgvVehiculo.Rows[e.RowIndex].DataBoundItem as entVehiculo;
            if (o != null) MostrarEnControles(o);
        }
    }
}
