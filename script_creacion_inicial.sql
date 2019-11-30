USE [GD2C2019]
GO

create schema THE_RIGHT_JOIN;
GO


/*create schema THE_RIGHT_JOIN;
GO*/
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
Provee_Activo numeric(1,0),
Provee_email nvarchar(255),
Provee_postal nvarchar(255),
Provee_contacto nvarchar(255))

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
Usuari_Habilitado numeric(1,0),
Usuari_Intentos numeric(18,0))

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
Oferta_CUIT nvarchar(20),
Oferta_CantxCli numeric(18,0),
Oferta_Disponible numeric(1,0),
)


ALTER TABLE THE_RIGHT_JOIN.Oferta
ADD CONSTRAINT FK_ProveedorOferta
FOREIGN KEY (Oferta_CUIT) REFERENCES THE_RIGHT_JOIN.Proveedor (Provee_CUIT)
------------------------------------------------------

CREATE TABLE THE_RIGHT_JOIN.Cupon(
idCupon INTEGER NOT NULL PRIMARY KEY IDENTITY(1,1),
codOferta nvarchar(50) NOT NULL,
cupon_dniCli numeric(18,0),
cupon_FechaCanje date,
cupon_FechaGen date,
cupon_dniCons numeric(18,0))

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
Factura_numFactura INTEGER NOT NULL identity(1,1),
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

GO

CREATE FUNCTION THE_RIGHT_JOIN.LimpiarCaracteres ( @Cadena VARCHAR(MAX) )
RETURNS VARCHAR(MAX)
AS 
BEGIN
-- ============================================================
-- Author:		
-- Create date: <06 Jul 2018>
-- Description:	--				 y caracteres especiales>
-- Retorno:		
-- ============================================================
 --Reemplazamos las vocales acentuadas y caracteres especiales
 -- áéíóúàèìòùãõâêîôûäëïöüñÑçÇ ÁÉÍÓÚÀÈÌÒÙÃÕÂÊÎÔÛÄËÏÖÜ 
    RETURN 	
	REPLACE(REPLACE( /*vocales ÃÕ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ÄËÏÖÜ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ÂÊÎÔÛ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ÀÈÌÒÙ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ÁÉÍÓÚ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ñÑçÇ  incluido espacio en blanco*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales äëïöü*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales âêîôû*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales àèìòù*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales áéíóú*/ @Cadena, 'á', 'a'), 'é','e'), 'í', 'i'), 'ó', 'o'), 'ú','u')		
			,'à','a'),'è','e'),'ì','i'),'ò','o'),'ù','u')
			,'â','a'),'ê','e'),'î','i'),'ô','o'),'û','u')
			,'ä','a'),'ë','e'),'ï','i'),'ö','o'),'ü','u')
			,'ñ','n'),'Ñ','N'),'ç','c'),'Ç','C'),' ','')
			,'Á','A'),'É','E'),'Í','I'),'Ó','O'),'Ú','U') 
			,'À','A'),'È','E'),'Ì','I'),'Ò','O'),'Ù','U') 
			,'Â','A'),'Ê','E'),'Î','I'),'Ô','O'),'Û','U')
			,'Ä','A'),'Ë','E'),'Ï','I'),'Ö','O'),'Ü','U') 
			,'Ã','A'),'Õ','O')  
END

go

create function THE_RIGHT_JOIN.traerFunc(@func nvarchar(255))
returns int
as
begin
return (select idFunc from THE_RIGHT_JOIN.Funcionalidad where funcio_name = @func);
end 

go

create procedure THE_RIGHT_JOIN.migracion
as
begin
--TABLA Clientes
--LISTO
insert
into THE_RIGHT_JOIN.Cliente select distinct Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Fecha_Nac,NULL,Cli_Telefono,NULL,NULL,0
from gd_esquema.Maestra


--TABLA RUBROS
--LISTO
insert into THE_RIGHT_JOIN.Rubro select distinct Provee_Rubro from gd_esquema.Maestra WHERE Provee_Rubro IS NOT NULL


