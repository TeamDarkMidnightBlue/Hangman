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

        public Word(string word)
            : base(word)
        {
            this.WordToGuess = word;
            string underscores = new string('_', this.revealedWord.Length);
            this.hiddenWord = underscores.ToCharArray();
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

        /// <summary>
        /// Method that checks if a given letter is contained in the word.
        /// If yes, returns true and modifies the hidden word, replacing underscores with the letter.
        /// </summary>
        /// <param name="charToGuess"></param>
        /// <returns></returns>
        override public bool Guess(char charToGuess)
        {
            bool isInWord = false;

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
        /// Asks the word to reveal the next hidden character.
        /// </summary>
        /// <returns>Returns the revealed character.</returns>
        public override char Help()
        {
            if (this.IsGuessed)
            {
                throw new InvalidOperationException("The word is already guessed correctly.");
            }

            for (int i = 0; i < this.hiddenWord.Length; i++)
            {
                if (this.hiddenWord[i] == '_')
                {
                    char revealedLetter = this.revealedWord[i];
                    this.Guess(revealedLetter);
                    return revealedLetter;
                }
            }

            return '_';
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