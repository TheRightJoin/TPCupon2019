create procedure THE_RIGHT_JOIN.facturarAProv(@cuit nvarchar(20), @fechaMin date, @fechaMax date, @fechaAct date,@importe int out, @numero int out)
as
insert into Factura select 'A',@fechaAct,sum(CompraOferta_Cantidad*Oferta_Precio), Oferta_CUIT 
	from Compra_Oferta join Oferta on Oferta_Codigo = CompraOferta_oferCodigo
	where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax
	group by Oferta_CUIT
 set @numero = (select IDENT_CURRENT('Factura'))
 insert into Item_Factura select 'A',@numero, CompraOferta_idCompra,CompraOferta_Cantidad*Oferta_Precio
	from Compra_Oferta join Oferta on CompraOferta_oferCodigo = Oferta_Codigo
	where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax
set @importe = (select Factura_total from Factura where Factura_tipoFactura = 'A' and Factura_numFactura = @numero)