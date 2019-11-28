create function THE_RIGHT_JOIN.traerFuncDelRol(@rol int)
returns table
as
return (select Funcionalidad.funcio_name from THE_RIGHT_JOIN.FuncXRol 
	join Funcionalidad on Funcionalidad.idFunc = FuncXRol.idFunc where FuncXRol.idRol = @rol);

select * from THE_RIGHT_JOIN.traerFuncDelRol(1)