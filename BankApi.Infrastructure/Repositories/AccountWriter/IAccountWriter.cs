using BankApi.Infrastructure.Models;
using System.Threading.Tasks;

namespace BankApi.Infrastructure.Repositories.AccountWriter
{
    public interface IAccountWriter
    {
        Task DepositAsync(DepositModel depositModel); 
    }
}
