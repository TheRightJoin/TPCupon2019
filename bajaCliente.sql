create procedure THE_RIGHT_JOIN.bajaCliente @dni numeric(18,0)
AS
delete from THE_RIGHT_JOIN.Cliente where Cli_Dni = @dni