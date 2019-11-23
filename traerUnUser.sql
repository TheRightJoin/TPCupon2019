create function THE_RIGHT_JOIN.traerUnUser(@username nvarchar(255))
returns table
as
return (select * from Usuario where Usuari_Username = @username);