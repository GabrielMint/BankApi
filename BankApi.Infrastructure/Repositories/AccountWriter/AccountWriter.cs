using BankApi.Infrastructure.DatabaseConnection;
using BankApi.Infrastructure.Models;
using Dapper;
using System;
using System.Threading.Tasks;

namespace BankApi.Infrastructure.Repositories.AccountWriter
{
    public class AccountWriter : IAccountWriter
    {
        public IDatabaseConnection DatabaseConnection { get; }

        public AccountWriter(IDatabaseConnection databaseConnection)
        {
            DatabaseConnection = databaseConnection ?? throw new ArgumentNullException(nameof(databaseConnection));
        }

        public async Task DepositAsync(DepositModel depositModel)
        {
            const string command = @"UPDATE Accounts
                                    SET Balance = @AmountToDeposit
                                    WHERE Id = @AccountId;";

            using var connection = DatabaseConnection.GetConnection();

            await connection.ExecuteAsync(command, 
                new { depositModel.AmountToDeposit, depositModel.AccountId});
        }
    }
}
