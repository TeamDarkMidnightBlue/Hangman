namespace HangmanGame
{
    public static class Messages
    {
        public const string WelcomeMessage = "\nWelcome to “Hangman” game.Please try to guess my secret word." +
            "\nUse 'top' to view the top scoreboard, 'restart' to start a new game, " +
            "\n'help' to cheat and 'exit' to quit the game.\n";
        public const string SecretWordMessage = "The secret word is {0}.";
        public const string EnterGuessMessage = "Enter your guess: ";
        public const string CorrectGuessMessage = "Good job! You revealed {0} letter";
        public const string WrongGuessMessage = "Sorry! There are no unrevealed letters.";
        public const string IncorrectCommandMessage = "Incorect command. Please, try again.";
        public const string RestartingGameMessage = "Hangman has restarted.";
        public const string WinningMessage = "\nYou won with {0}  mistakes.";
        public const string EnterNameMessage = "\nPlease enter your name for the top scoreboard: ";
        public const string LowScoreMessage = " but your result is lower than top scores.\n";
        public const string CheatedMessage = " but you have cheated. \nYou are not allowed to enter into the scoreboard.\n";
        public const string RankingHeaderMessage = "Ranking: ";
        public const string RankingEmptyMessage = "Ranking is empty.";
        public const string RevealNextLetterMessage = "OK, I reveal for you the next letter: \\{0}\\.";
    }
}
