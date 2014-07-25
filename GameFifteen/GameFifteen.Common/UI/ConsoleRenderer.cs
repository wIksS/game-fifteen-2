namespace GameFifteen.Common.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using System.Text;
    using GameFifteen.Common.Utils;

    public class ConsoleRenderer : IRenderer
    {
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
                    matrixAsString.AppendFormat("{0,3}",matrix[row,col]);
                }
                matrixAsString.AppendLine(UIConstants.WALL_SYMBOL);
            }

            matrixAsString.AppendLine(dashes);

            this.Print(matrixAsString.ToString());
        }

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

        public void PrintWelcome()
        {
            this.PrintLine(UIConstants.WELCOME_MESSAGE);
        }

        public void PrintGameWon(int moves)
        {
            string congratulationsMessage = string.Format(UIConstants.CONGRATULATIONS_MESSAGE, moves);
            this.PrintLine(congratulationsMessage);
        }

		public void PrintLine(string mesage)
		{
            ConsoleRender(mesage + UIConstants.NEW_LINE);
		}

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