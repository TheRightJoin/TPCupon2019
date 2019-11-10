USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 10/11/2019 18:57:52 ******/

CREATE procedure THE_RIGHT_JOIN.altaProveedor
@razonSocial nvarchar(255) = null,
@domicilio nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@telefono numeric(18,0) = NULL,
@cuit nvarchar(20) = NULL,
@rubro int = NULL,
@activo numeric(1,0) = NULL,
@email nvarchar(255) = NULL,
@postal nvarchar(30) = NULL,
@contacto nvarchar(255) = NULL
AS
INSERT INTO THE_RIGHT_JOIN.Proveedor (Provee_RS, Provee_Dom, Provee_Ciudad, Provee_Telefono, 
									  Provee_CUIT, Provee_Rubro, Provee_Activo, Provee_email,
									  Provee_postal, Provee_contacto)
VALUES (@razonSocial,@domicilio,@ciudad,@telefono,@cuit,@rubro,@activo,@email,@postal,@contacto)
