namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

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

            this.PrintLine(dashes);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                this.Print(wallSymbol);
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] <= 9)
                    {
                        this.Print(firstPlaceholder, matrix[i, j]);
                    }
                    else
                    {
                        if (matrix[i, j] == 16)
                        {
                            this.Print(emptySpaces);
                        }
                        else
                        {
                            this.Print(secondPlaceholder, matrix[i, j]);
                        }
                    }

                    if (j == matrix.GetLength(0) - 1)
                    {
                        this.Print(wallSymbol, newLine);
                    }
                }
            }

            this.PrintLine(dashes);
        }

        public void RenderScoreboard(Scoreboard scoreboard)
        {
            string emptyScoreboardMessage = "Scoreboard is empty";
            string scoreBoard = "Scoreboard:";
            string scoreResult = "{0}. {1} --> {2} moves";

            var players = scoreboard.GetPlayers();
            if (players.Count == 0)
            {
                this.PrintLine(emptyScoreboardMessage);
                return;
            }

            this.PrintLine(scoreBoard);

            for (int i = 0; i < players.Count; i++)
            {
                this.PrintLine(scoreResult, i + 1, players[i].Name, players[i].MovesCount);
            }

            Console.WriteLine();
        }

        public void PrintWelcome()
        {
            string welcomeMessage = "Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.";
            this.PrintLine(welcomeMessage);
        }

        public void PrintGameWon(int moves)
        {
            string congratulationsMessage = "Congratulations! You won the game in {0} moves.";
            this.PrintLine(congratulationsMessage, moves);
        }

        public void AskPlayerForName()
        {
            string questionForThePlayerName = "Please enter your name for the top scoreboard: ";
            this.PrintLine(questionForThePlayerName);
        }

        private void Print(string message)
        {
            Console.Write(message);
        }

        private void Print(string message, int parameter)
        {
            Console.Write(message, parameter);
        }

        private void Print(string symbol, string newLine)
        {
            Console.Write(symbol + newLine);
        }

        private void PrintLine(string message)
        {
            Console.WriteLine(message);
        }

        private void PrintLine(string message, int parameter)
        {
            Console.WriteLine(message, parameter);
        }

        private void PrintLine(string scoreResult, int i, string name, int movesCount)
        {
            Console.WriteLine(scoreResult, i, name, movesCount);
        }
    }
}