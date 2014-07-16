namespace GameFifteen.Common.Contracts
{
    public interface IConsoleReader
    {
        bool ExecuteComand(IConsoleRenderer matrixRenderer, string stringInput, ref int moves);

        string Read();
    }
}
