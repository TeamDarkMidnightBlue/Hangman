namespace HangmanGame
{
    using System;
    using System.Linq;
    using System.Text;

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

        //remove below fields after refactoring:
        private string w;
        private System.Text.StringBuilder PrintedWord = new System.Text.StringBuilder();
        private string _word;
        private StringBuilder _printedWord = new StringBuilder();

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

        }
        
        

        public void SetWordToBeGuessed(string inputWord)
        {
            _word = inputWord;
        }

        public string GetWordToBeGuessed()
        {
            return _word;
        }

        public void SetPrintedWord(StringBuilder printedWord)
        {
            _printedWord = printedWord;
        }

        //remove after refactoring
        public string GetPrintedWord()
        {
            return _printedWord.ToString();
        }

        public bool IsALetter(char inputLetter)
        {
            if (char.ToLower(inputLetter) >= 'a' && char.ToLower(inputLetter) <= 'z')
                return true;
            else
                return false;
        }

        //remove after refactoring
        public bool CheckForLetter(char inputLetter)
        {
            return _word.Contains(char.ToLower(inputLetter));
        }

        //remove after refactoring
        public string WriteTheLetter(char inputLetter)
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


        public int NumberOfInput(char inputLetter)
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