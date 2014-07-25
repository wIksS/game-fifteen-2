namespace GameFifteen.Common
{
    using GameFifteen.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Scoreboard
    {
        private static Scoreboard instance;
        private List<Player> players;

        private Scoreboard()
        {
            this.players = new List<Player>();
        }

        public static Scoreboard Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Scoreboard();
                }
                return instance;
            }
        }

        public List<Player> GetPlayers()
        {
			//there is a condition in ConsoleRenderer
            /*if (this.players.Count == 0)
            {
                throw new ArgumentNullException("Players must be added to the scoreboard before getting it.");
            }*/

            return this.players;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentException(CommonConstants.INVALID_PLAYER);                
            }

            this.players.Add(player);
            this.players = SortPlayers();

            if (this.players.Count > CommonConstants.MAX_PLAYERS_IN_SCOREBOARD)
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
