namespace BullsAndCows
{
    using System;
    using System.Text;

    public class SecretNumber
    {
        private Random randomGenerator;
        private char[] hintNumber;

        public SecretNumber()
        {
            randomGenerator = new Random();
            hintNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.HintsUsed = 0;
            this.GuessesCount = 0;
            this.GenerateSecretDigits();
        }

        public int HintsUsed
        {
            get;
            private set;
        }

        public int GuessesCount
        {
            get;
            private set;
        }

        public int FirstDigit
        {
            get;
            private set;
        }

        public int SecondDigit
        {
            get;
            private set;
        }

        public int ThirdDigit
        {
            get;
            private set;
        }

        public int FourthDigit
        {
            get;
            private set;
        }

        public string GetHint()
        {
            if (this.HintsUsed < 4)
            {
                while (true)
                {
                    int hintPossition = randomGenerator.Next(0, 4);
                    if (hintNumber[hintPossition] == 'X')
                    {
                        switch (hintPossition)
	                    {
                            case 0: hintNumber[hintPossition] = (char)(this.FirstDigit + '0');
                                break;
                            case 1: hintNumber[hintPossition] = (char)(this.SecondDigit + '0');
                                break;
                            case 2: hintNumber[hintPossition] = (char)(this.ThirdDigit + '0');
                                break;
                            default: hintNumber[hintPossition] = (char)(this.FourthDigit + '0');
                                break;
	                    }
                        break;
                    }
                }
                HintsUsed++;
            }
            return new String(hintNumber);
        }

        public GuessResult TryToGuess(string number)
        {
            if (string.IsNullOrEmpty(number) || number.Trim().Length != 4)
            {
                throw new ArgumentException("Invalid string number");
            }
            return TryToGuess(number[0] - '0', number[1] - '0', number[2] - '0', number[3] - '0');
        }

        private GuessResult TryToGuess(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
        {
            if (firstDigit < 0 || firstDigit > 9)
            {
                throw new ArgumentException("Invalid first digit");
            }
            if (secondDigit < 0 || secondDigit > 9)
            {
                throw new ArgumentException("Invalid second digit");
            }
            if (thirdDigit < 0 || thirdDigit > 9)
            {
                throw new ArgumentException("Invalid third digit");
            }
            if (fourthDigit < 0 || fourthDigit > 9)
            {
                throw new ArgumentException("Invalid fourth digit");
            }

            this.GuessesCount++;

            int bulls = 0;

            bool isFirstDigitBullOrCow = false;
            // checks if firstDigit is a bull:
            if (this.FirstDigit == firstDigit)
            {
                isFirstDigitBullOrCow = true;
                bulls++;
            }

            bool isSecondDigitBullOrCow = false;
            // checks if secondDigit is a bull:
            if (this.SecondDigit == secondDigit)
            {
                isSecondDigitBullOrCow = true;
                bulls++;
            }

            bool isThirdDigitBullOrCow = false;
            // checks if thirdDigit is a bull:
            if (this.ThirdDigit == thirdDigit)
            {
                isThirdDigitBullOrCow = true;
                bulls++;
            }

            bool isFourthDigitBullOrCow = false;
            // checks if fourthDigit is a bull:
            if (this.FourthDigit == fourthDigit)
            {
                isFourthDigitBullOrCow = true;
                bulls++;
            }

            int cows = 0;
            // checks if firstDigit is cow:
            if (!isSecondDigitBullOrCow && firstDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && firstDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && firstDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if secondDigit is cow:
            if (!isFirstDigitBullOrCow && secondDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && secondDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && secondDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if thirdDigit is cow:
            if (!isFirstDigitBullOrCow && thirdDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && thirdDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isFourthDigitBullOrCow && thirdDigit == FourthDigit)
            {
                isFourthDigitBullOrCow = true;
                cows++;
            }

            // checks if fourthDigit is cow:
            if (!isFirstDigitBullOrCow && fourthDigit == FirstDigit)
            {
                isFirstDigitBullOrCow = true;
                cows++;
            }
            else if (!isSecondDigitBullOrCow && fourthDigit == SecondDigit)
            {
                isSecondDigitBullOrCow = true;
                cows++;
            }
            else if (!isThirdDigitBullOrCow && fourthDigit == ThirdDigit)
            {
                isThirdDigitBullOrCow = true;
                cows++;
            }

            GuessResult guessResult = new GuessResult();
            guessResult.Bulls = bulls;
            guessResult.Cows = cows;
            return guessResult;
        }

        private void GenerateSecretDigits()
        {
            this.FirstDigit = randomGenerator.Next(0, 10);
            this.SecondDigit = randomGenerator.Next(0, 10);
            this.ThirdDigit = randomGenerator.Next(0, 10);
            this.FourthDigit = randomGenerator.Next(0, 10);
        }

        public override string ToString()
        {
            StringBuilder numberStringBuilder = new StringBuilder();
            numberStringBuilder.Append(FirstDigit);
            numberStringBuilder.Append(SecondDigit);
            numberStringBuilder.Append(ThirdDigit);
            numberStringBuilder.Append(FourthDigit);
            return numberStringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            SecretNumber objectToCompare = obj as SecretNumber;
            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return (FirstDigit == objectToCompare.FirstDigit &&
                        SecondDigit == objectToCompare.SecondDigit &&
                        ThirdDigit == objectToCompare.ThirdDigit &&
                        FourthDigit == objectToCompare.FourthDigit);
            }
        }

        public override int GetHashCode()
        {
            return FirstDigit.GetHashCode() ^ SecondDigit.GetHashCode() ^ ThirdDigit.GetHashCode() ^ FourthDigit.GetHashCode();
        }
    }
}
