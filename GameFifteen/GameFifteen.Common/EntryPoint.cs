namespace GameFifteen
{
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Logic;

    /// <summary>Represents the entry point.</summary>
    public class Program
    {
        /// <summary>Main entry-point for this application.</summary>
        /// <param name="args" type="string[]">Array of command-line argument strings.</param>
        static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();

            do
            {
                gameEngine.StartNewGame();
            }
            while (gameEngine.IsGameOver);
        }
    }
}