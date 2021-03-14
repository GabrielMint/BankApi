using AutoMapper;
using BankApi.Infrastructure.Models;
using BankApi.Models;

namespace BankApi.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<DepositRequest, DepositModel>();
        }
    }
}
