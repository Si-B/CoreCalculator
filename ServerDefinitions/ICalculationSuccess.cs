namespace CoreCalculator.ServerDefinitions
{
    public interface ICalculationSuccess : ICalculationResult
    {
        double Result { get; set; }
    }
}
