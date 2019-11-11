create function THE_RIGHT_JOIN.traerUnaOferta(@idOferta nvarchar(50))
returns table
as
return select * from Oferta where Oferta_Codigo = @idOferta