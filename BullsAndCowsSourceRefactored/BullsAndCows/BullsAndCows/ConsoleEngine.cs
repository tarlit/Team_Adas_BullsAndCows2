namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;

    class ConsoleEngine
    {
        private static readonly ConsoleEngine consoleEngineInstance;
        private string output;
        private IList<int> secretNumber;
        private HintProvider hintProvider;
        private ScoreBoard scoreBoard;
        private int guessesCount;

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

        private ConsoleEngine(IList<int> secretNumber, HintProvider hintProvider, ScoreBoard scoreBoard)
        {
            this.secretNumber = secretNumber;
            this.hintProvider = hintProvider;
            this.scoreBoard = scoreBoard;
            this.guessesCount = 0;
            this.output = GameConstants.WelcomeMessage;
        }

        public static ConsoleEngine GetEngine(IList<int> secretNumber, HintProvider hintProvider, ScoreBoard scoreBoard)
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
            secretNumber = SecretNumberProcessor.GenerateSecretNumber();
            this.guessesCount = 0;
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
                FormattedGuessResult guessResult = SecretNumberProcessor.CheckGuessResult(playerCommand, this.secretNumber);
                if (guessResult.Bulls == 4)
                {
                    if (hintProvider.HintsUsed == 0)
                    {
                        this.output = string.Format(
                            GameConstants.NumberGuessedWithoutHints, this.guessesCount, this.guessesCount == 1 ? "attempt" : "attempts");
                        string name = Console.ReadLine();
                        scoreBoard.AddScore(name, this.guessesCount);
                    }
                    else
                    {
                        this.output = string.Format(GameConstants.NumberGuessedWithHints,
                            this.guessesCount, this.guessesCount == 1 ? "attempt" : "attempts",
                            hintProvider.HintsUsed, hintProvider.HintsUsed == 1 ? "cheat" : "cheats");
                    }
                    this.output += scoreBoard.ToString() + Environment.NewLine +
                                    GameConstants.WelcomeMessage + Environment.NewLine;
                    secretNumber = SecretNumberProcessor.GenerateSecretNumber();
                    this.guessesCount = 0;
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
