namespace CoreCalculator.ServerDefinitions
{
    public interface ICalculationFail : ICalculationResult
    {
        string Message { get; set; }
    }
}
