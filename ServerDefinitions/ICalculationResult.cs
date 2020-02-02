namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Base interface for any type of a CalculationResult.
    /// </summary>
    public interface ICalculationResult
    {
        /// <summary>
        /// Returns if there was any error while the calculation process.
        /// </summary>
        bool Error { get; set; }
    }
}
