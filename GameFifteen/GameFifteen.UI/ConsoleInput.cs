namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    class ConsoleInput : IConsoleReader
    {
        // TODO don't pass IConsoleRenderer matrixRenderer. Nothing is rendered here!
        public bool ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves, int[,] currentMatrix, Point emptyPoint)
        {
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
                    int number = 0;
                    if (ValidMooveCommand(ref number, stringInput))
                    {
                        GameEngine.ExecuteMooveCommand(number, ref moves, currentMatrix, emptyPoint);
                    }
                    break;
            }
            return false;
        }

        private bool ValidMooveCommand(ref int number, string stringInput)
        {
            bool isNumber = int.TryParse(stringInput, out number);
            Direction[] directions = Directions.GetDirection;
            int directionsCount = directions.GetLength(0);

            if (!isNumber)
            {
                Console.WriteLine("Invalid comand!");
                return false;
            }

            if (number >= directionsCount * directionsCount && number <= 0)
            {
                Console.WriteLine("Invalid number");
                return false;
            }

            return true;
        }

        // There is no need to create a method for Console.ReadLine(). The interface may be redundant
        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}