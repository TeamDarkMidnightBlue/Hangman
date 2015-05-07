namespace HangmanGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class holding the scores for a single player
    /// </summary>
    public class Player
    {
        private string name;
        private List<int> scores = new List<int>();

        public Player(string name)
        {
            this.Name = name;
            this.scores.Add(0);
        }

        /// <summary>
        /// The player's name
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player name must not be null or empty.");
                }
                this.name = value;
            }
        }

        /// <summary>
        /// Adds a score to player's scores
        /// </summary>
        /// <param name="score">The score to be added</param>
        public void AddScore (int score)
        {
            if (score < 0 )
            {
                throw new InvalidOperationException("Score must a positive number.");
            }
            this.scores.Add(score);
        }

        /// <summary>
        /// Increases the score of the player for the current game he/she is playing.
        /// </summary>
        public void IncrementCurrentScore()
        {
            this.scores[this.scores.Count - 1]++;
        }

        /// <summary>
        /// Method that returns the score of the player for the current game he/she is playing.
        /// </summary>
        public int CurrentScore
        {
            get
            {
                return this.scores[this.scores.Count - 1];
            }
        }

        /// <summary>
        /// Read-only property returning the top score of the player.
        /// In our case this is the minimum value of all scores.
        /// </summary>
        public double TopScore
        {
            get
            {
                if (this.scores.Count == 0)
                {
                    throw new InvalidOperationException("Player has no scores.");
                }

                return this.scores.Min();
            }
        }

        public string AllScores()
        {
            return string.Join(",", this.scores.ToArray());
        }
    }
}
