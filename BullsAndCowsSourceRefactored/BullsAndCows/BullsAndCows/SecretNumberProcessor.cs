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

            for (int digit = 0; digit < GameConstants.SecretNumberDigitsCount; digit++)
            {
                secretNumber[digit] = randomGenerator.Next(0, 10);    
            }

            return secretNumber;
        } 

        public static FormattedGuessResult CheckGuessResult(string stringInput, IList<int> secretNumber)
        {
            ValidateGuessNumber(stringInput);
            return GetGuessResult(stringInput, secretNumber);
        }

        private static uint ValidateGuessNumber(string stringInput)
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

            uint guessNumber = 0;
            bool isValidNumber = uint.TryParse(guessNumberAsString, out guessNumber);
            if (!isValidNumber)
            {
                throw new ArgumentException(GameConstants.IncorrectNumberMessage);
            }

            return guessNumber;
        }

        private static FormattedGuessResult GetGuessResult(string guessNumberAsString, IList<int> secretNumber)
        {
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

            var guessResult = new FormattedGuessResult();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;
        }

        private static bool[] InitBoolArrayWithValue(int length, bool value)
        {
            var result = new bool[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = value;
            }

            return result;
        }

        private static int GetBullsCount(ref bool[] isDigitBullOrCow, int[] guessNumberDigits, IList<int> secretNumber)
        {
            int bulls = 0;
            for (int digit = 0; digit < GameConstants.SecretNumberDigitsCount; digit++)
            {
                if (secretNumber[digit] == guessNumberDigits[digit])
                {
                    isDigitBullOrCow[digit] = true;
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
