namespace BullsAndCows
{
    using System;

    public class PlayerResult : IComparable
    {
        public PlayerResult(string playerName, int playerGuesses)
        {
            this.PlayerName = playerName;
            this.PlayerGuesses = playerGuesses;
        }

        public string PlayerName
        {
            get;
            private set;
        }

        public int PlayerGuesses
        {
            get;
            private set;
        }

        public override bool Equals(object obj)
        {
            var objectToCompare = obj as PlayerResult;
            if (objectToCompare == null)
            {
                return false;
            }
            else
            {
                return this.PlayerGuesses.Equals(objectToCompare) && this.PlayerName.Equals(objectToCompare);
            }
        }

        public override int GetHashCode()
        {
            return this.PlayerName.GetHashCode() ^ this.PlayerGuesses.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} {2}", this.PlayerName, this.PlayerGuesses, this.PlayerGuesses == 1 ? "guess" : "guesses");
        }

        public int CompareTo(object obj)
        {
            var objectToCompare = obj as PlayerResult;
            if (objectToCompare == null)
            {
                return -1;
            }
            if (this.PlayerGuesses.CompareTo(objectToCompare.PlayerGuesses) == 0)
            {
                return this.PlayerName.CompareTo(objectToCompare.PlayerName);
            }
            else
            {
                return this.PlayerGuesses.CompareTo(objectToCompare.PlayerGuesses);
            }
        }

        public string Serialize()
        {
            return string.Format("{0}_:::_{1}", this.PlayerName, this.PlayerGuesses);
        }

        public static PlayerResult Deserialize(string data)
        {
            string[] dataAsStringArray = data.Split(new string[] { "_:::_" }, StringSplitOptions.None);
            if (dataAsStringArray.Length != 2) return null;

            string name = dataAsStringArray[0];

            int guesses = 0;
            int.TryParse(dataAsStringArray[1], out guesses);

            return new PlayerResult(name, guesses);
        }
    }
}