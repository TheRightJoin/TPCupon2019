create procedure cambiarContra (@usuari nvarchar(255), @pass nvarchar(255))
as
UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Password = HASHBYTES('SHA2_256', @pass) WHERE Usuari_Username = @usuari