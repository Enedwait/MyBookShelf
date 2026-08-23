CREATE PROCEDURE dbo.GetBookById
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Title, Author, PublishYear, Contents
	FROM dbo.Books

	WHERE Id = @Id;
END;