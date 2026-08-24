CREATE PROCEDURE dbo.GetChapterList
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		ChapterData.value('@Title', 'NVARCHAR(255)') AS Title,
		ChapterData.value('@Page', 'INT') AS Page
	FROM Books
	CROSS APPLY Contents.nodes('/BookContents/Contents//Chapter') AS C(ChapterData)
	WHERE Id = @Id;
END