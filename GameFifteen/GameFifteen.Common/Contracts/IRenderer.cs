namespace GameFifteen.Common.Contracts
{
    public interface IRenderer
    {
        void RenderMatrix(int[,] matrix);

        void RenderScoreboard(Scoreboard scoreboard);

        void PrintWelcome();

        void PrintGameWon(int moves);

        void AskPlayerForName();

        void PrintInvalid(string invalidType);
    }
}
