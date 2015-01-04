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


        // checks if firstDigit is a bull:
        if (this.FirstDigit == firstDigit)
        {
            isFirstDigitBullOrCow = true;
            bulls++;
        }
    
        // checks if secondDigit is a bull:
        if (this.SecondDigit == secondDigit)
        {
            isSecondDigitBullOrCow = true;
            bulls++;
        }
        
        // checks if thirdDigit is a bull:
        if (this.ThirdDigit == thirdDigit)
        {
            isThirdDigitBullOrCow = true;
            bulls++;
        }
        
        // checks if fourthDigit is a bull:
        if (this.FourthDigit == fourthDigit)
        {
            isFourthDigitBullOrCow = true;
            bulls++;
        }
        
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
}
