namespace HangmanGame
{
    using System;
    using System.Collections.Generic;

    public class WordFactory : IWordFactory
    {
        private List<string> wordsRepository = new List<string>();
        private Random rnd = new Random();

        public WordFactory(params string[] words)
        {
            this.wordsRepository.AddRange(words);
        }

        public WordFactory(IEnumerable<string> words)
        {
            this.wordsRepository.AddRange(words);
        }

        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Adding empty word or null is not allowed.");
            }

            this.wordsRepository.Add(word);
        }

        public void AddWords(IEnumerable<string> words)
        {
            if (words == null)
            {
                throw new ArgumentNullException("Words cannot be null.");
            }

            this.wordsRepository.AddRange(words);
        }
        

        public WordBase CreateWord()
        {
            if (this.wordsRepository.Count == 0)
            {
                throw new InvalidOperationException("Could not create word cause the WordFactory is empty.");
            }

            int index = this.rnd.Next(0, this.wordsRepository.Count);
            string word = this.wordsRepository[index];

            return new Word(word);
        }
    }
}