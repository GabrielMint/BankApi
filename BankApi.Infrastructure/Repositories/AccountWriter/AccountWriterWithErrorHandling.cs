using BankApi.Infrastructure.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApi.Infrastructure.Repositories.AccountWriter
{
    public class AccountWriterWithErrorHandling : IAccountWriter
    {
        public ILogger Logger { get; }
        public IAccountWriter AccountWriter { get; }

        public AccountWriterWithErrorHandling(
            ILogger logger,
            IAccountWriter accountWriter)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            AccountWriter = accountWriter ?? throw new ArgumentNullException(nameof(accountWriter));
        }

        public async Task DepositAsync(DepositModel depositModel)
        {
            try
            {
                await AccountWriter.DepositAsync(depositModel);
            }
            catch(Exception e)
            {
                Logger.Error(e, e.Message);
                throw;
            }
        }
    }
}
