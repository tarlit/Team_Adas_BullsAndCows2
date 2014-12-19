namespace BullsAndCowsTests
{
    using System;
    using BullsAndCows;
    using NUnit.Framework;

    [TestFixture]

    public class BullsAndCowsUnitTests
    {
        private static SecretNumber testSecretNumber= new SecretNumber();

        [Test]
        public void EmptyGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "";

            Assert.Catch(typeof (ArgumentException), () =>
            {
                testSecretNumber.TryToGuess(guessNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }

        [Test]
        public void LargeGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "12345";

            Assert.Catch(typeof(ArgumentException), () =>
            {
                testSecretNumber.TryToGuess(guessNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }

        [Test]
        public void ShortGuessNumberStringShouldThrowArgumentException()
        {
            string guessNumber = "12345";

            Assert.Catch(typeof(ArgumentException), () =>
            {
                testSecretNumber.TryToGuess(guessNumber);
            }, "Passing empty guess number didn't throw correct exception.");
        }
    }
}
