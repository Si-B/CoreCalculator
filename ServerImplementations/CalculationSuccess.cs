using CoreCalculator.ServerDefinitions;

namespace CoreCalculator.ServerImplementations
{
    /// <summary>
    /// Used for returning the calculated result if calculation was successful.
    /// </summary>
    public class CalculationSuccess : ICalculationSuccess
    {
        /// <summary>
        /// A boolean value which should be false if calculation was succesful.
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// Holds the calculated result.
        /// </summary>
        public double Result { get; set; }        
    }
}
