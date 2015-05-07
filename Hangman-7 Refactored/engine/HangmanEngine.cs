namespace HangmanGame
{
    using System;

    public class HangmanEngine
    {
        private IWordFactory wordFactory;
        private Ranking theRanking;
        private bool isRunning = true;

        public HangmanEngine(IWordFactory factory)
        {
            this.wordFactory = factory;
            this.theRanking = new Ranking();
        }

        public void Run()
        {
            // This is the main loop, used for exiting or restarting the game
            while (this.isRunning)
            {
                Word wordToGuess = (Word)wordFactory.CreateWord();
                Player currentPlayer = new Player("guest");
                bool hasUsedHelp = false;

                Console.Write(Messages.WelcomeMessage);

                // This is the game loop, which runs while the player tries to guess the word
                while (!wordToGuess.IsGuessed && this.isRunning)
                {
                    Console.WriteLine(Messages.SecretWordMessage, wordToGuess.HiddenWord);
                    Console.Write(Messages.EnterGuessMessage);

                    string playerInputString = Console.ReadLine();

                    if (!IsValid(playerInputString))
                    {
                        bool restartGame = false;
                        switch (playerInputString)
                        {
                            case "exit":
                                isRunning = false;
                                break;
                            case "restart":
                                restartGame = true;
                                break;
                            case "top":
                                Console.WriteLine(theRanking.GetRanking());
                                break;
                            case "help":
                                Console.WriteLine(Messages.RevealNextLetterMessage, wordToGuess.Help());
                                hasUsedHelp = true;
                                break;
                            default:
                                {
                                    Console.WriteLine(Messages.IncorrectCommandMessage);
                                    break;
                                }
                        }

                        if (restartGame)
                        {
                            Console.WriteLine(Messages.RestartingGameMessage);
                            break;
                        }
                    }
                    else
                    {
                        if (playerInputString != null)
                        {
                            char inputLetter = (char)playerInputString.ToCharArray()[0];

                            if (wordToGuess.Guess(inputLetter))
                            {
                                Console.WriteLine(Messages.CorrectGuessMessage, inputLetter);
                            }
                            else
                            {
                                Console.WriteLine(Messages.WrongGuessMessage);
                                currentPlayer.IncrementCurrentScore();
                            }
                        }

                        if (wordToGuess.IsGuessed)
                        {
                            Console.WriteLine(Messages.WinningMessage, currentPlayer.CurrentScore);
                            Console.WriteLine(Messages.SecretWordMessage, wordToGuess.RevealedWord);

                            if (hasUsedHelp)
                            {
                                Console.WriteLine(Messages.CheatedMessage);
                            }
                            else
                            {
                                Console.Write(Messages.EnterNameMessage);
                                string name = Console.ReadLine();

                                if (name.Length > 0)
                                {
                                    currentPlayer.Name = name;
                                }

                                theRanking.AddScore(currentPlayer);
                                Console.WriteLine(theRanking.GetRanking());
                            }
                        }
                    }
                }
            }

            Environment.Exit(0);
        }

        private static bool IsValid(string input)
        {
            bool result = (input.Length == 1 && char.ToLower(input[0]) >= 'a' && char.ToLower(input[0]) <= 'z');
            return result;
        }
    }
}