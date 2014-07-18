namespace GameFifteen.Common.Contracts
{
    public interface IReader
    {
        void ExecuteComand(string stringInput, ref int moves, int[,] currentMatrix, Point emptyPoint, Scoreboard scoreboard);

        string Read();
    }
}
