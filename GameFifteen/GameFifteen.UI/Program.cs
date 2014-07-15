namespace GameFifteen.UI
{
    using GameFifteen.Common;
    using GameFifteen.Common.Contracts;

    public class Program
    {
        static void Main(string[] args)
        {
            IMatrixRenderer renderer = new MatrixRenderer();
            GameEngine gameEngine = new GameEngine();
            gameEngine.Start(renderer);
        }
    }
}
