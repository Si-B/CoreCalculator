namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Interface that a InputHelper class has to implement.
    /// </summary>
    public interface IInputHelper
    {        
        /// <summary>
        /// Adds missing padding if needed.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Raw input or input with added padding.</returns>
        string PrepareBase64Input(string input);
        /// <summary>
        /// Removes any whitespace from given input.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>Given input without any whitespace.</returns>
        string RemoveWhiteSpace(string input);
        /// <summary>
        /// Checks if given input can be interpreted as valid Base64.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if input seems to be Base64. False if not.</returns>
        bool IsBase64Input(string input);
        /// <summary>
        /// Checks if given input contains only characters that can be handled by a Calculator.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there are only valid characters. False if not.</returns>
        bool InputHasOnlyValidCharacters(string input);
        /// <summary>
        /// Checks if there is an equal amount of parenthesises if any present.
        /// </summary>
        /// <param name="input">Any string.</param>
        /// <returns>True if there is an equal amount of parenthesis. False if not.</returns>
        bool InputHasCorrectParenthesis(string input);
    }
}
