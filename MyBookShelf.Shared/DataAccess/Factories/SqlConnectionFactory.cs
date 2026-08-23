using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyBookShelf.Shared.Constants;

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


        public SqlConnectionFactory(IConfiguration configuration)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            string connectionString = configuration.GetConnectionString(Defaults.CONNECTION);
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException($"{Defaults.CONNECTION} not found in {configuration}!");

            this._connectionString = connectionString;
        }

        #endregion

        #region CreateConnection

        public IDbConnection CreateConnection() => 
            new SqlConnection(_connectionString);

        #endregion
    }
}
