<<<<<<< HEAD

CREATE DATABASE [inventory]

USE [inventory]
GO

CREATE TABLE [dbo].[clientes](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](25) NOT NULL,
	[Cedula] [varchar](30) NOT NULL,
	[correo] [varchar](150) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

select * from clientes
CREATE PROCEDURE Insertar_Clientes
    @idcliente INT,
    @Nombre VARCHAR(50),
    @Direccion VARCHAR(150),
    @telefono VARCHAR(25),
    @Cedula int,
    @correo VARCHAR(150)
AS
BEGIN
    INSERT INTO clientes (Nombre, Direccion, telefono, Cedula, correo)
    VALUES (@Nombre, @Direccion, @telefono, @Cedula, @correo);
END;
GO
EXEC SP_Insertar_Clientes
   @idcliente = '20',
   @Nombre = 'Valor2',
   @Direccion = 'Valor3',
   @telefono = 'Valor4',
   @Cedula = 'Valor5',
   @correo = 'Valor6';

INSERT INTO [dbo].[clientes] ([Nombre], [Direccion], [telefono], [Cedula], [correo])
VALUES
    ('Juan Pérez', '123 Calle Principal', '555-1234', '12345678901', 'juan.perez@example.com'),
    ('María Rodríguez', '456 Avenida Central', '555-5678', '98765432102', 'maria.rodriguez@example.com'),
    ('Carlos Gómez', '789 Calle Secundaria', '555-9876', '11223344503', 'carlos.gomez@example.com'),
    ('Ana Sánchez', '321 Calle Norte', '555-5432', '99887766504', 'ana.sanchez@example.com'),
    ('Miguel Martínez', '654 Calle Sur', '555-8765', '66778899005', 'miguel.martinez@example.com'),
    ('Isabel López', '987 Calle Este', '555-2345', '44556677806', 'isabel.lopez@example.com'),
    ('Roberto Díaz', '210 Calle Oeste', '555-7890', '11223344507', 'roberto.diaz@example.com'),
    ('Laura Torres', '543 Avenida Principal', '555-9012', '99887766508', 'laura.torres@example.com'),
    ('Javier Ramírez', '876 Avenida Secundaria', '555-4567', '66778899009', 'javier.ramirez@example.com'),
    ('Patricia Herrera', '109 Avenida Norte', '555-8901', '445566778010', 'patricia.herrera@example.com'),
    ('Alejandro Castro', '432 Avenida Sur', '555-3456', '112233445011', 'alejandro.castro@example.com'),
    ('Sofía Vargas', '765 Avenida Este', '555-6789', '998877665012', 'sofia.vargas@example.com'),
    ('Daniel Mendoza', '198 Avenida Oeste', '555-9012', '667788990013', 'daniel.mendoza@example.com'),
    ('Elena Flores', '876 Calle Principal', '555-4567', '445566778014', 'elena.flores@example.com'),
    ('Luis González', '543 Calle Norte', '555-7890', '112233445015', 'luis.gonzalez@example.com');



	ALTER TABLE [dbo].[productos]
ALTER COLUMN nombre VARCHAR(50);

