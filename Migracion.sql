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
    (select idRubro from THE_RIGHT_JOIN.Rubro R where R.Rubro_Descripcion = Provee_Rubro),NULL
 from gd_esquema.Maestra WHERE Provee_CUIT IS NOT NULL


--TABLA CARGA_CREDITO
--LISTO
insert into THE_RIGHT_JOIN.CargaCredito select Carga_Fecha,Cli_Dni,Carga_Credito,Tipo_Pago_Desc,NULL,NULL
from gd_esquema.Maestra
where Carga_Credito IS NOT NULL

--TABLA OFERTAS
--LISTO
insert into THE_RIGHT_JOIN.Oferta select distinct Oferta_Precio,Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Cantidad,Oferta_Descripcion,
Oferta_Codigo,NULL,NULL,Provee_CUIT,Oferta_Cantidad
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
insert into THE_RIGHT_JOIN.Cupon select Oferta_Codigo,Cli_Dni from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL

--TABLA Factura
--LISTO
insert into THE_RIGHT_JOIN.Factura select 'A',Factura_Nro,Factura_Fecha,sum(Oferta_Precio),Provee_CUIT from gd_esquema.Maestra
where Factura_Nro IS NOT NULL
group by Factura_Nro,Factura_Fecha,Provee_CUIT

--Tabla Item
--LISTO
insert into THE_RIGHT_JOIN.Item_Factura select 'A',Factura_Nro,CompraOferta_idCompra,CompraOferta_Cantidad*Oferta_Precio as monto from gd_esquema.Maestra,THE_RIGHT_JOIN.Compra_Oferta
where Factura_Nro IS NOT NULL and Cli_Dni = CompraOferta_dniClie and Oferta_Codigo = CompraOferta_oferCodigo and Oferta_Fecha_Compra = CompraOferta_Fecha
end

--USUARIOS
--LA FUNCION DE ABAJO LA NECESITAMOS PARA LIMPIAR LOS CARACTERES ESPECIALES
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
 -- �������������������������� ���������������������� 
    RETURN 	
	REPLACE(REPLACE( /*vocales ��*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales ����  incluido espacio en blanco*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/
	REPLACE(REPLACE(REPLACE(REPLACE(REPLACE( /*vocales �����*/ @Cadena, '�', 'a'), '�','e'), '�', 'i'), '�', 'o'), '�','u')		
			,'�','a'),'�','e'),'�','i'),'�','o'),'�','u')
			,'�','a'),'�','e'),'�','i'),'�','o'),'�','u')
			,'�','a'),'�','e'),'�','i'),'�','o'),'�','u')
			,'�','n'),'�','N'),'�','c'),'�','C'),' ','')
			,'�','A'),'�','E'),'�','I'),'�','O'),'�','U') 
			,'�','A'),'�','E'),'�','I'),'�','O'),'�','U') 
			,'�','A'),'�','E'),'�','I'),'�','O'),'�','U')
			,'�','A'),'�','E'),'�','I'),'�','O'),'�','U') 
			,'�','A'),'�','O')  
END

insert into THE_RIGHT_JOIN.Usuario 
select THE_RIGHT_JOIN.LimpiarCaracteres( LOWER( REPLACE( Cli_Nombre+Cli_Apellido,' ', '')))
,HASHBYTES('SHA2_256','password') 
,Cli_Dni,NULL,1 
from THE_RIGHT_JOIN.Cliente

insert into THE_RIGHT_JOIN.Usuario
select Provee_CUIT, HASHBYTES('SHA2_256','password'), NULL, Provee_CUIT,1
 from THE_RIGHT_JOIN.Proveedor