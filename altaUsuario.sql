USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 10/11/2019 18:57:52 ******/

create procedure THE_RIGHT_JOIN.altaUsuario
@usuario nvarchar(255) = null,
@pass nvarchar(255) = NULL,
@dni numeric(18,0) = NULL,
@cuit nvarchar(255) = NULL,
@idRol int = null,
@retorno numeric(18,0) out

-- retorna 0 si ta todo joya
-- retona -1 si existe uno con el mismo username

AS
begin
set @retorno = 0
if(not exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario))
	begin
		INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado, Usuari_Intentos)
		VALUES (@usuario, HASHBYTES('SHA2_256',@pass), @dni, @cuit, 1, 0)

		if(@dni IS NOT NULL)
			begin
			insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
			values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_DNI = @dni),@idRol)
			end
		else
			begin
			insert into THE_RIGHT_JOIN.RolXUsuario (idUser,idRol)
			values ((select Usuari_idUser from THE_RIGHT_JOIN.Usuario WHERE Usuari_CUIT = @cuit),@idRol)
			end
		end
	else
set @retorno = -1
end