CREATE TABLE [dbo].[empleados](
	[idEmpleados] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
	[Cedula] [int] NOT NULL,
	[edad] [int] NOT NULL,
	[sueldo] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO empleados (nombre, apellido, Cedula, edad, sueldo)
VALUES ('Diorkys', 'Pérez', 123456789, 30, 50000);

-- Insertar el segundo empleado
INSERT INTO empleados (nombre, apellido, Cedula, edad, sueldo)
VALUES ('Dionys', 'Gómez', 987654321, 25, 45000);

drop table entradas
CREATE TABLE [dbo].[entradas](
	[identrada] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[idproducto] [int] NULL,
	[idproveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[identrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[factura](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](30) NOT NULL,
	[NIF] [varchar](30) NOT NULL,
	[Dirección] [varchar](30) NOT NULL,
	[producto] [varchar](30) NOT NULL,
	[cantidad] [int] NOT NULL,
	[descripción] [varchar](30) NOT NULL,
	[Precio] [int] NOT NULL,
	[Descuento] [decimal](18, 0) NULL,
	[IVA] [int] NOT NULL,
	[Fecha] [date] NULL,
	[subtotal] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

select * from productos





ALTER TABLE productos NOCHECK CONSTRAINT ALL;
select * from productos
-- Realiza la inserción

-- Activa la clave foránea nuevamente
ALTER TABLE productos CHECK CONSTRAINT ALL;


CREATE PROCEDURE sp_InsertarProducto2
	@idProducto int,
    @nombre varchar,
    @cantidad int,
    @descripcion varchar(30),
    @Precio_de_compra int,
    @Precio_de_venta int,
    @Fecha date,
    @idproveedor int,
    @estado smallint
AS
    -- Insertar el producto
    INSERT INTO productos (nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado)
    VALUES (@nombre, @cantidad, @descripcion, @Precio_de_compra, @Precio_de_venta, @Fecha, @idproveedor, @estado);


	-- Eliminar el producto
	CREATE PROCEDURE sp_EliminarProducto
    @idProducto int
AS
    UPDATE productos
    SET estado = 0
    WHERE idProducto = @idProducto;




	CREATE PROCEDURE sp_ActualizarProducto
    @idProducto int,
    @nombre varchar(40),
    @cantidad int,
    @descripcion varchar(30),
    @PrecioCompra int,
    @PrecioVenta int,
    @Fecha date,
    @idProveedor int,
    @estado smallint
AS

    UPDATE productos
    SET nombre = @nombre,
        cantidad = @cantidad,
        descripcion = @descripcion,
        Precio_de_compra = @PrecioCompra,
        Precio_de_venta = @PrecioVenta,
        Fecha = @Fecha,
        idproveedor = @idProveedor,
        estado = @estado
    WHERE idProducto = @idProducto;




	EXEC sp_InsertarProducto2
	@idProducto = 12, 
    @nombre = 'Producto de prueba',
    @cantidad = 10,
    @descripcion = 'Descripción de prueba',
    @Precio_de_compra = 100,
    @Precio_de_venta = 150,
    @Fecha = '2023-12-15',
    @idproveedor = 4, -- Asegúrate de que 1 sea un id existente en la tabla proveedores
    @estado = 1;

	select * from productos

	INSERT INTO productos (nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado)
VALUES 
    ('Leche', 100, 'Leche entera', 2, 3, '2023-12-01', 4, 1),
    ('Pan', 150, 'Pan blanco', 1, 2, '2023-12-02', 2, 1),
    ('Arroz', 120, 'Arroz blanco', 3, 5, '2023-12-03', 3, 1),
    ('Pollo', 200, 'Pechuga de pollo', 5, 8, '2023-12-04', 7, 1),
    ('Manzanas', 80, 'Manzanas frescas', 4, 6, '2023-12-05', 2, 1);

CREATE TABLE [dbo].[productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[cantidad] [int] NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
	[Fecha] [date] NULL,
	[codigoqr] [image] NULL,
	[idproveedor] [int] NULL,
	[estado] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[proveedores](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](35) NOT NULL,
	[Telefono] [varchar](30) NOT NULL,
	[Productos] [varchar](35) NOT NULL,
	[Direccion] [varchar](35) NOT NULL,
	[Correo_electronico] [varchar](60) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



use inventory
select * from proveedores
CREATE PROCEDURE sp_InsertarProveedor1

    @Nombre VARCHAR(35),
    @Telefono VARCHAR(30),
    @Productos VARCHAR(35),
    @Direccion VARCHAR(35),
    @CorreoElectronico VARCHAR(60)
AS

    INSERT INTO Proveedores (Nombre, Telefono, Productos, Direccion, Correo_electronico)
    VALUES (@Nombre, @Telefono, @Productos, @Direccion, @CorreoElectronico);




	CREATE PROCEDURE sp_ObtenerProveedores
AS

    SELECT idProveedor, Nombre, Telefono, Productos, Direccion, Correo_electronico
    FROM proveedores;


-- Insertar datos en la tabla proveedores
INSERT INTO proveedores (Nombre, Telefono, Productos, Direccion, Correo_electronico)
VALUES
    ('Distribuidora ABC', '123-456-7890', 'Leche Milex', 'Calle 1, Ciudad A', 'distribuidoraabc@example.com'),
    ('Proveedor XYZ', '987-654-3210', 'Queso Cheddar', 'Avenida 2, Ciudad B', 'proveedorxyz@example.com'),
    ('Comestibles S.A.', '555-555-5555', 'Yogur Natural', 'Calle Principal, Ciudad C', 'comestibles@example.com'),
    ('Productos Deliciosos', '111-222-3333', 'Helado Vainilla', 'Avenida Central, Ciudad D', 'productosdeliciosos@example.com'),
    ('Distribuidora León', '444-555-6666', 'Leche Condensada', 'Calle 3, Ciudad E', 'distribuidoraleon@example.com'),
    ('Proveedores Unidos', '777-888-9999', 'Queso Fresco', 'Avenida 4, Ciudad F', 'proveedoresunidos@example.com'),
    ('Lácteos Express', '123-123-1234', 'Leche Entera', 'Calle 5, Ciudad G', 'lacteosexpress@example.com'),
    ('Productos Sanos', '456-456-4567', 'Yogur de Frutas', 'Avenida 6, Ciudad H', 'productossanos@example.com'),
    ('Distribuidora Global', '789-789-7890', 'Leche Deslactosada', 'Calle 7, Ciudad I', 'distribuidoraglobal@example.com'),
    ('Alimentos Ricos', '111-222-3333', 'Crema de Leche', 'Avenida 8, Ciudad J', 'alimentosricos@example.com'),
    ('Proveeduría Familiar', '444-555-6666', 'Leche de Soja', 'Calle 9, Ciudad K', 'proveeduriafamiliar@example.com'),
    ('Productos Naturales', '777-888-9999', 'Yogur Griego', 'Avenida 10, Ciudad L', 'productosnaturales@example.com'),
    ('Distribuidora Feliz', '123-123-1234', 'Leche sin Lactosa', 'Calle 11, Ciudad M', 'distribuidorafeliz@example.com'),
    ('Delicias Caseras', '456-456-4567', 'Queso Gouda', 'Avenida 12, Ciudad N', 'deliciascaseras@example.com'),
    ('Distribuidora Fresca', '789-789-7890', 'Leche de Almendras', 'Calle 13, Ciudad O', 'distribuidorafresca@example.com');

	ALTER TABLE proveedores
ALTER COLUMN Productos VARCHAR(50);

delete productos
ALTER TABLE productos
ALTER COLUMN nombre int;


ALTER TABLE productos
ADD CONSTRAINT FK_Productos_Proveedores
FOREIGN KEY (idproveedor) REFERENCES proveedores(idProveedor);


CREATE TABLE [dbo].[registro](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[cantidad] [int] NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[usuario](
	id_area varchar (5) primary key,
	id_empleados int,
	nombre varchar (50),
	usuario varchar (20),
	pass varchar (20),
	foreign key (id_empleados) references empleados (idEmpleados)
) 
GO

select * from usuario
use inventory


CREATE PROCEDURE sp_BuscarProductos
    @TerminoBusqueda NVARCHAR(100)
AS

    SELECT idProducto, nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado
    FROM productos
    WHERE nombre LIKE '%' + @TerminoBusqueda + '%'
        OR descripcion LIKE '%' + @TerminoBusqueda + '%';




ALTER TABLE proveedores
ADD CONSTRAINT fk_proveedores_productos
FOREIGN KEY (Productos) REFERENCES productos(idProducto);

select * from usuario

ALTER TABLE proveedores
ALTER COLUMN Productos INT;


ALTER TABLE proveedores
ADD CONSTRAINT fk_proveedores_productos
FOREIGN KEY (Productos) REFERENCES productos(idProducto);


 ALTER TABLE [dbo].[inventory]  WITH CHECK ADD CONSTRAINT [FK_empleado_usuario] FOREIGN KEY(id_empleados)
REFERENCES [dbo].empleados (idEmpleados)

insert into usuario (id_area, id_empleados, nombre, usuario, pass) values ('A0001', 1, 'Diorkys', 'Adm', 'Adm');
insert into usuario (id_area, id_empleados, nombre, usuario, pass) values ('A0002', 2, 'Dionys', 'Dionys02', '12345');

create proc logeo
@usuario varchar (20),
@pass varchar (20)
as
select id_area, id_empleados, nombre, usuario, pass from usuario where usuario=@usuario and pass=@pass
go

CREATE TABLE [dbo].[Ventas](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idproducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fecha] [varchar](10) NULL,
	[totalventa] [decimal](18, 0) NOT NULL,
	[estado] [int] NULL
) ON [PRIMARY]
GO

use inventory
ALTER TABLE Ventas
ALTER COLUMN fecha Datetime;
select * from Ventas
CREATE PROCEDURE sp_InsertarVenta2
@idventas INT,
    @idcliente INT,
    @idproducto INT,
    @cantidad INT,
    @fecha DATETIME,
    @totalventa INT,
    @precio_de_venta INT
AS
    INSERT INTO Ventas (idcliente, idproducto, cantidad, fecha, totalventa, precio_de_venta)
    VALUES (@idcliente, @idproducto, @cantidad, @fecha, @totalventa, @precio_de_venta);


ALTER TABLE [dbo].[Ventas]
ADD [precio_de_venta] [int] NOT NULL;

CREATE TABLE [dbo].[ventas1](
	[idVentas] [int] IDENTITY(1,1) NOT NULL,
	[Descuento] [decimal](18, 0) NULL,
	[IVA] [int] NOT NULL,
	[Fecha] [date] NULL,
	[subtotal] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idVentas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO










SET IDENTITY_INSERT [dbo].[ventas1] OFF
GO
ALTER TABLE [dbo].[productos] ADD  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [FK_entradas_productos] FOREIGN KEY([idproducto])
REFERENCES [dbo].[productos] ([idProducto])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [FK_entradas_productos]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [FK_entradas_proveedores] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedores] ([idProveedor])
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [FK_entradas_proveedores]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_proveedores] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedores] ([idProveedor])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_proveedores]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_clientes] FOREIGN KEY([idcliente])
REFERENCES [dbo].[clientes] ([idcliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_ventas_clientes]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_productos] FOREIGN KEY([idproducto])
REFERENCES [dbo].[productos] ([idProducto])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_ventas_productos]
GO
/****** Object:  StoredProcedure [dbo].[VentaAnularTicket]    Script Date: 21/06/2021 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VentaAnularTicket]
(
	@num_venta int  null
)as
begin 
declare @existe_venta int,
 @registros int, 
 @a int, 
 @codigo_inventario int, 
 @Cantidad_Inventario int,
 @existencia_actual int,
 @nueva_existencia int;

set @existe_venta = (select COUNT(*) from Ventas ve where ve.idventa = @num_venta and ve.estado =1);
if @existe_venta >0 
BEGIN
	create table TMP
	(
		id int identity primary key,
		cod_inventario int,
		cantidad_EnInventario int 
	)
	set @a = 1;
	set @registros =(select COUNT(*) from Ventas v where v.idventa = @num_venta );

	if @registros >0
	begin
		insert into TMP(cod_inventario,cantidad_EnInventario) select dv.idproducto,dv.cantidad from Ventas dv where dv.idventa = @num_venta;
		while @a <= @registros 
		begin
		set @codigo_inventario = (select TMP.cod_inventario from TMP where id = @a);
		set @Cantidad_Inventario = (select TMP.cantidad_EnInventario from TMP where id = @a);
		/*select tmp.cod_inventario, tmp.cantidad_EnInventario into codigo_inventario,Cantidad_Inventario from TMP tmp where id =a; */
		/*select inv.cantidad into  existencia_actual from Inventario inv where idarticulo = @codigo_inventario;*/
		set @existencia_actual = (select inv.cantidad from productos inv where inv.idProducto = @codigo_inventario);
		set @nueva_existencia = @existencia_actual+@Cantidad_Inventario;

		update productos set cantidad = @nueva_existencia where idProducto = @codigo_inventario;
		set @a=@a+1;
		end 
		update Ventas set estado = 2 where idventa= @num_venta;
		drop table TMP;
		SELECT * FROM Ventas WHERE Ventas.idventa = @num_venta;
	end
	
