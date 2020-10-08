using Microsoft.AspNetCore.Mvc;

namespace BankApi{
    [Route("api")]
    public class HealthCheckController : ControllerBase {

        [HttpGet]        
        [Route("health-check")]
        public IActionResult Get(){
            return Ok("I'm alive!");
        }
    }
}