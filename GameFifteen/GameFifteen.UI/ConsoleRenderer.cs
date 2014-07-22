namespace GameFifteen.UI
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
            string dashes = UIConstants.SPACE + new string(UIConstants.DASH, 12);
            var matrixAsString = new StringBuilder();

            matrixAsString.AppendLine(dashes);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixAsString.Append(UIConstants.WALL_SYMBOL);
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] <= 9)
                    {
                        matrixAsString.AppendFormat(UIConstants.FIRST_PLACEHOLDER, matrix[i, j]);
                    }
                    else
                    {
                        if (matrix[i, j] == 16)
                        {
                            matrixAsString.Append(UIConstants.EMPTY_SPACES);
                        }
                        else
                        {
                            matrixAsString.AppendFormat(UIConstants.SECOND_PLACEHOLDER, matrix[i, j]);
                        }
                    }

                    if (j == matrix.GetLength(0) - 1)
                    {
                        matrixAsString.AppendFormat(UIConstants.WALL_SYMBOL, UIConstants.NEW_LINE);
                    }
                }

                matrixAsString.AppendLine();
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