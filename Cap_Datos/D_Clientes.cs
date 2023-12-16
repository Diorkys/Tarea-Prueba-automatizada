using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cap_Entidades;

namespace Cap_Datos
{
    public class D_Clientes
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;



        public int ObtenerIdCliente(string nombreCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT idcliente FROM clientes WHERE Nombre = @nombreCliente";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombreCliente", nombreCliente);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            // Manejar el caso en que no se encuentre el cliente
                            throw new Exception("Cliente no encontrado");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener ID de cliente: " + ex.Message);
            }
        }
    

    



    public void Insertar(D_AtributosClientes cliente)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO clientes (Nombre, Direccion, telefono, Cedula, correo) VALUES (@Nombre, @Direccion, @telefono, @Cedula, @correo)", cn))
                    {
                        cmd.Parameters.AddWithValue("@idcliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre1);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion1);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula1);
                        cmd.Parameters.AddWithValue("@correo", cliente.Correo);

                        cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al insertar el cliente en la base de datos. Detalles: {ex.ToString()}", ex);
                }

            }

        }

        public void Actualizar(D_AtributosClientes cliente)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE clientes SET Nombre = @Nombre, Direccion = @Direccion, telefono = @telefono, Cedula = @Cedula, correo = @correo WHERE idcliente = @idcliente", cn))
                    {
                        cmd.Parameters.AddWithValue("@idcliente", cliente.IdCliente);
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre1);
                        cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion1);
                        cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula1);
                        cmd.Parameters.AddWithValue("@correo", cliente.Correo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el cliente en la base de datos. Detalles: {ex.ToString()}", ex);
            }
        }


        public void Eliminar(string idCliente)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("DELETE FROM clientes WHERE idcliente = @idcliente", cn))
                    {
                        cmd.Parameters.AddWithValue("@idcliente", idCliente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el cliente en la base de datos. Detalles: {ex.ToString()}", ex);
            }
        }



        public DataTable ObtenerTodosClientes()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM clientes", cn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }

    }
}


 


   


