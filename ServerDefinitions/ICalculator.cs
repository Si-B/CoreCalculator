namespace CoreCalculator.ServerDefinitions
{
    public interface ICalculator
    {
        double Calculate(string input);
        string ToPostFix(string input);
        double EvaluatePostFix(string inputAsPostifx);
    }
}
