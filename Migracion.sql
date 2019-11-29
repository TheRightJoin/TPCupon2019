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
 -- ·ÈÌÛ˙‡ËÏÚ˘„ı‚ÍÓÙ˚‰ÎÔˆ¸Ò—Á« ¡…Õ”⁄¿»Ã“Ÿ√’¬ Œ‘€ƒÀœ÷‹ 
    RETURN 	
	REPLACE(REPLACE( /*vocales √’*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ƒÀœ÷‹*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ¬ Œ‘€*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ¿»Ã“Ÿ*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ¡…Õ”⁄*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales Ò—Á«  incluido espacio en blanco*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ‰ÎÔˆ¸*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ‚ÍÓÙ˚*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ‡ËÏÚ˘*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ·ÈÌÛ˙*/ @Cadena, '·', 'a'), 'È','e'), 'Ì', 'i'), 'Û', 'o'), '˙','u')		
			,'‡','a'),'Ë','e'),'Ï','i'),'Ú','o'),'˘','u')
			,'‚','a'),'Í','e'),'Ó','i'),'Ù','o'),'˚','u')
			,'‰','a'),'Î','e'),'Ô','i'),'ˆ','o'),'¸','u')
			,'Ò','n'),'—','N'),'Á','c'),'«','C'),' ','')
			,'¡','A'),'…','E'),'Õ','I'),'”','O'),'⁄','U') 
			,'¿','A'),'»','E'),'Ã','I'),'“','O'),'Ÿ','U') 
			,'¬','A'),' ','E'),'Œ','I'),'‘','O'),'€','U')
			,'ƒ','A'),'À','E'),'œ','I'),'÷','O'),'‹','U') 
			,'√','A'),'’','O')  
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
into THE_RIGHT_JOIN.Cliente select distinct Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Fecha_Nac,NULL,Cli_Telefono,NULL,NULL,NULL
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

--TABLA OFERTAS
--LISTO
insert into THE_RIGHT_JOIN.Oferta select distinct Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Cantidad,Oferta_Descripcion,
Oferta_Codigo,Provee_CUIT,Oferta_Cantidad, null
from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL


--TABLA Compra_Oferta
--LISTO
insert into THE_RIGHT_JOIN.Compra_Oferta select Cli_Dni,Oferta_Codigo,COUNT(*)as cant,Oferta_Fecha_Compra from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL and Factura_Nro IS NULL
GROUP BY Cli_Dni,Oferta_Codigo,Oferta_Fecha_Compra,Factura_Nro
order by Cli_Dni,Oferta_Codigo,Factura_Nro


--TABLA Cupon
--LISTO
insert into THE_RIGHT_JOIN.Cupon select Oferta_Codigo,Cli_Dni, Oferta_Entregado_Fecha from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL

--TABLA Factura
--LISTO
set Identity_Insert THE_RIGHT_JOIN.Factura on

insert into THE_RIGHT_JOIN.Factura (Factura_tipoFactura, Factura_numFactura, Factura_fecha, Factura_total, Factura_CUIT) select 'A',Factura_Nro,Factura_Fecha,sum(Oferta_Precio),Provee_CUIT from gd_esquema.Maestra
where Factura_Nro IS NOT NULL
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
insert into THE_RIGHT_JOIN.Funcionalidad values ('MODIFICAR PASSWORD')

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
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(1,THE_RIGHT_JOIN.traerFunc('MODIFICAR PASSWORD'))

INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(2,THE_RIGHT_JOIN.traerFunc('CARGAR CREDITO'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(2,THE_RIGHT_JOIN.traerFunc('COMPRAR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(2,THE_RIGHT_JOIN.traerFunc('MODIFICAR PASSWORD'))

INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(3,THE_RIGHT_JOIN.traerFunc('CONSUMIR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(3,THE_RIGHT_JOIN.traerFunc('GENERAR OFERTA'))
INSERT INTO THE_RIGHT_JOIN.FuncXRol VALUES(3,THE_RIGHT_JOIN.traerFunc('MODIFICAR PASSWORD'))

--ROLXUSUARIO
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,2 from THE_RIGHT_JOIN.Usuario where Usuari_DNI IS NOT NULL
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,3 from THE_RIGHT_JOIN.Usuario where Usuari_CUIT IS NOT NULL

--CREAR USUARIO ADMIN
INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado)
VALUES ('admin', HASHBYTES('SHA2_256',N'w23e'), NULL, NULL, 1)
insert into THE_RIGHT_JOIN.RolXUsuario select Usuari_idUser,1 from THE_RIGHT_JOIN.Usuario where Usuari_Username = 'admin'
