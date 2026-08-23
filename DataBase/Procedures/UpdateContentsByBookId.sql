CREATE PROCEDURE dbo.UpdateContentsByBookId
	@Id INT,
	@Contents NVARCHAR(MAX) = NULL,
	@RowsAffected INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Books
	SET Contents = CAST(@Contents AS XML)
	WHERE Id = @Id;

	SET @RowsAffected = @@ROWCOUNT;
END;