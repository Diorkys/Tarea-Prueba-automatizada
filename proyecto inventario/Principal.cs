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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            clientes formClientes = new clientes();

            // Mostrar el formulario
            formClientes.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            productos formProductos = new productos();

            // Mostrar el formulario de productos
            formProductos.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ventas ventas = new ventas();

            // Mostrar el formulario de productos
            ventas.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (Form1.area == "A0001")
            {
                btnProductos.Enabled = true;
                btnProveedores.Enabled = true;
                btnEmpleados.Enabled = true;
                btnClientes.Enabled = true;
                btnVentas.Enabled = true;
                btnReportes.Enabled = true;
                btnCerrar.Enabled = true;

            }

            else if (Form1.area == "A0002")
            {
                btnProductos.Enabled = true;
                btnProveedores.Enabled = false;
                btnEmpleados.Enabled = false;
                btnClientes.Enabled = false;
                btnVentas.Enabled = true;
                btnReportes.Enabled = true;
                btnCerrar.Enabled = true;
            }

            else 
            {

                MessageBox.Show("¡USUARIO/CONTRASEÑA INCORRECTOS!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            proveedores formProveedores = new proveedores();

            // Mostrar el formulario de productos
            formProveedores.ShowDialog();
        }
    }
}
