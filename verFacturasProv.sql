create function THE_RIGHT_JOIN.verFacturasProv(@tipo nvarchar(255), @numFactura int )
returns table
as
return (select * from Item_Factura where Item_numFactura = @numFactura and Item_tipoFactura = @tipo)