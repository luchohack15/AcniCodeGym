Create DataBase GymNicaCode
use GymNicaCode
CREATE SCHEMA Usuario
CREATE SCHEMA MEMBRESIA
CREATE SCHEMA PV

CREATE TABLE USUARIO.Empleado(
IdEmpleado INT PRIMARY KEY IDENTITY(1,1) ,
NombresEmpleado NVARCHAR (100),
ApellidosEmpleado NVARCHAR(100),
Telefono INT,
Cedula NVARCHAR(100),
Estatus BIT
)
CREATE TABLE USUARIO.Usuarios(
 IdUsuario INT PRIMARY KEY IDENTITY (1,1) ,
 IdEmpleado INT FOREIGN KEY REFERENCES USUARIO.Empleado(IdEmpleado),
 Usuario NVARCHAR(100),
 Contraseña NVARCHAR(100),
 Estatus BIT
)

CREATE TABLE MEMBRESIA.Cliente(
IdCliente INT PRIMARY KEY IDENTITY (1,1),
NombresCliente NVARCHAR(100),
ApellidosCliente NVARCHAR(100),
Telefono INT,
Correo NVARCHAR(100),
Cedula NVARCHAR (100),
FotoCliente IMAGE,
ClaveDeAcceso NVARCHAR(100),
Estatus BIT
)
CREATE TABLE MEMBRESIA.Membresia(
IdMembresia INT PRIMARY KEY IDENTITY (1,1),
NombreMembresia NVARCHAR (100),
Precio DECIMAL(18,4),
TipoMembresia NVARCHAR(30),
Dias INT,
Semana INT,
Meses INT,
HoraInicio NVARCHAR(30),
HoraFinal NVARCHAR(30),
Estats BIT
)
CREATE  TABLE MEMBRESIA.MiembroGym(
IdMiembroGym INT PRIMARY KEY IDENTITY (1,1),
IdCliente INT FOREIGN KEY REFERENCES MEMBRESIA.Cliente(IdCliente),
FechaComienzo DATE,
Estatus BIT
)
CREATE TABLE MEMBRESIA.DetalleMiembroGym(
IdDetalleMiembroGym INT PRIMARY KEY IDENTITY (1,1),
IdMiembroGym INT FOREIGN KEY REFERENCES MEMBRESIA.MiembroGym(IdMiembroGym),
IdMembresia INT FOREIGN KEY REFERENCES MEMBRESIA.Membresia(IdMembresia),
FechaVencimiento DATE,
Estatus BIT
)
CREATE TABLE MEMBRESIA.RegistroEntradaCliente
(
 IdRegistroEntradaCliente INT PRIMARY KEY,
IdCliente INT FOREIGN KEY REFERENCES MEMBRESIA.Cliente(IdCliente),
FechaIngreso DATE,
Estatus BIT
)
CREATE TABLE PV.Almacen
(
IdAlmacen INT PRIMARY KEY IDENTITY (1,1),
NombreAlmacen NVARCHAR(100),
Estatus BIT
)
CREATE TABLE PV.Producto(
 IdProdcuto INT PRIMARY KEY IDENTITY(1,1),
 NombreProducto NVARCHAR(100),
 Descripcion NVARCHAR(100),
 Estatus BIT
)
CREATE TABLE PV.Compra(
IdCompra INT PRIMARY KEY IDENTITY(1,1),
IdAlmacen INT FOREIGN KEY REFERENCES PV.Almacen(IdAlmacen),
NoFactura NVARCHAR (100),
FechaCompra DATE,
IdEmpleado INT FOREIGN KEY REFERENCES USUARIO.Empleado(IdEmpleado),
Estatus BIT
)

CREATE TABLE PV.DetalleCompra(
IdDetalleCompra INT PRIMARY KEY IDENTITY(1,1),
IdCompra INT FOREIGN KEY REFERENCES PV.Compra(IdCompra),
IdProducto INT FOREIGN KEY REFERENCES PV.Producto(IdProdcuto),
Cantidad DECIMAL(18,4),
Costo DECIMAL (18,4),
MargenDeGanancia DECIMAL(18,4),
Estatus BIT
)
CREATE TABLE PV.Factura(
IdFactura INT PRIMARY KEY IDENTITY (1,1),
IdCliente INT FOREIGN KEY REFERENCES MEMBRESIA.Cliente(IdCliente),
IdAlmacen INT FOREIGN KEY REFERENCES PV.Almacen(IdAlmacen),
IdEmpleado INT FOREIGN KEY REFERENCES USUARIO.Empleado(IdEmpleado),
NoFactura NVARCHAR (100),
FechaFactura DATE,
Estatus BIT
)
CREATE TABLE PV.DetalleFactura(
IdDetalleFactura INT PRIMARY KEY IDENTITY(1,1),
IdFactura INT FOREIGN KEY REFERENCES PV.Factura(IdFactura),
IdProducto INT FOREIGN KEY REFERENCES PV.Producto(IdProdcuto),
Cantidad DECIMAL(18,4),
Precio DECIMAL (18,4),
Estatus BIT
)