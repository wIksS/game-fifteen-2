namespace GameFifteen.Common
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    using GameFifteen.Common.Contracts;

    public class GameEngine
    {
        // TODO moove common constants to game settings
        const int GAME_BOARD_SIZE = 4;
        public static bool PlayAgain = true;

        static OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);

        private static bool IfGoesToBoard(int moves)
        {
            foreach (var score in scoreboard)
            {
                if (moves < score.Key)
                {
                    return true;
                }
            }
            return false;
        }

        private static void RemoveLastScore()
        {
            if (scoreboard.Last().Value.Count > 0)
            {
                string[] values = new string[scoreboard.Last().Value.Count];
                scoreboard.Last().Value.CopyTo(values, 0);
                scoreboard.Last().Value.Remove(values.Last());
            }
            else
            {
                int[] keys = new int[scoreboard.Count];
                scoreboard.Keys.CopyTo(keys, 0);
                scoreboard.Remove(keys.Last());
            }
        }

        private static void GameWon(int moves)
        {
            Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
            int scorersCount = 0;
            foreach (var scorer in scoreboard)
            {
                scorersCount += scorer.Value.Count;
            }
            if (scorersCount == 5)
            {
                if (IfGoesToBoard(moves))
                {
                    RemoveLastScore();
                    HighScorePromt(moves);
                }
            }
            else
            {
                HighScorePromt(moves);
            }
        }

        private static void HighScorePromt(int moves)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            scoreboard.Add(moves, name);
        }

        public static void PrinntScoreBoard()
        {
            if (scoreboard.Count == 0)
            {
                Console.WriteLine("Scoreboard is empty");
                return;
            }
            Console.WriteLine("Scoreboard:");
            int i = 1;
            foreach (var score in scoreboard)
            {
                foreach (var value in score.Value)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves", i, value, score.Key);
                    i++;
                }
            }
            Console.WriteLine();
        }

        public void StartNewGame(IConsoleRenderer consoleRenderer, IConsoleReader consoleReader)
        {
            MatrixGenerator matrixGenerator = new MatrixGenerator(GAME_BOARD_SIZE);
            int[,] currentMatrix = matrixGenerator.GenerateMatrix();
            int matrixLength = currentMatrix.GetLength(0);
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(new MatrixGenerator(matrixLength));
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            Point emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            bool gameEnd = false;

            consoleRenderer.PrintWelcome();

            // main algorithm
            int moves = 0;
            string inputString = "";
            while (!gameEnd)
            {
                consoleRenderer.Render(currentMatrix);
                if (equalMatrixChecker.IsSorted(currentMatrix))  // IsGameWon check
                {
                    GameWon(moves);
                    PrinntScoreBoard();
                    return;
                }

                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();

                gameEnd = consoleReader.ExecuteComand(consoleRenderer, inputString, ref moves, currentMatrix, emptyPoint);
            }
        }
    }
}