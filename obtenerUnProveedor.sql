create function THE_RIGHT_JOIN.obtenerUnProveedor(@cuit nvarchar(255))
returns table
as
return select * from THE_RIGHT_JOIN.Proveedor JOIN Rubro ON (Provee_Rubro = idRubro) WHERE Provee_CUIT = @cuit