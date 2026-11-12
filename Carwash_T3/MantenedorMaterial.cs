using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaIdentidad;

namespace Carwash_T3
{
    public partial class MantenedorMaterial : Form
    {
        public MantenedorMaterial()
        {
            InitializeComponent();
            // Actualizado y sincronizado por Miguel
        }

        // Método para cargar y listar los materiales en el DataGridView
        private void ListarMateriales()
        {
            try
            {
                dgvMateriales.DataSource = logMaterial.Instancia.ListarMaterial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar materiales: " + ex.Message, "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MantenedorMaterial_Load(object sender, EventArgs e)
        {
            // Carga los datos automáticamente al abrir el formulario
            ListarMateriales();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que los campos obligatorios no estén vacíos
                if (string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(txtStock.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Crear la entidad y asignar los valores de las cajas de texto
                entMaterial objMaterial = new entMaterial();
                objMaterial.descripcion = txtDescripcion.Text.Trim();
                objMaterial.stock = decimal.Parse(txtStock.Text.Trim());
                objMaterial.precio = decimal.Parse(txtPrecio.Text.Trim());
                objMaterial.fecRegMaterial = DateTime.Now;
                objMaterial.estMaterial = true; // Activo por defecto

                // 3. Enviar a la capa lógica usando el patrón Singleton
                bool resultado = logMaterial.Instancia.InsertaMaterial(objMaterial);

                if (resultado)
                {
                    MessageBox.Show("Material registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarMateriales(); // Actualiza la tabla automáticamente
                    LimpiarCampos();    // Limpia las cajas de texto
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el material.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en Stock y Precio.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Método auxiliar para limpiar las cajas de texto
        private void LimpiarCampos()
        {
            txtIdMaterial.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtDescripcion.Focus();
        }

        private void dgvMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}