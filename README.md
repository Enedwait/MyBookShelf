# MyBookShelf
*Это тестовое [задание](#задание) по теме Backend C# / ASP.NET-разработки.*

### 📌Описание
Демонстрационная домашняя библиотека **ASP.NET Web Forms** (*.NET Framrwork 4.8*) + **MVC Core** (*.NET 8.0*) + **Shared C# class library** (*.NET Standard 2.0*) и с использованием **MS SQL Server Database** (*Express 2022*).

### 🛠Архитектура
- **DI** - **Autofac** в *WebForms*, в *MVC* - по умолчанию.
- **SOLID**, **YAGNI**

### ⚙️Настройка и запуск
0. Скачать проект.
1. Создать руками базу данных и хранимые процедуры как в [схеме](#схема). 
2. Открыть проект в **Visual Studio**.
3. Выбрать *Startup Project* по душе (*WebForms* или *MVC*).
4. Запустить, потыкать.
5. **PROFIT!**

### 📂Схема
#### Таблицы
[Books](DataBase/Tables/Books.sql)
#### Хранимые процедуры
[Процедуры](DataBase/Procedures/)
#### Образец XML-оглавления
[Образец XML-оглавления](DataBase/XML/Sample.xml)
#### Хранимые процедуры для выборки XML
[Процедуры XML](DataBase/XML/Procedures/)

### 📦Требования и зависимости

| Инструмент | Версия |
|------------|-------------------|
| Visual Studio | 2022 |
| MS SQL Server | 2022 |
| Autofac | 9.3.2 |
| Autofac.Web | 7.0.0 |
| Dapper | 2.1.79 |
| Microsoft.Data.SqlClient | 7.0.2 |
| HtmlSanitizer | 9.2.995 |
| CKEditor | 3.6.4 |
| И куча остального! | |

### 📋Задание
[Оригинальный текст ТЗ](TASK.md)

*Репозиторий создан в рамках выполнения тестового задания. Все права на оригинальную формулировку задачи принадлежат компании-заказчику.*

### 👤Контакты
**Олег Т.**
- [Telegram](https://t.me/enedwait)
- [Email](mailto:okrt.xyz@gmail.com)
- [GitHub](https://github.com/Enedwait)
