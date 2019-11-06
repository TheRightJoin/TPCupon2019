
--TABLA USUARIOS
select distinct Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Telefono,Cli_Fecha_Nac
from gd_esquema.Maestra

--TABLA PROVEEDORES
select distinct Provee_RS,Provee_Dom,Provee_Ciudad,Provee_Telefono,Provee_CUIT, 
    (select idRubro from THE_RIGHT_JOIN.Rubro where THE_RIGHT_JOIN.Rubro.Rubro_Descripcion = Provee_Rubro)
 from gd_esquema.Maestra

--TABLA RUBROS
select distinct Provee_Rubro from gd_esquema.Maestra

--TABLA CARGA_CREDITO (EN VEZ DE TRAER NOMBRE Y APELLIDO HAY Q HACER UN SUBSELECT Y TRAER EL IDCliente)
select Cli_Dni,Carga_Credito,Carga_Fecha,Tipo_Pago_Desc
from gd_esquema.Maestra
where Carga_Credito IS NOT NULL

--TABLA OFERTAS
select distinct Oferta_Codigo,Oferta_Fecha,Oferta_Fecha_Venc,Oferta_Precio,Oferta_Precio_Ficticio,Provee_RS,Oferta_Cantidad
from gd_esquema.Maestra
where Oferta_Codigo IS NOT NULL

select top 100000 * from gd_esquema.Maestra
where Factura_Nro IS NOT NULL