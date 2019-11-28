create procedure THE_RIGHT_JOIN.bajaRol(@idRol int)
as
begin
update Rol set rol_habilitado = 0 where id_Rol = @idRol
end