namespace BullsAndCows
{
    public struct rezultat
    {
        public int Bulls;
        public int Cows;

        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
