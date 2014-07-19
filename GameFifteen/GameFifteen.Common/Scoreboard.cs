using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common
{
    public class Scoreboard
    {
        private const int MAX_PLAYERS_IN_SCOREBOARD = 5;
        private List<Player> players;

        public Scoreboard()
        {
            this.players = new List<Player>();
        }

        public List<Player> GetPlayers()
        {
            if (this.players.Count == 0)
            {
                throw new ArgumentException("Players must be added to the scoreboard before getting it.");
            }

            return this.players;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null.");                
            }

            this.players.Add(player);
            this.players = SortPlayers();

            if (this.players.Count > 5)
            {
                DeleteLastPlayer();
            }
        }

        private void DeleteLastPlayer()
        {
            this.players.RemoveAt(this.players.Count - 1);
        }

        private List<Player> SortPlayers()
        {
            List<Player> sortedPlayers = this.players
                .OrderBy(student => student.MovesCount)
                .ThenBy(student => student.Name)
                .ToList();

            return sortedPlayers;
        }
    }
}
