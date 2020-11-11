
IF EXISTS (
        SELECT type_desc, type
        FROM sys.procedures WITH(NOLOCK)
        WHERE NAME = 'ObtenerProductosSinCategoria'
            AND type = 'P'
      )
     DROP PROCEDURE ObtenerProductosSinCategoria
GO

CREATE PROCEDURE ObtenerProductosSinCategoria
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT p.* 
	FROM Producto p
		LEFT OUTER JOIN ProductoCategoria pc ON pc.IdProducto = p.IdProducto
	WHERE 
		pc.IdProducto is null
END
GO
