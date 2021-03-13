using BankApi.Infrastructure.DatabaseConnection;
using BankApi.Infrastructure.DTOs;
using System;
using System.Threading.Tasks;
using Dapper;

namespace BankApi.Infrastructure.Repositories
{
    public class AccountReader : IAccountReader
    {
        public IDatabaseConnection DatabaseConnection { get; }

        public AccountReader(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection ?? throw new System.ArgumentNullException(nameof(databaseConnection));
        }

        public async Task<AccountDto> GetAccountByIdAsync(Guid accountId)
        {
            const string query = @"SELECT a.*, p.Name as OwnerName FROM Accounts a
                                   INNER JOIN Person p
                                   ON a.OwnerId = p.Id
                                   WHERE a.Id = @accountId";

            using(var connection = DatabaseConnection.GetConnection()){
                var result = await connection.QueryFirstOrDefaultAsync<AccountDto>(query, new { accountId });

                return result;
            }
        }
    }
}