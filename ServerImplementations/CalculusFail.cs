using CoreCalculator.ServerDefinitions;

namespace CoreCalculator.DataObjects
{
    public class CalculusFail : ICalculus
    {
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
