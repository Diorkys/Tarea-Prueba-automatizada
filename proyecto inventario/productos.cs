using Cap_Datos;
using Cap_Entidades;
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
    public partial class productos : Form
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public D_Productos datosProductos = new D_Productos();
        
        public productos()
        {
            InitializeComponent();
            dgvProductos.DataSource = ObtenerDatosProductos();
        }

        private void LimpiarTextBox()
        {
            txtNombre.Text = "NOMBRE";
            txtCantidad.Text = "CANTIDAD";
            txtDescripcion.Text = "DESCRIPCION";
            txtPrecioCompra.Text = "PRECIO DE COMPRA";
            txtPrecioVenta.Text = "PRECIO DE VENTA";
            txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd"); // Formato de fecha
            txtProveedor.Text = "PROVEEDOR";
            txtEstado.Text = "ESTADO";
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                E_AtributosProductos producto = new E_AtributosProductos
                {
                    Id = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Cantidad = Convert.ToInt32(txtCantidad.Text),
                    Descripcion = txtDescripcion.Text,
                    PrecioCompra = Convert.ToInt32(txtPrecioCompra.Text),
                    PrecioVenta = Convert.ToInt32(txtPrecioVenta.Text),
                    Fecha = txtFecha.Value, // Obtener la fecha del DateTimePicker
                    IdProveedor = Convert.ToInt32(txtProveedor.Text),
                    Estado = 1 // Puedes establecer el estado según tus necesidades
                };

                datosProductos.Insertar(producto);

                MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarTextBox();
                dgvProductos.DataSource = ObtenerDatosProductos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];

                // Llenar los TextBox con los valores de la fila seleccionada
                txtId.Text = row.Cells["idProducto"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtCantidad.Text = row.Cells["cantidad"].Value.ToString();
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();
                txtPrecioCompra.Text = row.Cells["Precio_de_compra"].Value.ToString();
                txtPrecioVenta.Text = row.Cells["Precio_de_venta"].Value.ToString();
                txtFecha.Text = row.Cells["Fecha"].Value.ToString();
                txtProveedor.Text = row.Cells["idproveedor"].Value.ToString();
                txtEstado.Text = row.Cells["estado"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                E_AtributosProductos producto = new E_AtributosProductos();
                producto.Id = int.Parse(txtId.Text);
                producto.Nombre = txtNombre.Text;
                producto.Cantidad = int.Parse(txtCantidad.Text);
                producto.Descripcion = txtDescripcion.Text;
                producto.PrecioCompra = int.Parse(txtPrecioCompra.Text);
                producto.PrecioVenta = int.Parse(txtPrecioVenta.Text);
                producto.Fecha = DateTime.Parse(txtFecha.Text);
                producto.IdProveedor = int.Parse(txtProveedor.Text);
                producto.Estado = short.Parse(txtEstado.Text);

                D_Productos datosProductos = new D_Productos();
                datosProductos.ActualizarProducto(producto);

                MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los TextBox después de la actualización
                LimpiarTextBox();
                dgvProductos.DataSource = ObtenerDatosProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = int.Parse(txtId.Text);

                D_Productos datosProductos = new D_Productos();
                datosProductos.EliminarProducto(idProducto);

                MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los TextBox después de la eliminación
                LimpiarTextBox();
                dgvProductos.DataSource = ObtenerDatosProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerDatosProductos()
        {
            D_Productos datosProductos = new D_Productos();
            return datosProductos.ObtenerTodosProductos(); // Asegúrate de tener este método en tu capa de datos
        }


        public void ActualizarTextBoxes(string nombreProducto, int idProveedor)
        {
            txtNombre.Text = nombreProducto;
            txtProveedor.Text = idProveedor.ToString();
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            NombreProductosProveedor formSeleccion = new NombreProductosProveedor();
            formSeleccion.Owner = this; // Establecer el formulario principal como propietario
            formSeleccion.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBuscar.Text.Trim();

            // Llamar al método de búsqueda en la capa de datos
            D_Productos dProductos = new D_Productos();
            DataTable resultados = dProductos.BuscarProductos(terminoBusqueda);

            // Enlazar los resultados al DataGridView
            dgvProductos.DataSource = resultados;
        }
    }
}
