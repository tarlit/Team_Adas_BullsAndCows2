namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Interfaces;

    public class GameEngine : IGameEngine
    {
        private static GameEngine consoleEngineInstance;
        private string output;
        private HintProvider hintProvider;
        private IList<int> secretNumber;
        private IResultStorage scoreBoard;
        private int guessesCount;
        private string username;

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

        private GameEngine(IList<int> secretNumber, HintProvider hintProvider, IResultStorage scoreBoard, string username)
        {
            this.secretNumber = secretNumber;
            this.hintProvider = hintProvider;
            this.scoreBoard = scoreBoard;
            this.username = username;
            this.guessesCount = 0;
            this.output = GameConstants.WelcomeMessage;
        }

        public static GameEngine GetEngine(IList<int> secretNumber, HintProvider hintProvider, ScoreBoard scoreBoard, string username)
        {
            if (consoleEngineInstance == null)
            {
                consoleEngineInstance = new GameEngine(secretNumber, hintProvider, scoreBoard, username);
            }

            return consoleEngineInstance;
        }

        public void ParseCommand(string playerInput)
        {
            if (playerInput == GameCommands.Exit)
            {
                this.output = GameConstants.GoodBuyMessage;
                return;
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

        public void SaveGameResultToFile()
        {
            scoreBoard.SaveToFile(GameConstants.ScoresFile);
        }

        private void ProcessRestartCommand()
        {
            this.Output = GameConstants.WelcomeMessage;
            secretNumber = SecretNumberProcessor.GenerateSecretNumber();
            this.guessesCount = 0;
        }

        private void ProcessHelpCommand()
        {
            this.Output = string.Format(GameConstants.HintMessage, this.hintProvider.GetHint(secretNumber));
        }

        private void ProcessGuessNumber(string playerCommand)
        {
            try
            {
                AnswerProvider guessResult = SecretNumberProcessor.CheckGuessResult(playerCommand, this.secretNumber);
                if (guessResult.Bulls == 4)
                {
                    if (hintProvider.HintsUsed == 0)
                    {
                        this.Output = string.Format(
                            GameConstants.NumberGuessedWithoutHints, this.guessesCount, this.guessesCount == 1 ? "attempt" : "attempts");
                        scoreBoard.AddScore(this.username, this.guessesCount);
                    }
                    else
                    {
                        this.Output = string.Format(GameConstants.NumberGuessedWithHints,
                            this.guessesCount, this.guessesCount == 1 ? "attempt" : "attempts",
                            hintProvider.HintsUsed, hintProvider.HintsUsed == 1 ? "cheat" : "cheats");
                    }

                    this.Output += scoreBoard.ToString() + Environment.NewLine +
                                    GameConstants.WelcomeMessage + Environment.NewLine;
                    secretNumber = SecretNumberProcessor.GenerateSecretNumber();
                    this.guessesCount = 0;
                }
                else
                {
                    this.Output = string.Format("{0} {1}", GameConstants.WrongNumberMessage, guessResult);
                    this.guessesCount++;
                }
            }
            catch (ArgumentException)
            {
                this.Output = GameConstants.InvalidCommandMessage;
            }
        }
    }
}
