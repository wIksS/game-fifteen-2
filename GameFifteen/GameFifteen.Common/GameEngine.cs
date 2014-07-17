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

        public void StartNewGame(IRenderer consoleRenderer, IReader consoleReader, Scoreboard scoreboard)
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
            int playerMoves = 0;
            string inputString = "";
            while (!gameEnd)
            {
                consoleRenderer.RenderMatrix(currentMatrix);
                if (equalMatrixChecker.IsSorted(currentMatrix))  // IsGameWon check
                {
                    consoleRenderer.PrintGameWon(playerMoves);
                    consoleRenderer.AskPlayerForName();
                    string playerName = consoleReader.Read();
                    Player currentPlayer = new Player(playerName, playerMoves);
                    scoreboard.AddPlayer(currentPlayer);
                    consoleRenderer.RenderScoreboard(scoreboard);
                    return;
                }

                Console.Write("Enter a number to move: ");
                inputString = Console.ReadLine();

                gameEnd = consoleReader.ExecuteComand(inputString, ref playerMoves, currentMatrix, emptyPoint,scoreboard);
            }
        }

        public static void ExecuteMooveCommand(int number, ref int moves, int[,] currentMatrix, Point emptyPoint)
        {
            Direction[] directions = Directions.GetDirection;
            int directionsCount = directions.GetLength(0);
            int matrixLength = currentMatrix.GetLength(0);

            Point newPoint = new Point(0, 0);
            for (int i = 0; i <= directionsCount; i++)
            {
                if (i == 4)
                {
                    Console.WriteLine("Invalid move");
                    break;
                }
                newPoint.Row = emptyPoint.Row + directions[i].Row;
                newPoint.Col = emptyPoint.Col + directions[i].Col;
                if (OutOfMatrixChecker.CheckIfOutOfMatrix(newPoint, matrixLength))
                {
                    continue;
                }
                if (currentMatrix[newPoint.Row, newPoint.Col] == number)
                {
                    EmptyCellMover.MoveEmptyCell(emptyPoint, new Point(newPoint.Row, newPoint.Col), currentMatrix);
                    moves++;
                    break;
                }
            }
        }
    }
}