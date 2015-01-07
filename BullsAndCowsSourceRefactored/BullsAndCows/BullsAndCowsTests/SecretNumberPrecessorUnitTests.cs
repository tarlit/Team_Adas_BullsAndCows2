namespace BullsAndCowsTests
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows;
    using NUnit.Framework;

    [TestFixture]

    public class SecretNumberPrecessorUnitTests
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

        [Test]
        public void GuessNumberOneBullOneCow()
        {
            string guessNumber = "1536";
            AnswerProvider guessResult = new AnswerProvider();
            guessResult.Bulls = 1;
            guessResult.Cows = 1;

            Assert.AreEqual(SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber), guessResult);
        }

        [Test]
        public void GuessNumberFourBullZeroCow()
        {
            string guessNumber = "1243";
            AnswerProvider guessResult = new AnswerProvider();
            guessResult.Bulls = 4;
            guessResult.Cows = 0;

            Assert.AreEqual(SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber), guessResult);
        }

        [Test]
        public void GuessNumberZeroBullZeroCow()
        {
            string guessNumber = "5566";
            AnswerProvider guessResult = new AnswerProvider();
            guessResult.Bulls = 0;
            guessResult.Cows = 0;

            Assert.AreEqual(SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber), guessResult);
        }

        [Test]
        public void GuessNumberZeroBullFourCow()
        {
            string guessNumber = "3412";
            AnswerProvider guessResult = new AnswerProvider();
            guessResult.Bulls = 0;
            guessResult.Cows = 4;

            Assert.AreEqual(SecretNumberProcessor.CheckGuessResult(guessNumber, testSecretNumber), guessResult);
        }

        [Test]
        public void GenerateSecretNumberLength()
        {
            IList<int> secretNumber = SecretNumberProcessor.GenerateSecretNumber();

            Assert.AreEqual(secretNumber.Count, 4);
        }

        [Test]
        public void GenerateSecretNumberValues()
        {
            IList<int> secretNumber = SecretNumberProcessor.GenerateSecretNumber();
            int n;
            Console.WriteLine(secretNumber.ToString());
            Assert.IsTrue(int.TryParse(secretNumber[0].ToString(), out n));
        }
    }
}
