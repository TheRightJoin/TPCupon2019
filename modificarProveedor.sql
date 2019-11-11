create procedure THE_RIGHT_JOIN.modificarProveedor
@cuit nvarchar(255)= null,
@RS nvarchar(255) = NULL,
@email nvarchar(255) = NULL,
@telefono numeric(18,0)= NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@rubro int = NULL,
@contacto nvarchar(255) = NULL,
@postal nvarchar(255) = NULL

AS
UPDATE THE_RIGHT_JOIN.Proveedor set 
Provee_RS = @RS, Provee_Dom = @direccion, Provee_Ciudad = @ciudad, Provee_Telefono = @telefono,
Provee_Rubro = @rubro, Provee_email = @email, Provee_postal = @postal, Provee_contacto = @contacto
WHERE Provee_CUIT= @cuit