using Cap_Datos;
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
    public partial class VentaCliente : Form
    {
        public D_AtributosClientes ClienteSeleccionado { get; set; }
        private D_Ventas datosClientes = new D_Ventas();
        public VentaCliente()
        {
            InitializeComponent();
            dataGridView1.DataSource = datosClientes.ObtenerClientes();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ClienteSeleccionado = new D_AtributosClientes()
                {
                    IdCliente = Convert.ToInt32(row.Cells["idcliente"].Value),
                    Nombre1 = row.Cells["Nombre"].Value.ToString(),
                    
                };

                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
