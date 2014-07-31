namespace GameFifteen.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Represents a scoreboard.</summary>
    public sealed class Scoreboard
    {
        private static Scoreboard instance;
        private List<Player> players;

        private Scoreboard()
        {
            this.players = new List<Player>();
        }

        /// <summary>Gets the instance of scoreboard.</summary>
        /// <value>The instance of scoreboard..</value>
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

        /// <summary>Gets the players.</summary>
        /// <returns>The players.</returns>
        public List<Player> GetPlayers()
        {
            return this.players;
        }

        /// <summary>Adds a player.</summary>
        /// <exception cref="ArgumentException">Thrown when one or more arguments have unsupported or
        ///                                     illegal values.</exception>
        /// <param name="player" type="Player">The player.</param>
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
