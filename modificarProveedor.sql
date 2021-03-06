USE [GD2C2019]
GO
/****** Object:  StoredProcedure [THE_RIGHT_JOIN].[modificarProveedor]    Script Date: 22/11/2019 9:09:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [THE_RIGHT_JOIN].[modificarProveedor]
@cuit nvarchar(255)= null,
@RS nvarchar(255) = NULL,
@email nvarchar(255) = NULL,
@telefono numeric(18,0)= NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@idRubro int = NULL,
@contacto nvarchar(255) = NULL,
@postal nvarchar(255) = NULL

AS
UPDATE THE_RIGHT_JOIN.Proveedor set 
Provee_RS = @RS, Provee_Dom = @direccion, Provee_Ciudad = @ciudad, Provee_Telefono = @telefono,
Provee_Rubro = @idRubro, Provee_email = @email, Provee_postal = @postal, Provee_contacto = @contacto
WHERE Provee_CUIT= @cuit