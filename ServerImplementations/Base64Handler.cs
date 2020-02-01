using CoreCalculator.ServerDefinitions;
using System;

namespace CoreCalculator.ServerImplementations
{
    public class Base64Handler : IBase64Handler
    {
        public string Decode(string base64Input)
        {
            var base64InputAsBytes = System.Convert.FromBase64String(base64Input);
            return System.Text.Encoding.UTF8.GetString(base64InputAsBytes);
        }

        public string Encode(string input)
        {
            var inputAsBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputAsBytes);
        }
    }
}
