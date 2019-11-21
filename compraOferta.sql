create procedure THE_RIGHT_JOIN.comprarOferta(
@dni numeric(18,2),
@cantidad numeric(18,2),
@fecha date,
@codOferta nvarchar(50),
@resultado numeric(18,0) out)
/* 
 0 todo bien
 1 no hay saldo
 2 no hay cantidad 
 4 supera la cant maxima
 3 no esta disponible
*/
as
declare @saldo numeric(18,2) = (select Cli_Saldo from THE_RIGHT_JOIN.Cliente where Cli_Dni = @dni)
declare @precio numeric(18,2) = (select Oferta_Precio from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) * @cantidad
declare @disponibilidad numeric(18,0) = (select Oferta_Cantidad from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta)
declare @cantMax numeric(18,0) = (select Oferta_CantxCli from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta)
if(@saldo >= @precio)
begin
	if(@disponibilidad >= @cantidad)
	begin
		if(@cantMax >= @cantidad)
		begin
			if((select Oferta_Disponible from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) = 1 and
			(select Oferta_Fecha_Ven from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta) < @fecha and 
			@fecha > (select Oferta_Fecha from THE_RIGHT_JOIN.Oferta where Oferta_Codigo = @codOferta))
			begin
				update THE_RIGHT_JOIN.Oferta set Oferta_Cantidad = Oferta_Cantidad - @cantidad
				insert into THE_RIGHT_JOIN.Compra_Oferta values (@dni,@codOferta,@cantidad,@fecha)
				update THE_RIGHT_JOIN.Cliente set Cli_Saldo = Cli_Saldo - @precio
				while(@cantidad > 0)
				begin
					insert into THE_RIGHT_JOIN.Cupon values (@codOferta,@dni,null)
					set @cantidad = @cantidad - 1
				end
			end
			else
			begin
				set @resultado = 3
				return;
			end
		end
		else
		begin
			set @resultado = 4
			return;
		end
	end
	else
	begin
		set @resultado = 2
		return;
	end
end
else
begin
	set @resultado = 1
	return;
end