--TABLA PROVEEDORES
--LISTO
insert into THE_RIGHT_JOIN.Proveedor select distinct Provee_RS,Provee_Dom,Provee_Ciudad,Provee_Telefono,Provee_CUIT, 
    (select idRubro from THE_RIGHT_JOIN.Rubro R where R.Rubro_Descripcion = Provee_Rubro),NULL, null, null, null
 from gd_esquema.Maestra WHERE Provee_CUIT IS NOT NULL


--TABLA CARGA_CREDITO
--LISTO
insert into THE_RIGHT_JOIN.CargaCredito select Carga_Fecha,Cli_Dni,Carga_Credito,Tipo_Pago_Desc,NULL,NULL
from gd_esquema.Maestra
where Carga_Credito IS NOT NULL

update THE_RIGHT_JOIN.Cliente set Cli_Saldo = (select SUM(Carga_Credito) from THE_RIGHT_JOIN.CargaCredito where Carga_dniClie = Cli_Dni)

--TABLA OFERTAS
--LISTO
insert into THE_RIGHT_JOIN.Oferta select distinct Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Cantidad,Oferta_Descripcion,
Oferta_Codigo,Provee_CUIT,Oferta_Cantidad, null
from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL


--TABLA Compra_Oferta
--LISTO
insert into THE_RIGHT_JOIN.Compra_Oferta /*select Cli_Dni,Oferta_Codigo, Oferta_Cantidad ,Oferta_Fecha_Compra from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL and Factura_Nro IS NULL and Oferta_Entregado_Fecha is null
order by Cli_Dni,Oferta_Codigo*/ select Cli_Dni,Oferta_Codigo,COUNT(*)as cant,Oferta_Fecha_Compra from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL and Factura_Nro IS NULL and Oferta_Entregado_Fecha is null
GROUP BY Cli_Dni,Oferta_Codigo,Oferta_Fecha_Compra,Factura_Nro
order by count(*),Oferta_Codigo,Factura_Nro



--119678
update THE_RIGHT_JOIN.Cliente set Cli_Saldo = Cli_Saldo - 
	(select SUM(CompraOferta_Cantidad*Oferta_Precio) from THE_RIGHT_JOIN.Compra_Oferta
	 join THE_RIGHT_JOIN.Oferta on Oferta_Codigo = CompraOferta_oferCodigo where CompraOferta_dniClie = Cli_Dni)

--TABLA Cupon
--LISTO

insert into THE_RIGHT_JOIN.Cupon select CompraOferta_oferCodigo,CompraOferta_dniClie,null,CompraOferta_Fecha,null
	from THE_RIGHT_JOIN.Compra_Oferta 

update THE_RIGHT_JOIN.Cupon set cupon_FechaCanje = 
	(select distinct Oferta_Entregado_Fecha from gd_esquema.Maestra join THE_RIGHT_JOIN.Compra_Oferta on CompraOferta_dniClie = Cli_Dni and CompraOferta_oferCodigo = codOferta and Oferta_Fecha_Compra = CompraOferta_Fecha
	where Oferta_Codigo = codOferta and cupon_dniCli = Cli_Dni and Oferta_Entregado_Fecha is not null
	and  Oferta_Fecha_Compra = cupon_FechaGen)

/*insert into THE_RIGHT_JOIN.Cupon select Oferta_Codigo,Cli_Dni, Oferta_Entregado_Fecha from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL*/


--TABLA Factura
--LISTO
set Identity_Insert THE_RIGHT_JOIN.Factura on

insert into THE_RIGHT_JOIN.Factura (Factura_tipoFactura, Factura_numFactura, Factura_fecha, Factura_total, Factura_CUIT) select 'A',Factura_Nro,Factura_Fecha,sum(Oferta_Precio),Provee_CUIT from gd_esquema.Maestra
where Factura_Nro IS NOT NULL and Oferta_Entregado_Fecha is null
group by Factura_Nro,Factura_Fecha,Provee_CUIT

