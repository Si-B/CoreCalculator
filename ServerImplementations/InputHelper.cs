using CoreCalculator.ServerDefinitions;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoreCalculator.ServerImplementations
{
    public class InputHelper : IInputHelper
    {
        /// <summary>
        /// Checks if given input can be interpreted as valid Base64.
        /// Uses a regular expression for checking input to contain only valid Base64 characters.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if input seems to be Base64. False if not.</returns>
        public bool IsBase64Input(string input)
        {
            var regex = new Regex(@"^[a-zA-Z0-9+\/]*={0,2}$");
            var match = regex.Match(input);

            return match.Success;
        }

        /// <summary>
        /// Checks if given input contains only characters that can be handled by a Calculator.
        /// Currently there are digits, +, -, *, /, ( and ) allowed.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there are only valid characters. False if not.</returns>
        public bool InputHasOnlyValidCharacters(string input)
        {
            var regex = new Regex(@"^[0-9\-\+\*\/\(\)\s]*$");
            var match = regex.Match(input);

            return match.Success;
        }

        /// <summary>
        /// Adds missing padding if needed.
        /// A Base64 encoded string length is always a multiple of 4 due to its implemenation.
        /// We assume that when the length of the given string can not be devided into a multiple of 4 we need to add = (padding characters in Base64).
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Raw input or input with added padding.</returns>
        public string PrepareBase64Input(string input)
        {
            while(input.Length % 4 > 0)
            {
                input += "=";
            }

            return input;
        }

        /// <summary>
        /// Checks if there is an equal amount of parenthesises if any present.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there is an equal amount of parenthesis. False if not.</returns>
        public bool InputHasCorrectParenthesis(string input)
        {
            return input.Count(i => i == '(') == input.Count(i => i == ')');
        }

        /// <summary>
        /// Removes any whitespace from given input.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Given input without any whitespace.</returns>
        public string RemoveWhiteSpace(string input)
        {
            return new string(input.Where(i => !char.IsWhiteSpace(i)).ToArray());
        }
    }
}
