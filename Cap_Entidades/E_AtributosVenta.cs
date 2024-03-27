using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Entidades
{
    public class E_AtributosVenta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalVenta { get; set; }

        public int Precio_Venta { get; set; }
    }
}
