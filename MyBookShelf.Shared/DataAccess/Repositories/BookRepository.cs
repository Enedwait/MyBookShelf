using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MyBookShelf.Shared.Constants;
using MyBookShelf.Shared.DataAccess.Factories;
using MyBookShelf.Shared.Extensions;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.Shared.DataAccess.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        #region Static

        internal static class UspParameterNames
        {
            public const string ID = "@Id";
            public const string TITLE = "@Title";
            public const string AUTHOR = "@Author";
            public const string PUBLISH_YEAR = "@PublishYear";
            public const string CONTENTS = "@Contents";
            public const string ROWS_AFFECTED = "@RowsAffected";
            public const string NEW_BOOK_ID = "@NewBookId";
        }

        internal static class UspNames
        {
            public const string ADD_BOOK = "dbo.AddBook";
            public const string GET_BOOK_BY_ID = "dbo.GetBookById";
            public const string GET_ALL_BOOKS = "dbo.GetAllBooks";
            public const string UPDATE_BOOK_BY_ID = "dbo.UpdateBookById";
            public const string UPDATE_CONTENTS_BY_BOOK_ID = "dbo.UpdateContentsByBookId";
            public const string DELETE_BOOK_BY_ID = "dbo.DeleteBookById";
        }

        #endregion

        #region Fields

        private readonly IDbConnectionFactory _connectionFactory;
        
        #endregion

        #region Init

        public BookRepository(IDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
                throw new ArgumentNullException(nameof(connectionFactory));
            
            this._connectionFactory = connectionFactory;
        }

        #endregion

        #region AddBook

        public async Task<int> AddBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.TITLE, book.Title, DbType.String,ParameterDirection.Input, GlobalParameters.MAX_TITLE_LENGTH);
                parameters.Add(UspParameterNames.AUTHOR, book.Author, DbType.String, ParameterDirection.Input, GlobalParameters.MAX_AUTHOR_LENGTH);
                parameters.Add(UspParameterNames.PUBLISH_YEAR, book.PublishYear, DbType.Int16, ParameterDirection.Input);
                parameters.Add(UspParameterNames.CONTENTS, book.Contents.NotEmptyStringOrDBNull(), DbType.String, ParameterDirection.Input, -1);
                parameters.Add(UspParameterNames.NEW_BOOK_ID, null, DbType.Int32, ParameterDirection.Output);

                await connection.ExecuteAsync(
                    UspNames.ADD_BOOK, 
                    parameters, 
                    null, 
                    null, 
                    CommandType.StoredProcedure);

                return book.Id = parameters.Get<int>(UspParameterNames.NEW_BOOK_ID);
            }
        }

        #endregion

        #region GetBook

        public async Task<Book> GetBookByIdAsync(int id)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, id, DbType.Int32, ParameterDirection.Input);

                return await connection.QuerySingleOrDefaultAsync<Book>(
                    UspNames.GET_BOOK_BY_ID,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<Book>(
                    UspNames.GET_ALL_BOOKS,
                    null,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }

        #endregion

        #region UpdateBook

        public async Task<bool> UpdateBookAsync(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, book.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add(UspParameterNames.TITLE, book.Title, DbType.String, ParameterDirection.Input, GlobalParameters.MAX_TITLE_LENGTH);
                parameters.Add(UspParameterNames.AUTHOR, book.Author, DbType.String, ParameterDirection.Input, GlobalParameters.MAX_AUTHOR_LENGTH);
                parameters.Add(UspParameterNames.PUBLISH_YEAR, book.PublishYear, DbType.Int16, ParameterDirection.Input);
                parameters.Add(UspParameterNames.CONTENTS, book.Contents.NotEmptyStringOrDBNull(), DbType.String, ParameterDirection.Input, -1);
                parameters.Add(UspParameterNames.ROWS_AFFECTED, null, DbType.Int32, ParameterDirection.Output);

                await connection.ExecuteAsync(
                    UspNames.UPDATE_BOOK_BY_ID,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);

                return parameters.Get<int>(UspParameterNames.ROWS_AFFECTED) > 0;
            }
        }

        #endregion

        #region UpdateContents

        public async Task<bool> UpdateContentsByBookIdAsync(int id, string contents)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, id, DbType.Int32, ParameterDirection.Input);
                parameters.Add(UspParameterNames.CONTENTS, contents.NotEmptyStringOrDBNull(), DbType.String, ParameterDirection.Input, -1);
                parameters.Add(UspParameterNames.ROWS_AFFECTED, null, DbType.Int32, ParameterDirection.Output);

                await connection.ExecuteAsync(
                    UspNames.UPDATE_CONTENTS_BY_BOOK_ID,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);

                return parameters.Get<int>(UspParameterNames.ROWS_AFFECTED) > 0;
            }
        }

        #endregion

        #region DeleteBook

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, id, DbType.Int32, ParameterDirection.Input);
                parameters.Add(UspParameterNames.ROWS_AFFECTED, null, DbType.Int32, ParameterDirection.Output);

                await connection.ExecuteAsync(
                    UspNames.DELETE_BOOK_BY_ID,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);

                return parameters.Get<int>(UspParameterNames.ROWS_AFFECTED) > 0;
            }
        }

        #endregion
    }
}
