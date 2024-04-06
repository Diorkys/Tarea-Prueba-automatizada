using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cap_Datos;
using Cap_Entidades;
using Moq;
using System;
using System.Data;

namespace MiProyectoPruebas
{
    [TestClass]
    public class ProductoTests
    {
        [TestMethod]
        public void TestInsertarProducto()
        {
            // Arrange
            var mockRepository = new Mock<IProductosRepository>();
            var producto = new E_AtributosProductos
            {
                Id = 1,
                Nombre = "Producto de Prueba",
                Cantidad = 10,
                Descripcion = "Producto de prueba para pruebas unitarias",
                PrecioCompra = 100,
                PrecioVenta = 150,
                Fecha = DateTime.Now,
                IdProveedor = 1,
                Estado = 1
            };

            // Act
            mockRepository.Object.Insertar(producto);

            // Assert
            mockRepository.Verify(rp => rp.Insertar(producto), Times.Once);
        }

        [TestMethod]
        public void TestActualizarProducto()
        {
            // Arrange
            var mockRepository = new Mock<IProductosRepository>();
            var producto = new E_AtributosProductos
            {
                Id = 1,
                Nombre = "Producto Actualizado",
                Cantidad = 20,
                Descripcion = "Producto actualizado para pruebas unitarias",
                PrecioCompra = 120,
                PrecioVenta = 180,
                Fecha = DateTime.Now,
                IdProveedor = 2,
                Estado = 1
            };

            // Act
            mockRepository.Object.Actualizar(producto);

            // Assert
            mockRepository.Verify(rp => rp.Actualizar(producto), Times.Once);
        }

        [TestMethod]
        public void TestEliminarProducto()
        {
            // Arrange
            var mockRepository = new Mock<IProductosRepository>();
            int idProductoAEliminar = 1;

            // Act
            mockRepository.Object.Eliminar(idProductoAEliminar);

            // Assert
            mockRepository.Verify(rp => rp.Eliminar(idProductoAEliminar), Times.Once);
        }

        [TestMethod]
        public void TestBuscarProductos()
        {
            // Arrange
            var mockRepository = new Mock<IProductosRepository>();
            string terminoBusqueda = "producto";

            // Act
            mockRepository.Object.BuscarProductos(terminoBusqueda);

            // Assert
            mockRepository.Verify(rp => rp.BuscarProductos(terminoBusqueda), Times.Once);
        }
    }
}
