namespace BullsAndCowsTests
{
    using BullsAndCows;
    using NUnit.Framework;

    class GameConstantsUnitTests
    {
        [Test]
        public void scoresFileGameConstant()
        {
            string scoresFile = GameConstants.ScoresFile;

            Assert.AreEqual(scoresFile, "scores.txt");
        }

        [Test]
        public void defaultSymbolGameConstant()
        {
            char defaultSymbol = GameConstants.DefaultSymbol;

            Assert.AreEqual(defaultSymbol, 'X');
        }

        [Test]
        public void secretNumberDigitsCountGameConstant()
        {
            int digitCount = GameConstants.SecretNumberDigitsCount;

            Assert.AreEqual(digitCount, 4);
        }

        [Test]
        public void emptyInputMessageGameConstant()
        {
            string emptyInputMessage = GameConstants.EmptyInputMessage;

            Assert.AreEqual(emptyInputMessage, "Empty input string passed.");
        }

        [Test]
        public void welcomMessageGameConstant()
        {
            string welcomeMessage = GameConstants.WelcomeMessage;

            Assert.AreEqual(welcomeMessage, "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }
    }
}
