create function THE_RIGHT_JOIN.provMaxDesc(@semestre date)
returns table
as
return (select top 5 Provee_RS, Provee_Dom, Provee_Rubro,Provee_CUIT,sum(Oferta_Precio)*100/sum(Oferta_Precio_Ficticio) porcentaje
from THE_RIGHT_JOIN.Oferta join THE_RIGHT_JOIN.Proveedor on Oferta_CUIT = Proveedor.Provee_CUIT
where Oferta_Fecha >= @semestre and DATEADD(MONTH,6,@semestre)> Oferta_Fecha
group by Provee_CUIT,Provee_RS, Provee_Dom, Provee_Rubro
order by(sum(Oferta_Precio)*100/sum(Oferta_Precio_Ficticio) ) desc);
