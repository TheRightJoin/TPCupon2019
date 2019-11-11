create function THE_RIGHT_JOIN.traerOfertasDisponibles(@fecha date)
returns table
as
return select * from Oferta where Oferta_Disponible = 1 and @fecha > Oferta_Fecha_Ven