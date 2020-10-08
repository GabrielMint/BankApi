using System;

namespace BankApi.Domain.Entities
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public DocumentTypes DocumentType { get; set; }
    }
}
