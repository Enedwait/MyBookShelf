-- Собственно, книги!
-- Для простоты взята такая краткая структура таблицы.
-- В реальности следовало бы создать всякие разные поля и такие таблицы как:
-- Language, Authors, Publishers, Genres и различные ассоциативные сущности для связей.
-- Но не сейчас.
CREATE TABLE Books
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(255) NOT NULL,
	Author NVARCHAR(255) NOT NULL,
	PublishYear SMALLINT NULL,
	Contents XML NULL,
	CONSTRAINT CHK_PublishYear	
	CHECK (PublishYear >= 0 AND PublishYear <= YEAR(GETDATE()))	
);