namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    class ConsoleInput : IConsoleReader
    {
        public bool ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves, int[,] currentMatrix, Point emptyPoint)
        {
            GameEngine gameEngine = new GameEngine();

            switch (stringInput)
            {
                case "exit":
                    GameEngine.PlayAgain = false;
                    Console.WriteLine("Good bye!");
                    return true;
                case "restart":
                    return true;
                case "top":
                    GameEngine.PrinntScoreBoard();
                    break;
                default:
                    HandleInvalidCommand(matrixRenderer, stringInput, ref moves, currentMatrix, emptyPoint);
                    break;
            }
            return false;
        }

        // There is no need to create a method for Console.ReadLine(). The interface may be redundant
        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }

        // This code reaks! Lots of the commands it handles are not invalid!
        public void HandleInvalidCommand(IConsoleRenderer matrixRenderer, string inputString, ref int moves, int[,] currentMatrix, Point emptyPoint)
        {
            int number = 0;
            int matrixLength = currentMatrix.GetLength(0);
            bool isNumber = int.TryParse(inputString, out number);
            if (!isNumber)
            {
                Console.WriteLine("Invalid comand!");
            }
            else if (number < 16 && number > 0)
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