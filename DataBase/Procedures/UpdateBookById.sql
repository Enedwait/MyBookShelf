CREATE PROCEDURE dbo.UpdateBookById
	@Id INT,
	@Title NVARCHAR(255),
	@Author NVARCHAR(255),
	@PublishYear SMALLINT = NULL,
	@Contents XML = NULL,
	@RowsAffected INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.Books
	SET Title = @Title,
		Author = @Author,
		PublishYear = @PublishYear,
		Contents = @Contents
	WHERE Id = @Id;

	SET @RowsAffected = @@ROWCOUNT;
END;
GO