using System;

namespace BankApi.Infrastructure.DTOs
{
    public class AccountModel
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public String OwnerName { get; set; }

        public long Balance { get; set; }
    }
}
