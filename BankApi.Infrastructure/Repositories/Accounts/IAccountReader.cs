using BankApi.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace BankApi.Infrastructure.Repositories
{
    public interface IAccountReader
    {
        Task<Account> GetAccountByIdAsync(Guid accountId);
    }
}
