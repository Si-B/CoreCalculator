namespace CoreCalculator.ServerDefinitions
{
    public interface IInputValidator
    {
        public (bool IsValid, string Message) IsValid(string input);
    }
}
