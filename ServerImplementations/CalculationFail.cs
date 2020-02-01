using CoreCalculator.ServerDefinitions;

namespace CoreCalculator.ServerImplementations
{
    public class CalculationFail : ICalculationFail
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
