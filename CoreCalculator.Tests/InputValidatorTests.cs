using CoreCalculator.ServerImplementations;
using Xunit;

namespace CoreCalculator.Tests
{
    public class InputValidatorTests
    {
        [Fact]
        public void InputGetsPreparedToGetHandledAsCorrectBase64()
        {
            var inputValidator = new InputHelper();
            var base64InputWithMissingPadding = "MiAqICgyMy8oMyozKSktIDIzICogKDIqMyk";
            var expectedResult = "MiAqICgyMy8oMyozKSktIDIzICogKDIqMyk=";

            var actualResult = inputValidator.PrepareBase64Input(base64InputWithMissingPadding);

            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public void InvalidBase64IsDetected()
        {
            var inputValidator = new InputHelper();
            var invalidBase64 = "QmFzZTY0RW5j b2RpbmdUZXN0!"; //Invalid due to space and !

            var valiationResult = inputValidator.IsBase64Input(invalidBase64);

            Assert.False(valiationResult);
        }

        [Fact]
        public void ValidBase64IsDetected()
        {
            var inputValidator = new InputHelper();
            var validBase64 = "QmFzZTY0RW5jb2RpbmdUZXN0"; //Decodes to Base64EncodingTest

            var valiationResult = inputValidator.IsBase64Input(validBase64);

            Assert.True(valiationResult);
        }

        [Fact]
        public void InvalidCharactersAreDetected()
        {
            var inputValidator = new InputHelper();
            var inputWithInvalidCharacters = "1-9%*a/z"; // %, a and z are invalid in current implementation.      

            var valiationResult = inputValidator.InputHasOnlyValidCharacters(inputWithInvalidCharacters);

            Assert.False(valiationResult);
        }

        [Fact]
        public void ValidCharactersAreDetected()
        {
            var inputValidator = new InputHelper();
            var inputWithValidCharacters = "1-9*3/2";

            var valiationResult = inputValidator.InputHasOnlyValidCharacters(inputWithValidCharacters);

            Assert.True(valiationResult);
        }

        [Fact]
        public void WhitespaceIsBeingRemoved()
        {
            var inputValidator = new InputHelper();
            var inputWithWhitespace = "1 -9* 3/2 \n";
            var expectedResult = "1-9*3/2";

            var actualResult = inputValidator.RemoveWhiteSpace(inputWithWhitespace);

            Assert.True(expectedResult == actualResult);
        }
    }
}
