using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.Shared.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(Book book);
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<bool> UpdateBookAsync(Book book);
        Task<bool> UpdateContentsByBookIdAsync(int id, string contents);
        Task<bool> DeleteBookByIdAsync(int id);
    }
}
