using CoreCalculator.ServerImplementations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CoreCalculator.Tests
{
    public class Base64HandlerTests
    {
        [Fact]
        public void StringIsEncodedToBase64() {
            var base64Handler = new Base64Handler();
            var input = "Base64EncodingTest";
            var expectedOutput = "QmFzZTY0RW5jb2RpbmdUZXN0";

            var actualOutput = base64Handler.Encode(input);

            Assert.True(expectedOutput == actualOutput);
        }

        [Fact]
        public void Base64StringIsDecodedCorrectly()
        {
            var base64Handler = new Base64Handler();
            var input = "QmFzZTY0RGVjb2RpbmdUZXN0";
            var expectedOutput = "Base64DecodingTest";

            var actualOutput = base64Handler.Decode(input);

            Assert.True(expectedOutput == actualOutput);
        }
    }
}
