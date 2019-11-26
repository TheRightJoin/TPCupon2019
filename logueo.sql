create function THE_RIGHT_JOIN.logueo(@usuario nvarchar(255), @pass nvarchar(255),@intentos int)
returns int
as
begin
if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Habilitado = 1))
begin
		if(exists (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @usuario and Usuari_Password = HASHBYTES('SHA2_256',@pass)) )
			return 0;
		else
			set @intentos = @intentos + 1
end
else
	return 4;
return @intentos;
end

