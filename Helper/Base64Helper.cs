using CoreCalculator.ServerDefinitions;
using System;
using System.Text.RegularExpressions;

namespace CoreCalculator.Helper
{
    /// <summary>
    /// Class to encode any string to Base64 or to decode a given Bae64 string back to normal form.
    /// </summary>
    public class Base64Helper
    {
        public string TryDecode(string base64EncodedValue) {
            //Assuming that query value is valid Base64 but with missing padding it gets added if needed
            var preparedInput = PrepareBase64Input(base64EncodedValue);

            //Check if the preparedInput seems to be Base64 encoded.
            if (!IsBase64Input(preparedInput))
            {
                throw new System.Exception("Query parameter was not Base64 encoded or invalid. Provided value was: " + base64EncodedValue);
            }

            //Decode to a string that can be tried to be calculated.
            return Decode(preparedInput);
        }

        /// <summary>
        /// Decodes a valid Base64 string and returns it. Throws Exception if input is not Base64 encoded.
        /// </summary>
        /// <param name="base64Input">Has to be a valid Base64 encoded string.</param>
        /// <returns>Result of a Base64 decoding process.</returns>
        public string Decode(string base64Input)
        {
            var base64InputAsBytes = Convert.FromBase64String(base64Input);
            return System.Text.Encoding.UTF8.GetString(base64InputAsBytes);
        }

        /// <summary>
        /// Encodes any input into Base64.
        /// </summary>
        /// <param name="input">Any valid string.</param>
        /// <returns>A Base64 encoded string.</returns>
        public string Encode(string input)
        {
            var inputAsBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputAsBytes);
        }

        /// <summary>
        /// Adds missing padding if needed.
        /// A Base64 encoded string length is always a multiple of 4 due to its implemenation.
        /// We assume that when the length of the given string can not be devided into a multiple of 4 we need to add = (padding characters in Base64).
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Raw input or input with added padding.</returns>
        private string PrepareBase64Input(string input)
        {
            while (input.Length % 4 > 0)
            {
                input += "=";
            }

            return input;
        }

        /// <summary>
        /// Checks if given input can be interpreted as valid Base64.
        /// Uses a regular expression for checking input to contain only valid Base64 characters.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if input seems to be Base64. False if not.</returns>
        private bool IsBase64Input(string input)
        {
            var regex = new Regex(@"^[a-zA-Z0-9+\/]*={0,2}$");
            var match = regex.Match(input);

            return match.Success;
        }
    }
}
