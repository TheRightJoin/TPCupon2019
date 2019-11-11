create procedure THE_RIGHT_JOIN.bajaCliente @dni numeric(18,0)
AS
update THE_RIGHT_JOIN.Cliente set Cli_Activo = 0 where Cli_Dni = @dni