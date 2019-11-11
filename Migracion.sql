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
Oferta_Codigo,NULL,NULL,Provee_CUIT
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