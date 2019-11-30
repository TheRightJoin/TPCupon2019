create procedure THE_RIGHT_JOIN.consumirOferta(@fecha date,@codCupon int ,@dniCli numeric(18,0),@filasAfectadas int out)
as
update Cupon set cupon_FechaCanje = @fecha, cupon_dniCli = @dniCli where cupon_FechaCanje is null and idCupon = @codCupon
set @filasAfectadas = @@ROWCOUNT
return;

 