create procedure THE_RIGHT_JOIN.crearRol(@nombre nvarchar(255),@filasAfectadas int out)
as
begin
insert into Rol values(@nombre,1)
set @filasAfectadas = @@ROWCOUNT
end