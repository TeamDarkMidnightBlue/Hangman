namespace HangmanGame
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Factory class, which is used by the game engine to create Word objects upon request
    /// </summary>
    public class WordFactory : IWordFactory
    {
        private readonly List<string> wordsRepository = new List<string>();
        private readonly Random rnd = new Random();

        /// <summary>
        /// Constructor accepting a variable number of strings
        /// </summary>
        /// <param name="words">A variable number of strings</param>
        public WordFactory(params string[] words)
        {
            this.wordsRepository.AddRange(words);
        }

        /// <summary>
        /// Constructor that accepts a list, dictionary or other IEnumerable object of words
        /// </summary>
        /// <param name="words"></param>
        public WordFactory(IEnumerable<string> words)
        {
            this.wordsRepository.AddRange(words);
        }

        /// <summary>
        /// Add a single word to the repo
        /// </summary>
        /// <param name="word">A word</param>
        public void AddWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Adding empty word or null is not allowed.");
            }

            this.wordsRepository.Add(word);
        }

        /// <summary>
        /// Method for adding more words to the internal repository.
        /// </summary>
        /// <param name="words">IEnumerable object with words.</param>
        public void AddWords(IEnumerable<string> words)
        {
            if (words == null)
            {
                throw new ArgumentNullException("Words cannot be null.");
            }

            this.wordsRepository.AddRange(words);
        }
        
        /// <summary>
        /// The method that actually creates the words.
        /// </summary>
        /// <returns></returns>
        public WordBase CreateWord()
        {
            if (this.wordsRepository.Count == 0)
            {
                throw new InvalidOperationException("Could not create word because the WordFactory is empty.");
            }

            int index = this.rnd.Next(0, this.wordsRepository.Count);
            string word = this.wordsRepository[index];

            return new Word(word);
        }
    }
}