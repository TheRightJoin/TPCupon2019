create procedure THE_RIGHT_JOIN.logueo(@usuario nvarchar(255), @pass nvarchar(255), @ret int out)
as
begin
if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Habilitado = 1))
begin
		if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Password = HASHBYTES('SHA2_256',@pass)) )
			begin
			set @ret = 0
			UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Intentos = 0 where Usuari_Username = @usuario
			end
		else
			begin
			UPDATE THE_RIGHT_JOIN.Usuario SET Usuari_Intentos = Usuari_Intentos + 1 where 
			Usuari_Username = @usuario
			set @ret = (SELECT Usuari_Intentos FROM THE_RIGHT_JOIN.Usuario WHERE Usuari_Username = @usuario)
			end
end
else
	set @ret = 4;
end