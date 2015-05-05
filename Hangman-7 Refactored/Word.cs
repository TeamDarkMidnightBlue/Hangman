namespace Hangman
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
        {
            this.w = theWord;
        }

        //remove after refactoring
        public string GetPlayedWord()
        {
            return this.w;
        }

        //remove after refactoring
        public void SetPrintedWord(System.Text.StringBuilder theWord)
        {
            this.PrintedWord = theWord;
        }

        //remove after refactoring
        public string GetPrintedWord()
        {
            return this.PrintedWord.ToString();
        }

        //remove after refactoring. Or move to different place. Breaks single responsibility principle.
        public bool Isletter(char Theletter)
        {
            if (char.ToLower(Theletter) >= 'a' && char.ToLower(Theletter) <= 'z')
                return true;
            else
                return false;
        }

        //remove after refactoring
        public bool CheckForLetter(char TheLetter)
        {
            if (w.Contains(char.ToLower(TheLetter)))
            {
                return true;
            }
            else return false;
        }

        //remove after refactoring
        public string WriteTheLetter(char TheLetter)
        {

            for (int WordLenght = 0; WordLenght < w.Length - 1; WordLenght++)
            {
                if (this.w.IndexOf(char.ToLower(TheLetter), WordLenght) >= 0)
                {
                    this.PrintedWord[this.w.IndexOf(char.ToLower(TheLetter), WordLenght) * 2] = TheLetter;
                }
            }

            return PrintedWord.ToString();
        }

        //remove after refactoring
        public int NumberOfInput(char TheLetter)
        {
            int Number = 0;
            for (int WordLenght = 0; WordLenght < w.Length; WordLenght++)
            {
                if (this.w[WordLenght].Equals(char.ToLower(TheLetter))) 
                Number++;
            }
            return Number;
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