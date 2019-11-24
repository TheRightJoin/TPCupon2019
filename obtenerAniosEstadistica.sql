create function THE_RIGHT_JOIN.aniosDisponibles()
returns table
as
return (select distinct year(Factura_fecha) as Anio from THE_RIGHT_JOIN.Factura)