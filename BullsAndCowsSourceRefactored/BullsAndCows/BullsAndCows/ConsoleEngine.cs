namespace BullsAndCows
{
    using System;

    class ConsoleEngine
    {
        private static readonly ConsoleEngine consoleEngineInstance;
        private string output;
        private SecretNumber secretNumber;
        private HintProvider hintProvider;
        private ScoreBoard scoreBoard;

        public string Output
        {
            get
            {
                return this.output;
            }

            private set
            {
                this.output = value;
            }
        }

        private ConsoleEngine(SecretNumber secretNumber, HintProvider hintProvider, ScoreBoard scoreBoard)
        {
            this.secretNumber = secretNumber;
            this.hintProvider = hintProvider;
            this.scoreBoard = scoreBoard;
            this.output = GameConstants.WelcomeMessage;
        }

        public static ConsoleEngine GetEngine(SecretNumber secretNumber, HintProvider hintProvider, ScoreBoard scoreBoard)
        {
            if (consoleEngineInstance == null)
            {
                return new ConsoleEngine(secretNumber, hintProvider, scoreBoard);
            }
            else
            {
                return consoleEngineInstance;
            }
        }

        public void ParseCommand(string playerInput)
        {
                if (playerInput == GameCommands.Exit)
                {
                    this.output = GameConstants.GoodBuyMessage;
                }

                switch (playerInput)
                {
                    case GameCommands.Top:
                    {
                        this.output = scoreBoard.ToString();
                        break;
                    }
                    case GameCommands.Restart:
                    {
                        ProcessRestartCommand();
                        break;
                    }
                    case GameCommands.Help:
                    {
                        ProcessHelpCommand();
                        break;   
                    }
                    default:
                    {
                        ProcessGuessNumber(playerInput);
                        break;
                    }
                }
            }

        public void SaveGameResult()
        {
            scoreBoard.SaveToFile(GameConstants.ScoresFile);
        }

        private void ProcessRestartCommand()
        {
            this.output = GameConstants.WelcomeMessage;
            secretNumber = new SecretNumber();
        }

        private void ProcessHelpCommand()
        {
            if (secretNumber == null)
            {
                this.output = GameConstants.EmptyInputMessage;
            }
            else
            {
                this.output = string.Format("The number looks like {0}.", this.hintProvider.GetHint(secretNumber));
            }
        }

        private void ProcessGuessNumber(string playerCommand)
        {
            try
            {
                FormattedGuessResult guessResult = secretNumber.CheckGuessResult(playerCommand);
                if (guessResult.Bulls == 4)
                {
                    if (hintProvider.HintsUsed == 0)
                    {
                        this.output = string.Format(
                            GameConstants.NumberGuessedWithoutHints, secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts");
                        string name = Console.ReadLine();
                        scoreBoard.AddScore(name, secretNumber.GuessesCount);
                    }
                    else
                    {
                        this.output = string.Format(GameConstants.NumberGuessedWithHints,
                            secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts",
                            hintProvider.HintsUsed, hintProvider.HintsUsed == 1 ? "cheat" : "cheats");
                    }
                    this.output += scoreBoard.ToString() + Environment.NewLine +
                                    GameConstants.WelcomeMessage + Environment.NewLine;
                    secretNumber = new SecretNumber();
                }
                else
                {
                    this.output = string.Format("{0} {1}", GameConstants.WrongNumberMessage, guessResult);
                }
            }
            catch (ArgumentException)
            {
                this.output = GameConstants.InvalidCommandMessage;
            }
        }
    }
}
