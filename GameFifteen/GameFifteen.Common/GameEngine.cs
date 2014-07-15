namespace GameFifteen.Common
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    public class GameEngine
    {
        // TODO moove common constants to game settings
        const int GAME_BOARD_SIZE = 4;
        public static bool PlayAgain = true;
        //const int INIT_POINT_POSITION = 3;

        static Point emptyPoint = new Point(GAME_BOARD_SIZE - 1, GAME_BOARD_SIZE - 1);
        static int[,] currentMatrix = new int[GAME_BOARD_SIZE, GAME_BOARD_SIZE];
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

        private static void PrinntScoreBoard()
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

            currentMatrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            int matrixLength = currentMatrix.GetLength(0);
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(new MatrixGenerator(matrixLength));
           
            //GenerateMatrix();
            consoleRenderer.PrintWelcome();
            consoleRenderer.Render(currentMatrix);

            // main algorithm
            int moves = 0;
            Console.Write("Enter a number to move: ");
            string inputString = consoleReader.Read();
            while (true)
            {
                consoleReader.ExecuteComand(consoleRenderer, inputString, ref moves);
                if (equalMatrixChecker.IsSorted(currentMatrix))
                {
                    GameWon(moves);
                    PrinntScoreBoard();
                    emptyPoint = new Point(GAME_BOARD_SIZE - 1, GAME_BOARD_SIZE - 1);
                    currentMatrix = matrixGenerator.GenerateMatrix();
                    emptyPoint = matrixRandomizator.Randomize(currentMatrix);
                    consoleRenderer.PrintWelcome();
                    consoleRenderer.Render(currentMatrix);
                    moves = 0;
                }
                Console.Write("Enter a number to move: ");
                inputString = consoleReader.Read();
            }

            // TODO add method in ConsoleRenderer
            // Console.WriteLine("Good bye!");
        }

        public void HandleStartNewGame(IConsoleRenderer matrixRenderer, ref int moves)
        {
            MatrixGenerator matrixGenerator = new MatrixGenerator(GAME_BOARD_SIZE);
            moves = 0;
            emptyPoint = new Point(GAME_BOARD_SIZE - 1, GAME_BOARD_SIZE - 1);
            currentMatrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            matrixRenderer.PrintWelcome();
            matrixRenderer.Render(currentMatrix);
        }

        public void HandleRenderScoreBoard(IConsoleRenderer matrixRenderer)
        {
            PrinntScoreBoard();
            matrixRenderer.Render(currentMatrix);
        }

        public void HandleInvalidCommand(IConsoleRenderer matrixRenderer, string inputString, ref int moves)
        {
            int number = 0;
            int matrixLength = currentMatrix.GetLength(0);
            bool isNumber = int.TryParse(inputString, out number);
            if (!isNumber)
            {
                Console.WriteLine("Invalid comand!");
            }
            if (number < 16 && number > 0)
            {
                Point newPoint = new Point(0, 0);
                for (int i = 0; i < 4; i++)
                {
                    newPoint.Row = emptyPoint.Row + Directions.GetDirection(i).Row;
                    newPoint.Col = emptyPoint.Col + Directions.GetDirection(i).Col;
                    if (OutOfMatrixChecker.CheckIfOutOfMatrix(newPoint, matrixLength))
                    {
                        if (i == 3)
                        {
                            Console.WriteLine("Invalid move");
                        }
                        continue;
                    }
                    if (currentMatrix[newPoint.Row, newPoint.Col] == number)
                    {
                        EmptyCellMover.MoveEmptyCell(emptyPoint, new Point(newPoint.Row, newPoint.Col), currentMatrix);
                        moves++;
                        matrixRenderer.Render(currentMatrix);
                        break;
                    }
                    if (i == 3)
                    {
                        Console.WriteLine("Invalid move");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid move");
            }
        }
    }
}