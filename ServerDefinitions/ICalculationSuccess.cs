namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Interface that a CalculationSuccess class has to implement.
    /// </summary>
    public interface ICalculationSuccess : ICalculationResult
    {
        /// <summary>
        /// Holds the calculated value of a calculation process.
        /// </summary>
        double Result { get; set; }
    }
}