END
else
	select 0 Ventas

end;
GO
/****** Object:  Trigger [dbo].[TRI_ENTRADAS]    Script Date: 21/06/2021 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TRI_ENTRADAS] ON [dbo].[productos] 
AFTER INSERT
AS
BEGIN

DECLARE @PRODUCTO VARCHAR(50);
DECLARE @CANTIDAD INT;
DECLARE @PRECIO_DE_COMPRA INT;
DECLARE @FECHA DATETIME;
DECLARE @IDPRODUCTO INT;
DECLARE @IDPROVEEDOR INT;

SELECT @PRODUCTO = DATOS.nombre from inserted DATOS;
SELECT @CANTIDAD = DATOS.cantidad from inserted DATOS;
SELECT @PRECIO_DE_COMPRA = DATOS.Precio_de_compra from inserted DATOS;
SELECT @FECHA = DATOS.Fecha from inserted DATOS;
SELECT @IDPRODUCTO = DATOS.idProducto from inserted DATOS;
SELECT @IDPROVEEDOR = DATOS.idproveedor from inserted DATOS;

insert into entradas values(@PRODUCTO,@CANTIDAD,@PRECIO_DE_COMPRA,@FECHA,@IDPRODUCTO,@IDPROVEEDOR)

END
GO
ALTER TABLE [dbo].[productos] ENABLE TRIGGER [TRI_ENTRADAS]
GO
USE [master]
GO
ALTER DATABASE [login] SET  READ_WRITE 
GO
=======

CREATE DATABASE [inventory]

USE [inventory]
GO

CREATE TABLE [dbo].[clientes](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Direccion] [varchar](150) NOT NULL,
	[telefono] [varchar](25) NOT NULL,
	[Cedula] [varchar](30) NOT NULL,
	[correo] [varchar](150) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

select * from clientes
CREATE PROCEDURE Insertar_Clientes
    @idcliente INT,
    @Nombre VARCHAR(50),
    @Direccion VARCHAR(150),
    @telefono VARCHAR(25),
    @Cedula int,
    @correo VARCHAR(150)
AS
BEGIN
    INSERT INTO clientes (Nombre, Direccion, telefono, Cedula, correo)
    VALUES (@Nombre, @Direccion, @telefono, @Cedula, @correo);
END;
GO
EXEC SP_Insertar_Clientes
   @idcliente = '20',
   @Nombre = 'Valor2',
   @Direccion = 'Valor3',
   @telefono = 'Valor4',
   @Cedula = 'Valor5',
   @correo = 'Valor6';

INSERT INTO [dbo].[clientes] ([Nombre], [Direccion], [telefono], [Cedula], [correo])
VALUES
    ('Juan Pérez', '123 Calle Principal', '555-1234', '12345678901', 'juan.perez@example.com'),
    ('María Rodríguez', '456 Avenida Central', '555-5678', '98765432102', 'maria.rodriguez@example.com'),
    ('Carlos Gómez', '789 Calle Secundaria', '555-9876', '11223344503', 'carlos.gomez@example.com'),
    ('Ana Sánchez', '321 Calle Norte', '555-5432', '99887766504', 'ana.sanchez@example.com'),
    ('Miguel Martínez', '654 Calle Sur', '555-8765', '66778899005', 'miguel.martinez@example.com'),
    ('Isabel López', '987 Calle Este', '555-2345', '44556677806', 'isabel.lopez@example.com'),
    ('Roberto Díaz', '210 Calle Oeste', '555-7890', '11223344507', 'roberto.diaz@example.com'),
    ('Laura Torres', '543 Avenida Principal', '555-9012', '99887766508', 'laura.torres@example.com'),
    ('Javier Ramírez', '876 Avenida Secundaria', '555-4567', '66778899009', 'javier.ramirez@example.com'),
    ('Patricia Herrera', '109 Avenida Norte', '555-8901', '445566778010', 'patricia.herrera@example.com'),
    ('Alejandro Castro', '432 Avenida Sur', '555-3456', '112233445011', 'alejandro.castro@example.com'),
    ('Sofía Vargas', '765 Avenida Este', '555-6789', '998877665012', 'sofia.vargas@example.com'),
    ('Daniel Mendoza', '198 Avenida Oeste', '555-9012', '667788990013', 'daniel.mendoza@example.com'),
    ('Elena Flores', '876 Calle Principal', '555-4567', '445566778014', 'elena.flores@example.com'),
    ('Luis González', '543 Calle Norte', '555-7890', '112233445015', 'luis.gonzalez@example.com');



	ALTER TABLE [dbo].[productos]
ALTER COLUMN nombre VARCHAR(50);

CREATE TABLE [dbo].[empleados](
	[idEmpleados] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[apellido] [varchar](20) NULL,
	[Cedula] [int] NOT NULL,
	[edad] [int] NOT NULL,
	[sueldo] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEmpleados] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


INSERT INTO empleados (nombre, apellido, Cedula, edad, sueldo)
VALUES ('Diorkys', 'Pérez', 123456789, 30, 50000);

-- Insertar el segundo empleado
INSERT INTO empleados (nombre, apellido, Cedula, edad, sueldo)
VALUES ('Dionys', 'Gómez', 987654321, 25, 45000);

drop table entradas
CREATE TABLE [dbo].[entradas](
	[identrada] [int] IDENTITY(1,1) NOT NULL,
	[Producto] [varchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[idproducto] [int] NULL,
	[idproveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[identrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[factura](
	[idFactura] [int] IDENTITY(1,1) NOT NULL,
	[Cliente] [varchar](30) NOT NULL,
	[NIF] [varchar](30) NOT NULL,
	[Dirección] [varchar](30) NOT NULL,
	[producto] [varchar](30) NOT NULL,
	[cantidad] [int] NOT NULL,
	[descripción] [varchar](30) NOT NULL,
	[Precio] [int] NOT NULL,
	[Descuento] [decimal](18, 0) NULL,
	[IVA] [int] NOT NULL,
	[Fecha] [date] NULL,
	[subtotal] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

select * from productos





ALTER TABLE productos NOCHECK CONSTRAINT ALL;
select * from productos
-- Realiza la inserción

-- Activa la clave foránea nuevamente
ALTER TABLE productos CHECK CONSTRAINT ALL;


CREATE PROCEDURE sp_InsertarProducto2
	@idProducto int,
    @nombre varchar,
    @cantidad int,
    @descripcion varchar(30),
    @Precio_de_compra int,
    @Precio_de_venta int,
    @Fecha date,
    @idproveedor int,
    @estado smallint
AS
    -- Insertar el producto
    INSERT INTO productos (nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado)
    VALUES (@nombre, @cantidad, @descripcion, @Precio_de_compra, @Precio_de_venta, @Fecha, @idproveedor, @estado);


	-- Eliminar el producto
	CREATE PROCEDURE sp_EliminarProducto
    @idProducto int
AS
    UPDATE productos
    SET estado = 0
    WHERE idProducto = @idProducto;




	CREATE PROCEDURE sp_ActualizarProducto
    @idProducto int,
    @nombre varchar(40),
    @cantidad int,
    @descripcion varchar(30),
    @PrecioCompra int,
    @PrecioVenta int,
    @Fecha date,
    @idProveedor int,
    @estado smallint
AS

    UPDATE productos
    SET nombre = @nombre,
        cantidad = @cantidad,
        descripcion = @descripcion,
        Precio_de_compra = @PrecioCompra,
        Precio_de_venta = @PrecioVenta,
        Fecha = @Fecha,
        idproveedor = @idProveedor,
        estado = @estado
    WHERE idProducto = @idProducto;




	EXEC sp_InsertarProducto2
	@idProducto = 12, 
    @nombre = 'Producto de prueba',
    @cantidad = 10,
    @descripcion = 'Descripción de prueba',
    @Precio_de_compra = 100,
    @Precio_de_venta = 150,
    @Fecha = '2023-12-15',
    @idproveedor = 4, -- Asegúrate de que 1 sea un id existente en la tabla proveedores
    @estado = 1;

	select * from productos

	INSERT INTO productos (nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado)
VALUES 
    ('Leche', 100, 'Leche entera', 2, 3, '2023-12-01', 4, 1),
    ('Pan', 150, 'Pan blanco', 1, 2, '2023-12-02', 2, 1),
    ('Arroz', 120, 'Arroz blanco', 3, 5, '2023-12-03', 3, 1),
    ('Pollo', 200, 'Pechuga de pollo', 5, 8, '2023-12-04', 7, 1),
    ('Manzanas', 80, 'Manzanas frescas', 4, 6, '2023-12-05', 2, 1);

CREATE TABLE [dbo].[productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[cantidad] [int] NOT NULL,
	[descripcion] [varchar](30) NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
	[Fecha] [date] NULL,
	[codigoqr] [image] NULL,
	[idproveedor] [int] NULL,
	[estado] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[proveedores](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](35) NOT NULL,
	[Telefono] [varchar](30) NOT NULL,
	[Productos] [varchar](35) NOT NULL,
	[Direccion] [varchar](35) NOT NULL,
	[Correo_electronico] [varchar](60) NOT NULL
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



use inventory
select * from proveedores
CREATE PROCEDURE sp_InsertarProveedor1

    @Nombre VARCHAR(35),
    @Telefono VARCHAR(30),
    @Productos VARCHAR(35),
    @Direccion VARCHAR(35),
    @CorreoElectronico VARCHAR(60)
AS

    INSERT INTO Proveedores (Nombre, Telefono, Productos, Direccion, Correo_electronico)
    VALUES (@Nombre, @Telefono, @Productos, @Direccion, @CorreoElectronico);




	CREATE PROCEDURE sp_ObtenerProveedores
AS

    SELECT idProveedor, Nombre, Telefono, Productos, Direccion, Correo_electronico
    FROM proveedores;


-- Insertar datos en la tabla proveedores
INSERT INTO proveedores (Nombre, Telefono, Productos, Direccion, Correo_electronico)
VALUES
    ('Distribuidora ABC', '123-456-7890', 'Leche Milex', 'Calle 1, Ciudad A', 'distribuidoraabc@example.com'),
    ('Proveedor XYZ', '987-654-3210', 'Queso Cheddar', 'Avenida 2, Ciudad B', 'proveedorxyz@example.com'),
    ('Comestibles S.A.', '555-555-5555', 'Yogur Natural', 'Calle Principal, Ciudad C', 'comestibles@example.com'),
    ('Productos Deliciosos', '111-222-3333', 'Helado Vainilla', 'Avenida Central, Ciudad D', 'productosdeliciosos@example.com'),
    ('Distribuidora León', '444-555-6666', 'Leche Condensada', 'Calle 3, Ciudad E', 'distribuidoraleon@example.com'),
    ('Proveedores Unidos', '777-888-9999', 'Queso Fresco', 'Avenida 4, Ciudad F', 'proveedoresunidos@example.com'),
    ('Lácteos Express', '123-123-1234', 'Leche Entera', 'Calle 5, Ciudad G', 'lacteosexpress@example.com'),
    ('Productos Sanos', '456-456-4567', 'Yogur de Frutas', 'Avenida 6, Ciudad H', 'productossanos@example.com'),
    ('Distribuidora Global', '789-789-7890', 'Leche Deslactosada', 'Calle 7, Ciudad I', 'distribuidoraglobal@example.com'),
    ('Alimentos Ricos', '111-222-3333', 'Crema de Leche', 'Avenida 8, Ciudad J', 'alimentosricos@example.com'),
    ('Proveeduría Familiar', '444-555-6666', 'Leche de Soja', 'Calle 9, Ciudad K', 'proveeduriafamiliar@example.com'),
    ('Productos Naturales', '777-888-9999', 'Yogur Griego', 'Avenida 10, Ciudad L', 'productosnaturales@example.com'),
    ('Distribuidora Feliz', '123-123-1234', 'Leche sin Lactosa', 'Calle 11, Ciudad M', 'distribuidorafeliz@example.com'),
    ('Delicias Caseras', '456-456-4567', 'Queso Gouda', 'Avenida 12, Ciudad N', 'deliciascaseras@example.com'),
    ('Distribuidora Fresca', '789-789-7890', 'Leche de Almendras', 'Calle 13, Ciudad O', 'distribuidorafresca@example.com');

	ALTER TABLE proveedores
ALTER COLUMN Productos VARCHAR(50);

delete productos
ALTER TABLE productos
ALTER COLUMN nombre int;


ALTER TABLE productos
ADD CONSTRAINT FK_Productos_Proveedores
FOREIGN KEY (idproveedor) REFERENCES proveedores(idProveedor);


CREATE TABLE [dbo].[registro](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NULL,
	[cantidad] [int] NOT NULL,
	[Precio_de_compra] [int] NOT NULL,
	[Precio_de_venta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[usuario](
	id_area varchar (5) primary key,
	id_empleados int,
	nombre varchar (50),
	usuario varchar (20),
	pass varchar (20),
	foreign key (id_empleados) references empleados (idEmpleados)
) 
GO

select * from usuario
use inventory


CREATE PROCEDURE sp_BuscarProductos
    @TerminoBusqueda NVARCHAR(100)
AS

    SELECT idProducto, nombre, cantidad, descripcion, Precio_de_compra, Precio_de_venta, Fecha, idproveedor, estado
    FROM productos
    WHERE nombre LIKE '%' + @TerminoBusqueda + '%'
        OR descripcion LIKE '%' + @TerminoBusqueda + '%';




ALTER TABLE proveedores
ADD CONSTRAINT fk_proveedores_productos
FOREIGN KEY (Productos) REFERENCES productos(idProducto);

select * from usuario

ALTER TABLE proveedores
ALTER COLUMN Productos INT;


ALTER TABLE proveedores
ADD CONSTRAINT fk_proveedores_productos
FOREIGN KEY (Productos) REFERENCES productos(idProducto);


 ALTER TABLE [dbo].[inventory]  WITH CHECK ADD CONSTRAINT [FK_empleado_usuario] FOREIGN KEY(id_empleados)
REFERENCES [dbo].empleados (idEmpleados)

insert into usuario (id_area, id_empleados, nombre, usuario, pass) values ('A0001', 1, 'Diorkys', 'Adm', 'Adm');
insert into usuario (id_area, id_empleados, nombre, usuario, pass) values ('A0002', 2, 'Dionys', 'Dionys02', '12345');

create proc logeo
@usuario varchar (20),
@pass varchar (20)
as
select id_area, id_empleados, nombre, usuario, pass from usuario where usuario=@usuario and pass=@pass
go

CREATE TABLE [dbo].[Ventas](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idproducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fecha] [varchar](10) NULL,
	[totalventa] [decimal](18, 0) NOT NULL,
	[estado] [int] NULL
) ON [PRIMARY]
GO

use inventory
ALTER TABLE Ventas
ALTER COLUMN fecha Datetime;
select * from Ventas
CREATE PROCEDURE sp_InsertarVenta2
@idventas INT,
    @idcliente INT,
    @idproducto INT,
    @cantidad INT,
    @fecha DATETIME,
    @totalventa INT,
    @precio_de_venta INT
AS
    INSERT INTO Ventas (idcliente, idproducto, cantidad, fecha, totalventa, precio_de_venta)
    VALUES (@idcliente, @idproducto, @cantidad, @fecha, @totalventa, @precio_de_venta);


ALTER TABLE [dbo].[Ventas]
ADD [precio_de_venta] [int] NOT NULL;

CREATE TABLE [dbo].[ventas1](
	[idVentas] [int] IDENTITY(1,1) NOT NULL,
	[Descuento] [decimal](18, 0) NULL,
	[IVA] [int] NOT NULL,
	[Fecha] [date] NULL,
	[subtotal] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idVentas] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO










SET IDENTITY_INSERT [dbo].[ventas1] OFF
GO
ALTER TABLE [dbo].[productos] ADD  DEFAULT ((0)) FOR [Eliminado]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [FK_entradas_productos] FOREIGN KEY([idproducto])
REFERENCES [dbo].[productos] ([idProducto])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [FK_entradas_productos]
GO
ALTER TABLE [dbo].[entradas]  WITH CHECK ADD  CONSTRAINT [FK_entradas_proveedores] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedores] ([idProveedor])
GO
ALTER TABLE [dbo].[entradas] CHECK CONSTRAINT [FK_entradas_proveedores]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_proveedores] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedores] ([idProveedor])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_proveedores]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_clientes] FOREIGN KEY([idcliente])
REFERENCES [dbo].[clientes] ([idcliente])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_ventas_clientes]
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_productos] FOREIGN KEY([idproducto])
REFERENCES [dbo].[productos] ([idProducto])
GO
ALTER TABLE [dbo].[Ventas] CHECK CONSTRAINT [FK_ventas_productos]
GO
/****** Object:  StoredProcedure [dbo].[VentaAnularTicket]    Script Date: 21/06/2021 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VentaAnularTicket]
(
	@num_venta int  null
)as
begin 
declare @existe_venta int,
 @registros int, 
 @a int, 
 @codigo_inventario int, 
 @Cantidad_Inventario int,
 @existencia_actual int,
 @nueva_existencia int;

set @existe_venta = (select COUNT(*) from Ventas ve where ve.idventa = @num_venta and ve.estado =1);
if @existe_venta >0 
BEGIN
	create table TMP
	(
		id int identity primary key,
		cod_inventario int,
		cantidad_EnInventario int 
	)
	set @a = 1;
	set @registros =(select COUNT(*) from Ventas v where v.idventa = @num_venta );

	if @registros >0
	begin
		insert into TMP(cod_inventario,cantidad_EnInventario) select dv.idproducto,dv.cantidad from Ventas dv where dv.idventa = @num_venta;
		while @a <= @registros 
		begin
		set @codigo_inventario = (select TMP.cod_inventario from TMP where id = @a);
		set @Cantidad_Inventario = (select TMP.cantidad_EnInventario from TMP where id = @a);
		/*select tmp.cod_inventario, tmp.cantidad_EnInventario into codigo_inventario,Cantidad_Inventario from TMP tmp where id =a; */
		/*select inv.cantidad into  existencia_actual from Inventario inv where idarticulo = @codigo_inventario;*/
		set @existencia_actual = (select inv.cantidad from productos inv where inv.idProducto = @codigo_inventario);
		set @nueva_existencia = @existencia_actual+@Cantidad_Inventario;

		update productos set cantidad = @nueva_existencia where idProducto = @codigo_inventario;
		set @a=@a+1;
		end 
		update Ventas set estado = 2 where idventa= @num_venta;
		drop table TMP;
		SELECT * FROM Ventas WHERE Ventas.idventa = @num_venta;
	end
	
