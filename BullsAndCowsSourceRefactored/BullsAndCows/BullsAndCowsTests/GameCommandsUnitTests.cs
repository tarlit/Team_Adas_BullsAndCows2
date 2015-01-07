namespace BullsAndCowsTests
{
    using BullsAndCows;
    using NUnit.Framework;

    class GameCommandsUnitTests
    {
        [Test]
        public void exitGameCommand()
        {
            string exitCommand = GameCommands.Exit;

            Assert.AreEqual(exitCommand, "exit");
        }
    }
}
