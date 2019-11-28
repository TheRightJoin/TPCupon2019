create function THE_RIGHT_JOIN.traerRolxUsuario(@username nvarchar(255))
returns table
as
return (select  Rol.id_Rol,Rol.rol_Name from RolXUsuario join Rol on RolXUsuario.idRol = Rol.id_Rol where idUser = 
(select u.Usuari_idUser from THE_RIGHT_JOIN.Usuario u where u.Usuari_Username = @username));


