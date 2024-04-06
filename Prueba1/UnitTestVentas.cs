using Cap_Datos;
using Cap_Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Prueba1
{
    [TestClass]
    public class UnitTestVentas
    {
        [TestMethod]
        public void TestInsertarVenta()
        {
            // Arrange
            var mockRepository = new Mock<IVentasRepository>();
            var venta = new E_AtributosVenta
            {
                IdVenta = 1,
                IdCliente = 1,
                IdProducto = 1,
                Cantidad = 10,
                Fecha = DateTime.Now,
                TotalVenta = 1500,
                Precio_Venta = 150
            };

            // Act
            mockRepository.Object.InsertarVenta(venta.IdCliente, venta.IdProducto, venta.Cantidad, venta.Fecha, venta.TotalVenta, venta.Precio_Venta);

            // Assert
            // Agrega las verificaciones según lo que esperas que haga el método InsertarVenta
        }
    }
}
