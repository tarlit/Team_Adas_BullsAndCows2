
namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public string GetHint()
    {
        if (this.HintsUsed < SecretNumberDigitsCount)
        {
            while (true)
            {
                int hintPossition = randomGenerator.Next(0, SecretNumberDigitsCount);
                if (hintNumber[hintPossition] == DefaultSymbol)
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
}
