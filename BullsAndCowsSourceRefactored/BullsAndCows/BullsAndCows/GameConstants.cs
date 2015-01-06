namespace BullsAndCows
{
    using System;

    public static class GameConstants
    {
        public const string ScoresFile = "scores.txt";
        public const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        public const string WrongNumberMessage = "Wrong number!";
        public const string InvalidCommandMessage = "Incorrect guess or command!";
        public const string NumberGuessedWithoutHints = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        public const string NumberGuessedWithHints = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        public const string GoodBuyMessage = "Good bye!";
        public const char DefaultSymbol = 'X';
        public const int SecretNumberDigitsCount = 4;
        public const string EmptyInputMessage = "Empty input string passed.";
        public const string WrongLenghtInputMessage = "Wrong length for the input string";
        public const string IncorrectNumberMessage = "Input string is not a correct number";
        // Commands
        public const string Exit = "exit";

    }
}
