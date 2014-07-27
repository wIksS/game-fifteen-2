namespace GameFifteen.Contracts
{
    using GameFifteen.Common;

    /// <summary>Interface for renderer.</summary>
    public interface IRenderer
    {

        /// <summary>Renders the matrix described by matrix.</summary>
        /// <param name="matrix" type="int[,]">The matrix.</param>
        void RenderMatrix(int[,] matrix);

        /// <summary>Renders the scoreboard described by scoreboard.</summary>
        /// <param name="scoreboard" type="Scoreboard">The scoreboard.</param>
        void RenderScoreboard(Scoreboard scoreboard);

        /// <summary>Print welcome message.</summary>
        void PrintWelcome();

        /// <summary>Print game won message.</summary>
        /// <param name="moves" type="int">The number of moves.</param>
        void PrintGameWon(int moves);

        /// <summary>Print line with message.</summary>
        /// <param name="message" type="string">The message.</param>
		void PrintLine(string message);

        /// <summary>Prints message.</summary>
        /// <param name="message" type="string">The message.</param>
		void Print(string message);
    }
}
