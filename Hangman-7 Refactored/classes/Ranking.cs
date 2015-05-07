namespace HangmanGame
{
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Ranking
    {
        private List<Player> players;

        public Ranking()
        {
            this.players = new List<Player>();
        } 

        public void AddScore(Player player)
        {
            foreach (Player existingPlayer in this.players)
            {
                if (existingPlayer.Name == player.Name)
                {
                    existingPlayer.AddScore(player.CurrentScore);
                    return;
                }
            }

            this.players.Add(player);
        }

        public List<Player> Players
        {
            get
            {
                return this.players;
            }
        }

        public string GetRanking()
        {
            StringBuilder Ranking = new StringBuilder();

            Ranking.AppendLine("Ranking:");

            int rank = 1;

            if (this.players.Count == 0)
            {
                Ranking.AppendLine("Ranking is empty.");
                return Ranking.ToString();
            }

            var sortedPlayers = this.players.OrderBy(player => player.TopScore);

            foreach (var player in sortedPlayers)
            {
                string playerData = string.Format("{0}. Name: {1}, Top score: {2}, All scores: {3}\n", 
                    rank, player.Name, player.TopScore, player.AllScores());
                Ranking.Append(playerData);
                rank++;
            }

            return Ranking.ToString();
        }
    }
}