set Identity_Insert THE_RIGHT_JOIN.Factura off

--Tabla Item
--LISTO
insert into THE_RIGHT_JOIN.Item_Factura select 'A',Factura_Nro,CompraOferta_idCompra,CompraOferta_Cantidad*Oferta_Precio as monto from gd_esquema.Maestra,THE_RIGHT_JOIN.Compra_Oferta
where Factura_Nro IS NOT NULL and Cli_Dni = CompraOferta_dniClie and Oferta_Codigo = CompraOferta_oferCodigo and Oferta_Fecha_Compra = CompraOferta_Fecha
end

--USUARIOS
--LA FUNCION DE ABAJO LA NECESITAMOS PARA LIMPIAR LOS CARACTERES ESPECIALES

insert into THE_RIGHT_JOIN.Usuario 
select THE_RIGHT_JOIN.LimpiarCaracteres( LOWER( REPLACE( Cli_Nombre+Cli_Apellido,' ', '')))
,HASHBYTES('SHA2_256',N'password') 
,Cli_Dni,NULL,1,0 
from THE_RIGHT_JOIN.Cliente

insert into THE_RIGHT_JOIN.Usuario
select Provee_CUIT, HASHBYTES('SHA2_256',N'password'), NULL, Provee_CUIT,1,0
 from THE_RIGHT_JOIN.Proveedor

--FUNCIONALIDADES
insert into THE_RIGHT_JOIN.Funcionalidad values ('ABM ROL')
insert into THE_RIGHT_JOIN.Funcionalidad values ('ABM CLIENTE')
insert into THE_RIGHT_JOIN.Funcionalidad values ('ABM PROVEEDOR')
insert into THE_RIGHT_JOIN.Funcionalidad values ('CARGAR CREDITO')
insert into THE_RIGHT_JOIN.Funcionalidad values ('GENERAR OFERTA')
insert into THE_RIGHT_JOIN.Funcionalidad values ('COMPRAR OFERTA')
insert into THE_RIGHT_JOIN.Funcionalidad values ('CONSUMIR OFERTA')
insert into THE_RIGHT_JOIN.Funcionalidad values ('FACTURACION')
insert into THE_RIGHT_JOIN.Funcionalidad values ('ESTADISTICA')

--ROLES
INSERT INTO THE_RIGHT_JOIN.Rol VALUES ('ADMIN',1)
INSERT INTO THE_RIGHT_JOIN.Rol VALUES ('CLIENTE',1)
INSERT INTO THE_RIGHT_JOIN.Rol VALUES ('PROVEEDOR',1)

--ROLXFUNC
-- ADMIN 1, CLI 2, PROV 3

INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('ABM ROL'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('ABM CLIENTE'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('ABM PROVEEDOR'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('GENERAR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('FACTURACION'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('CONSUMIR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('COMPRAR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('ESTADISTICA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('CARGAR CREDITO'))

INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(2,THE_RIGHT_JOIN.traerFunc('CARGAR CREDITO'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(2,THE_RIGHT_JOIN.traerFunc('COMPRAR OFERTA'))

INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(3,THE_RIGHT_JOIN.traerFunc('CONSUMIR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(3,THE_RIGHT_JOIN.traerFunc('GENERAR OFERTA'))

--ROLXUSUARIO
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,2 from THE_RIGHT_JOIN.Usuario where Usuari_DNI IS NOT NULL
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,3 from THE_RIGHT_JOIN.Usuario where Usuari_CUIT IS NOT NULL

--CREAR USUARIO ADMIN
INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado)
VALUES ('admin', HASHBYTES('SHA2_256',N'w23e'), NULL, NULL, 1)
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,1 from THE_RIGHT_JOIN.Usuario where Usuari_Username = 'admin'

GO

EXEC THE_RIGHT_JOIN.CREACION_TABLAS_CONSTRAINTS

GO

EXEC THE_RIGHT_JOIN.migracion

GO

create procedure THE_RIGHT_JOIN.altaCliente
@dni numeric(18,0) = null,
@nombre nvarchar(255) = NULL,
@apellido nvarchar(255) = NULL,
@mail nvarchar(255) = NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@fechaNac datetime = NULL,
@telefono numeric(18,0) = NULL,
@codpost nvarchar(255) = NULL,
@localidad nvarchar(255) = NULL,
@retorno int out
AS
if(not exists (select * from Cliente 
					where Cli_Nombre = @nombre and
					 Cli_Apellido = @apellido and 
					 Cli_Mail = @mail and
					 Cli_Direccion = @direccion and
					 Cli_Ciudad = @ciudad and
					 Cli_Fecha_Nac = @fechaNac and
					 Cli_Telefono = @telefono and
					 Cli_CodPostal = @codpost and
					 Cli_Localidad = @localidad and
					 Cli_Activo = 1))
begin
begin try
INSERT INTO THE_RIGHT_JOIN.Cliente (Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Fecha_Nac,Cli_Telefono,Cli_CodPostal,Cli_Localidad,Cli_Activo,Cli_Saldo)
VALUES (@dni,@nombre,@apellido,@mail,@direccion,@ciudad,@fechaNac,@telefono,@codpost,@localidad,1,200)
set @retorno = @@ROWCOUNT
end try
begin catch
set @retorno = -1
end catch
end
else
set @retorno = -1

GO

create procedure THE_RIGHT_JOIN.altaOferta
@codigo nvarchar(50) = null,
@precio numeric(18,2) = null,
@precioFicticio numeric(18,2) = null,
@fecha datetime = null,
@fecha_ven datetime = null,
@cantidad numeric(18,2) = null,
@desc nvarchar(255) = null,
@disponible numeric(1,0) = null,
@cuit nvarchar(20) = null,
@cantxClie numeric(18,0),
@filasAfectadas int out
as
insert into THE_RIGHT_JOIN.Oferta (Oferta_Codigo,Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Ven,Oferta_Cantidad,Oferta_Descripcion,Oferta_Disponible,Oferta_CUIT, Oferta_CantxCli)
values(@codigo,@precio,@precioFicticio,@fecha,@fecha_ven,@cantidad,@desc,@disponible,@cuit,@cantxClie)
set @filasAfectadas = @@ROWCOUNT
return;

GO

CREATE procedure [THE_RIGHT_JOIN].[altaProveedor]
@razonSocial nvarchar(255) = null,
@domicilio nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@telefono numeric(18,0) = NULL,
@cuit nvarchar(20) = NULL,
@idRubro int = NULL,
@activo numeric(1,0) = NULL,
@email nvarchar(255) = NULL,
@postal nvarchar(30) = NULL,
@contacto nvarchar(255) = NULL,
@retorno numeric(18,0) out

-- 0 si lo creo
-- -1 si ya existe 

AS
set @retorno = 0
if(not exists (select * from THE_RIGHT_JOIN.Proveedor WHERE Provee_CUIT = @cuit))
	Begin
	INSERT INTO THE_RIGHT_JOIN.Proveedor (Provee_RS, Provee_Dom, Provee_Ciudad, Provee_Telefono, 
									  Provee_CUIT, Provee_Rubro, Provee_Activo, Provee_email,
									  Provee_postal, Provee_contacto)
	VALUES (@razonSocial,@domicilio,@ciudad,@telefono,@cuit,@idRubro,@activo,@email,@postal,@contacto)
	End
else
set @retorno = -1

GO

USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 10/11/2019 18:57:52 ******/

create procedure THE_RIGHT_JOIN.altaUsuario
@usuario nvarchar(255) = null,
@pass nvarchar(255) = NULL,
@dni numeric(18,0) = NULL,
@cuit nvarchar(255) = NULL,
@idRol int = null,
@retorno numeric(18,0) out

-- retorna 0 si ta todo joya
-- retona -1 si existe uno con el mismo username

AS
begin
set @retorno = 0
if(not exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario))
	begin
		INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado, Usuari_Intentos)
		VALUES (@usuario, HASHBYTES('SHA2_256',@pass), @dni, @cuit, 1, 0)

		if(@dni IS NOT NULL)
			begin
			insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
			values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_DNI = @dni),@idRol)
			end
		else
			begin
			insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
			values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_CUIT = @cuit),@idRol)
			end
		end
	else
set @retorno = -1
end

GO

create procedure THE_RIGHT_JOIN.asignarFuncionalidad(@idRol int, @idFunc int, @flag int out)
as
begin
if(not exists (select * from FuncXRol where idRol = @idRol and idFunc = @idFunc))
begin
	insert into FuncXRol values (@idRol,@idFunc)
	set @flag = @@ROWCOUNT
end
else
	set @flag = 0
end

GO

create procedure THE_RIGHT_JOIN.bajaCliente @dni numeric(18,0)
AS
update THE_RIGHT_JOIN.Cliente set Cli_Activo = 0 where Cli_Dni = @dni

GO

create procedure THE_RIGHT_JOIN.bajaProveedor @CUIT nvarchar(255)
AS
update THE_RIGHT_JOIN.Proveedor set Provee_Activo= 0 where Provee_CUIT = @CUIT

GO

create procedure THE_RIGHT_JOIN.bajaRol(@idRol int)
as
begin
update Rol set rol_habilitado = 0 where id_Rol = @idRol
end

GO

create procedure THE_RIGHT_JOIN.bloquearUser(@username nvarchar(255))
as
update Usuario set Usuari_Habilitado = 0 where Usuari_Username = @username

GO

create procedure THE_RIGHT_JOIN.cambiarContra (@usuario nvarchar(255), @pass nvarchar(255))
as
UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Password = HASHBYTES('SHA2_256', @pass) WHERE Usuari_Username = @usuario

GO

create procedure THE_RIGHT_JOIN.cargarCredito
@fecha date = null,
@dniCliente numeric(18,0) = null,
@tipo nvarchar(255) = null,
@monto numeric(18,2) = null,
@numTarjeta numeric(18,0) = null,
@fechaVen smalldatetime = null,
@filasAfectadas int out
as
insert into THE_RIGHT_JOIN.CargaCredito values (@fecha,@dniCliente,@monto,@tipo,@numTarjeta,@fechaVen)
update THE_RIGHT_JOIN.Cliente set Cli_Saldo = Cli_Saldo + @monto where Cli_Dni = @dniCliente
set @filasAfectadas = @@ROWCOUNT
return;

GO

create function THE_RIGHT_JOIN.clientesDelProv(@cuit nvarchar(20))
returns table
as
return( select * from THE_RIGHT_JOIN.Cliente 
where Cli_Dni in 
	(select cupon_dniCli from THE_RIGHT_JOIN.Cupon join THE_RIGHT_JOIN.Oferta on Oferta_Codigo = codOferta 
	where cupon_FechaCanje is null and Oferta_CUIT = @cuit));

GO

create procedure THE_RIGHT_JOIN.comprarOferta(
@dni numeric(18,2),
@cantidad numeric(18,2),
@fecha date,
@codOferta nvarchar(50),
@resultado numeric(18,0) out)
/* 
 0 todo bien
 1 no hay saldo
 2 no hay cantidad 
 3 no esta disponible
 4 supera la cant maxima

*/
as
set @resultado = 0
declare @saldo numeric(18,2) = (select Cli_Saldo from THE_RIGHT_JOIN.Cliente where Cli_Dni = @dni)
declare @precio numeric(18,2) = (select Oferta_Precio from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) * @cantidad
declare @disponibilidad numeric(18,0) = (select Oferta_Cantidad from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta)
declare @cantMax numeric(18,0) = (select Oferta_CantxCli from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta)
if(@saldo >= @precio)
begin
	if(@disponibilidad >= @cantidad)
	begin
		if(@cantMax >= @cantidad)
		begin
			if((select Oferta_Disponible from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) = 1 and
			(select Oferta_Fecha_Ven from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) > @fecha and 
			@fecha > (select Oferta_Fecha from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta))
			begin
				update THE_RIGHT_JOIN.Oferta set Oferta_Cantidad = Oferta_Cantidad - @cantidad where Oferta_Codigo = @codOferta
				insert into THE_RIGHT_JOIN.Compra_Oferta values (@dni,@codOferta,@cantidad,@fecha)
				update THE_RIGHT_JOIN.Cliente set Cli_Saldo = Cli_Saldo - @precio where Cli_Dni = @dni
				while(@cantidad > 0)
				begin
					insert into THE_RIGHT_JOIN.Cupon values (@codOferta,@dni,null,@fecha,null)
					set @cantidad = @cantidad - 1
				end
			end
			else
			begin
				set @resultado = 3
				return;
			end
		end
		else
		begin
			set @resultado = 4
			return;
		end
	end
	else
	begin
		set @resultado = 2
		return;
	end
end
else
begin
	set @resultado = 1
	return;
end

GO

create procedure THE_RIGHT_JOIN.consumirOferta(@fecha date,@codCupon int ,@dniCli numeric(18,0),@filasAfectadas int out)
as
if(exists (select * from THE_RIGHT_JOIN.Cliente where Cli_Dni = @dniCli))
begin
update Cupon set cupon_FechaCanje = @fecha, cupon_dniCons = @dniCli where cupon_FechaCanje is null and idCupon = @codCupon
set @filasAfectadas = @@ROWCOUNT
end
else
set @filasAfectadas = -1
return;

GO

create procedure THE_RIGHT_JOIN.crearRol(@nombre nvarchar(255),@filasAfectadas int out)
as
begin
insert into Rol values(@nombre,1)
set @filasAfectadas = @@ROWCOUNT
end

GO

create procedure THE_RIGHT_JOIN.eliminarUsuario(@username nvarchar(255))
as
update THE_RIGHT_JOIN.Usuario SET Usuari_Habilitado = 0 WHERE Usuari_Username = @username

GO

create procedure THE_RIGHT_JOIN.facturarAProv(@cuit nvarchar(20), @fechaMin date, @fechaMax date, @fechaAct date,@importe int out, @numero int out)
as
insert into Factura select 'A',@fechaAct,sum(CompraOferta_Cantidad*Oferta_Precio), Oferta_CUIT 
	from Compra_Oferta join Oferta on Oferta_Codigo = CompraOferta_oferCodigo
	where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax
	group by Oferta_CUIT
 set @numero = (select IDENT_CURRENT('THE_RIGHT_JOIN.Factura'))
 insert into Item_Factura select 'A',@numero, CompraOferta_idCompra,CompraOferta_Cantidad*Oferta_Precio
	from Compra_Oferta join Oferta on CompraOferta_oferCodigo = Oferta_Codigo
	where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax
set @importe = (select Factura_total from Factura where Factura_tipoFactura = 'A' and Factura_numFactura = @numero)

GO

create procedure THE_RIGHT_JOIN.logueo(@usuario nvarchar(255), @pass nvarchar(255), @ret int out)
as
begin
if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Habilitado = 1))
begin
		if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Password = HASHBYTES('SHA2_256',@pass)) )
			begin
			set @ret = 0
			UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Intentos = 0 where Usuari_Username = @usuario
			end
		else
			begin
			UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Intentos = Usuari_Intentos + 1 where 
			Usuari_Username = @usuario
			set @ret = (SELECT Usuari_Intentos FROM THE_RIGHT_JOIN.Usuario WHERE Usuari_Username = @usuario)
			end
