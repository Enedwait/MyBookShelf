using System.Collections.Generic;
using System.Threading.Tasks;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.Shared.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(IBook book);
        Task<IBook> GetBookByIdAsync(int id);
        Task<IEnumerable<IBook>> GetAllBooksAsync();
        Task<bool> UpdateBookAsync(IBook book);
        Task<bool> UpdateContentsByBookIdAsync(int id, string contents);
        Task<bool> DeleteBookByIdAsync(int id);
    }
}
