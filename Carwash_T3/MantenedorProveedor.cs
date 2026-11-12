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
        private DataGridView dgvProveedor;
        private GroupBox grpDatos;
        private TextBox txtIdProveedor;
        private TextBox txtRazonSocial;
        private TextBox txtRuc;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private CheckBox chkEstadoProveedor;
        private Button btnNuevo, btnEditar, btnGuardar, btnDeshabilitar, btnCancelar, btnCerrar;
        private bool esNuevo;

        public MantenedorProveedor()
        {

            ConstruirInterfaz();
            listarProveedor();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
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

        private void AgregarCampo(string etiqueta, Control c, int x, int y, int ancho)
        {
            grpDatos.Controls.Add(new Label { Text = etiqueta, Location = new Point(x, y + 3), AutoSize = true });
            c.Location = new Point(x + 140, y);
            c.Width = ancho;
            grpDatos.Controls.Add(c);
        }

        private Button NuevoBoton(string texto, int x, EventHandler click)
        {
            Button b = new Button { Text = texto, Location = new Point(x, 468), Size = new Size(105, 32) };
            b.Click += click;
            Controls.Add(b);
            return b;
        }

        private void ConstruirInterfaz()
        {
            Text = "Mantenedor de Proveedores";
            ClientSize = new Size(884, 538);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            dgvProveedor = new DataGridView();
            dgvProveedor.Location = new Point(12, 12);
            dgvProveedor.Size = new Size(860, 255);
            dgvProveedor.ReadOnly = true;
            dgvProveedor.AllowUserToAddRows = false;
            dgvProveedor.AllowUserToDeleteRows = false;
            dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedor.MultiSelect = false;
            dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedor.RowHeadersVisible = false;
            dgvProveedor.CellClick += dgvProveedor_CellClick;
            dgvProveedor.CellDoubleClick += dgvProveedor_CellDoubleClick;
            Controls.Add(dgvProveedor);

            grpDatos = new GroupBox { Text = "Datos de Proveedor", Location = new Point(12, 280), Size = new Size(860, 176) };
            Controls.Add(grpDatos);

            txtIdProveedor = new TextBox { ReadOnly = true };
            AgregarCampo("Código", txtIdProveedor, 15, 25, 230);
            txtRazonSocial = new TextBox { MaxLength = 100 };
            AgregarCampo("Razón social *", txtRazonSocial, 445, 25, 230);
            txtRuc = new TextBox { MaxLength = 11 };
            AgregarCampo("RUC *", txtRuc, 15, 59, 230);
            txtTelefono = new TextBox { MaxLength = 15 };
            AgregarCampo("Teléfono", txtTelefono, 445, 59, 230);
            txtDireccion = new TextBox { MaxLength = 150 };
            AgregarCampo("Dirección", txtDireccion, 15, 93, 230);
            txtEmail = new TextBox { MaxLength = 100 };
            AgregarCampo("Correo", txtEmail, 445, 93, 230);
            chkEstadoProveedor = new CheckBox { Text = "Activo", Checked = true };
            chkEstadoProveedor.Location = new Point(155, 127);
            grpDatos.Controls.Add(chkEstadoProveedor);

            btnNuevo = NuevoBoton("Nuevo", 12, btnNuevo_Click);
            btnEditar = NuevoBoton("Editar", 127, btnEditar_Click);
            btnGuardar = NuevoBoton("Guardar", 242, btnGuardar_Click);
            btnDeshabilitar = NuevoBoton("Deshabilitar", 357, btnDeshabilitar_Click);
            btnCancelar = NuevoBoton("Cancelar", 472, btnCancelar_Click);
            btnCerrar = NuevoBoton("Cerrar", 767, btnCerrar_Click);
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

