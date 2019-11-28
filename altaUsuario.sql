USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 10/11/2019 18:57:52 ******/

CREATE procedure THE_RIGHT_JOIN.altaUsuario
@usuario nvarchar(255) = null,
@pass nvarchar(255) = NULL,
@dni numeric(18,0) = NULL,
@cuit nvarchar(255) = NULL

AS
INSERT INTO THE_RIGHT_JOIN.Usuario(Usuari_Username, Usuari_Password, Usuari_DNI, Usuari_CUIT, Usuari_Habilitado)
VALUES (@usuario, HASHBYTES('SHA2_256',@pass), @dni, @cuit, 1)
