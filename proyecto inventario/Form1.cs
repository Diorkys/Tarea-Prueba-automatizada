using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cap_Entidades;
using Cap_Negocio;

namespace proyecto_inventario
{
    public partial class Form1 : Form
    {
        E_Users objeuser = new E_Users();
        N_Users objnuser = new N_Users();
        Principal frm1 = new Principal();


        public static string usuario_nombre;
        public static string area;


        void logueo()
        { 
            DataTable dt = new DataTable(); 
            objeuser.usuario = txtUsuario.Text;
            objeuser.pass = txtContrasenia.Text;

            dt = objnuser.N_user(objeuser);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido " + dt.Rows[0][1].ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][1].ToString();
                area = dt.Rows[0][0].ToString();

                frm1.ShowDialog();

                Form1 form1 = new Form1();
                form1.ShowDialog();

                if (form1.DialogResult == DialogResult.OK)
                    Application.Run(new Principal());
                txtUsuario.Clear();
                txtContrasenia.Clear();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            logueo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
