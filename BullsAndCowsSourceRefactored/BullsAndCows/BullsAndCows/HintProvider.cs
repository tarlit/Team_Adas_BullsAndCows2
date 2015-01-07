namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;

    public class HintProvider
    {
        private char[] hintNumber = { GameConstants.DefaultSymbol, GameConstants.DefaultSymbol, GameConstants.DefaultSymbol, GameConstants.DefaultSymbol };

        public int HintsUsed
        {
            get;
            private set;
        }

        private readonly Random randomGenerator = new Random();

        public string GetHint(IList<int> secretNumber)
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
                                hintNumber[hintPossition] = (char)(secretNumber[0] + '0');
                                break;
                            case 1:
                                hintNumber[hintPossition] = (char)(secretNumber[1] + '0');
                                break;
                            case 2:
                                hintNumber[hintPossition] = (char)(secretNumber[2] + '0');
                                break;
                            default:
                                hintNumber[hintPossition] = (char)(secretNumber[3] + '0');
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