end
else
	set @ret = 4;
end

GO

create procedure THE_RIGHT_JOIN.modificarCliente
@dni numeric(18,0) = null,
@nombre nvarchar(255) = NULL,
@apellido nvarchar(255) = NULL,
@mail nvarchar(255) = NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@fechaNac datetime = NULL,
@telefono numeric(18,0) = NULL,
@codpost nvarchar(255) = NULL,
@localidad nvarchar(255) = NULL
AS
UPDATE THE_RIGHT_JOIN.Cliente set 
Cli_Nombre=@nombre,Cli_Apellido=@apellido,Cli_Mail=@mail,Cli_Direccion=@direccion,
Cli_Ciudad=@ciudad,Cli_Fecha_Nac=@fechaNac,Cli_Telefono=@telefono,Cli_CodPostal=@codpost,Cli_Localidad=@localidad
WHERE Cli_Dni = @dni

GO

USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[modificarProveedor]    Script Date: 22/11/2019 9:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [THE_RIGHT_JOIN].[modificarProveedor]
@cuit nvarchar(255)= null,
@RS nvarchar(255) = NULL,
@email nvarchar(255) = NULL,
@telefono numeric(18,0)= NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@idRubro int = NULL,
@contacto nvarchar(255) = NULL,
@postal nvarchar(255) = NULL

