create procedure THE_RIGHT_JOIN.bloquearUser(@username nvarchar(255))
as
update Usuario set Usuari_Habilitado = 0 where Usuari_Username = @username