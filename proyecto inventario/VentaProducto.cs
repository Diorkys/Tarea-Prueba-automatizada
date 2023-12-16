using Cap_Datos;
using Cap_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_inventario
{
    public partial class VentaProducto : Form
    {
        public E_AtributosProductos ProductoSeleccionado { get; set; }

        private D_Ventas datosProductos = new D_Ventas();
        public VentaProducto()
        {
            InitializeComponent();
            dataGridView1.DataSource = datosProductos.ObtenerProductos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ProductoSeleccionado = new E_AtributosProductos()
                {
                    Id = Convert.ToInt32(row.Cells["idProducto"].Value),
                    Nombre = row.Cells["nombre"].Value.ToString(),
                    PrecioVenta = Convert.ToInt32(row.Cells["Precio_de_venta"].Value),
                    
                };

                this.Close();
            }
        }
    }
}

