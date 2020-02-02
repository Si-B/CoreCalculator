using CoreCalculator.ServerDefinitions;
using System;

namespace CoreCalculator.ServerImplementations
{
    /// <summary>
    /// Class to encode any string to Base64 or to decode a given Bae64 string back to normal form.
    /// </summary>
    public class Base64Handler : IBase64Handler
    {
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
    }
}
