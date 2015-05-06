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
            if (this.players.Count > 4)
            {
                List<Player> rankedPlayers = this.players.OrderBy(pl => pl.Score).ToList<Player>();
                if (rankedPlayers[4].Score > player.Score)
                {
                    rankedPlayers = rankedPlayers.Take(rankedPlayers.Count() - 1).ToList<Player>();
                    this.players = rankedPlayers;
                }
            }

            this.players.Add(player);
        }

        public bool IsPlayerTop(Player player, bool playerHasUsedHelp)
        {
            if (playerHasUsedHelp)
            {
                return false;
            }

            if (this.players.Count < 5)
            {
                return true;
            }
            else
            {
                List<Player> rankedPlayers = this.players.OrderBy(pl => pl.Score).ToList<Player>();
                if (rankedPlayers[4].Score > player.Score)
                {
                    rankedPlayers = rankedPlayers.Take(rankedPlayers.Count() - 1).ToList<Player>();
                    this.players = rankedPlayers;
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
