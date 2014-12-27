namespace BullsAndCows
{
    using System;

    public class EntryPoint
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutHints = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithHints = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";

        static void Main(string[] args)
        {
            var secretNumber = SecretNumber.Instance;
            var scoreBoard = new Scoreboard(ScoresFile);
            Console.WriteLine(WelcomeMessage);
            while (true)
            {
                Console.Write("Enter your guess or command: ");
                string playerCommand = Console.ReadLine();
                if (playerCommand == "exit")
                {
                    Console.WriteLine(GoodBuyMessage);
                    break;
                }
                switch (playerCommand)
                {
                    case "top":
                        {
                            Console.Write(scoreBoard);
                            break;
                        }
                    case "restart":
                        {
                            Console.WriteLine();
                            Console.WriteLine(WelcomeMessage);
                            secretNumber = SecretNumber.Instance;
                            break;
                        }
                    case "help":
                        {
                            Console.WriteLine("The number looks like {0}.", secretNumber.GetHint());
                            break;
                        }
                    default:
                        {
                            try
                            {
                                GuessResult guessResult = secretNumber.CheckGuessResult(playerCommand);
                                if (guessResult.Bulls == 4)
                                {
                                    if (secretNumber.HintsUsed == 0)
                                    {
                                        Console.Write(NumberGuessedWithoutHints, secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts");
                                        string name = Console.ReadLine();
                                        scoreBoard.AddScore(name, secretNumber.GuessesCount);
                                    }
                                    else
                                    {
                                        Console.WriteLine(NumberGuessedWithHints,
                                            secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts",
                                            secretNumber.HintsUsed, secretNumber.HintsUsed == 1 ? "cheat" : "cheats");
                                    }
                                    Console.Write(scoreBoard);
                                    Console.WriteLine();
                                    Console.WriteLine(WelcomeMessage);
                                    secretNumber = SecretNumber.Instance;
                                }
                                else
                                {
                                    Console.WriteLine("{0} {1}", WrongNumberMessage, guessResult);
                                }
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine(InvalidCommandMessage);
                            }
                            break;
                        }
                }
            }
            scoreBoard.SaveToFile(ScoresFile);
        }
    }
}
