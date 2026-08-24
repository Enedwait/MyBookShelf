using MyBookShelf.MVC.Controllers;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.MVC.Constants
{
    internal static class BooksControllerActionNames
    {
        public const string Index = nameof(BooksController.Index);
        public const string Create = nameof(BooksController.Create);
        public const string Edit = nameof(BooksController.Edit);
        public const string Delete = nameof(BooksController.Delete);
        public const string BookContents = nameof(BooksController.BookContents);
    }

    internal static class BookPropertyNames
    {
        public const string Title = nameof(Book.Title);
        public const string Author = nameof(Book.Author);
        public const string PublishYear = nameof(Book.PublishYear);
        public const string Contents = nameof(Book.Contents);
    }

    internal static class ViewKeys
    {
        public const string Title = "Title";
    }
}
