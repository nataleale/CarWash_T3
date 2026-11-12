using CapaIdentidad;
using CapaLogica;
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
    public partial class MantenedorEmpleado : Form
    {
        public MantenedorEmpleado()
        {
            InitializeComponent();
            listarEmpleado();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
            
        }
        private bool esNuevo;

        private void ActualizarBotones(bool editando)
        {
            btnNuevo.Enabled = !editando;
            btnEditar.Enabled = !editando;
            btnDeshabilitar.Enabled = !editando;
            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;
            dgvEmpleado.Enabled = !editando;
        }

        private void Limpiar()
        {
            txtIdEmpleado.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDni.Text = "";
            txtTelefono.Text = "";
            cboCargo.SelectedIndex = -1;
            dtpFecContratacion.Value = DateTime.Today;
            chkEstadoEmpleado.Checked = true;
        }

        private void MostrarEnControles(entEmpleado o)
        {
            txtIdEmpleado.Text = o.idEmpleado.ToString();
            txtNombres.Text = o.nombres;
            txtApellidos.Text = o.apellidos;
            txtDni.Text = o.dni;
            txtTelefono.Text = o.telefono;
            cboCargo.SelectedItem = o.cargo;
            dtpFecContratacion.Value = o.fecContratacion;
            chkEstadoEmpleado.Checked = o.estEmpleado;
        }
        public void listarEmpleado()
        {
            dgvEmpleado.DataSource = null;
            dgvEmpleado.DataSource = logEmpleado.Instancia.ListarEmpleado();
            ConfigurarColumnas();
            Limpiar();
        }

        private void Col(string nombre, string titulo, bool visible = true)
        {
            if (dgvEmpleado.Columns[nombre] != null)
            {
                dgvEmpleado.Columns[nombre].HeaderText = titulo;
                dgvEmpleado.Columns[nombre].Visible = visible;
            }
        }

        private void ConfigurarColumnas()
        {
            Col("idEmpleado", "Código");
            Col("nombres", "Nombres");
            Col("apellidos", "Apellidos");
            Col("dni", "DNI");
            Col("telefono", "Teléfono");
            Col("cargo", "Cargo");
            Col("fecContratacion", "Fecha de contratación");
            Col("estEmpleado", "Activo");
        }


        private void MantenedorEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void dgvEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            entEmpleado o = dgvEmpleado.Rows[e.RowIndex].DataBoundItem as entEmpleado;
            if (o != null) MostrarEnControles(o);
        }

        private void dgvEmpleado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvEmpleado_CellClick(sender, e);
            btnEditar_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Limpiar();
            grpDatos.Enabled = true;
            ActualizarBotones(true);
            txtNombres.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            esNuevo = false;
            grpDatos.Enabled = true;
            ActualizarBotones(true);
        }

        private void Aviso(string mensaje, Control c)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
        }

        private bool TryObtener(out entEmpleado o)
        {
            o = null;
            if (string.IsNullOrWhiteSpace(txtNombres.Text)) { Aviso("Ingrese: Nombres.", txtNombres); return false; }
            if (string.IsNullOrWhiteSpace(txtApellidos.Text)) { Aviso("Ingrese: Apellidos.", txtApellidos); return false; }
            if (string.IsNullOrWhiteSpace(txtDni.Text)) { Aviso("Ingrese: DNI.", txtDni); return false; }
            if (cboCargo.SelectedItem == null) { Aviso("Seleccione: Cargo.", cboCargo); return false; }

            o = new entEmpleado();
            o.idEmpleado = string.IsNullOrWhiteSpace(txtIdEmpleado.Text) ? 0 : int.Parse(txtIdEmpleado.Text);
            o.nombres = txtNombres.Text.Trim();
            o.apellidos = txtApellidos.Text.Trim();
            o.dni = txtDni.Text.Trim();
            o.telefono = txtTelefono.Text.Trim();
            o.cargo = cboCargo.SelectedItem.ToString();
            o.fecContratacion = dtpFecContratacion.Value.Date;
            o.estEmpleado = chkEstadoEmpleado.Checked;
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            entEmpleado o;
            if (!TryObtener(out o)) return;
            try
            {
                bool ok = esNuevo ? logEmpleado.Instancia.InsertaEmpleado(o) : logEmpleado.Instancia.EditaEmpleado(o);
                if (ok)
                    MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo guardar el registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE") || ex.Message.Contains("duplicate"))
                    MessageBox.Show("Ya existe un registro con el mismo dato único (documento, RUC, DNI, placa o nombre).", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpDatos.Enabled = false;
            ActualizarBotones(false);
            listarEmpleado();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdEmpleado.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea deshabilitar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                entEmpleado o = new entEmpleado();
                o.idEmpleado = int.Parse(txtIdEmpleado.Text);
                logEmpleado.Instancia.DeshabilitarEmpleado(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpDatos.Enabled = false;
            listarEmpleado();
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

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
