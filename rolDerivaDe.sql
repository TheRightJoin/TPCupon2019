create function THE_RIGHT_JOIN.rolDerivaDe(@idRol int)
returns int
as
begin
declare @retorno int
set @retorno = 0
declare @idCliente int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'CLIENTE')
declare @idProv int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'PROVEEDOR')
if(exists (select funcio_name from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name in (select funcio_name from THE_RIGHT_JOIN.Funcionalidad join THE_RIGHT_JOIN.FuncXRol on FuncXRol.idFunc = Funcionalidad.idFunc 
where idRol = @idCliente and Funcionalidad.idFunc not in (select f.idFunc from THE_RIGHT_JOIN.FuncXRol  f where f.idRol <> FuncXRol.idRol and f.idRol<= @idProv))))
	set @retorno = @idCliente
else
	begin
	if(exists (select funcio_name from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name in (select funcio_name from THE_RIGHT_JOIN.Funcionalidad join THE_RIGHT_JOIN.FuncXRol on FuncXRol.idFunc = Funcionalidad.idFunc 
	where idRol = @idProv and Funcionalidad.idFunc not in (select f.idFunc from THE_RIGHT_JOIN.FuncXRol  f where f.idRol <> FuncXRol.idRol and f.idRol <= @idProv))))
		set @retorno = @idProv
	end
return @retorno;
end
go

