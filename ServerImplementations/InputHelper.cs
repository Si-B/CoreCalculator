using CoreCalculator.ServerDefinitions;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoreCalculator.ServerImplementations
{
    public class InputHelper : IInputHelper
    {
        public bool IsBase64Input(string input)
        {
            var regex = new Regex(@"^[a-zA-Z0-9+\/]*={0,2}$");
            var match = regex.Match(input);

            return match.Success;
        }

        public bool InputHasOnlyValidCharacters(string input)
        {
            var regex = new Regex(@"^[0-9\-\+\*\/\(\)\s]*$");
            var match = regex.Match(input);

            return match.Success;
        }

        public string PrepareBase64Input(string input)
        {
            if (input.Length % 4 == 0)
            {
                return input;
            }

            for (int i = 0; i < input.Length % 4; i++)
            {
                input += "=";
            }

            return input;
        }

        public bool InputHasCorrectParenthesis(string input)
        {
            return input.Count(i => i == '(') == input.Count(i => i == ')');
        }

        public string RemoveWhiteSpace(string input)
        {
            return new string(input.Where(i => !char.IsWhiteSpace(i)).ToArray());
        }
    }
}
