CREATE PROCEDURE dbo.AddBook
	@Title NVARCHAR(255),
	@Author NVARCHAR(255),
	@PublishYear SMALLINT = NULL,
	@Contents XML = NULL,
	@NewBookId INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Books (Title, Author, PublishYear, Contents)
	VALUES (@Title, @Author, @PublishYear, @Contents);

	SET @NewBookId = SCOPE_IDENTITY();
END;
GO