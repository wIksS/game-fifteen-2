namespace GameFifteen.UI
{
    using System;
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    class ConsoleInput : IConsoleReader
    {
        public void ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves)
        {
            GameEngine gameEngine = new GameEngine();
            //var command = Console.ReadLine();

            switch (stringInput)
            {
                case "restart":
                    gameEngine.HandleStartNewGame(matrixRenderer, ref moves);
                    break;
                case "top":
                    gameEngine.HandleRenderScoreBoard(matrixRenderer);
                    break;
                default:
                    gameEngine.HandleInvalidCommand(matrixRenderer, stringInput, ref moves);
                    break;
            }
        }

        public string Read()
        {
            var command = Console.ReadLine();
            return command;
        }
    }
}