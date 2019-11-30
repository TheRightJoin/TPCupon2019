create function THE_RIGHT_JOIN.clientesDelProv(@cuit nvarchar(20))
returns table
as
return( select * from THE_RIGHT_JOIN.Cliente 
where Cli_Dni in 
	(select cupon_dniCli from THE_RIGHT_JOIN.Cupon join THE_RIGHT_JOIN.Oferta on Oferta_Codigo = codOferta 
	where cupon_FechaCanje is null and Oferta_CUIT = @cuit));