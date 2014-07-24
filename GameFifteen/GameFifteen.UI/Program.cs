namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    public class Program
    {
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