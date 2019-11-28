create procedure THE_RIGHT_JOIN.asignarFuncionalidad(@idRol int, @idFunc int)
as
begin
insert into FuncXRol values (@idRol,@idFunc)
end
go