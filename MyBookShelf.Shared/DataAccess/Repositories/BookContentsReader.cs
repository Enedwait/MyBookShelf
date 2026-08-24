using Dapper;
using MyBookShelf.Shared.DataAccess.Factories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MyBookShelf.Shared.Models;

namespace MyBookShelf.Shared.DataAccess.Repositories
{
    public sealed class BookContentsReader : IBookContentsReader
    {
        #region Static

        internal static class UspParameterNames
        {
            public const string ID = "@Id";
        }

        internal static class UspNames
        {
            public const string GET_TOTAL_PAGES = "dbo.GetTotalPages";
            public const string GET_CHAPTER_COUNT = "GetChapterCount";
            public const string GET_CHAPTER_LIST = "GetChapterList"; 
        }

        #endregion

        #region Fields

        private readonly IDbConnectionFactory _connectionFactory;

        #endregion

        #region Init

        public BookContentsReader(IDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
                throw new ArgumentNullException(nameof(connectionFactory));

            this._connectionFactory = connectionFactory;
        }

        #endregion

        #region GetTotalPages

        public async Task<int> GetTotalPagesAsync(int bookId)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, bookId, DbType.Int32, ParameterDirection.Input);

                var result = await connection.ExecuteScalarAsync(
                    UspNames.GET_TOTAL_PAGES,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);

                if (result == null) return 0;
                return Convert.ToInt32(result);
            }
        }

        #endregion

        #region GetTotalPages

        public async Task<int> GetChapterCountAsync(int bookId)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, bookId, DbType.Int32, ParameterDirection.Input);

                var result = await connection.ExecuteScalarAsync(
                    UspNames.GET_CHAPTER_COUNT,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);

                if (result == null) return 0;
                return Convert.ToInt32(result);
            }
        }

        #endregion

        #region GetChapterList

        public async Task<IEnumerable<IChapter>> GetChapterListAsync(int bookId)
        {
            using (IDbConnection connection = _connectionFactory.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add(UspParameterNames.ID, bookId, DbType.Int32, ParameterDirection.Input);

                return await connection.QueryAsync<Chapter>(
                    UspNames.GET_CHAPTER_LIST,
                    parameters,
                    null,
                    null,
                    CommandType.StoredProcedure);
            }
        }

        #endregion
    }
}
