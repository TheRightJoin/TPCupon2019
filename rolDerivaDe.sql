create function THE_RIGHT_JOIN.rolDerivaDe(@idRol int)
returns int
as
begin
declare @retorno int
set @retorno = 0
declare @idCliente int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'CLIENTE')
declare @idProv int = (select r.id_Rol from THE_RIGHT_JOIN.Rol r where r.rol_Name = 'PROVEEDOR')
if(not exists(select * from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name <> 'MODIFICAR PASSWORD'))
	return 0;
if((select rol_Name from Rol where id_Rol = @idRol) = 'ADMIN')
	return 1;
if(exists (select funcio_name from THE_RIGHT_JOIN.traerFuncDelRol(@idRol) where funcio_name in (select funcio_name from THE_RIGHT_JOIN.Funcionalidad join THE_RIGHT_JOIN.FuncXRol on FuncXRol.idFunc = Funcionalidad.idFunc 
where idRol = @idCliente and Funcionalidad.idFunc not in (select f.idFunc from THE_RIGHT_JOIN.FuncXRol  f where f.idRol <> FuncXRol.idRol and f.idRol<= @idProv and f.idRol >= @idCliente))))
	set @retorno = @idCliente
else
	begin
		set @retorno = @idProv
	end
return @retorno;
end
go
