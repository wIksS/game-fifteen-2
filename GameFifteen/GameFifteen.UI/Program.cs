﻿namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    public class Program
    {
        static void Main(string[] args)
        {
            IConsoleRenderer renderer = new ConsoleRenderer();
            IConsoleReader inputReader = new ConsoleInput();
            GameEngine gameEngine = new GameEngine();
            
            gameEngine.StartNewGame(renderer, inputReader);
        }
    }
}