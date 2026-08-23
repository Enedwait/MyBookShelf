CREATE PROCEDURE dbo.UpdateBookById
	@Id INT,
	@Title NVARCHAR(255),
	@Author NVARCHAR(255),
	@PublishYear SMALLINT = NULL,
	@Contents NVARCHAR(MAX) = NULL,
	@RowsAffected INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Books
	SET Title = @Title,
		Author = @Author,
		PublishYear = @PublishYear,
		Contents = CAST(@Contents AS XML)
	WHERE Id = @Id;

	SET @RowsAffected = @@ROWCOUNT;
END;