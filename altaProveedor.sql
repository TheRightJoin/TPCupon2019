CREATE procedure [THE_RIGHT_JOIN].[altaProveedor]
@razonSocial nvarchar(255) = null,
@domicilio nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@telefono numeric(18,0) = NULL,
@cuit nvarchar(20) = NULL,
@idRubro int = NULL,
@activo numeric(1,0) = NULL,
@email nvarchar(255) = NULL,
@postal nvarchar(30) = NULL,
@contacto nvarchar(255) = NULL,
@retorno numeric(18,0) out

-- 0 si lo creo
-- -1 si ya existe 

AS
set @retorno = 0
if(not exists (select * from THE_RIGHT_JOIN.Proveedor WHERE Provee_CUIT = @cuit))
	Begin
	INSERT INTO THE_RIGHT_JOIN.Proveedor (Provee_RS, Provee_Dom, Provee_Ciudad, Provee_Telefono, 
									  Provee_CUIT, Provee_Rubro, Provee_Activo, Provee_email,
									  Provee_postal, Provee_contacto)
	VALUES (@razonSocial,@domicilio,@ciudad,@telefono,@cuit,@idRubro,@activo,@email,@postal,@contacto)
	End
else
set @retorno = -1



