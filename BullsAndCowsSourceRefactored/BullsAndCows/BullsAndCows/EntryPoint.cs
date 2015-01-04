namespace BullsAndCows
 {
     using System;

     public class EntryPoint
     {
         static void Main(string[] args)
         {
             var secretNumber = new SecretNumber();
             var scoreBoard = new ScoreBoard(GameConstants.ScoresFile);
             Console.WriteLine(GameConstants.WelcomeMessage);
             while (true)
             {
                 Console.Write("Enter your guess or command: ");
                 string playerCommand = Console.ReadLine();
                 if (playerCommand == "exit")
                 {
                     Console.WriteLine(GameConstants.GoodBuyMessage);
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
                             Console.WriteLine(GameConstants.WelcomeMessage);
                             secretNumber = new SecretNumber();
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
                                         Console.Write(GameConstants.NumberGuessedWithoutHints, secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts");
                                         string name = Console.ReadLine();
                                         scoreBoard.AddScore(name, secretNumber.GuessesCount);
                                     }
                                     else
                                     {
                                         Console.WriteLine(GameConstants.NumberGuessedWithHints,
                                             secretNumber.GuessesCount, secretNumber.GuessesCount == 1 ? "attempt" : "attempts",
                                             secretNumber.HintsUsed, secretNumber.HintsUsed == 1 ? "cheat" : "cheats");
                                     }
                                     Console.Write(scoreBoard);
                                     Console.WriteLine();
                                     Console.WriteLine(GameConstants.WelcomeMessage);
                                     secretNumber = new SecretNumber();
                                 }
                                 else
                                 {
                                     Console.WriteLine("{0} {1}", GameConstants.WrongNumberMessage, guessResult);
                                 }
                             }
                             catch (ArgumentException)
                             {
                                 Console.WriteLine(GameConstants.InvalidCommandMessage);
                             }
                             break;
                         }
                 }
             }
             scoreBoard.SaveToFile(GameConstants.ScoresFile);
         }
     }
 }
