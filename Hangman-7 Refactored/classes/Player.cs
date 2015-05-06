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
        private List<double> scores = new List<double>();

        public Player(bool hasUsedHelp, int initialScore)
        {
            this.HasUsedHelp = hasUsedHelp;
            this.Score = initialScore;
        }

        public bool HasUsedHelp { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }
    }
}
