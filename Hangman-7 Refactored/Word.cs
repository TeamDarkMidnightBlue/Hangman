using System.Linq;
using System.Text;

namespace HangmanGame
{
    class Word
    {
        private string _word;
        private StringBuilder _printedWord = new StringBuilder();

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

        public bool CheckForLetter(char inputLetter)
        {
            return _word.Contains(char.ToLower(inputLetter));
        }

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
    }
}

