using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows;
using NUnit.Framework;

namespace BullsAndCowsTests
{
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
