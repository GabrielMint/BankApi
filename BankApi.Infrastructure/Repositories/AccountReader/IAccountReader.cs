using System;
using System.Threading.Tasks;
using BankApi.Infrastructure.DTOs;


namespace BankApi.Infrastructure.Repositories
{
    public interface IAccountReader
    {
        Task<AccountModel> GetAccountByIdAsync(Guid accountId);
    }
}
