namespace CoreCalculator.ServerDefinitions
{
    /// <summary>
    /// Interface that a Calculator class has to implement.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Calculates given input and returns evaluated value.
        /// </summary>
        /// <param name="input">A string that can be calculated.</param>
        /// <returns>Calculationresult as double.</returns>
        double Calculate(string input);
        /// <summary>
        /// Given input is being transformed from infix to postfix notation.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>A string that has been transformed into postifx notation.</returns>
        string ToPostFix(string input);
        /// <summary>
        /// Evaluates a postfix input and returns evaluated value.
        /// </summary>
        /// <param name="inputAsPostifx"></param>
        /// <returns>A double with the result of the evaluated input.</returns>
        double EvaluatePostFix(string inputAsPostifx);
    }
}