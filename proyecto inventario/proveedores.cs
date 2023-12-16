using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cap_Datos;

namespace proyecto_inventario
{
    public partial class proveedores : Form
    {
        public proveedores()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CargarProveedores()
        {
            D_Proveedores dProveedores = new D_Proveedores();
            DataTable dataTable = dProveedores.ObtenerProveedores();

            // Enlazar la tabla de proveedores al DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener datos del formulario o de donde sea necesario
            string nombre = txtNombre.Text;
            string telefono = txtTelefono.Text;
            string productos = txtProductos.Text;
            string direccion = txtDireccion.Text;
            string correoElectronico = txtCorreo.Text;

            // Llamar al método de inserción en la capa de datos
            D_Proveedores dProveedores = new D_Proveedores();
            dProveedores.InsertarProveedor(nombre, telefono, productos, direccion, correoElectronico);

            // Puedes agregar un mensaje de éxito o cualquier lógica adicional aquí
            MessageBox.Show("Proveedor insertado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Llenar los TextBox con los datos del proveedor seleccionado
                txtId.Text = row.Cells["idProveedor"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
                txtProductos.Text = row.Cells["Productos"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtCorreo.Text = row.Cells["Correo_electronico"].Value.ToString();
            }
        }

        private void proveedores_Load(object sender, EventArgs e)
        {
           CargarProveedores();
        }
    }
}
