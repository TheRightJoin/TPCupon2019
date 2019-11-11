create procedure THE_RIGHT_JOIN.modificarCliente
@dni numeric(18,0) = null,
@nombre nvarchar(255) = NULL,
@apellido nvarchar(255) = NULL,
@mail nvarchar(255) = NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@fechaNac datetime = NULL,
@telefono numeric(18,0) = NULL,
@codpost nvarchar(255) = NULL,
@localidad nvarchar(255) = NULL
AS
UPDATE THE_RIGHT_JOIN.Cliente set 
Cli_Nombre=@nombre,Cli_Apellido=@apellido,Cli_Mail=@mail,Cli_Direccion=@direccion,
Cli_Ciudad=@ciudad,Cli_Fecha_Nac=@fechaNac,Cli_Telefono=@telefono,Cli_CodPostal=@codpost,Cli_Localidad=@localidad
WHERE Cli_Dni = @dni
