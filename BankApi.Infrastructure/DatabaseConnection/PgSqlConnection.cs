using System;
using System.Data;
using Npgsql;

namespace BankApi.Infrastructure.DatabaseConnection
{
    public class PgSqlConnection : IDatabaseConnection
    { 
        public string ConnectionString { get; }

        public PgSqlConnection(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentException(nameof(connectionString));

            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection() =>
             new NpgsqlConnection(ConnectionString);
    }
}
