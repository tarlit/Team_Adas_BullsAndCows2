namespace BullsAndCows
{
    public struct AnswerProvider
    {
        public int Bulls;
        public int Cows;

        public override string ToString()
        {
            return string.Format(GameConstants.GuessResultFormat, this.Bulls, this.Cows);
        }
    }
}
