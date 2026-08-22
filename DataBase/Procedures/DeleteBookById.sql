CREATE PROCEDURE dbo.DeleteBookById
	@Id INT,
	@RowsAffected INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Books
	WHERE Id = @Id;

	SET @RowsAffected = @@ROWCOUNT;
END;
GO