namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    public class Program
    {
        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer();
            IReader inputReader = new ConsoleReader();
            GameEngine gameEngine = new GameEngine();
            Scoreboard scoreboard = new Scoreboard();
            INumberGenerator numberGenerator = new NumberGenerator(16);

            do
            {
                gameEngine.StartNewGame(renderer, inputReader,scoreboard,numberGenerator);
            }
            while (gameEngine.IsGameOver);
        }
    }
}