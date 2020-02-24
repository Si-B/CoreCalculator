using CoreCalculator.Helper;
using CoreCalculator.ServerImplementations;
using Microsoft.AspNetCore.Mvc;

namespace CoreCalculator.Controllers
{
    [Route("[controller]")]
    public class CalculusController : ControllerBase
    {        
        [HttpGet]
        public IActionResult Get(string query)
        {            
            try
            {
                //Try to decode query parameters. Throws Exception on error.
                var validatedQuery = new InputProcessor().TryDecodeAndValidate(query);

                //Do the actual calculation.
                var calculationResult = new Calculator().Calculate(validatedQuery);

                return Ok(new CalculationSuccess { Result = calculationResult });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new CalculationFail { Message = ex.Message });
            }                                    
        }
    }
}
