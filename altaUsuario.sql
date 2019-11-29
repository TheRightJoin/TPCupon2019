USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 10/11/2019 18:57:52 ******/

create procedure THE_RIGHT_JOIN.altaUsuario
@usuario nvarchar(255) = null,
@pass nvarchar(255) = NULL,
@dni numeric(18,0) = NULL,
@cuit nvarchar(255) = NULL

AS
begin
INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado, Usuari_Intentos)
VALUES (@usuario, HASHBYTES('SHA2_256',@pass), @dni, @cuit, 1, 0)

if(@dni IS NOT NULL)
	begin
	insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
	values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_DNI = @dni),2)
	end
else
	begin
	insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
	values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_CUIT = @cuit),3)
	end
end