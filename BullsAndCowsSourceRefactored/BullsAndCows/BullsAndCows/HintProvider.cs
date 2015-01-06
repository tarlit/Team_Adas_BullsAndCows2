using System;

namespace BullsAndCows
{
    public class HintProvider
    {
        private char[] hintNumber = { GameConstants.DefaultSymbol, GameConstants.DefaultSymbol, GameConstants.DefaultSymbol, GameConstants.DefaultSymbol };

        public int HintsUsed
        {
            get;
            private set;
        }
        
        private readonly Random randomGenerator = new Random();

        public string GetHint(SecretNumber secretNumber)
        {

            if (this.HintsUsed < GameConstants.SecretNumberDigitsCount)
            {
                while (true)
                {
                    int hintPossition = randomGenerator.Next(0, GameConstants.SecretNumberDigitsCount);
                    if (hintNumber[hintPossition] == GameConstants.DefaultSymbol)
                    {
                        switch (hintPossition)
                        {
                            case 0:
                                hintNumber[hintPossition] = (char)(secretNumber.FirstDigit + '0');
                                break;
                            case 1:
                                hintNumber[hintPossition] = (char)(secretNumber.SecondDigit + '0');
                                break;
                            case 2:
                                hintNumber[hintPossition] = (char)(secretNumber.ThirdDigit + '0');
                                break;
                            default:
                                hintNumber[hintPossition] = (char)(secretNumber.FourthDigit + '0');
                                break;
                        }
                        break;
                    }
                }
                HintsUsed++;
            }
            return new String(hintNumber);
        }
    }
}