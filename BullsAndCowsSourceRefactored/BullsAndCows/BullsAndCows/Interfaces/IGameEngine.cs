namespace BullsAndCows.Interfaces
{
    interface IGameEngine
    {
        string Output { get; }

        void ParseCommand(string playerInput);

        void SaveGameResultToFile();
    }
}
