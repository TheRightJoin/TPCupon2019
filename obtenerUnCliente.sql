create function THE_RIGHT_JOIN.obtenerUnCliente(@dni numeric(18,0))
returns table
as
return select * from THE_RIGHT_JOIN.Cliente WHERE Cli_Dni = @dni