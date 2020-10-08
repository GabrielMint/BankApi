using Microsoft.AspNetCore.Mvc;

namespace BankApi.Controllers
{
    public class DepositController : ControllerBase
    {
        [HttpPut]
        [Route("/deposit")]
        public IActionResult Deposit()
        {
            return Ok();
        }
    }
}
