namespace GameFifteen.Common.Contracts
{
    public interface IConsoleRenderer
    {
        void Render(int[,] matrix);

        void PrintWelcome();
    }
}
