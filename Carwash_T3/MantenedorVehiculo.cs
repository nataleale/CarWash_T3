using System;
using System.Windows.Forms;
using CapaEntidad;
using CapaLogica;

namespace Carwash_T3
{
    public partial class MantenedorVehiculo : Form
    {
        private bool esNuevo;

        public MantenedorVehiculo()
        {
            InitializeComponent();
            ConfigurarControles();
            CargarCombos();
            listarVehiculo();
            grpDatos.Enabled = false;
            ActualizarBotones(false);
        }

        // Conecta un botón con su método sin duplicar el evento
        private void Conectar(Button b, EventHandler h)
        {
            b.Click -= h;
            b.Click += h;
        }

        private void ConfigurarControles()
        {
            dgvVehiculo.AutoGenerateColumns = true;
            dgvVehiculo.ReadOnly = true;
            dgvVehiculo.AllowUserToAddRows = false;
            dgvVehiculo.AllowUserToDeleteRows = false;
            dgvVehiculo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculo.MultiSelect = false;
            dgvVehiculo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculo.RowHeadersVisible = false;

            txtIdVehiculo.ReadOnly = true;
            txtPlaca.MaxLength = 10;
            txtPlaca.CharacterCasing = CharacterCasing.Upper;
            txtMarca.MaxLength = 40;
            txtModelo.MaxLength = 40;
            txtColor.MaxLength = 30;
            txtAnio.MaxLength = 4;

            cboTipoVehiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cboTipoVehiculo.Items.Count == 0)
                cboTipoVehiculo.Items.AddRange(new object[] { "Auto", "Camioneta", "Moto", "Camión", "Furgoneta" });
            cboIdCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            Conectar(btnNuevo, btnNuevo_Click);
            Conectar(btnEditar, btnEditar_Click);
            Conectar(btnGuardar, btnGuardar_Click);
            Conectar(btnDeshabilitar, btnDeshabilitar_Click);
            Conectar(btnCerrar, btnCerrar_Click);

            dgvVehiculo.CellClick -= dgvVehiculo_CellClick;
            dgvVehiculo.CellClick += dgvVehiculo_CellClick;
            dgvVehiculo.CellDoubleClick -= dgvVehiculo_CellDoubleClick;
            dgvVehiculo.CellDoubleClick += dgvVehiculo_CellDoubleClick;
            txtAnio.KeyPress -= txtAnio_KeyPress;
            txtAnio.KeyPress += txtAnio_KeyPress;
        }

        private void CargarCombos()
        {
            // Si te marca error en "razonSocial", pon el nombre de la propiedad
            // que usa entCliente para mostrar el nombre del cliente.
            cboIdCliente.DisplayMember = "razonSocial";
            cboIdCliente.ValueMember = "idCliente";
            cboIdCliente.DataSource = logCliente.Instancia.ListarCliente();
            cboIdCliente.SelectedIndex = -1;
        }

        public void listarVehiculo()
        {
            dgvVehiculo.DataSource = null;
            dgvVehiculo.DataSource = logVehiculo.Instancia.ListarVehiculo();
            ConfigurarColumnas();
            Limpiar();
        }

        // El DataGridView crea las columnas solo (una por propiedad de entVehiculo).
        // Aquí solo se les cambia el título o se ocultan.
        private void Col(string nombre, string titulo, bool visible = true)
        {
            if (dgvVehiculo.Columns[nombre] != null)
            {
                dgvVehiculo.Columns[nombre].HeaderText = titulo;
                dgvVehiculo.Columns[nombre].Visible = visible;
            }
        }

        private void ConfigurarColumnas()
        {
            Col("idVehiculo", "Código");
            Col("placa", "Placa");
            Col("marca", "Marca");
            Col("modelo", "Modelo");
            Col("color", "Color");
            Col("anio", "Año");
            Col("tipoVehiculo", "Tipo de vehículo");
            Col("idCliente", "Cliente (dueño)", false);
            Col("estVehiculo", "Activo");
            Col("clienteNombre", "Cliente");
        }

