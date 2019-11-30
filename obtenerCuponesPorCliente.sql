create function THE_RIGHT_JOIN.obtenerCuponesPorCliente(@dni int)
returns table
return select * from THE_RIGHT_JOIN.Cupon where cupon_dniCli = @dni
