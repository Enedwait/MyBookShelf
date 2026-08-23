CREATE PROCEDURE dbo.AddBook
	@Title NVARCHAR(255),
	@Author NVARCHAR(255),
	@PublishYear SMALLINT = NULL,
	@Contents NVARCHAR(MAX) = NULL,
	@NewBookId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Books (Title, Author, PublishYear, Contents)
	VALUES (@Title, @Author, @PublishYear, CAST(@Contents AS XML));

	SET @NewBookId = SCOPE_IDENTITY();
END;