namespace BullsAndCows
{
    using System;

    class ConsoleEngine
    {
        private static readonly ConsoleEngine consoleEngineInstance;
        private string input;
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

        public string Input
        {
            get
            {
                return this.input;
            }

            set
            {
                this.input = value;
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

        public void ParseCommand(string playerCommand)
        {
                if (playerCommand == "exit")
                {
                    this.output = GameConstants.GoodBuyMessage;
                }

                switch (playerCommand)
                {
                    case "top":
                        {
                            this.output = scoreBoard.ToString();
                            break;
                        }
                    case "restart":
                        {
                            this.output = GameConstants.WelcomeMessage;
                            secretNumber = new SecretNumber();
                            break;
                        }
                    case "help":
                        {
                            if (secretNumber == null)
                            {
                                this.output = GameConstants.EmptyInputMessage;
                            }
                            else
                            {
                                this.output = string.Format("The number looks like {0}.", this.hintProvider.GetHint(secretNumber));
                            }
                            break;   
                        }
                    default:
                        {
                            try
                            {
                                GuessResult guessResult = secretNumber.CheckGuessResult(playerCommand);
                                if (guessResult.Bulls == 4)
                                {
                                    if (hintProvider.HintsUsed == 0)
                                    {
                                        this.output = string.Format(GameConstants.NumberGuessedWithoutHints, secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts");
                                        string name = Console.ReadLine();
                                        scoreBoard.AddScore(name, secretNumber.GuessesCount);
                                    }
                                    else
                                    {
                                        this.output = string.Format(GameConstants.NumberGuessedWithHints,
                                            secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts",
                                            hintProvider.HintsUsed, hintProvider.HintsUsed == 1 ? "cheat" : "cheats");
                                    }
                                    this.output = scoreBoard.ToString() + Environment.NewLine +
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
                            break;
                        }
                }
            }
            // scoreBoard.SaveToFile(GameConstants.ScoresFile);
    }
}
