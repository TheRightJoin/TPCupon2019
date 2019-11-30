create function THE_RIGHT_JOIN.obtenerCuponesPorClienteYProv(@dni int, @cuit nvarchar(20))
returns table
return select Cupon.* from THE_RIGHT_JOIN.Cupon join Oferta on codOferta = Oferta_Codigo where cupon_dniCli = @dni and Oferta_CUIT = @cuit