END
else
	select 0 Ventas

end;
GO
/****** Object:  Trigger [dbo].[TRI_ENTRADAS]    Script Date: 21/06/2021 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[TRI_ENTRADAS] ON [dbo].[productos] 
AFTER INSERT
AS
BEGIN

DECLARE @PRODUCTO VARCHAR(50);
DECLARE @CANTIDAD INT;
DECLARE @PRECIO_DE_COMPRA INT;
DECLARE @FECHA DATETIME;
DECLARE @IDPRODUCTO INT;
DECLARE @IDPROVEEDOR INT;

SELECT @PRODUCTO = DATOS.nombre from inserted DATOS;
SELECT @CANTIDAD = DATOS.cantidad from inserted DATOS;
SELECT @PRECIO_DE_COMPRA = DATOS.Precio_de_compra from inserted DATOS;
SELECT @FECHA = DATOS.Fecha from inserted DATOS;
SELECT @IDPRODUCTO = DATOS.idProducto from inserted DATOS;
SELECT @IDPROVEEDOR = DATOS.idproveedor from inserted DATOS;

insert into entradas values(@PRODUCTO,@CANTIDAD,@PRECIO_DE_COMPRA,@FECHA,@IDPRODUCTO,@IDPROVEEDOR)

END
GO
ALTER TABLE [dbo].[productos] ENABLE TRIGGER [TRI_ENTRADAS]
GO
USE [master]
GO
ALTER DATABASE [login] SET  READ_WRITE 
GO
>>>>>>> e1c5fc09e954115ab6e013791bc8701da9dd07b1
