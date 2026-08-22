CREATE PROCEDURE dbo.GetAllBooks
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Title, Author, PublishYear, Contents
	FROM dbo.Books

	ORDER BY Id;
END;
GO