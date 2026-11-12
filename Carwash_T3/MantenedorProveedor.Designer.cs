using CapaIdentidad;
using CapaLogica;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carwash_T3
{
    partial class MantenedorProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {            this.grpDatos = new System.Windows.Forms.GroupBox();
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
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            this.SuspendLayout();
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
            this.grpDatos.Location = new System.Drawing.Point(13, 201);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(771, 135);
            this.grpDatos.TabIndex = 1;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos de Proveedor";
            this.grpDatos.Enter += new System.EventHandler(this.grpDatos_Enter);
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
            this.txtIdProveedor.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(15, 342);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(91, 24);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(113, 343);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 22);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(208, 342);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Location = new System.Drawing.Point(307, 342);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(85, 23);
            this.btnDeshabilitar.TabIndex = 5;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(400, 342);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(695, 339);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(89, 27);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Location = new System.Drawing.Point(13, 12);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.Size = new System.Drawing.Size(771, 183);
            this.dgvProveedor.TabIndex = 0;
            // 
            // MantenedorProveedor
            // 
            this.ClientSize = new System.Drawing.Size(796, 381);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.dgvProveedor);
            this.Name = "MantenedorProveedor";
            this.Load += new System.EventHandler(this.MantenedorProveedor_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            this.ResumeLayout(false);

}
        #endregion
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label Código;
        private System.Windows.Forms.TextBox txtIdProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label RUC;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtRuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.CheckBox chkEstadoProveedor;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgvProveedor;

        private bool esNuevo = false;

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