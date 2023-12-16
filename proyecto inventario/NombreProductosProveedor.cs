using Cap_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace proyecto_inventario
{
    public partial class NombreProductosProveedor : Form
    {

        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
       

        
        public NombreProductosProveedor()
        {
            InitializeComponent();
            D_Productos datosProductos = new D_Productos();
            dataGridView1.DataSource = datosProductos.ObtenerNombresProductosProveedores();




        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NombreProductosProveedor_Load(object sender, EventArgs e)
        {
            D_Productos datosProductos = new D_Productos();
            dataGridView1.DataSource = datosProductos.ObtenerNombresProductosProveedores();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtener el nombre del producto y el ID del proveedor
                string nombreProducto = row.Cells["Productos"].Value.ToString();
                int idProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value);

                // Enviar la información de vuelta al formulario principal
                ((productos)this.Owner).ActualizarTextBoxes(nombreProducto, idProveedor);

                // Cerrar el formulario de selección de productos
                this.Close();
            }
        }
    }
}
