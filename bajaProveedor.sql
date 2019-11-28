create procedure THE_RIGHT_JOIN.bajaProveedor @CUIT nvarchar(255)
AS
update THE_RIGHT_JOIN.Proveedor set Provee_Activo= 0 where Provee_CUIT = @CUIT