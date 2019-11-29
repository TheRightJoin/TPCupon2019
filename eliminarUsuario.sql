create procedure THE_RIGHT_JOIN.eliminarUsuario(@username nvarchar(255))
as
update THE_RIGHT_JOIN.Usuario SET Usuari_Habilitado = 0 WHERE Usuari_Username = @username