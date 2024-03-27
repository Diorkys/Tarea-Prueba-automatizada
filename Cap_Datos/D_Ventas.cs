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
    public class D_Ventas
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;


        public DataTable ObtenerProductosMasVendidos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TOP 5 P.nombre AS Producto, SUM(V.cantidad) AS CantidadVendida " +
                               "FROM Ventas V " +
                               "JOIN productos P ON V.idproducto = P.idproducto " +
                               "GROUP BY P.nombre " +
                               "ORDER BY CantidadVendida DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public void InsertarVenta(int idCliente, int idProducto, int cantidad, DateTime fecha, int totalVenta, int precioDeVenta)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Ventas (idcliente, idproducto, cantidad, fecha, totalventa, precio_de_venta) " +
                                   "VALUES (@idcliente, @idproducto, @cantidad, @fecha, @totalventa, @precio_de_venta)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idcliente", idCliente);
                        cmd.Parameters.AddWithValue("@idproducto", idProducto);
                        cmd.Parameters.AddWithValue("@cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@fecha", fecha);
                        cmd.Parameters.AddWithValue("@totalventa", totalVenta);
                        cmd.Parameters.AddWithValue("@precio_de_venta", precioDeVenta);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar venta: " + ex.Message);
            }
        }

        public DataTable ObtenerClientes()
        {
            DataTable dt = new DataTable();

            string query = "SELECT idcliente, Nombre, Cedula FROM clientes";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cn.Open();
                        da.Fill(dt);
                    }
                }
            }

            return dt;

        }

        public DataTable ObtenerProductos()
        {
            DataTable dt = new DataTable();
            string query = "SELECT idProducto, nombre, Precio_de_venta FROM productos";

            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        cn.Open();
                        da.Fill(dt);
                    }
                }
            }

            return dt;

        }



        
    }
}
