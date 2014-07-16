namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    class ConsoleInput : IConsoleReader
    {
        public bool ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves)
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
                    gameEngine.HandleInvalidCommand(matrixRenderer, stringInput, ref moves);
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
    }
}