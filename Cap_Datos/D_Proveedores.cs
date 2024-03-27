using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Cap_Entidades;

namespace Cap_Datos
{
    public class D_Proveedores
    {



        private string connectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;



        public DataTable ObtenerProveedores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_ObtenerProveedores", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }



        public void InsertarProveedor(string nombre, string telefono, string productos, string direccion, string correoElectronico)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_InsertarProveedor1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Productos", productos);
                    command.Parameters.AddWithValue("@Direccion", direccion);
                    command.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);

                    command.ExecuteNonQuery();
                }
            }
        }



        public void EliminarProveedor(int idProveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("sp_EliminarProveedor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdProveedor", idProveedor);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar el proveedor: {ex.Message}");
                }
            }
        }



        public void ActualizarProveedor(E_AtributosProveedores proveedor)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_ActualizarProveedor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                    command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                    command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    command.Parameters.AddWithValue("@Productos", proveedor.Productos);
                    command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    command.Parameters.AddWithValue("@CorreoElectronico", proveedor.CorreoElectronico);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
