namespace BullsAndCows
 {
     using System;

     public class BullsAndCowsGame
     {
         static void Main()
         {
             var hintProvider = new HintProvider();
             var secretNumber = new SecretNumber();
             var scoreBoard = new ScoreBoard(GameConstants.ScoresFile);
             var consoleEngine = ConsoleEngine.GetEngine(secretNumber, hintProvider, scoreBoard);
             StartGame(consoleEngine);
         }

         private static void StartGame(ConsoleEngine engine)
         {
             Console.WriteLine(engine.Output);
             string playerInput = Console.ReadLine();
             while (playerInput != GameCommands.Exit)
             {
                 engine.ParseCommand(playerInput);
                 Console.WriteLine(engine.Output);
                 playerInput = Console.ReadLine();
             }
             engine.SaveGameResult();
         }
     }
 }
