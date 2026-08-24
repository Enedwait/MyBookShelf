using MyBookShelf.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBookShelf.Shared.DataAccess.Repositories
{
    public interface IBookContentsReader
    {
        Task<int> GetTotalPagesAsync(int bookId);
        Task<int> GetChapterCountAsync(int bookId);
        Task<IEnumerable<IChapter>> GetChapterListAsync(int bookId);
    }
}
