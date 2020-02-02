namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Interface that a CalculationFail class has to implement.
    /// </summary>
    public interface ICalculationFail : ICalculationResult
    {
        /// <summary>
        /// Returns a message explaining why a calculation has failed.
        /// </summary>
        string Message { get; set; }
    }
}
