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
    public partial class MantenedorMetodoPago : Form
    {
        private bool esNuevo;

        public MantenedorMetodoPago()
        {
            InitializeComponent();
            listarMetodoPago();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }

        public void listarMetodoPago()
        {
            dgvMetodoPago.DataSource = null;
            dgvMetodoPago.DataSource = logMetodoPago.Instancia.ListarMetodoPago();
            ConfigurarColumnas();
            Limpiar();
        }

        private void Col(string nombre, string titulo, bool visible = true)
        {
            if (dgvMetodoPago.Columns[nombre] != null)
            {
                dgvMetodoPago.Columns[nombre].HeaderText = titulo;
                dgvMetodoPago.Columns[nombre].Visible = visible;
            }
        }

        private void ConfigurarColumnas()
        {
            Col("idMetodoPago", "Código");
            Col("nombre", "Nombre");
            Col("descripcion", "Descripción");
            Col("estMetodoPago", "Activo");
        }

        private void ActualizarBotones(bool editando)
        {
            btnNuevo.Enabled = !editando;
            btnEditar.Enabled = !editando;
            btnDeshabilitar.Enabled = !editando;
            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;
            dgvMetodoPago.Enabled = !editando;
        }

        private void Limpiar()
        {
            txtIdMetodoPago.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            chkEstadoMetodoPago.Checked = true;
        }

        private void MostrarEnControles(entMetodoPago o)
        {
            txtIdMetodoPago.Text = o.idMetodoPago.ToString();
            txtNombre.Text = o.nombre;
            txtDescripcion.Text = o.descripcion;
            chkEstadoMetodoPago.Checked = o.estMetodoPago;
        }

        private void dgvMetodoPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            entMetodoPago o = dgvMetodoPago.Rows[e.RowIndex].DataBoundItem as entMetodoPago;

            if (o != null)
                MostrarEnControles(o);
        }

        private void dgvMetodoPago_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvMetodoPago_CellClick(sender, e);
            btnEditar_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Limpiar();

            grpDatos.Enabled = true;
            ActualizarBotones(true);

            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdMetodoPago.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            esNuevo = false;
            grpDatos.Enabled = true;
            ActualizarBotones(true);
        }

        private void Aviso(string mensaje, Control c)
        {
            MessageBox.Show(mensaje, "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            c.Focus();
        }

        private bool TryObtener(out entMetodoPago o)
        {
            o = null;

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                Aviso("Ingrese: Nombre.", txtNombre);
                return false;
            }

            o = new entMetodoPago();

            o.idMetodoPago = string.IsNullOrWhiteSpace(txtIdMetodoPago.Text)
                ? 0 : int.Parse(txtIdMetodoPago.Text);

            o.nombre = txtNombre.Text.Trim();
            o.descripcion = txtDescripcion.Text.Trim();
            o.estMetodoPago = chkEstadoMetodoPago.Checked;

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            entMetodoPago o;

            if (!TryObtener(out o)) return;

            try
            {
                bool ok = esNuevo
                    ? logMetodoPago.Instancia.InsertaMetodoPago(o)
                    : logMetodoPago.Instancia.EditaMetodoPago(o);

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
                    MessageBox.Show("Ya existe un método de pago con el mismo nombre.",
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
            listarMetodoPago();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdMetodoPago.Text))
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
                entMetodoPago o = new entMetodoPago();
                o.idMetodoPago = int.Parse(txtIdMetodoPago.Text);

                logMetodoPago.Instancia.DeshabilitarMetodoPago(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            grpDatos.Enabled = false;
            ActualizarBotones(false);
            listarMetodoPago();
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
    }
}