create procedure THE_RIGHT_JOIN.consumirOferta(@fecha date,@codCupon int ,@dniCli numeric(18,0),@filasAfectadas int out)
as
if(exists (select * from THE_RIGHT_JOIN.Cliente where Cli_Dni = @dniCli))
begin
update Cupon set cupon_FechaCanje = @fecha, cupon_dniCons = @dniCli where cupon_FechaCanje is null and idCupon = @codCupon
set @filasAfectadas = @@ROWCOUNT
end
else
set @filasAfectadas = -1
return;

 