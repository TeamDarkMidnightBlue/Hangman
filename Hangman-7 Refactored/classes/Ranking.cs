using System;
using System.Runtime.CompilerServices;

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

        public bool IsPlayerTop(Player player, bool playerHasUsedHelp)
        {
            if (this.players.Count < 6)
            {
                return true;
            }
            else
            {
                Player[] rankedPlayers = this.players.OrderBy(pl => pl.Score).ToArray();
                if (rankedPlayers[4].Score < player.Score && !playerHasUsedHelp)
                {
                    rankedPlayers = rankedPlayers.Take(rankedPlayers.Count() - 1).ToArray();
                    return true;
                }

                return false;
            }
        }

        public string GetRanking()
        {
            StringBuilder ranking = new StringBuilder();

            if (this.players.Count == 0)
            {
                return "Ranking is empty.";
            }

            var sortedPlayers = this.players.OrderBy(player => player.Score);

            ranking.Append("Scoreboard: \n");

            foreach (var player in sortedPlayers)
            {
                string playerData = string.Format("{0} {1}\n", player.Score, player.Name);
                ranking.Append(playerData);
            }

            return ranking.ToString();
        }
    }
}
