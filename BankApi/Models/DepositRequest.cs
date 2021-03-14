using System;

namespace BankApi.Models
{
    public class DepositRequest
    {
        public Guid AccountId { get; set; }

        public long AmountToDeposit { get; set; }
    }
}
