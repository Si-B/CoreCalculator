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
            var inputHelper = new InputHelper();
            var preparedInput = inputHelper.PrepareBase64Input(query);
            
            if (!inputHelper.IsBase64Input(preparedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter was not Base64 encoded or invalid. Provided value was: " + query });
            }

            var decodedInput = new Base64Handler().Decode(preparedInput);
            
            if (!inputHelper.InputHasOnlyValidCharacters(decodedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter contains invalid characters. Allowed characters are digits, +, -, *, / and whitespace. Provided value was: " + decodedInput });
            }
            
            if (!inputHelper.InputHasCorrectParenthesis(decodedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter contains an parenthensis error. Provided value was: " + decodedInput });
            }

            var decodedInputWithoutWhitespace = inputHelper.RemoveWhiteSpace(decodedInput);
            var calculationResult = new Calculator().Calculate(decodedInputWithoutWhitespace);

            return Ok(new CalculationSuccess { Result = calculationResult });
        }
    }
}
