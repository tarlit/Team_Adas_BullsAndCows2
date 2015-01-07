namespace BullsAndCows
{
    public struct FormattedGuessResult
    {
        public int Bulls;
        public int Cows;

        public override string ToString()
        {
            return string.Format(GameConstants.GuessResultFormat, this.Bulls, this.Cows);
        }
    }
}
