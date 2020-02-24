using CoreCalculator.ServerDefinitions;

namespace CoreCalculator.ServerImplementations
{
    /// <summary>
    /// Used for returning a message in addition to a boolean why a calculation attempt has failed.
    /// </summary>
    public class CalculationFail : ICalculationFail
    {        
        /// <summary>
        /// A boolean value which should be true if an error while calculation occured.
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// Returns a message explaining why a calculation has failed.
        /// </summary>
        public string Message { get; set; }

        public CalculationFail()
        {
            Error = true;
        }
    }
}
