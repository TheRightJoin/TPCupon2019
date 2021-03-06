create function THE_RIGHT_JOIN.provMaxFact(@semestre DateTime)
returns table
as
return (select top 5 Provee_CUIT,Provee_RS,sum(Factura_total) facturacion
from THE_RIGHT_JOIN.Factura join THE_RIGHT_JOIN.Proveedor on Factura_CUIT = Provee_CUIT
where Factura_fecha >= @semestre and DATEADD(MONTH,6,@semestre)> Factura_fecha
group by Provee_CUIT,Provee_RS
order by sum(factura_total) desc);