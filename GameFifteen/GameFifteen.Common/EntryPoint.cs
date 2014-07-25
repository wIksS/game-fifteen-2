namespace GameFifteen
{
    using GameFifteen.Common;
    using GameFifteen.Contracts;
    using GameFifteen.Logic;

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