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
        private Button btnCerrar;
        private Button btnCancelar;
        private Button btnDeshabilitar;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnNuevo;
        private GroupBox grpDatos;
        private CheckBox chkEstadoProveedor;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtRazonSocial;
        private TextBox txtDireccion;
        private TextBox txtRuc;
        private TextBox txtIdProveedor;
        private Label label1;
        private Label RUC;
        private Label Código;
        private DataGridView dgvProveedor;
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

        private void InitializeComponent()
        {
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.chkEstadoProveedor = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtRuc = new System.Windows.Forms.TextBox();
            this.txtIdProveedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RUC = new System.Windows.Forms.Label();
            this.Código = new System.Windows.Forms.Label();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(709, 369);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(89, 27);
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(414, 372);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 23);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Location = new System.Drawing.Point(321, 372);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(85, 23);
            this.btnDeshabilitar.TabIndex = 21;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(222, 372);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(127, 373);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 22);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(29, 372);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(91, 24);
            this.btnNuevo.TabIndex = 18;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.chkEstadoProveedor);
            this.grpDatos.Controls.Add(this.label4);
            this.grpDatos.Controls.Add(this.label3);
            this.grpDatos.Controls.Add(this.label2);
            this.grpDatos.Controls.Add(this.txtEmail);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.txtRazonSocial);
            this.grpDatos.Controls.Add(this.txtDireccion);
            this.grpDatos.Controls.Add(this.txtRuc);
            this.grpDatos.Controls.Add(this.txtIdProveedor);
            this.grpDatos.Controls.Add(this.label1);
            this.grpDatos.Controls.Add(this.RUC);
            this.grpDatos.Controls.Add(this.Código);
            this.grpDatos.Location = new System.Drawing.Point(27, 231);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(771, 135);
            this.grpDatos.TabIndex = 17;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de Proveedor";
            // 
            // chkEstadoProveedor
            // 
            this.chkEstadoProveedor.AutoSize = true;
            this.chkEstadoProveedor.Location = new System.Drawing.Point(134, 112);
            this.chkEstadoProveedor.Name = "chkEstadoProveedor";
            this.chkEstadoProveedor.Size = new System.Drawing.Size(56, 17);
            this.chkEstadoProveedor.TabIndex = 2;
            this.chkEstadoProveedor.Text = "Activo";
            this.chkEstadoProveedor.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Correo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Teléfono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Razón Social";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(504, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(209, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(504, 51);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(210, 20);
            this.txtTelefono.TabIndex = 7;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(503, 24);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(211, 20);
            this.txtRazonSocial.TabIndex = 6;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(134, 86);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 20);
            this.txtDireccion.TabIndex = 5;
            // 
            // txtRuc
            // 
            this.txtRuc.Location = new System.Drawing.Point(122, 51);
            this.txtRuc.Name = "txtRuc";
            this.txtRuc.Size = new System.Drawing.Size(212, 20);
            this.txtRuc.TabIndex = 4;
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Location = new System.Drawing.Point(122, 24);
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.Size = new System.Drawing.Size(212, 20);
            this.txtIdProveedor.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dirección";
            // 
            // RUC
            // 
            this.RUC.AutoSize = true;
            this.RUC.Location = new System.Drawing.Point(76, 58);
            this.RUC.Name = "RUC";
            this.RUC.Size = new System.Drawing.Size(30, 13);
            this.RUC.TabIndex = 1;
            this.RUC.Text = "RUC";
            // 
            // Código
            // 
            this.Código.AutoSize = true;
            this.Código.Location = new System.Drawing.Point(76, 27);
            this.Código.Name = "Código";
            this.Código.Size = new System.Drawing.Size(40, 13);
            this.Código.TabIndex = 0;
            this.Código.Text = "Código";
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Location = new System.Drawing.Point(27, 42);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.Size = new System.Drawing.Size(771, 183);
            this.dgvProveedor.TabIndex = 16;
            // 
            // MantenedorProveedor
            // 
            this.ClientSize = new System.Drawing.Size(825, 438);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.dgvProveedor);
            this.Name = "MantenedorProveedor";
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

