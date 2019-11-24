create procedure THE_RIGHT_JOIN.altaCliente
@dni numeric(18,0) = null,
@nombre nvarchar(255) = NULL,
@apellido nvarchar(255) = NULL,
@mail nvarchar(255) = NULL,
@direccion nvarchar(255) = NULL,
@ciudad nvarchar(255) = NULL,
@fechaNac datetime = NULL,
@telefono numeric(18,0) = NULL,
@codpost nvarchar(255) = NULL,
@localidad nvarchar(255) = NULL,
@retorno int out
AS
if(not exists (select * from Cliente 
					where Cli_Nombre = @nombre and
					 Cli_Apellido = @apellido and 
					 Cli_Mail = @mail and
					 Cli_Direccion = @direccion and
					 Cli_Ciudad = @ciudad and
					 Cli_Fecha_Nac = @fechaNac and
					 Cli_Telefono = @telefono and
					 Cli_CodPostal = @codpost and
					 Cli_Localidad = @localidad and
					 Cli_Activo = 1))
begin
INSERT INTO THE_RIGHT_JOIN.Cliente (Cli_Dni,Cli_Nombre,Cli_Apellido,Cli_Mail,Cli_Direccion,Cli_Ciudad,Cli_Fecha_Nac,Cli_Telefono,Cli_CodPostal,Cli_Localidad,Cli_Activo,Cli_Saldo)
VALUES (@dni,@nombre,@apellido,@mail,@direccion,@ciudad,@fechaNac,@telefono,@codpost,@localidad,1,200)
set @retorno = @@ROWCOUNT
end
else
set @retorno = -1
