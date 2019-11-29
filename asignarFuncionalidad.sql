create procedure THE_RIGHT_JOIN.asignarFuncionalidad(@idRol int, @idFunc int, @flag int out)
as
begin
if(not exists (select * from FuncXRol where idRol = @idRol and idFunc = @idFunc))
begin
	insert into FuncXRol values (@idRol,@idFunc)
	set @flag = @@ROWCOUNT
end
else
	set @flag = 0
end
go