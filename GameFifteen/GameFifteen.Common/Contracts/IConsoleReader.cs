namespace GameFifteen.Common.Contracts
{
    public interface IConsoleReader
    {
        void ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves);

        string Read();
    }
}
