using Cap_Datos;
using Cap_Entidades;
using Cap_Negocio;
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
    public partial class ventas : Form
    {
        private List<E_AtributosProductos> productosSeleccionados = new List<E_AtributosProductos>();
        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        private D_Ventas dVentas = new D_Ventas();
        private DataGridView GridView = new DataGridView();

        public ventas()
        {
            InitializeComponent();


        }

        // Método para actualizar TextBox con datos del producto

        private void ventas_Load(object sender, EventArgs e)
        {

        }

        private void txtCliente_Click(object sender, EventArgs e)
        {
            VentaCliente formSeleccion = new VentaCliente
            {
                Owner = this // Establecer el formulario principal como propietario
            };

            // Manejar el evento después de cerrar el formulario de selección
            formSeleccion.FormClosed += (s, args) =>
            {
                // Verificar si la propiedad ClienteSeleccionado se estableció en el formulario de selección
                if (formSeleccion.ClienteSeleccionado != null)
                {
                    // Llenar el TextBox con el nombre del cliente seleccionado
                    txtCliente.Text = formSeleccion.ClienteSeleccionado.Nombre1;
                }
            };

            formSeleccion.ShowDialog();
        }

        private void txtProducto_Click(object sender, EventArgs e)
        {
            VentaProducto formSeleccionProducto = new VentaProducto();
            formSeleccionProducto.Owner = this; // Establecer el formulario principal como propietario

            // Manejar el evento después de cerrar el formulario de selección de productos
            formSeleccionProducto.FormClosed += (s, args) =>
            {
                // Verificar si la propiedad ProductoSeleccionado se estableció en el formulario de selección de productos
                if (formSeleccionProducto.ProductoSeleccionado != null)
                {
                    // Llenar el TextBox con el nombre del producto seleccionado
                    txtProducto.Text = formSeleccionProducto.ProductoSeleccionado.Nombre;

                    // Convertir el precio de venta a string antes de asignarlo al TextBox
                    txtPrecioVenta.Text = formSeleccionProducto.ProductoSeleccionado.PrecioVenta.ToString();
                }
            };

            formSeleccionProducto.ShowDialog();


        }

        private void btnAgregar_Click(object sender, EventArgs e)

        {
            

            // Agregar la fila al DataGridView
            dataGridView1.Rows.Add( txtCliente.Text, txtProducto.Text, txtCantidad.Text, txtFecha.Text, txtPrecioVenta.Text, txtTotalVenta.Text);

        }



        private void txtTotalVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            // Verificar que la cantidad sea un valor numérico
            if (int.TryParse(txtCantidad.Text, out int cantidad))
            {
                // Calcular el total (cantidad * precio de venta)
                int total = cantidad * int.Parse(txtPrecioVenta.Text);

                // Mostrar el total en el TextBox de total
                txtTotalVenta.Text = total.ToString();
            }
        }
        private int ObtenerIdCliente()
        {
            if (int.TryParse(txtCliente.Text, out int idCliente))
            {
                return idCliente;
            }
            return 0; // Retorna 0 si no se pudo convertir
        }

        private DateTime ObtenerFecha()
        {
            if (!string.IsNullOrEmpty(txtFecha.Text))
            {
                // Intenta convertir la cadena a DateTime
                if (DateTime.TryParse(txtFecha.Text, out DateTime fecha))
                {
                    return fecha;
                }
                else
                {
                    // Manejo de error si la conversión falla
                    throw new Exception("Formato de fecha inválido");
                }
            }
            return DateTime.Now; // Si el campo de texto está vacío, devuelve la fecha actual
        }

        // Método para mostrar mensajes en la página

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                D_Clientes dClientes = new D_Clientes();
                D_Productos dProductos = new D_Productos();
                D_Ventas dVentas = new D_Ventas();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Obtener los datos directamente de las celdas del DataGridView
                    string nombreCliente = row.Cells["Column2"].Value?.ToString();
                    string nombreProducto = row.Cells["Column3"].Value?.ToString();

                    if (!string.IsNullOrEmpty(nombreCliente) && !string.IsNullOrEmpty(nombreProducto))
                    {
                        // Obtener IDs de cliente y producto usando las capas de datos
                        int idCliente = dClientes.ObtenerIdCliente(nombreCliente);
                        int idProducto = dProductos.ObtenerIdProducto(nombreProducto);

                        // Obtener otros datos de la venta desde el DataGridView
                        int cantidad = Convert.ToInt32(row.Cells["Column4"].Value);
                        DateTime fecha = Convert.ToDateTime(row.Cells["Column5"].Value);
                        int totalVenta = Convert.ToInt32(row.Cells["Column6"].Value);
                        int precioDeVenta = Convert.ToInt32(row.Cells["Column7"].Value);

                        // Insertar la venta en la base de datos
                        dVentas.InsertarVenta(idCliente, idProducto, cantidad, fecha, totalVenta, precioDeVenta);
                    }
                    else
                    {
                        
                    }
                }

                // Limpiar el DataGridView después de la venta
                dataGridView1.Rows.Clear();

                // Mostrar mensaje de éxito
                MessageBox.Show("Ventas realizadas con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error en caso de excepción
                MessageBox.Show("Error al realizar las ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
    }
}

