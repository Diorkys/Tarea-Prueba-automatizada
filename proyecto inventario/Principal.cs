using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
            // Cerrar el formulario principal
            this.Hide();

            // Abrir el formulario de Productos
            clientes formCliente = new clientes();
            formCliente.ShowDialog();

            // Mostrar nuevamente el formulario principal al cerrar el formulario de cliente
            this.Show();
        }



        private void btnProductos_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide(); 

            // Abrir el formulario de Productos
            productos formProductos = new productos();
            formProductos.ShowDialog();

            // Mostrar nuevamente el formulario principal al cerrar el formulario de productos
            this.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide();

            // Abrir el formulario de Productos
            ventas formVentas = new ventas();
            formVentas.ShowDialog();

            this.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (Form1.area == "A0001")
            {
                btnProductos.Enabled = true;
                btnProveedores.Enabled = true;
                btnClientes.Enabled = true;
                btnVentas.Enabled = true;
                btnReportes.Enabled = true;
                btnCerrar.Enabled = true;

            }

            else if (Form1.area == "A0002")
            {
                btnProductos.Enabled = true;
                btnProveedores.Enabled = false;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide(); 
<<<<<<< HEAD

            // Abrir el formulario de Productos
            proveedores formProveedor = new proveedores();
            formProveedor.ShowDialog();

            // Mostrar nuevamente el formulario principal al cerrar el formulario de proveedores
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide();

            // Abrir el formulario de Productos
            reportes formVentas = new reportes();
            formVentas.ShowDialog();

            this.Show();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formVentas = new Form1();
            formVentas.ShowDialog();

            this.Show();

=======

            // Abrir el formulario de Productos
            proveedores formProveedor = new proveedores();
            formProveedor.ShowDialog();

            // Mostrar nuevamente el formulario principal al cerrar el formulario de proveedores
            this.Show();
>>>>>>> 027efc638981e1ec8e18dc59b93610a278334976
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario principal
            this.Hide();

            // Abrir el formulario de Productos
            reportes formVentas = new reportes();
            formVentas.ShowDialog();

            this.Show();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 formVentas = new Form1();
            formVentas.ShowDialog();

            this.Show();

        }
<<<<<<< HEAD

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
=======
>>>>>>> e1c5fc09e954115ab6e013791bc8701da9dd07b1
    }
}
