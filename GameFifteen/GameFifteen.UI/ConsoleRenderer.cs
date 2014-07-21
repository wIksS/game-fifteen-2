namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using System.Text;

    public class ConsoleRenderer : IRenderer
    {
        public void RenderMatrix(int[,] matrix)
        {
            string dashes = ' ' + new string('-', 12);
            string wallSymbol = "|";
            string newLine = "\n";
            string firstPlaceholder = "  {0}";
            string secondPlaceholder = " {0}";
            string emptySpaces = "   ";
            var matrixAsString = new StringBuilder();

            matrixAsString.AppendLine(dashes);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrixAsString.Append(wallSymbol);
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] <= 9)
                    {
                        matrixAsString.AppendFormat(firstPlaceholder, matrix[i, j]);
                    }
                    else
                    {
                        if (matrix[i, j] == 16)
                        {
                            matrixAsString.Append(emptySpaces);
                        }
                        else
                        {
                            matrixAsString.AppendFormat(secondPlaceholder, matrix[i, j]);
                        }
                    }

                    if (j == matrix.GetLength(0) - 1)
                    {
                        matrixAsString.AppendFormat(wallSymbol, newLine);
                    }
                }

                matrixAsString.AppendLine();
            }

            matrixAsString.AppendLine(dashes);

            this.Print(matrixAsString.ToString());
        }

        public void RenderScoreboard(Scoreboard scoreboard)
        {
            string emptyScoreboardMessage = "Scoreboard is empty";
            var players = scoreboard.GetPlayers();

            if (players.Count == 0)
            {
                this.PrintLine(emptyScoreboardMessage);
                return;
            }

            string scoreBoard = "Scoreboard:";
            this.PrintLine(scoreBoard);

            var scoreBoardAsString = new StringBuilder();
            string scoreResult = "{0}. {1} --> {2} moves";

            for (int i = 0; i < players.Count; i++)
            {
                scoreBoardAsString.AppendFormat(scoreResult, i + 1, players[i].Name, players[i].MovesCount);
                scoreBoardAsString.AppendLine();
            }

            scoreBoardAsString.AppendLine();
            this.Print(scoreBoardAsString.ToString());
        }

        public void PrintWelcome()
        {
            string welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.";
            this.PrintLine(welcomeMessage);
        }

        public void PrintGameWon(int moves)
        {
			string congratulationsMessage = string.Format("Congratulations! You won the game in {0} moves.", moves);
            this.PrintLine(congratulationsMessage);
        }

		public void PrintLine(string mesage)
		{
			ConsoleRender(mesage + "\n");
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