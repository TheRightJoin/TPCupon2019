create procedure THE_RIGHT_JOIN.consumirOferta(@fecha date,@codCupon nvarchar(50),@dniCli numeric(18,0),@filasAfectadas int out)
as
update Cupon set cupon_FechaCanje = @fecha, cupon_dniCli = @dniCli where cupon_FechaCanje is not null and idCupon = @codCupon
set @filasAfectadas = @@ROWCOUNT
return;

 