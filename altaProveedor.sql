USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[altaProveedor]    Script Date: 22/11/2019 9:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [THE_RIGHT_JOIN].[altaProveedor]
@razonSocial nvarchar(255) = null,
@domicilio nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@telefono numeric(18,0) = NULL,
@cuit nvarchar(20) = NULL,
@idRubro int = NULL,
@activo numeric(1,0) = NULL,
@email nvarchar(255) = NULL,
@postal nvarchar(30) = NULL,
@contacto nvarchar(255) = NULL
AS
INSERT INTO THE_RIGHT_JOIN.Proveedor (Provee_RS, Provee_Dom, Provee_Ciudad, Provee_Telefono, 
									  Provee_CUIT, Provee_Rubro, Provee_Activo, Provee_email,
									  Provee_postal, Provee_contacto)
VALUES (@razonSocial,@domicilio,@ciudad,@telefono,@cuit,@idRubro,@activo,@email,@postal,@contacto)
