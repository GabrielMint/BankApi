﻿using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace BankApi.Infrastructure.DatabaseConnection
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public string ConnectionString { get; }

        public DatabaseConnection(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentException(nameof(connectionString));

            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection() =>
             new SqlConnection(ConnectionString);
    }
}
