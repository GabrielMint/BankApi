using System;

namespace BankApi.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public long Balance { get; set; }
    }
}
