namespace CoreCalculator.ServerDefinitions
{
    public interface IInputHelper
    {        
        string PrepareBase64Input(string input);
        string RemoveWhiteSpace(string input);
        bool IsBase64Input(string input);
        bool InputHasOnlyValidCharacters(string input);
        bool InputHasCorrectParenthesis(string input);
    }
}
