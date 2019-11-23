create function THE_RIGHT_JOIN.traerRolxUsuario(@idUser numeric(18,0))
returns table
as
return (select Rol.rol_Name from RolXUsuario join Rol on RolXUsuario.idRol = Rol.id_Rol where idUser = @idUser);