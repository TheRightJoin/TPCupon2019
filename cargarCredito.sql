create procedure THE_RIGHT_JOIN.cargarCredito
@fecha date = null,
@dniCliente numeric(18,0) = null,
@tipo nvarchar(255) = null,
@monto numeric(18,2) = null,
@numTarjeta numeric(18,0) = null,
@fechaVen smalldatetime = null,
@filasAfectadas int out
as
insert into THE_RIGHT_JOIN.CargaCredito values (@fecha,@dniCliente,@monto,@tipo,@numTarjeta,@fechaVen)
update THE_RIGHT_JOIN.Cliente set Cli_Saldo = Cli_Saldo + @monto where Cli_Dni = @dniCliente
set @filasAfectadas = @@ROWCOUNT
return;