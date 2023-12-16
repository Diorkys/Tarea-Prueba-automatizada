using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Entidades
{
    public class E_AtributosProductos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public DateTime Fecha { get; set; }
        public int IdProveedor { get; set; }
        public int Estado { get; set; }
    }
}
