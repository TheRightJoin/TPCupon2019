
create procedure THE_RIGHT_JOIN.CREACION_TABLAS_CONSTRAINTS
AS
BEGIN
CREATE TABLE THE_RIGHT_JOIN.Cliente
(Cli_Dni numeric(18,0) PRIMARY KEY NOT NULL,
Cli_Nombre nvarchar(255),
Cli_Apellido nvarchar(255),
Cli_Mail nvarchar(255),
Cli_Direccion nvarchar(255),
Cli_Ciudad nvarchar(255),
Cli_Fecha_Nac datetime,
Cli_Activo numeric(1,0),
Cli_Telefono numeric(18,0),
Cli_CodPostal nvarchar(255),
Cli_Localidad nvarchar(255),
Cli_Saldo numeric(18,2))


------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Rubro(
idRubro int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Rubro_Descripcion varchar(255))


-------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Proveedor(
Provee_RS nvarchar(255),
Provee_Dom nvarchar(255),
Provee_Ciudad nvarchar(255),
Provee_Telefono numeric(18,0),
Provee_CUIT nvarchar(20) PRIMARY KEY NOT NULL,
Provee_Rubro int,
Provee_Activo numeric(1,0))

ALTER TABLE THE_RIGHT_JOIN.Proveedor
ADD CONSTRAINT FK_Rubro
FOREIGN KEY (Provee_Rubro)
REFERENCES THE_RIGHT_JOIN.Rubro (idRubro)

-------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Usuario(
Usuari_idUser int IDENTITY(1,1) PRIMARY KEY NOT NULL,
Usuari_Username nvarchar(255) UNIQUE,
Usuari_Password nvarchar(255),
Usuari_DNI numeric(18,0),
Usuari_CUIT nvarchar(20),
Usuari_Habilitado numeric(1,0))

ALTER TABLE THE_RIGHT_JOIN.Usuario
ADD CONSTRAINT FK_Cliente
FOREIGN KEY (Usuari_DNI)
REFERENCES THE_RIGHT_JOIN.Cliente (Cli_Dni)

ALTER TABLE THE_RIGHT_JOIN.Usuario
ADD CONSTRAINT FK_Proveedor
FOREIGN KEY (Usuari_CUIT)
REFERENCES THE_RIGHT_JOIN.Proveedor (Provee_CUIT)


-----------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Rol(
id_Rol INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
rol_Name nvarchar(255),
rol_habilitado numeric(1,0))

------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.RolXUsuario(
idUser INTEGER NOT NULL,
idRol INTEGER NOT NULL
PRIMARY KEY (idUser,idRol))

ALTER TABLE THE_RIGHT_JOIN.RolXUsuario
ADD CONSTRAINT FK_Usuario
FOREIGN KEY (idUser) REFERENCES THE_RIGHT_JOIN.Usuario (Usuari_idUser)

ALTER TABLE THE_RIGHT_JOIN.RolXUsuario
ADD CONSTRAINT FK_Rol
FOREIGN KEY (idRol) REFERENCES THE_RIGHT_JOIN.Rol (id_Rol)
------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Funcionalidad(
idFunc INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
funcio_name nvarchar(255))

------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.FuncXRol(
idRol INTEGER NOT NULL,
idFunc INTEGER NOT NULL
PRIMARY KEY (idRol,idFunc))

ALTER TABLE THE_RIGHT_JOIN.FuncXRol
ADD CONSTRAINT FK_RolFuncXRol
FOREIGN KEY (idRol) REFERENCES THE_RIGHT_JOIN.Rol (id_Rol)

ALTER TABLE THE_RIGHT_JOIN.FuncXRol
ADD CONSTRAINT FK_Func
FOREIGN KEY (idFunc) REFERENCES THE_RIGHT_JOIN.Funcionalidad (idFunc)


------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Oferta(
Oferta_Precio numeric(18,2),
Oferta_Precio_Ficticio numeric(18,2),
Oferta_Fecha datetime,
Oferta_Fecha_Ven datetime,
Oferta_Cantidad numeric(18,0),
Oferta_Descripcion nvarchar(255),
Oferta_Codigo nvarchar(50) NOT NULL PRIMARY KEY,
Oferta_Disponible numeric(1,0),
Oferta_CUIT nvarchar(20),
Oferta_CantxCli numeric(18,0))


