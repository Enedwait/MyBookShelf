using MyBookShelf.Shared.DataAccess.Repositories;
using MyBookShelf.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookShelf.Shared.Helpers
{
    public static class BookHelper
    {
        #region GetBookListItem

        public static async Task<BookListItem> GetBookListItemAsync(this IBookContentsReader reader, IBook book)
        {
            if (reader == null) return null;
            if (book == null) return null;
            int totalPages = await reader.GetTotalPagesAsync(book.Id);
            int chapterCount = await reader.GetChapterCountAsync(book.Id);
            var chapters = await reader.GetChapterListAsync(book.Id);
            return new BookListItem(
                book,
                (totalPages > 0 ? totalPages : (int?)null),
                (chapterCount > 0 ? chapterCount : (int?)null),
                chapters);
        }

        #endregion

        #region GetBookListItems

        public static async Task<List<BookListItem>> GetBookListItemsAsync(this IBookContentsReader reader, IEnumerable<IBook> books)
        {
            if (reader == null) return null;
            List<BookListItem> viewModels = new List<BookListItem>(books.Count());
            foreach (IBook book in books)
            {
                BookListItem model = await reader.GetBookListItemAsync(book);
                if (model != null)
                    viewModels.Add(model);
            }
            return viewModels;
        }

        #endregion
    }
}
