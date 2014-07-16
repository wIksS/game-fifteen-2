namespace GameFifteen.Common.Contracts
{
    public interface IConsoleReader
    {
        bool ExecuteComand(string stringInput, ref int moves, int[,] currentMatrix, Point emptyPoint);

        string Read();
    }
}
