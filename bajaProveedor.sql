create procedure THE_RIGHT_JOIN.bajaProveedor @cuit varchar(255)
AS
delete from THE_RIGHT_JOIN.Proveedor where Provee_CUIT = @cuit