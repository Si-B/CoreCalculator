using CoreCalculator.ServerDefinitions;
using System.Text.RegularExpressions;

namespace CoreCalculator.ServerImplementations
{
    public class InputValidator : IInputValidator
    {        
        public (bool IsValid, string Message) IsValid(string input)
        {
            if (!IsBase64Input(input))
            {
                return (false, "Input was not Base64 encoded or invalid.");
            }

            var decodedInput = new Base64Handler().Decode(input);

            if (!InputHasOnlyValidCharacters(decodedInput))
            {
                return (false, "Input contains invalid characters.");
            }

            return (true, "Input is valid.");
        }

        public bool IsBase64Input(string input) {
            var regex = new Regex(@"^[a-zA-Z0-9+\/]*={0,2}$");            
            var match = regex.Match(input);         
            
            return match.Success && input.Length % 4 == 0;
        }

        public bool InputHasOnlyValidCharacters(string input) {
            var regex = new Regex(@"^[0-9\-\+\*\/\(\)]*$");
            var match = regex.Match(input);

            return match.Success;
        }
    }
}
