create procedure THE_RIGHT_JOIN.altaCliente
@dni numeric(18,0) = null,
@nombre nvarchar(255) = NULL,
@apellido nvarchar(255) = NULL,
@mail nvarchar(255) = NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@fechaNac datetime = NULL,
@telefono numeric(18,0) = NULL
AS
INSERT INTO THE_RIGHT_JOIN.Cliente (Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Fecha_Nac,Cli_Telefono)
VALUES (@dni,@nombre,@apellido,@mail,@direccion,@ciudad,@fechaNac,@telefono)