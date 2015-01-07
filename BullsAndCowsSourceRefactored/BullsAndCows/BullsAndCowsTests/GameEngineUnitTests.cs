namespace BullsAndCowsTests
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using BullsAndCows;
    using NUnit.Framework;

    class GameEngineUnitTests
    {
        private static string username = "TestPlayer";
        private static HintProvider hintProvider = new HintProvider();
        private static IList<int> secretNumber = new int[]{ 5, 8, 9, 7 };
        private static ScoreBoard scoreBoard = new ScoreBoard(GameConstants.ScoresFile);
        private static GameEngine consoleEngine = GameEngine.GetEngine(secretNumber, hintProvider, scoreBoard, username);

        [Test]
        public void UserRestartCommandShouldShowTheWelcomeMessage()
        {
            string userCommand = "restart";
            consoleEngine.ParseCommand(userCommand);
            var output = consoleEngine.Output;

            Assert.AreEqual(GameConstants.WelcomeMessage, output);
        }

        [Test]
        public void UserExitCommandShouldShowTheGoodByeMessage()
        {
            string userCommand = "exit";
            consoleEngine.ParseCommand(userCommand);
            var output = consoleEngine.Output;

            Assert.AreEqual(GameConstants.GoodBuyMessage, output);
        }

        [Test]
        public void UserHelpCommandShoulReturnHelpNumber()
        {
            string helpMessagePattern = "^The number looks like [X0-9]{4}.$";
            Regex helpMessageRegex = new Regex(helpMessagePattern);
            string userCommand = "help";
            consoleEngine.ParseCommand(userCommand);
            var hintMessage = consoleEngine.Output;
            bool hintMessageMatchesThePattern = helpMessageRegex.IsMatch(hintMessage);

            Assert.True(hintMessageMatchesThePattern);
        }
    }
}