AS
UPDATE THE_RIGHT_JOIN.Proveedor set 
Provee_RS = @RS, Provee_Dom = @direccion, Provee_Ciudad = @ciudad, Provee_Telefono = @telefono,
Provee_Rubro = @idRubro, Provee_email = @email, Provee_postal = @postal, Provee_contacto = @contacto
WHERE Provee_CUIT= @cuit

GO

create procedure THE_RIGHT_JOIN.modificarRol(@idRol int,@nombre nvarchar(255), @habilitado numeric(1,0))
as
begin
update Rol set rol_Name = @nombre, rol_habilitado = @habilitado where id_Rol = @idRol
end

GO

create function THE_RIGHT_JOIN.aniosDisponibles()
returns table
as
return (select distinct year(Factura_fecha) as Anio from THE_RIGHT_JOIN.Factura)

GO

create function THE_RIGHT_JOIN.obtenerClientes()
returns table
as
return select * from THE_RIGHT_JOIN.Cliente

GO

create function THE_RIGHT_JOIN.obtenerCuponesPorCliente(@dni int)
returns table
return select * from THE_RIGHT_JOIN.Cupon where cupon_dniCli = @dni

GO

create function THE_RIGHT_JOIN.obtenerCuponesPorClienteYProv(@dni int, @cuit nvarchar(20))
returns table
return select Cupon.* from THE_RIGHT_JOIN.Cupon join Oferta on codOferta = Oferta_Codigo where cupon_dniCli = @dni and Oferta_CUIT = @cuit

