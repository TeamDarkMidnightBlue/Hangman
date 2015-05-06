/*using System;
using System.Linq;
using System.Text;

namespace HangmanGame
{
    public class MainClass
    {
        //New class Ranking:
        private static Ranking theRanking = new Ranking();

        private const int InputLettersAllowedCount = 1;
        private const double NotRealPlayer = 1000000000.5;

        // Set words that can be guessed by the player
        private static readonly string[] WordsToGuess = 
        { 
            "computer",
            "programmer",
            "software",
            "debugger",
            "compiler",
            "developer",
            "algorithm",
            "array",
            "method",
            "variable"
        };
        private static readonly TopPlayer DefaultTopPlayer = new TopPlayer { PlayerName = "", PlayerScore = NotRealPlayer };
        
        // this is to track whether the player has used help, which affects his score
        private static bool _playerHasUsedHelp = false;

        // this is to hold the player's input after the validations of the input have been made
        private static char _playerInputLetter;

        // this is to track the number of games played and players,
        //so there wouldn't be more than 5 top players on the scoreboard
        private static int _gamesPlayedCounter;
        private static TopPlayer[] _topPlayers = new TopPlayer[6];

        public static void Main(string[] args)
        {
            // Upon start of the game, fill the scoreboard with default values
            for (int playersNumber = 0; playersNumber < 6; playersNumber++)
            {
                _topPlayers[playersNumber] = DefaultTopPlayer;
            }

            Random randomWordIndex = new Random();

            while (true)
            {   
                // main loop, used to restart game automatically
                int playerMistakes = 0;
                string currentWordtoGuess = WordsToGuess[randomWordIndex.Next(0, 10)];

                // these are what is shown on the actual screen
                // this is the word, or part of it, which is shown on the screen
                StringBuilder printedWord = new StringBuilder();

                //this is to hold the character, the player has input, while the validations are being done to it
                StringBuilder playerInputString = new StringBuilder();
                printedWord.Clear();

                Console.Write("\nWelcome to “Hangman” game.Please try to guess my secret word." +
                              "\nUse 'top' to view the top scoreboard, 'restart' to start a new game, " +
                              "\n'help' to cheat and 'exit' to quit the game.\n");

                for (int wordLength = 0; wordLength < currentWordtoGuess.Length; wordLength++)
                {   
                    // Takes the randomly selected word and hides it's characters to represent
                    // each of its letters in underscores
                    // e.g.: software becomes _ _ _ _ _ _ _ _
                    printedWord.Append("_ ");
                }
                
                // This is here to represent two things - the word the player's guessing
                // and the word that's being shown on the screen
                Word wordsInGame = new Word();
                wordsInGame.SetWordToBeGuessed(currentWordtoGuess);
                wordsInGame.SetPrintedWord(printedWord);

                while (wordsInGame.GetPrintedWord().Contains('_'))
                {
                    // while there are still characters to be guessed, continue with the game
                    Console.WriteLine("The secret word is " + wordsInGame.GetPrintedWord());
                    Console.Write("Enter your guess: ");

                    playerInputString.Clear();
                    playerInputString.Append(Console.ReadLine());

                    if (playerInputString.Length == InputLettersAllowedCount)
                    {
                        _playerInputLetter = (playerInputString[0]);
                    }

                    if (playerInputString.Length == InputLettersAllowedCount && 
                        wordsInGame.IsALetter(char.ToLower(_playerInputLetter)))
                    {
                        if (wordsInGame.CheckForLetter(char.ToLower(_playerInputLetter)))
                        {
                            wordsInGame.WriteTheLetter(char.ToLower(_playerInputLetter));
                            Console.WriteLine("Good job! You revealed " + wordsInGame.NumberOfInput(_playerInputLetter) + " letter");
                        }
                        else
                        {
                            Console.WriteLine("Sorry! There are no unrevealed letters " + "\"" + char.ToLower(_playerInputLetter)+ "\"");
                            playerMistakes++;
                        }

                    }
                    else
                    {
                        bool restart = false;

                        switch (playerInputString.ToString())
                        {
                            case "help": Help(wordsInGame); break;                                

                            case "exit": Environment.Exit(0); break;

                            case "restart": restart = true; break;

                            case "top": Top(); break;

                            default:
                                {
                                    Console.WriteLine("Incorect input");
                                    playerMistakes++;
                                    break;
                                }
                        }

                        if (!restart) continue;
                        Console.WriteLine("Game is Restarted");
                        break;
                    }

                    

                }   //end of while

                if (!wordsInGame.GetPrintedWord().Contains('_'))
                {
                    Console.WriteLine("The secret word is " + wordsInGame.GetPrintedWord());
                    Console.Write("\nYou won with " + playerMistakes + " mistakes");

                    bool betterThanLast = _topPlayers[4].PlayerScore > playerMistakes;
                    if (!_playerHasUsedHelp && betterThanLast)
                    {
                        
                        Console.Write("\nPlease enter your name for the top scoreboard: ");

                        //Example use of the new classes Ranking and Player:
                        string name = Console.ReadLine();
                        Player player = new Player(name);
                        player.AddScore(playerMistakes);
                        theRanking.AddPlayer(player);

                        Console.WriteLine(theRanking.GetRanking());

                        _topPlayers[_gamesPlayedCounter] = new TopPlayer { PlayerName = name, PlayerScore = playerMistakes };

                        //if (_gamesPlayedCounter < 5)
                        //{
                        //    _gamesPlayedCounter++;
                        //}

                        //Array.Sort(_topPlayers, (topPlayer1, topPlayer2) => topPlayer1.PlayerScore.CompareTo(topPlayer2.PlayerScore));
                        //Top();
                    }
                    else if (!betterThanLast)
                    {
                        Console.Write(" but your result is lower than top scores\n");
                    }
                    else
                    {
                        Console.Write(" but you have cheated. \nYou are not allowed to enter into the scoreboard.\n");
                    }

                    _playerHasUsedHelp = false;
                }
            }   //end of master loop
        } 
       
        private static void Top()
        {
            Console.WriteLine("Scoreboard: ");
            for (int playersNumber = 0; playersNumber < 5; playersNumber++)
            {
                if (_topPlayers[playersNumber].PlayerScore != NotRealPlayer)
                {
                    Console.WriteLine(_topPlayers[playersNumber].PlayerScore.ToString() + " " + _topPlayers[playersNumber].PlayerName);
                }
            }
            if (_gamesPlayedCounter == 0)
            {
                Console.WriteLine("Scoreboard is empty");
            }
        }
        private static void Help(Word game)
        {
            Console.WriteLine("OK, I reveal for you the next letter " + "\""
                               + game.GetWordToBeGuessed()[game.GetPrintedWord().IndexOf('_') / 2] + "\"");
            int firstMissingLetter = game.GetPrintedWord().IndexOf('_');
            game.WriteTheLetter(game.GetWordToBeGuessed()[firstMissingLetter / 2]);
            _playerHasUsedHelp = true;
        }
    }
}
*/