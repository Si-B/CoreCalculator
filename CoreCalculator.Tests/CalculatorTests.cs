using CoreCalculator.ServerImplementations;
using Xunit;

namespace CoreCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void PostFixCreationWorks() {
            var input = "13*2/(5*3)+2";
            var expectedOutput = "13 2 * 5 3 * / 2 +";
            var calculator = new Calculator();

            var inputAsPostifx = calculator.ToPostFix(input);
            
            Assert.True(inputAsPostifx == expectedOutput);
        }

        [Fact]
        public void PostFixEvalutationWorks() {
            var input = "25 5 *"; //25 * 5
            var expectedOutput = 125;
            var calculator = new Calculator();

            var evaluationResult = calculator.EvaluatePostFix(input);

            Assert.True(expectedOutput == evaluationResult);
        }
        
        [Fact]
        public void CalculationWorks() {
            var input = "13*2/(8/4)+2"; // = 15
            var expectedResult = 15;
            var calculator = new Calculator();

            var actualResult = calculator.Calculate(input);

            Assert.True(expectedResult == actualResult);
        }
    }
}
