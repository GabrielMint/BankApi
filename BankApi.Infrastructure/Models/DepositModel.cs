using System;

namespace BankApi.Infrastructure.Models
{
    public class DepositModel
    {
        public Guid AccountId { get; set; }
        public long AmountToDeposit { get; set; }
    }
}
