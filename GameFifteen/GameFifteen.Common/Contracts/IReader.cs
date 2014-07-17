namespace GameFifteen.Common.Contracts
{
    public interface IReader
    {
        bool ExecuteComand(string stringInput, ref int moves, int[,] currentMatrix, Point emptyPoint, Scoreboard scoreboard);

        string Read();
    }
}
