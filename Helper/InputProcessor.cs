using CoreCalculator.ServerDefinitions;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoreCalculator.Helper
{
    public class InputProcessor
    {
        public string TryDecodeAndValidate(string input)
        {
            var decodedInput = new Base64Helper().TryDecode(input);

            new InputValidator().Validate(decodedInput);

            //Remove any whitespace from the input to calculate.
            return RemoveWhiteSpace(decodedInput);
        }
        
        /// <summary>
        /// Removes any whitespace from given input.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Given input without any whitespace.</returns>
        private string RemoveWhiteSpace(string input)
        {
            return new string(input.Where(i => !char.IsWhiteSpace(i)).ToArray());
        }
    }
}