ALTER TABLE THE_RIGHT_JOIN.Oferta
ADD CONSTRAINT FK_ProveedorOferta
FOREIGN KEY (Oferta_CUIT) REFERENCES THE_RIGHT_JOIN.Proveedor (Provee_CUIT)
------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Cupon(
idCupon INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
codOferta nvarchar(50) NOT NULL,
cupon_dniCli numeric(18,0),
cupon_FechaCanje date)

ALTER TABLE THE_RIGHT_JOIN.Cupon
ADD CONSTRAINT FK_CuponOferta
FOREIGN KEY (codOferta) REFERENCES THE_RIGHT_JOIN.Oferta (Oferta_Codigo)

ALTER TABLE THE_RIGHT_JOIN.Cupon
ADD CONSTRAINT FK_CuponCliente
FOREIGN KEY (cupon_dniCli) REFERENCES THE_RIGHT_JOIN.Cliente (Cli_Dni)


-------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.CargaCredito(
Carga_idCarga INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
Carga_Fecha datetime,
Carga_dniClie numeric(18,0),
Carga_Credito numeric(18,2),
Carga_TipoPago nvarchar(255),
Carga_NumTarjeta numeric(18,0),
Cargar_FechaVen smalldatetime)

ALTER TABLE THE_RIGHT_JOIN.CargaCredito
ADD CONSTRAINT FK_CargarCreditoCliente
FOREIGN KEY (Carga_dniClie) REFERENCES THE_RIGHT_JOIN.Cliente (Cli_Dni)

--------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Factura(
Factura_tipoFactura nvarchar(255) NOT NULL,
Factura_numFactura INTEGER NOT NULL,
Factura_fecha datetime,
Factura_total numeric(18,0),
Factura_CUIT nvarchar(20))

ALTER TABLE THE_RIGHT_JOIN.Factura
ADD CONSTRAINT PK_Factura
PRIMARY KEY (Factura_tipoFactura, Factura_numFactura)

ALTER TABLE THE_RIGHT_JOIN.Factura
ADD CONSTRAINT FK_Factura_Proveedor
FOREIGN KEY (Factura_CUIT) REFERENCES THE_RIGHT_JOIN.Proveedor (Provee_CUIT)

--------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Compra_Oferta(
CompraOferta_idCompra INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
CompraOferta_dniClie numeric(18,0),
CompraOferta_oferCodigo nvarchar(50),
CompraOferta_Cantidad INTEGER,
CompraOferta_Fecha date)

ALTER TABLE THE_RIGHT_JOIN.Compra_Oferta
ADD CONSTRAINT FK_CompraOferta_Cliente
FOREIGN KEY (CompraOferta_dniClie) REFERENCES THE_RIGHT_JOIN.Cliente (Cli_Dni)

ALTER TABLE THE_RIGHT_JOIN.Compra_Oferta
ADD CONSTRAINT FK_CompraOferta_Oferta
FOREIGN KEY (CompraOferta_oferCodigo) REFERENCES THE_RIGHT_JOIN.Oferta (Oferta_Codigo)

--------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Item_Factura(
Item_tipoFactura nvarchar(255) NOT NULL,
Item_numFactura INTEGER NOT NULL,
Item_idItem INTEGER NOT NULL IDENTITY(1,1),
Item_idCompraOferta INTEGER,
Item_montoItem numeric(18,2))

ALTER TABLE THE_RIGHT_JOIN.Item_Factura
ADD CONSTRAINT PK_Item_Factura
PRIMARY KEY (Item_tipoFactura, Item_numFactura, Item_idItem)

ALTER TABLE THE_RIGHT_JOIN.Item_Factura
ADD CONSTRAINT FK_Item_Factura_CompraOferta
FOREIGN KEY (Item_idCompraOferta) REFERENCES THE_RIGHT_JOIN.Compra_Oferta (CompraOferta_idCompra)

ALTER TABLE THE_RIGHT_JOIN.Item_Factura
ADD CONSTRAINT FK_Item_Factura_Factura
FOREIGN KEY (Item_tipoFactura,Item_numFactura) REFERENCES THE_RIGHT_JOIN.Factura (Factura_tipoFactura,Factura_numFactura)

END