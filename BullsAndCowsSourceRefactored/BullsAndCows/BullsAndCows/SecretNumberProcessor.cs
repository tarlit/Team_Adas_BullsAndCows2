using System.Diagnostics;
using System.Dynamic;
using System.Runtime.Remoting.Messaging;

namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;

    public static class SecretNumberProcessor
    {

        private static Random randomGenerator = new Random();

        public static IList<int> GenerateSecretNumber()
        {
            var secretNumber = new int[GameConstants.SecretNumberDigitsCount];

            for (int i = 0; i < GameConstants.SecretNumberDigitsCount; i++)
            {
                secretNumber[i] = randomGenerator.Next(0, 10);    
            }

            return secretNumber;
        } 

        public static FormattedGuessResult CheckGuessResult(string stringInput, IList<int> secretNumber)
        {
            ValidateGuessNumber(stringInput);
            return GetGuessResult(stringInput, secretNumber);
        }

        private static int ValidateGuessNumber(string stringInput)
        {
            string guessNumberAsString = stringInput.Trim();
            if (string.IsNullOrEmpty(guessNumberAsString))
            {
                throw new ArgumentException(GameConstants.EmptyInputMessage);
            }
            if (guessNumberAsString.Length != GameConstants.SecretNumberDigitsCount)
            {
                throw new ArgumentException(GameConstants.WrongLenghtInputMessage);
            }

            int guessNumber = 0;
            bool isValidNumber = int.TryParse(guessNumberAsString, out guessNumber);
            if (!isValidNumber)
            {
                throw new ArgumentException(GameConstants.IncorrectNumberMessage);
            }

            return guessNumber;
        }

        private static FormattedGuessResult GetGuessResult(string guessNumberAsString, IList<int> secretNumber)
        {
            // this.GuessesCount++;
            var isDigitBullOrCow = InitBoolArrayWithValue(GameConstants.SecretNumberDigitsCount, false);
            int bulls = 0;
            int cows = 0;

            var guessNumberDigits = new int[GameConstants.SecretNumberDigitsCount];
            for (int i = 0; i < GameConstants.SecretNumberDigitsCount; i++)
            {
                guessNumberDigits[i] = int.Parse(guessNumberAsString[i].ToString());    
            }       

            bulls = GetBullsCount(ref isDigitBullOrCow, guessNumberDigits, secretNumber);
            cows = GetCowsCount(ref isDigitBullOrCow, guessNumberDigits, secretNumber);

            FormattedGuessResult guessResult = new FormattedGuessResult();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;
        }

        private static bool[] InitBoolArrayWithValue(int length, bool value)
        {
            bool[] result = new bool[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = value;
            }
            return result;
        }

        private static int GetBullsCount(ref bool[] isDigitBullOrCow, int[] guessNumberDigits, IList<int> secretNumber)
        {
            int bulls = 0;
            for (int i = 0; i < GameConstants.SecretNumberDigitsCount; i++)
            {
                if (secretNumber[i] == guessNumberDigits[i])
                {
                    isDigitBullOrCow[i] = true;
                    bulls++;
                }
            }
            return bulls;
        }

        private static int GetCowsCount(ref bool[] isDigitBullOrCow, int[] guessNumberDigits, IList<int> secretNumber)
        {
            int cows = 0;
            for (int k = 0; k < GameConstants.SecretNumberDigitsCount; k++)
            {
                bool isCowFound = false;
                for (int i = 0; i < GameConstants.SecretNumberDigitsCount; i++)
                {
                    if (i != k && !isCowFound)
                    {
                        if (!isDigitBullOrCow[i] && guessNumberDigits[k] == secretNumber[i])
                        {
                            isDigitBullOrCow[i] = true;
                            isCowFound = true;
                            cows++;
                        }
                    }
                }
            }
            return cows;
        }
    }
}
