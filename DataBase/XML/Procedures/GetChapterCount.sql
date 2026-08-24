CREATE PROCEDURE dbo.GetChapterCount
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ISNULL(Contents.value('count(/BookContents/Contents//Chapter)', 'INT'), 0) AS ChapterCount
	FROM Books
	WHERE Id = @Id;
END