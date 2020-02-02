namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Interface that a Base64Handler class has to implement.
    /// </summary>
    public interface IBase64Handler
    {
        /// <summary>
        /// Encodes any input into Base64.
        /// </summary>
        /// <param name="input">Any valid string.</param>
        /// <returns></returns>
        string Encode(string input);
        /// <summary>
        /// Decodes a valid Base64 string. Throws Exception if input is not Base64 encoded.
        /// </summary>
        /// <param name="base64Input">Has to be a valid Base64 encoded string.</param>
        /// <returns></returns>
        string Decode(string base64Input);
    }
}
