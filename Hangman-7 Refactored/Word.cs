<<<<<<< HEAD
﻿namespace Hangman
=======
﻿using System.Linq;
using System.Text;

namespace HangmanGame
>>>>>>> origin/master
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class serves as container for a word to be guessed by the user,
    /// and provides convenience methods to guess letters, check if the word is guessed
    /// and print the word in its revealed form or hidden form
    /// </summary>
    /// 
    public class Word : WordBase
    {
<<<<<<< HEAD
        private char[] revealedWord;
        private char[] hiddenWord;

        private string w;
        private System.Text.StringBuilder PrintedWord = new System.Text.StringBuilder();

        public Word(string word)
            : base(word)
        {
            this.WordToGuess = word;
            string underscores = new string('_', this.revealedWord.Length);
            this.hiddenWord = underscores.ToCharArray();
        }

        //remove this after refactoring
        public Word()
        {

        }

        /// <summary>
        /// returns the word in its revealed form
        /// </summary>
        override public string RevealedWord
        {
            get
            {
                return new string(this.revealedWord);
            }
        }

        /// <summary>
        /// Returns the word in its hidden form with underscores hiding the letters
        /// </summary>
        override public string HiddenWord
        {
            get
            {
                return new string(this.hiddenWord);
            }
        }

        /// <summary>
        /// Returns true if all letters/chars in the word are revealed
        /// Otherwise, returns false
        /// </summary>
        override public bool IsGuessed
        {
            get
            {
                for (int i = 0; i < this.hiddenWord.Length; i++)
                {
                    if (this.hiddenWord[i] == '_')
                    {
                        return false;
                    }
                }

                return true;
            }
        }


        //remove after refactoring
        public void SetPlayedWord(string theWord)
=======
        private string _word;
        private StringBuilder _printedWord = new StringBuilder();

        public void SetWordToBeGuessed(string inputWord)
>>>>>>> origin/master
        {
            _word = inputWord;
        }

<<<<<<< HEAD
        //remove after refactoring
        public string GetPlayedWord()
=======
        public string GetWordToBeGuessed()
>>>>>>> origin/master
        {
            return _word;
        }

<<<<<<< HEAD
        //remove after refactoring
        public void SetPrintedWord(System.Text.StringBuilder theWord)
=======
        public void SetPrintedWord(StringBuilder printedWord)
>>>>>>> origin/master
        {
            _printedWord = printedWord;
        }

        //remove after refactoring
        public string GetPrintedWord()
        {
            return _printedWord.ToString();
        }

<<<<<<< HEAD
        //remove after refactoring. Or move to different place. Breaks single responsibility principle.
        public bool Isletter(char Theletter)
=======
        public bool IsALetter(char inputLetter)
>>>>>>> origin/master
        {
            if (char.ToLower(inputLetter) >= 'a' && char.ToLower(inputLetter) <= 'z')
                return true;
            else
                return false;
        }

<<<<<<< HEAD
        //remove after refactoring
        public bool CheckForLetter(char TheLetter)
=======
        public bool CheckForLetter(char inputLetter)
>>>>>>> origin/master
        {
            return _word.Contains(char.ToLower(inputLetter));
        }

<<<<<<< HEAD
        //remove after refactoring
        public string WriteTheLetter(char TheLetter)
=======
        public string WriteTheLetter(char inputLetter)
>>>>>>> origin/master
        {

            for (int wordLength = 0; wordLength < _word.Length - 1; wordLength++)
            {
                if (_word.IndexOf(char.ToLower(inputLetter), wordLength) >= 0)
                {
                    _printedWord[_word.IndexOf(char.ToLower(inputLetter), wordLength) * 2] = inputLetter;
                }
            }

            return _printedWord.ToString();
        }

<<<<<<< HEAD
        //remove after refactoring
        public int NumberOfInput(char TheLetter)
=======
        public int NumberOfInput(char inputLetter)
>>>>>>> origin/master
        {
            return _word.Where((t, wordLength) => _word[wordLength].Equals(char.ToLower(inputLetter))).Count();
        }

        /// <summary>
        /// Method that checks if a given letter is contained in the word.
        /// If yes, returns true and modifies the hidden word, replacing underscores with the letter.
        /// </summary>
        /// <param name="charToGuess"></param>
        /// <returns></returns>
        override public bool Guess(char charToGuess)
        {
            var isInWord = false;

            for (int i = 0; i < this.revealedWord.Length; i++)
            {
                if (this.revealedWord[i] == charToGuess)
                {
                    isInWord = true;
                    this.hiddenWord[i] = charToGuess;
                }
            }

            return isInWord;
        }

        /// <summary>
        /// Private getters and setters for the word to be guessed.
        /// Throws exception if the word passed to the constructor contains illegal characters.
        /// </summary>
        private string WordToGuess
        {
            get
            {
                return new string(this.revealedWord);
            }

            set
            {
                string word = value.ToLower();

                foreach (char letter in word)
                {
                    if (letter < 'a' || letter > 'z')
                    {
                        throw new ArgumentException("The word can contain only characters from the English alphabet.");
                    }
                }
                this.revealedWord = word.ToCharArray();
            }
        }
    }
}