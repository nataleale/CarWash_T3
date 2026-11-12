using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaIdentidad;
using CapaLogica;

namespace Carwash_T3
{
    public partial class MantenedorCliente : Form
    {
        private bool esNuevo;

        public MantenedorCliente()
        {
            InitializeComponent();
            listarCliente();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }

        public void listarCliente()
        {
            dgvCliente.DataSource = null;
            dgvCliente.DataSource = logCliente.Instancia.ListarCliente();
            ConfigurarColumnas();
            Limpiar();
        }

        private void ConfigurarColumnas()
        {
            Col("idCliente", "Código");
            Col("razonSocial", "Razón social / Nombre");
            Col("documento", "DNI / RUC");
            Col("telefono", "Teléfono");
            Col("direccion", "Dirección");
            Col("email", "Correo");
            Col("fecRegCliente", "Fecha de registro");
            Col("estCliente", "Activo");
        }

        private void Col(string nombre, string titulo, bool visible = true)
        {
            if (dgvCliente.Columns[nombre] != null)
            {
                dgvCliente.Columns[nombre].HeaderText = titulo;
                dgvCliente.Columns[nombre].Visible = visible;
            }
        }

        private void ActualizarBotones(bool editando)
        {
            btnNuevo.Enabled = !editando;
            btnEditar.Enabled = !editando;
            btnDeshabilitar.Enabled = !editando;
            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;
            dgvCliente.Enabled = !editando;
        }

        private void Limpiar()
        {
            txtIdCliente.Text = "";
            txtRazonSocial.Text = "";
            txtDocumento.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            dtpFecRegCliente.Value = DateTime.Today;
            chkEstadoCliente.Checked = true;
        }

        private void MostrarEnControles(entCliente o)
        {
            txtIdCliente.Text = o.idCliente.ToString();
            txtRazonSocial.Text = o.razonSocial;
            txtDocumento.Text = o.documento;
            txtTelefono.Text = o.telefono;
            txtDireccion.Text = o.direccion;
            txtEmail.Text = o.email;
            dtpFecRegCliente.Value = o.fecRegCliente;
            chkEstadoCliente.Checked = o.estCliente;
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            entCliente o = dgvCliente.Rows[e.RowIndex].DataBoundItem as entCliente;

            if (o != null)
                MostrarEnControles(o);
        }

        private void dgvCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvCliente_CellClick(sender, e);
            btnEditar_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Limpiar();

            grpDatos.Enabled = true;
            ActualizarBotones(true);

            txtRazonSocial.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            esNuevo = false;
            grpDatos.Enabled = true;
            ActualizarBotones(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            entCliente o;

            if (!TryObtener(out o)) return;

            try
            {
                bool ok = esNuevo
                    ? logCliente.Instancia.InsertaCliente(o)
                    : logCliente.Instancia.EditaCliente(o);

                if (ok)
                {
                    MessageBox.Show("Registro guardado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el registro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE") ||
                    ex.Message.Contains("duplicate"))
                {
                    MessageBox.Show("Ya existe un registro con el mismo documento.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            grpDatos.Enabled = false;
            ActualizarBotones(false);
            listarCliente();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea deshabilitar este registro?",
                "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                entCliente o = new entCliente();
                o.idCliente = int.Parse(txtIdCliente.Text);

                logCliente.Instancia.DeshabilitarCliente(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            grpDatos.Enabled = false;
            ActualizarBotones(false);
            listarCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();

            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Aviso(string mensaje, Control c)
        {
            MessageBox.Show(mensaje, "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            c.Focus();
        }

        private bool TryObtener(out entCliente o)
        {
            o = null;

            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                Aviso("Ingrese: Razón social / Nombre.", txtRazonSocial);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                Aviso("Ingrese: DNI / RUC.", txtDocumento);
                return false;
            }

            o = new entCliente();

            o.idCliente = string.IsNullOrWhiteSpace(txtIdCliente.Text)
                ? 0 : int.Parse(txtIdCliente.Text);

            o.razonSocial = txtRazonSocial.Text.Trim();
            o.documento = txtDocumento.Text.Trim();
            o.telefono = txtTelefono.Text.Trim();
            o.direccion = txtDireccion.Text.Trim();
            o.email = txtEmail.Text.Trim();
            o.fecRegCliente = dtpFecRegCliente.Value.Date;
            o.estCliente = chkEstadoCliente.Checked;

            return true;
        }

        private void MantenedorCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
