using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using GameFifteen.Common.Contracts;

namespace GameFifteen.Common
{
    // pozdravi na vsi4ki ot pernik!

    public class GameEngine
    {
        static int[] dirR = new int[4] { -1, 0, 1, 0 };
        static int[] dirC = new int[4] { 0, 1, 0, -1 };
        static Random r = new Random();
        public const int MatrixLength = 4;
        static Point emptyPoint = new Point(3, 3);
        static int[,] sol = new int[MatrixLength, MatrixLength] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, 
                                                                     { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        static int[,] currentMatrix = new int[MatrixLength, MatrixLength] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 },
                                                                          { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
        static OrderedMultiDictionary<int, string> scoreboard = new OrderedMultiDictionary<int, string>(true);


        private static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially.\n" +
            "Use 'top' to view the top scoreboard, 'restart' to start a new game and \n'exit' to quit the game.");
        }

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
                    tocki(moves);
                }
            }
            else
            {
                tocki(moves);
            }
        }
        private static void tocki(int moves)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            scoreboard.Add(moves, name);
        }
        private static void pe4at()
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

        public void Start()
        {
            MatrixGenerator matrixGenerator = new MatrixGenerator(MatrixLength);
            IMatrixRenderer matrixRenderer = new MatrixRenderer();
            currentMatrix = matrixGenerator.GenerateMatrix();
            MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
            emptyPoint = matrixRandomizator.Randomize(currentMatrix);
            int matrixLength = currentMatrix.GetLength(0);
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(matrixLength, new MatrixGenerator(matrixLength));

            //GenerateMatrix();
            PrintWelcome();
            matrixRenderer.Render(currentMatrix);

            // main algorithm
            int moves = 0;
            Console.Write("Enter a number to move: ");
            string inputString = Console.ReadLine();
            while (inputString.CompareTo("exit") != 0)
            {
                ExecuteComand(inputString, ref moves);
                if (equalMatrixChecker.CheckMatrix(currentMatrix))
                {
                    GameWon(moves);
                    pe4at();
                    emptyPoint = new Point(3, 3);
                    currentMatrix = matrixGenerator.GenerateMatrix();
                    emptyPoint = matrixRandomizator.Randomize(currentMatrix);
                    PrintWelcome();
                    matrixRenderer.Render(currentMatrix);
                    moves = 0;
                }
                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();



            }
            Console.WriteLine("Good bye!");
        }

        private static void ExecuteComand(string inputString, ref int moves)
        {
            MatrixGenerator matrixGenerator = new MatrixGenerator(MatrixLength);
            IMatrixRenderer matrixRenderer = new MatrixRenderer();
            int matrixLength = currentMatrix.GetLength(0);
            IEqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(matrixLength, new MatrixGenerator(matrixLength));

            switch (inputString)
            {
                case "restart":
                    moves = 0;
                    emptyPoint = new Point(3, 3);
                    currentMatrix = matrixGenerator.GenerateMatrix();
                    MatrixEmptyCellRandomizator matrixRandomizator = new MatrixEmptyCellRandomizator();
                    emptyPoint = matrixRandomizator.Randomize(currentMatrix);
                    PrintWelcome();
                    matrixRenderer.Render(currentMatrix);
                    break;

                case "top":
                    pe4at();
                    matrixRenderer.Render(currentMatrix);
                    break;

                default:
                    int number = 0;
                    bool isNumber = int.TryParse(inputString, out number);
                    if (!isNumber)
                    {
                        Console.WriteLine("Invalid comand!");
                        break;
                    }
                    if (number < 16 && number > 0)
                    {
                        Point newPoint = new Point(0, 0);
                        for (int i = 0; i < 4; i++)
                        {
                            newPoint.Row = emptyPoint.Row + dirR[i];
                            newPoint.Col = emptyPoint.Col + dirC[i];
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
                        break;
                    }
                    break;
            }

        }
    }
}
