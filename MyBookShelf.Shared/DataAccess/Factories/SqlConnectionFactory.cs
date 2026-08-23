using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MyBookShelf.Shared.DataAccess.Factories
{
    public sealed class SqlConnectionFactory : IDbConnectionFactory
    {
        #region Fields

        private readonly string _connectionString;

        #endregion

        #region Init

        public SqlConnectionFactory(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            this._connectionString = connectionString;
        }

        #endregion

        #region CreateConnection

        public IDbConnection CreateConnection() => 
            new SqlConnection(_connectionString);

        #endregion
    }
}