GO

create procedure THE_RIGHT_JOIN.obtenerDNI(@username nvarchar(255), @dni int out)
as
set @dni = (Select Usuari_DNI from THE_RIGHT_JOIN.Usuario where Usuari_Username = @username)

GO

create function THE_RIGHT_JOIN.obtenerUnCliente(@dni numeric(18,0))
returns table
as
return select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Dni = @dni

GO

create function THE_RIGHT_JOIN.obtenerUnProveedor(@cuit nvarchar(255))
returns table
as
return select * from THE_RIGHT_JOIN.Proveedor JOIN Rubro ON (Provee_Rubro = idRubro) WHERE Provee_CUIT = @cuit

GO

create function [THE_RIGHT_JOIN].[ofertasAdquiridasPorCliente](@cuit nvarchar(255),@fechaMin date, @fechaMax date, @fechaAct date)
returns table
as
return select CompraOferta_oferCodigo,CompraOferta_Fecha,CompraOferta_Cantidad
from THE_RIGHT_JOIN.Compra_Oferta join THE_RIGHT_JOIN.Oferta on (CompraOferta_oferCodigo = Oferta_Codigo)
where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax

GO

create function THE_RIGHT_JOIN.provMaxDesc(@semestre date)
returns table
as
return (select top 5 Provee_RS, Provee_Dom, Provee_Rubro,Provee_CUIT,sum(Oferta_Precio)*100/sum(Oferta_Precio_Ficticio) porcentaje
from THE_RIGHT_JOIN.Oferta join THE_RIGHT_JOIN.Proveedor on Oferta_CUIT = Proveedor.Provee_CUIT
where Oferta_Fecha >= @semestre and DATEADD(MONTH,6,@semestre)> Oferta_Fecha
group by Provee_CUIT,Provee_RS, Provee_Dom, Provee_Rubro
order by(sum(Oferta_Precio)*100/sum(Oferta_Precio_Ficticio) ) desc);


