﻿namespace HangmanGame
{
    using System;

    public class Engine
    {
        public static void Main(string[] args)
        {
            bool isRunning = true;
            Ranking ranking = new Ranking();
            WordFactory wordFactory = new WordFactory(WordRepository.Words);

            // This is the main loop, used for exiting or restarting the game
            while (isRunning)
            {
                Player player = new Player(false, 0);
                Word wordToGuess = (Word) wordFactory.CreateWord();

                Console.Write(Messages.WelcomeMessage);

                // This is the game loop, which runs while the player tries to guess the word
                while (!wordToGuess.IsGuessed && isRunning)
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
                                Console.WriteLine(ranking.GetRanking());
                                break;
                            case "help":
                                Help(ref player, wordToGuess);
                                break;
                            default:
                            {
                                Console.WriteLine(Messages.IncorrectCommandMessage);
                                player.Score++;
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
                                Console.WriteLine(Messages.CorrectGuessMessage, wordToGuess.NumberOfInput(inputLetter));
                            }
                            else
                            {
                                player.Score++;
                                Console.WriteLine(Messages.WrongGuessMessage);
                            }
                        }

                        if (wordToGuess.IsGuessed)
                        {
                            Console.WriteLine(Messages.WinningMessage, player.Score);

                            if (ranking.IsPlayerTop(player, player.HasUsedHelp))
                            {
                                Console.Write(Messages.EnterNameMessage);
                                player.Name = Console.ReadLine();
                                ranking.AddPlayer(player);
                            }
                            else if (!player.HasUsedHelp)
                            {
                                Console.WriteLine(Messages.LowScoreMessage);
                            }
                            else
                            {
                                Console.WriteLine(Messages.CheatedMessage);
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

        //this doesn't work properly yet..
        private static void Help(ref Player player, Word currentWord)
        {
            Console.WriteLine(Messages.RevealNextLetterMessage, currentWord.RevealedWord.ToCharArray()[currentWord.HiddenWord.IndexOf('_')]);
            int firstMissingLetter = currentWord.HiddenWord.IndexOf('_');
            currentWord.Guess(currentWord.RevealedWord.ToCharArray()[firstMissingLetter]);
            player.HasUsedHelp = true;
        }
    }
}
