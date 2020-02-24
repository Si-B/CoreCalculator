using System.Linq;
using System.Text.RegularExpressions;

namespace CoreCalculator.Helper
{
    public class InputValidator
    {
        public void Validate(string decodedInput)
        {
            //Check if there are only characters that the Calculator can process.
            if (!InputHasOnlyValidCharacters(decodedInput))
            {
                throw new System.Exception("Query parameter contains invalid characters. Allowed characters are digits, +, -, *, / and whitespace. Provided value was: " + decodedInput);
            }

            //Check if there is an equal amount of parenthesises if present.
            if (!InputHasCorrectParenthesis(decodedInput))
            {
                throw new System.Exception("Query parameter contains an parenthensis error. Provided value was: " + decodedInput);
            }
        }

        /// <summary>
        /// Checks if given input contains only characters that can be handled by a Calculator.
        /// Currently there are digits, +, -, *, /, ( and ) allowed.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there are only valid characters. False if not.</returns>
        private bool InputHasOnlyValidCharacters(string input)
        {
            var regex = new Regex(@"^[0-9\-\+\*\/\(\)\s]*$");
            var match = regex.Match(input);

            return match.Success;
        }

        /// <summary>
        /// Checks if there is an equal amount of parenthesises if any present.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there is an equal amount of parenthesis. False if not.</returns>
        private bool InputHasCorrectParenthesis(string input)
        {
            return input.Count(i => i == '(') == input.Count(i => i == ')');
        }
    }
}
