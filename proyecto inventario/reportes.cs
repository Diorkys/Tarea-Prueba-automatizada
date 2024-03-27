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
using System.Windows.Forms.DataVisualization.Charting;

namespace proyecto_inventario
{
    public partial class reportes : Form
    {
        public reportes()
        {
            InitializeComponent();

            D_Productos Acceso = new D_Productos();
            DataTable obtener = Acceso.ObtenerProductos();

            // Asignar el DataTable al DataSource del DataGridView
            dataGridView1.DataSource = obtener;
        }


       

        private void reportes_Load(object sender, EventArgs e)
        {
            D_Ventas dataAccess = new D_Ventas();
            DataTable dataTable = dataAccess.ObtenerProductosMasVendidos();

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Title = "Productos";
            chart1.ChartAreas[0].AxisY.Title = "Cantidad Vendida";

            Series series = chart1.Series.Add("Ventas");
            series.ChartType = SeriesChartType.Pie; // Cambiar a Pie

            foreach (DataRow row in dataTable.Rows)
            {
                series.Points.AddXY(row["Producto"].ToString(), row["CantidadVendida"]);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
