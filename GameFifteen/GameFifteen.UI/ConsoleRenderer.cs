namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common.Contracts;

    public class ConsoleRenderer : IConsoleRenderer
    {
        public void Render(int[,] matrix)
        {
            Console.WriteLine(" -------------");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if (matrix[i, j] <= 9)
                    {
                        Console.Write("  {0}", matrix[i, j]);
                    }
                    else
                    {
                        if (matrix[i, j] == 16)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0}", matrix[i, j]);
                        }
                    }
                    if (j == matrix.GetLength(0) - 1)
                    {
                        Console.Write(" |\n");
                    }
                }
            }

            Console.WriteLine(" -------------");
        }

        public void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }
    }
}
