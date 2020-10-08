using BankApi.Domain.Entities;
using BankApi.Infrastructure.DatabaseConnection;
using System;
using System.Threading.Tasks;

namespace BankApi.Infrastructure.Repositories
{
    public class AccountReader : IAccountReader
    {
        public IDatabaseConnection DatabaseConnection { get; }

        public AccountReader(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection ?? throw new System.ArgumentNullException(nameof(databaseConnection));
        }

        public Task<Account> GetAccountByIdAsync(Guid accountId)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Balance = 10000,
                OwnerId = Guid.NewGuid()
            };

            return Task.FromResult(account);
        }
    }
}