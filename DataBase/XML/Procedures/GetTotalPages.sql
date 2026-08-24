CREATE PROCEDURE dbo.GetTotalPages
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ISNULL(Contents.value('(BookContents/Header/Pages/@Total)[1]', 'INT'), 0) AS TotalPages
	FROM Books
	WHERE Id = @Id;
END