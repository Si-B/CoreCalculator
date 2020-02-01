using CoreCalculator.ServerDefinitions;

namespace CoreCalculator
{
    public class CalculusSuccess : ICalculus
    {
        public bool Error { get; set; }
        public double Result { get; set; }        
    }
}
