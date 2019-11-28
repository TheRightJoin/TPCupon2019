create function [THE_RIGHT_JOIN].[ofertasAdquiridasPorCliente](@cuit nvarchar(255),@fechaMin date, @fechaMax date, @fechaAct date)
returns table
as
return select CompraOferta_oferCodigo,CompraOferta_Fecha,CompraOferta_Cantidad
from THE_RIGHT_JOIN.Compra_Oferta join THE_RIGHT_JOIN.Oferta on (CompraOferta_oferCodigo = Oferta_Codigo)
where Oferta_CUIT = @cuit and CompraOferta_Fecha >= @fechaMin and CompraOferta_Fecha <= @fechaMax