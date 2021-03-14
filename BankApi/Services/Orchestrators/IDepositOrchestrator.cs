using BankApi.Models;
using System.Threading.Tasks;

namespace BankApi.Services.Orchestrators
{
    public interface IDepositOrchestrator
    {
        Task DepositAsync(DepositRequest depositRequest);
    }
}
