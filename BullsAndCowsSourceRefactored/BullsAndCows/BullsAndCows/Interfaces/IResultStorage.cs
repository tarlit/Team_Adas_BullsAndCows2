namespace BullsAndCows.Interfaces
{
    interface IResultStorage
    {
        void AddScore(string playerName, int playerGuesses);

        void SaveToFile(string filename);
    }
}
