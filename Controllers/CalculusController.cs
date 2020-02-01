using CoreCalculator.ServerImplementations;
using Microsoft.AspNetCore.Mvc;

namespace CoreCalculator.Controllers
{
    [Route("[controller]")]
    public class CalculusController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(string query) {
            var inputValidationResult = new InputValidator().IsValid(query);

            if (!inputValidationResult.IsValid)
            {
                return BadRequest(new CalculationFail() { Error = true, Message = inputValidationResult.Message });
            }

            var calculationResult = new Calculator().Calculate(query);

            return Ok(calculationResult);
        }
    }
}
