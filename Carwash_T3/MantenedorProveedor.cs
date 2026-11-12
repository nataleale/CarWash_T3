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
    public partial class MantenedorProveedor : Form
    {
        private bool esNuevo = false;
        private void MantenedorProveedor_Load(object sender, EventArgs e)
        {
            InitializeComponent();   
            ConectarEventos();
            listarProveedor();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }
        private void ConectarEventos()
        {
            dgvProveedor.ReadOnly = true;
            dgvProveedor.AllowUserToAddRows = false;
            dgvProveedor.AllowUserToDeleteRows = false;
            dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedor.MultiSelect = false;
            dgvProveedor.CellClick += dgvProveedor_CellClick;
            dgvProveedor.CellDoubleClick += dgvProveedor_CellDoubleClick;

            txtIdProveedor.ReadOnly = true;
            txtRazonSocial.MaxLength = 100;
            txtRuc.MaxLength = 11;
            txtTelefono.MaxLength = 15;
            txtDireccion.MaxLength = 150;
            txtEmail.MaxLength = 100;

            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnDeshabilitar.Click += btnDeshabilitar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        public void listarProveedor()
        {
            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = logProveedor.Instancia.ListarProveedor();
            ConfigurarColumnas();
            Limpiar();
        }

        private void Col(string nombre, string titulo, bool visible = true)
        {
            if (dgvProveedor.Columns[nombre] != null)
            {
                dgvProveedor.Columns[nombre].HeaderText = titulo;
                dgvProveedor.Columns[nombre].Visible = visible;
            }
        }

        private void ConfigurarColumnas()
        {
            Col("idProveedor", "Código");
            Col("razonSocial", "Razón social");
            Col("ruc", "RUC");
            Col("telefono", "Teléfono");
            Col("direccion", "Dirección");
            Col("email", "Correo");
            Col("estProveedor", "Activo");
        }

        private void ActualizarBotones(bool editando)
        {
            btnNuevo.Enabled = !editando;
            btnEditar.Enabled = !editando;
            btnDeshabilitar.Enabled = !editando;
            btnGuardar.Enabled = editando;
            btnCancelar.Enabled = editando;
            dgvProveedor.Enabled = !editando;
        }

        private void Limpiar()
        {
            txtIdProveedor.Text = "";
            txtRazonSocial.Text = "";
            txtRuc.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            chkEstadoProveedor.Checked = true;
        }

        private void MostrarEnControles(entProveedor o)
        {
            txtIdProveedor.Text = o.idProveedor.ToString();
            txtRazonSocial.Text = o.razonSocial;
            txtRuc.Text = o.ruc;
            txtTelefono.Text = o.telefono;
            txtDireccion.Text = o.direccion;
            txtEmail.Text = o.email;
            chkEstadoProveedor.Checked = o.estProveedor;
        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            entProveedor o = dgvProveedor.Rows[e.RowIndex].DataBoundItem as entProveedor;
            if (o != null) MostrarEnControles(o);
        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvProveedor_CellClick(sender, e);
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
            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text))
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

        private bool TryObtener(out entProveedor o)
        {
            o = null;
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text)) { Aviso("Ingrese: Razón social.", txtRazonSocial); return false; }
            if (string.IsNullOrWhiteSpace(txtRuc.Text)) { Aviso("Ingrese: RUC.", txtRuc); return false; }

            o = new entProveedor();
            o.idProveedor = string.IsNullOrWhiteSpace(txtIdProveedor.Text) ? 0 : int.Parse(txtIdProveedor.Text);
            o.razonSocial = txtRazonSocial.Text.Trim();
            o.ruc = txtRuc.Text.Trim();
            o.telefono = txtTelefono.Text.Trim();
            o.direccion = txtDireccion.Text.Trim();
            o.email = txtEmail.Text.Trim();
            o.estProveedor = chkEstadoProveedor.Checked;
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProveedor.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea deshabilitar este registro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                entProveedor o = new entProveedor();
                o.idProveedor = int.Parse(txtIdProveedor.Text);
                logProveedor.Instancia.DeshabilitarProveedor(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpDatos.Enabled = false;
            listarProveedor();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

       
        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Limpiar();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            entProveedor o;
            if (!TryObtener(out o)) return;
            try
            {
                bool ok = esNuevo ? logProveedor.Instancia.InsertaProveedor(o) : logProveedor.Instancia.EditaProveedor(o);
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
            listarProveedor();
        }
    }
}

