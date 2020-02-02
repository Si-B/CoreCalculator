using CoreCalculator.Controllers;
using CoreCalculator.ServerImplementations;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CoreCalculator.Tests
{
    public class CalculatorControllerTests
    {
        [Fact]
        public void ValidInput_OkResult_CalculationSuccessResult_ValueWasEvaluatedCorrect() 
        {            
            var query = "MisoNSozKS81"; //2+(5*3)/5
            var expectedResult = new CalculationSuccess { Error = false, Result = 5 };
            var calculusController = new CalculusController();
            
            var actualResult = calculusController.Get(query) as OkObjectResult;
            Assert.NotNull(actualResult);

            var okResult = actualResult.Value as CalculationSuccess;
            Assert.NotNull(okResult);
            Assert.True(expectedResult.Result == okResult.Result && expectedResult.Error == okResult.Error);
        }

        [Fact]
        public void InvalidBase64IsPreparedToValidInput_OkResult_CalculationSuccessResult_ValueWasEvaluatedCorrect()
        {
            var query = "MiAqICgyMy8oMyozKSktIDIzICogKDIqMyk"; //2 * (23/(3*3))- 23 * (2*3)
            var expectedResult = new CalculationSuccess { Error = false, Result = -132.88888888888889 };
            var calculusController = new CalculusController();

            var actualResult = calculusController.Get(query) as OkObjectResult;
            Assert.NotNull(actualResult);

            var okResult = actualResult.Value as CalculationSuccess;
            Assert.NotNull(okResult);
            Assert.True(expectedResult.Result == okResult.Result && expectedResult.Error == okResult.Error);
        }

        [Fact]
        public void InvalidBase64Input_BadResult_CalculationFailResult()
        {
            var query = "MisoNSozKS81!%"; //Invalid Base64
            var expectedResult = new CalculationFail { Error = true, Message = "Query parameter was not Base64 encoded or invalid. Provided value was: MisoNSozKS81!%" };
            var calculusController = new CalculusController();

            var actualResult = calculusController.Get(query) as BadRequestObjectResult;
            Assert.NotNull(actualResult);

            var badResult = actualResult.Value as CalculationFail;
            Assert.NotNull(badResult);
            Assert.True(expectedResult.Message == badResult.Message && expectedResult.Error == badResult.Error);
        }

        [Fact]
        public void ValidBase64ButInvalidCharacterInput_BadResult_CalculationFailResult()
        {
            var query = "JTIrICg1KjMpLzUh"; //%2+ (5*3)/5!
            var expectedResult = new CalculationFail { Error = true, Message = "Query parameter contains invalid characters. Allowed characters are digits, +, -, *, / and whitespace. Provided value was: %2+ (5*3)/5!" };
            var calculusController = new CalculusController();

            var actualResult = calculusController.Get(query) as BadRequestObjectResult;
            Assert.NotNull(actualResult);

            var badResult = actualResult.Value as CalculationFail;
            Assert.NotNull(badResult);
            Assert.True(expectedResult.Message == badResult.Message && expectedResult.Error == badResult.Error);
        }
    }
}
