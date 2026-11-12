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
            // Actualizado y sincronizado por Ever Fernandez
        }

        // Método para cargar y listar los materiales en el DataGridView
        private void ListarMateriales()
        {
            try
            {
                // Usamos "ListarMaterial" en singular tal como está en logMaterial
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón Nuevo
        }

        private void dgvMateriales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}