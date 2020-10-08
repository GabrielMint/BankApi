using BankApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [Route("api/accounts")]
    public class AccountQueryController : ControllerBase
    {
        public IAccountReader AccountReader { get; }

        public AccountQueryController(IAccountReader accountReader)
        {
            AccountReader = accountReader ?? throw new System.ArgumentNullException(nameof(accountReader));
        }

        [HttpGet]
        [Route("/{accountId}")]
        public async Task<IActionResult> Get([FromRoute] Guid accountId)
        {
            var account = await AccountReader.GetAccountByIdAsync(accountId);

            if (account == null)
                return NotFound();

            return Ok(account);
        }
    }
}
