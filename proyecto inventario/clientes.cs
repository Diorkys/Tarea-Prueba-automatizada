using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Cap_Datos;


namespace proyecto_inventario
{
    public partial class clientes : Form
    {
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        private D_Clientes datosClientes = new D_Clientes();


        public clientes()
        {
            
            InitializeComponent();

        }

        public DataTable llenar_grid()
        {
           
            DataTable dt = new DataTable();
            string consulta = "select * from clientes";
            SqlCommand cmd = new SqlCommand(consulta, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
            
            
        
        }

        public DataTable ObtenerTodosClientes()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = llenar_grid();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los clientes. Detalles: {ex.ToString()}", ex);
            }

            return dt;
        }





        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = llenar_grid(); 

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                D_AtributosClientes cliente = new D_AtributosClientes
                {
                    IdCliente = int.TryParse(txtId.Text, out int id) ? id : 0,
                    Nombre1 = txtNombre.Text,
                    Direccion1 = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Cedula1 = txtCedula.Text,
                    Correo = txtCorreo.Text
                };

                datosClientes.Insertar(cliente);

                MessageBox.Show("Cliente agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                dgvClientes.DataSource = datosClientes.ObtenerTodosClientes();
                LimpiarTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // para asegurarnos de que se haya hecho clic en una fila válida
            {
                DataGridViewRow row = dgvClientes.Rows[e.RowIndex];

                // Llenar los TextBoxes con los valores de la fila seleccionada
                txtId.Text = row.Cells["idcliente"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value.ToString();
                txtCedula.Text = row.Cells["Cedula"].Value.ToString();
                txtCorreo.Text = row.Cells["correo"].Value.ToString();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                D_AtributosClientes cliente = new D_AtributosClientes
                {
                    IdCliente = int.TryParse(txtId.Text, out int id) ? id : 0,
                    Nombre1 = txtNombre.Text,
                    Direccion1 = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Cedula1 = txtCedula.Text,
                    Correo = txtCorreo.Text
                };

                datosClientes.Actualizar(cliente);

                MessageBox.Show("Cliente actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvClientes.DataSource = datosClientes.ObtenerTodosClientes();
                LimpiarTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el idCliente que se va a eliminar
                string idCliente = txtId.Text;

                // Llamar al método de eliminación en la capa de datos
                datosClientes.Eliminar(idCliente);

                MessageBox.Show("Cliente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvClientes.DataSource = datosClientes.ObtenerTodosClientes();
                LimpiarTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarTextBox()
        {

            txtId.Text = "ID";
            txtNombre.Text = "NOMBRE";
            txtDireccion.Text = "DIRECCIÓN";
            txtTelefono.Text = "TELÉFONO";
            txtCedula.Text = "CÉDULA";
            txtCorreo.Text = "CORREO";
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
