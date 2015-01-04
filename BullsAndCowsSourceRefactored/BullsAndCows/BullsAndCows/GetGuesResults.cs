namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    private GuessResult GetGuessResult(int firstDigit, int secondDigit, int thirdDigit, int fourthDigit)
    {
        this.GuessesCount++;

        int bulls = 0;
        int cows = 0;

        bool isFirstDigitBullOrCow = false;
        bool isSecondDigitBullOrCow = false;
        bool isThirdDigitBullOrCow = false;
        bool isFourthDigitBullOrCow = false;

        // checks if 1st, 2nd, 3rd of 4th digits are bull:
        if (this.FirstDigit == firstDigit)
        {
            isFirstDigitBullOrCow = true;
            bulls++;
        }

        if (this.SecondDigit == secondDigit)
        {
            isSecondDigitBullOrCow = true;
            bulls++;
        }
        
        if (this.ThirdDigit == thirdDigit)
        {
            isThirdDigitBullOrCow = true;
            bulls++;
        }
        
        if (this.FourthDigit == fourthDigit)
        {
            isFourthDigitBullOrCow = true;
            bulls++;
        }
        
        // checks if 1st, 2nd, 3rd of 4th digits are cow:
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
}
