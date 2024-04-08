using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Datos
{
    public interface IVentasRepository
    {

        void InsertarVenta(int idCliente, int idProducto, int cantidad, DateTime fecha, int totalVenta, int precioDeVenta);
    }
}