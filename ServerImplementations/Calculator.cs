using CoreCalculator.ServerDefinitions;
using System;

namespace CoreCalculator.ServerImplementations
{
    public class Calculator : ICalculator
    {
        public ICalculationResult Calculate(string input)
        {


            return new CalculationFail { Error = true, Message = "Not implemented yet." };
        }

        public string ToPostFix(string input)
        {
            throw new NotImplementedException();
        }

        public string EvaluatePostFix(string inputAsPostifx)
        {
            throw new NotImplementedException();
        }
    }
}
