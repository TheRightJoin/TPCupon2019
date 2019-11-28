create procedure THE_RIGHT_JOIN.modificarRol(@idRol int,@nombre nvarchar(255), @habilitado numeric(1,0))
as
begin
update Rol set rol_Name = @nombre, rol_habilitado = @habilitado where id_Rol = @idRol
end