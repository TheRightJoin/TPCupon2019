create procedure THE_RIGHT_JOIN.consumirOferta(@fecha date,@codCupon nvarchar(50),@dniCli numeric(18,0),@filasAfectadas int out)
as
update Cupon set cupon_FechaCanje = @fecha where cupon_FechaCanje is not null and cupon_dniCli = @dniCli
set @filasAfectadas = @@ROWCOUNT
return; 