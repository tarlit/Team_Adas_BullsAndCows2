namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using BullsAndCows.Interfaces;

    public class Scoreboard : IResultStorage
    {
        private SortedSet<PlayerResult> playersResults;
        private const int MaxPlayersToShowInScoreboard = 10;

        public Scoreboard(string filename)
        {
            this.playersResults = new SortedSet<PlayerResult>();
            try
            {
                using (var inputStream = new StreamReader(filename))
                {
                    while (!inputStream.EndOfStream)
                    {
                        string scoreString = inputStream.ReadLine();
                        this.playersResults.Add(PlayerResult.Deserialize(scoreString));
                    }
                }
            }
            catch (IOException)
            {
                // Stop reading
            }
        }

        public void AddScore(string playerName, int playerGuesses)
        {
            var pleyerResult = new PlayerResult(playerName, playerGuesses);
            this.playersResults.Add(pleyerResult);
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using (var outputStream = new StreamWriter(filename))
                {
                    foreach (PlayerResult playerResult in playersResults)
                    {
                        outputStream.WriteLine(playerResult.Serialize());
                    }
                }
            }
            catch (IOException)
            {
                // Stop writing
            }
        }

        public override string ToString()
        {
            if (playersResults.Count == 0)
            {
                return "Top scoreboard is empty." + Environment.NewLine;
            }

            var scoreBoard = new StringBuilder();
            scoreBoard.AppendLine("Scoreboard:");
            int players = 0;
            foreach (PlayerResult playerResult in playersResults)
            {
                players++;
                scoreBoard.AppendLine(string.Format("{0}. {1}", players, playerResult));
                if (players > MaxPlayersToShowInScoreboard)
                {
                    break;
                }
            }

            return scoreBoard.ToString();
        }
    }
}
