using Microsoft.AspNetCore.Mvc;

namespace BankApi{
    [Route("api")]
    public class HealthCheckController : ControllerBase {

        [HttpGet]        
        [Route("health-check")]
        public IActionResult Get(){

            var result = new {
                Message = "Hello, I'm Alive"
            };

            return Ok(result);
        }
    }
}