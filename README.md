# MyBookShelf
*Это тестовое [задание](#задание) по теме Backend C# / ASP.NET-разработки.*

### 📌Описание
Демонстрационная домашняя библиотека **ASP.NET Web Forms** (*.NET Framrwork 4.8*) + **MVC Core** (*.NET 8.0*) + **Shared C# class library** (*.NET Standard 2.0*) и с использованием **MS SQL Server Database** (*Express 2022*).

### ✅Реализовано:
- Всё, что требовалось по заданию (по моему скромному мнению).
- Разделяемая библиотека *Shared* для использования одних и тех же моделей, доступа к данным и вспомогательных функций между разными проектами.
- Зависимости через интерфейсы, а не реализации.
- Хранимые процедуры для **CRUD**, примеры хранимых процедур для извлечения данных их **XML**.
- Санитизация пользовательского ввода.
- Использован HTML-редактор **CKEditor** и в *WebForms* (на странице *BookContents*; установка через **NuGet**), и в *MVC* (view *BookContents*; ручная установка).

### ❌Не реализовано:
- Всё, что не требовалось реализовать.

### 🛠Архитектура
- **Database First** - согласно заданию, база устанавливается, создаётся и заполняется *вручную*.
- **DI** - **Autofac** в *WebForms*, в *MVC* - по умолчанию из коробки.
- **MVC** в *MVC* - но в остальных проектах логика отделена от данных по максимуму. 
- **SOLID**, **YAGNI**, **KISS**.
- **Санитизация** - **HtmlSanitizer** - на вводе оглавления книг.

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

| Инструмент | Версия | Источник | Комментарии |
|------------|-------------------|--------|--------|
| Visual Studio | 2022 | [Скачать](https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=Community&channel=Release&Version=VS2022&source=VSLandingPage&add=Microsoft.VisualStudio.Workload.CoreEditor&add=Microsoft.VisualStudio.Workload.NetCrossPlat;includeRecommended&cid=2305)  | |
| MS SQL Server | 2022 | [Скачать](https://download.microsoft.com/download/5/1/4/5145fe04-4d30-4b85-b0d1-39533663a2f1/SQL2022-SSEI-Expr.exe) | |
| Autofac | 9.3.2 | NuGet | |
| Autofac.Web | 7.0.0 | NuGet | |
| Dapper | 2.1.79 | NuGet | |
| Microsoft.Data.SqlClient | 7.0.2 | NuGet | |
| HtmlSanitizer | 9.2.995 | NuGet | |
| CKEditor (для *WebForms*) | 3.6.4 | NuGet | |
| CKEditor 4 (для *MVC*) | 4.22.1 | [Скачать](https://download.cksource.com/CKEditor/CKEditor/CKEditor%204.22.1/ckeditor_4.22.1_full.zip) | Поместить папку *ckeditor* в <code>MyBookShelf.MVC\wwwroot\lib\ |
| И куча остального! | | NuGet | Авось само поставится! |

### 📋Задание
[Оригинальный текст ТЗ](TASK.md)

*Репозиторий создан в рамках выполнения тестового задания. Все права на оригинальную формулировку задачи принадлежат компании-заказчику.*

### 👤Контакты
**Олег Т.**
- [Telegram](https://t.me/enedwait)
- [Email](mailto:okrt.xyz@gmail.com)
- [GitHub](https://github.com/Enedwait)

Ростов-на-Дону, 2026 г.