GO

create function THE_RIGHT_JOIN.provMaxFact(@semestre DateTime)
returns table
as
return (select top 5 Provee_CUIT,Provee_RS,sum(Factura_total) facturacion
from THE_RIGHT_JOIN.Factura join THE_RIGHT_JOIN.Proveedor on Factura_CUIT = Provee_CUIT
where Factura_fecha >= @semestre and DATEADD(MONTH,6,@semestre)> Factura_fecha
group by Provee_CUIT,Provee_RS
order by sum(factura_total) desc);

GO

create function THE_RIGHT_JOIN.rolDerivaDe(@idRol int)
returns int
as
begin
declare @retorno int
set @retorno = 0
declare @idCliente int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'CLIENTE')
declare @idProv int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'PROVEEDOR')
if(not exists(select * from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name <> 'MODIFICAR PASSWORD'))
	return 0;
if((select rol_Name from Rol where id_Rol = @idRol) = 'ADMIN')
	return 1;
if(exists (select funcio_name from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name in (select funcio_name from THE_RIGHT_JOIN.Funcionalidad join THE_RIGHT_JOIN.FuncXRol on FuncXRol.idFunc = Funcionalidad.idFunc 
where idRol = @idCliente and Funcionalidad.idFunc not in (select f.idFunc from THE_RIGHT_JOIN.FuncXRol  f where f.idRol <> FuncXRol.idRol and f.idRol<= @idProv and f.idRol >= @idCliente))))
	set @retorno = @idCliente
else
	begin
		set @retorno = @idProv
	end
return @retorno;
end


GO

create function THE_RIGHT_JOIN.traerFuncDelRol(@rol int)
returns table
as
return (select Funcionalidad.idFunc,Funcionalidad.funcio_name from THE_RIGHT_JOIN.FuncXRol 
	join Funcionalidad on Funcionalidad.idFunc = FuncXRol.idFunc where FuncXRol.idRol = @rol);

GO

create function THE_RIGHT_JOIN.traerOfertasDisponibles(@fecha date)
returns table
as
return select * from THE_RIGHT_JOIN.Oferta  where @fecha >= Oferta_Fecha and @fecha <= Oferta_Fecha_Ven

GO

create function THE_RIGHT_JOIN.traerRolxUsuario(@username nvarchar(255))
returns table
as
return (select  Rol.id_Rol,Rol.rol_Name from RolXUsuario join Rol on RolXUsuario.idRol = Rol.id_Rol where idUser = 
(select u.Usuari_idUser from THE_RIGHT_JOIN.Usuario u where u.Usuari_Username = @username));


GO

create function THE_RIGHT_JOIN.traerUnaOferta(@idOferta nvarchar(50))
returns table
as
return select * from Oferta where Oferta_Codigo = @idOferta

GO

create function THE_RIGHT_JOIN.traerUnUser(@username nvarchar(255))
returns table
as
return (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @username);

GO

create function THE_RIGHT_JOIN.verFacturasProv(@tipo nvarchar(255), @numFactura int )
returns table
as
return (select * from Item_Factura where Item_numFactura = @numFactura and Item_tipoFactura = @tipo)

GO



