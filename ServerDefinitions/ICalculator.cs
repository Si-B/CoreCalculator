using System;

namespace CoreCalculator.ServerDefinitions
{
    public interface ICalculator
    {
        ICalculationResult Calculate(string input);
        string ToPostFix(string input);
        string EvaluatePostFix(string inputAsPostifx);
    }
}
