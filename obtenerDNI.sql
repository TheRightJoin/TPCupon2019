create procedure THE_RIGHT_JOIN.obtenerDNI(@username nvarchar(255), @dni int out)
as
set @dni = (Select Usuari_DNI from THE_RIGHT_JOIN.Usuario where Usuari_Username = @username)