        private void ActualizarBotones(bool editando)
        {
            btnGuardar.Enabled = editando;
            btnDeshabilitar.Enabled = !editando;
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

        private void MostrarEnControles(entVehiculo o)
        {
            txtIdVehiculo.Text = o.idVehiculo.ToString();
            txtPlaca.Text = o.placa;
            txtMarca.Text = o.marca;
            txtModelo.Text = o.modelo;
            txtColor.Text = o.color;
            txtAnio.Text = o.anio.ToString();
            cboTipoVehiculo.SelectedIndex = cboTipoVehiculo.FindStringExact(o.tipoVehiculo);
            cboIdCliente.SelectedValue = o.idCliente;
            chkEstadoVehiculo.Checked = o.estVehiculo;
        }

        private void txtAnio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dgvVehiculo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            entVehiculo o = dgvVehiculo.Rows[e.RowIndex].DataBoundItem as entVehiculo;
            if (o != null) MostrarEnControles(o);
        }

        private void dgvVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvVehiculo_CellClick(sender, e);
            btnEditar_Click(sender, e);
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
            if (string.IsNullOrWhiteSpace(txtIdVehiculo.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            esNuevo = false;
            grpDatos.Enabled = true;
            ActualizarBotones(true);
            txtPlaca.Focus();
        }

        private void Aviso(string mensaje, Control c)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.Focus();
        }

        private bool TryObtener(out entVehiculo o)
        {
            o = null;
            if (string.IsNullOrWhiteSpace(txtPlaca.Text)) { Aviso("Ingrese: Placa.", txtPlaca); return false; }
            if (string.IsNullOrWhiteSpace(txtMarca.Text)) { Aviso("Ingrese: Marca.", txtMarca); return false; }
            int v_anio;
            if (!int.TryParse(txtAnio.Text.Trim(), out v_anio) || v_anio < 1900 || v_anio > DateTime.Now.Year + 1)
            { Aviso("Año debe ser un número válido (por ejemplo 2020).", txtAnio); return false; }
            if (cboTipoVehiculo.SelectedItem == null) { Aviso("Seleccione: Tipo de vehículo.", cboTipoVehiculo); return false; }
            if (cboIdCliente.SelectedValue == null) { Aviso("Seleccione: Cliente (dueño).", cboIdCliente); return false; }

            o = new entVehiculo();
            o.idVehiculo = string.IsNullOrWhiteSpace(txtIdVehiculo.Text) ? 0 : int.Parse(txtIdVehiculo.Text);
            o.placa = txtPlaca.Text.Trim();
            o.marca = txtMarca.Text.Trim();
            o.modelo = txtModelo.Text.Trim();
            o.color = txtColor.Text.Trim();
            o.anio = v_anio;
            o.tipoVehiculo = cboTipoVehiculo.SelectedItem.ToString();
            o.idCliente = Convert.ToInt32(cboIdCliente.SelectedValue);
            o.estVehiculo = chkEstadoVehiculo.Checked;
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            entVehiculo o;
            if (!TryObtener(out o)) return;
            try
            {
                bool ok = esNuevo ? logVehiculo.Instancia.InsertaVehiculo(o) : logVehiculo.Instancia.EditaVehiculo(o);
                if (ok)
                    MessageBox.Show("Registro guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No se pudo guardar el registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE") || ex.Message.Contains("duplicate"))
                    MessageBox.Show("Ya existe un vehículo con esa placa.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpDatos.Enabled = false;
            ActualizarBotones(false);
            listarVehiculo();
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVehiculo.Text))
            {
                MessageBox.Show("Seleccione un registro de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("¿Desea deshabilitar este vehículo?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                entVehiculo o = new entVehiculo();
                o.idVehiculo = int.Parse(txtIdVehiculo.Text);
                bool ok = logVehiculo.Instancia.DeshabilitarVehiculo(o);
                MessageBox.Show(ok ? "Vehículo deshabilitado." : "No se pudo deshabilitar el registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpDatos.Enabled = false;
            listarVehiculo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

     
}
