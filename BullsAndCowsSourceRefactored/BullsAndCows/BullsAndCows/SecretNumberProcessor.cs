namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;

    public static class SecretNumberProcessor
    {

        private static Random randomGenerator = new Random();

        public static IList<int> GenerateSecretNumber()
        {
            var secretNumber = new int[4];

            secretNumber[0] = randomGenerator.Next(0, 10);
            secretNumber[1] = randomGenerator.Next(0, 10);
            secretNumber[2] = randomGenerator.Next(0, 10);
            secretNumber[3] = randomGenerator.Next(0, 10);

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

            int bulls = 0;
            var guessNumberDigits = new int[4];
            guessNumberDigits[0] = int.Parse(guessNumberAsString[0].ToString());
            guessNumberDigits[1] = int.Parse(guessNumberAsString[1].ToString());
            guessNumberDigits[2] = int.Parse(guessNumberAsString[2].ToString());
            guessNumberDigits[3] = int.Parse(guessNumberAsString[3].ToString());

            bool isFirstDigitBullOrCow = false;
            // checks if firstDigit is a bull:
            if (secretNumber[0] == guessNumberDigits[0])
            {
                isFirstDigitBullOrCow = true;
                bulls++;
            }

            bool isSecondDigitBullOrCow = false;
            // checks if secondDigit is a bull:
            if (secretNumber[1] == guessNumberDigits[1])
            {
                isSecondDigitBullOrCow = true;
                bulls++;
            }

            bool isThirdDigitBullOrCow = false;
            // checks if thirdDigit is a bull:
            if (secretNumber[2] == guessNumberDigits[2])
            {
                isThirdDigitBullOrCow = true;
                bulls++;
            }

            bool isFourthDigitBullOrCow = false;
            // checks if fourthDigit is a bull:
            if (secretNumber[3] == guessNumberDigits[3])
            {
                isFourthDigitBullOrCow = true;
                bulls++;
            }

            int cows = 0;
            // checks if firstDigit is cow:
            if (!isSecondDigitBullOrCow && guessNumberDigits[0] == secretNumber[1])
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && guessNumberDigits[0] == secretNumber[2])
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && guessNumberDigits[0] == secretNumber[3])
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if secondDigit is cow:
            if (!isFirstDigitBullOrCow && guessNumberDigits[1] == secretNumber[0])
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && guessNumberDigits[1] == secretNumber[2])
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && guessNumberDigits[1] == secretNumber[3])
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if thirdDigit is cow:
            if (!isFirstDigitBullOrCow && guessNumberDigits[2] == secretNumber[0])
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && guessNumberDigits[2] == secretNumber[1])
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && guessNumberDigits[2] == secretNumber[3])
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if fourthDigit is cow:
            if (!isFirstDigitBullOrCow && guessNumberDigits[3] == secretNumber[0])
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && guessNumberDigits[3] == secretNumber[1])
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && guessNumberDigits[3] == secretNumber[3])
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }

            FormattedGuessResult guessResult = new FormattedGuessResult();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;
        }
    }
}
