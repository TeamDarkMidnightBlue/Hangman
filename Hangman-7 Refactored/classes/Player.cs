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
        private List<double> scores = new List<double>();

        public Player(string name)
        {
            this.Name = name;
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
        public void AddScore (double score)
        {
            if (score < 0 )
            {
                throw new InvalidOperationException("Score must a positive number.");
            }
            this.scores.Add(score);
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
