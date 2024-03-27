using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cap_Entidades;

namespace Cap_Datos
{
    public class D_Productos
    {   
        private string connectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);


        public DataTable ObtenerProductos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT nombre, cantidad FROM productos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }



        public int ObtenerIdProducto(string nombreProducto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT idProducto FROM Productos WHERE nombre = @nombreProducto";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombreProducto", nombreProducto);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("Producto no encontrado en la base de datos");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener ID de producto: " + ex.Message);
            }
        }


        public DataTable BuscarProductos(string terminoBusqueda)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_BuscarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TerminoBusqueda", terminoBusqueda);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public void Insertar(E_AtributosProductos obj)
        {
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_InsertarProducto2", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idProducto", obj.Id);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@cantidad", obj.Cantidad);
                cmd.Parameters.AddWithValue("@descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Precio_de_compra", obj.PrecioCompra);
                cmd.Parameters.AddWithValue("@Precio_de_venta", obj.PrecioVenta);
                cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                cmd.Parameters.AddWithValue("@idproveedor", obj.IdProveedor);
                cmd.Parameters.AddWithValue("@estado", obj.Estado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Manejo de errores
            }
            finally
            {
                cn.Close();
            }

        }



        public void ActualizarProducto(E_AtributosProductos producto)
        {
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idProducto", producto.Id);
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@PrecioCompra", producto.PrecioCompra);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Fecha", producto.Fecha);
                cmd.Parameters.AddWithValue("@idProveedor", producto.IdProveedor);
                cmd.Parameters.AddWithValue("@estado", producto.Estado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el producto: {ex.Message}");
            }
            finally
            {
                cn.Close();
            }
        }



        public void EliminarProducto(int idProducto)
        {
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el producto: {ex.Message}");
            }
            finally
            {
                cn.Close();
            }
        }



        public DataTable ObtenerTodosProductos()
        {
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM productos WHERE estado = 1", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los productos: {ex.Message}");
            }
            finally
            {
                cn.Close();
            }
        }


        public DataTable ObtenerNombresProductosProveedores()
        {
            try
            {
                string consulta = "SELECT idProveedor, Nombre, Productos FROM proveedores";
                SqlDataAdapter da = new SqlDataAdapter(consulta, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los nombres de productos: {ex.Message}");
            }
        }
    }
}
