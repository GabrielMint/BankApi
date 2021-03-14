using AutoMapper;
using BankApi.Infrastructure.Models;
using BankApi.Infrastructure.Repositories;
using BankApi.Infrastructure.Repositories.AccountWriter;
using BankApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class DepositController : ControllerBase
    {
        public IAccountReader AccountReader { get; }
        public IAccountWriter AccountWriter { get; }
        public IMapper Mapper { get; }

        public DepositController(
            IAccountReader accountReader,
            IAccountWriter accountWriter,
            IMapper mapper)
        {
            AccountReader = accountReader ?? throw new System.ArgumentNullException(nameof(accountReader));
            AccountWriter = accountWriter ?? throw new System.ArgumentNullException(nameof(accountWriter));
            Mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        [HttpPut]
        [Route("/deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositRequest request)
        {
            var account = await AccountReader.GetAccountByIdAsync(request.AccountId);

            if (account == null)
            {
                return BadRequest("Account not found");
            }

            var deposit = Mapper.Map<DepositModel>(request);

            await AccountWriter.DepositAsync(deposit);

            return Ok();
        }
    }
}
