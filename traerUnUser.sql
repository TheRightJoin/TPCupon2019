create function THE_RIGHT_JOIN.traerUnUser(@username nvarchar(255))
returns table
as
return (select * from THE_RIGHT_JOIN.Usuario where Usuari_Username = @username);