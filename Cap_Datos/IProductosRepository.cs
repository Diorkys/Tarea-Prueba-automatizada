using Cap_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Datos
{
    public interface IProductosRepository
    {
        void Insertar(E_AtributosProductos producto);
        void Actualizar(E_AtributosProductos producto);
        void Eliminar(int idProducto);
        DataTable BuscarProductos(string terminoBusqueda);
    }
}