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
            //Initializing an input helper for multiple usage.
            var inputHelper = new InputHelper();
            //Aussuming that query value is valid Base64 but with missing padding it gets added if needed
            var preparedInput = inputHelper.PrepareBase64Input(query);
            
            //Check if the preparedInput seems to be Base64 encoded.
            if (!inputHelper.IsBase64Input(preparedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter was not Base64 encoded or invalid. Provided value was: " + query });
            }

            //Decode to a string that can be tried to be calculated.
            var decodedInput = new Base64Handler().Decode(preparedInput);
            
            //Check if there are only characters that the Calculator can process.
            if (!inputHelper.InputHasOnlyValidCharacters(decodedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter contains invalid characters. Allowed characters are digits, +, -, *, / and whitespace. Provided value was: " + decodedInput });
            }
            
            //Check if there is an equal amount of parenthesises if present.
            if (!inputHelper.InputHasCorrectParenthesis(decodedInput))
            {
                return BadRequest(new CalculationFail() { Error = true, Message = "Query parameter contains an parenthensis error. Provided value was: " + decodedInput });
            }
            
            //Remove any whitespace from the input to calculate.
            var decodedInputWithoutWhitespace = inputHelper.RemoveWhiteSpace(decodedInput);
            
            //Do the actual calculation.
            var calculationResult = new Calculator().Calculate(decodedInputWithoutWhitespace);
            
            //Calculationresult is being returned.
            return Ok(new CalculationSuccess { Result = calculationResult });
        }
    }
}
