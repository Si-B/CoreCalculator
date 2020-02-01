using CoreCalculator.ServerDefinitions;

namespace CoreCalculator.ServerImplementations
{
    public class CalculationSuccess : ICalculationSuccess
    {
        public bool Error { get; set; }
        public double Result { get; set; }        
    }
}
