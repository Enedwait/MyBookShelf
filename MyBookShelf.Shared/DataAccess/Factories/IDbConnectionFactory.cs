using System.Data;

namespace MyBookShelf.Shared.DataAccess.Factories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
