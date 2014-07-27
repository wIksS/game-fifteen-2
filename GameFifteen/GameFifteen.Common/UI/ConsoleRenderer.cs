namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using System.Text;
    using GameFifteen.Utils;

    /// <summary>Represents a console renderer.</summary>
    public class ConsoleRenderer : IRenderer
    {
        /// <summary>Renders the matrix described by matrix.</summary>
        /// <param name="matrix" type="int[,]">The matrix.</param>
        public void RenderMatrix(int[,] matrix)
        {
            int matrixLength = matrix.GetLength(0);
            string dashes = UIConstants.SPACE + new string(UIConstants.DASH, matrixLength * UIConstants.MATRIX_INTERVALS);
            StringBuilder matrixAsString = new StringBuilder();

            matrixAsString.AppendLine(dashes);

            for (int row = 0; row < matrixLength; row++)
            {
                matrixAsString.Append(UIConstants.WALL_SYMBOL);
                for (int col = 0; col < matrixLength; col++)
                {
                    string currentMatrixSymbol = matrix[row, col].ToString();
                     if (int.Parse(currentMatrixSymbol) == CommonConstants.INITIAL_EMPTY_CELL)
                    {
                        currentMatrixSymbol = " ";
                    }
                    matrixAsString.AppendFormat("{0,3}",currentMatrixSymbol);
                }
                matrixAsString.AppendLine(UIConstants.WALL_SYMBOL);
            }

            matrixAsString.AppendLine(dashes);

            this.Print(matrixAsString.ToString());
        }

        /// <summary>Renders the scoreboard described by scoreboard.</summary>
        /// <param name="scoreboard" type="Scoreboard">The scoreboard.</param>
        public void RenderScoreboard(Scoreboard scoreboard)
        {
            var players = scoreboard.GetPlayers();

            if (players.Count == 0)
            {
                this.PrintLine(UIConstants.EMPTY_SCOREBOARD_MESSAGE);
                return;
            }

            this.PrintLine(UIConstants.SCOREBOARD);

            var scoreBoardAsString = new StringBuilder();

            for (int i = 0; i < players.Count; i++)
            {
                scoreBoardAsString.AppendFormat(UIConstants.SCORE_RESULT_FORMAT, i + 1, players[i].Name, players[i].MovesCount);
                scoreBoardAsString.AppendLine();
            }

            scoreBoardAsString.AppendLine();
            this.Print(scoreBoardAsString.ToString());
        }

        /// <summary>Print welcome message.</summary>
        public void PrintWelcome()
        {
            this.PrintLine(UIConstants.WELCOME_MESSAGE);
        }

        /// <summary>Print game won message.</summary>
        /// <param name="moves" type="int">The number of moves.</param>
        public void PrintGameWon(int moves)
        {
            string congratulationsMessage = string.Format(UIConstants.CONGRATULATIONS_MESSAGE, moves);
            this.PrintLine(congratulationsMessage);
        }

        /// <summary>Print line with a message.</summary>
        /// <param name="mesage" type="string">The message.</param>
		public void PrintLine(string mesage)
		{
            ConsoleRender(mesage + UIConstants.NEW_LINE);
		}

        /// <summary>Prints message.</summary>
        /// <param name="mesage" type="string">The message.</param>
		public void Print(string mesage)
		{
			ConsoleRender(mesage);
		}

		private void ConsoleRender(string output)
		{
			Console.Write(output);
		}
    }
}