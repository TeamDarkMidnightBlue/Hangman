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

        public void AddPlayer(Player player)
        {
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
            int rank = 1;

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
