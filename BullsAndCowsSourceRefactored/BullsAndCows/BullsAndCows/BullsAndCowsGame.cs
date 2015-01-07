namespace BullsAndCows
 {
     using System;
     using BullsAndCows.Interfaces;

     public class BullsAndCowsGame
     {
         static void Main()
         {
             // Get player information
             Console.Write(GameConstants.EnterUsernameMessage);
             string username = Console.ReadLine();

             var hintProvider = new HintProvider();
             var secretNumber = SecretNumberProcessor.GenerateSecretNumber();
             var scoreBoard = new ScoreBoard(GameConstants.ScoresFile);
             var consoleEngine = GameEngine.GetEngine(secretNumber, hintProvider, scoreBoard, username); 
             StartGame(consoleEngine);
         }

         private static void StartGame(IGameEngine engine)
         {
             Console.WriteLine(engine.Output);
             string playerInput = Console.ReadLine();
             while (playerInput != GameCommands.Exit)
             {
                 engine.ParseCommand(playerInput);
                 Console.WriteLine(engine.Output);
                 playerInput = Console.ReadLine();
             }

             engine.SaveGameResultToFile();
         }
     }
 }
