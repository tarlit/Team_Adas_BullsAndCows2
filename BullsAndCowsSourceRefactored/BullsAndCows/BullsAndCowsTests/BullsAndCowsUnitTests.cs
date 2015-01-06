namespace BullsAndCowsTests
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows;
    using NUnit.Framework;

    [TestFixture]

    public class BullsAndCowsUnitTests
    {
        private static IList<int> testSecretNumber = new int[] {1, 2, 4, 3};

        [Test]
        public void EmptyGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "";

            Assert.Catch(typeof (ArgumentException), () =>
            {
                SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }

        [Test]
        public void LargeGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "12345";

            Assert.Catch(typeof(ArgumentException), () =>
            {
                SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }

        [Test]
        public void ShortGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "123";

            Assert.Catch(typeof(ArgumentException), () =>
            {
                SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }

        [Test]
        public void GuessNumberStringContainingInvalidSymbolsShouldThrowArgumentException()
        {
            string guessNumber = "-123";

            Assert.Catch(typeof(ArgumentException), () =>
            {
                SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }
    }
}
