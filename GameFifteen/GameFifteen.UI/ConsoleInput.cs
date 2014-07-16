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
            //var command = Console.ReadLine();

            switch (stringInput)
            {
                case "exit":
                    GameEngine.PlayAgain = false;
                    Console.WriteLine("Good bye!");
                    return true;
                case "restart":
                    //gameEngine.HandleStartNewGame(matrixRenderer, ref moves);
                    return true;
                    //break;
                case "top":
                    gameEngine.HandleRenderScoreBoard(matrixRenderer);
                    break;
                default:
                    gameEngine.HandleInvalidCommand(matrixRenderer, stringInput, ref moves);
                    break;
            }
            return false;
        }

        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}