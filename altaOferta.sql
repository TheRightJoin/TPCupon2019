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
@filasAfectadas int out
as
insert into THE_RIGHT_JOIN.Oferta (Oferta_Codigo,Oferta_Precio_Ficticio,Oferta_Fecha,Oferta_Fecha_Ven,Oferta_Cantidad,Oferta_Descripcion,Oferta_Disponible,Oferta_CUIT)
values(@codigo,@precio,@precioFicticio,@fecha,@fecha_ven,@cantidad,@desc,@disponible,@cuit)
set @filasAfectadas = @@ROWCOUNT
return;