using CoreCalculator.ServerImplementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreCalculator.Tests
{
    public class InputValidatorTests
    {
        [Fact]
        public void InvalidBase64IsDetected() {
            var inputValidator = new InputValidator();
            var invalidBase64 = "QmFzZTY0RW5j b2RpbmdUZXN0!";

            var valiationResult = inputValidator.IsBase64Input(invalidBase64);

            Assert.False(valiationResult);
        }

        [Fact]
        public void ValidBase64IsDetected()
        {
            var inputValidator = new InputValidator();
            var validBase64 = "QmFzZTY0RW5jb2RpbmdUZXN0";

            var valiationResult = inputValidator.IsBase64Input(validBase64);

            Assert.True(valiationResult);
        }

        [Fact]
        public void InvalidCharactersAreDetected() {
            var inputValidator = new InputValidator();
            var inputWithInvalidCharacters = "1-9*a/z";            

            var valiationResult = inputValidator.InputHasOnlyValidCharacters(inputWithInvalidCharacters);

            Assert.False(valiationResult);
        }

        [Fact]
        public void ValidCharactersAreDetected()
        {
            var inputValidator = new InputValidator();
            var inputWithValidCharacters = "1-9*3/2";
            
            var valiationResult = inputValidator.InputHasOnlyValidCharacters(inputWithValidCharacters);

            Assert.True(valiationResult);
        }
    }
}
