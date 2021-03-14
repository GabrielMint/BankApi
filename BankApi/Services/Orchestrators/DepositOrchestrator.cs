using BankApi.Infrastructure.Repositories;
using BankApi.Models;
using System;
using System.Threading.Tasks;

namespace BankApi.Services.Orchestrators
{
    public class DepositOrchestrator : IDepositOrchestrator
    {
        public IAccountReader AccountReader { get; }

        public DepositOrchestrator(IAccountReader accountReader)
        {
            AccountReader = accountReader ?? throw new ArgumentNullException(nameof(accountReader));
        }

        public async Task DepositAsync(DepositRequest depositRequest)
        {
            var account = await AccountReader.GetAccountByIdAsync(depositRequest.AccountId);

            

        }
    }
}
