﻿namespace GameFifteen.Common.Contracts
{
    public interface IRenderer
    {
        void RenderMatrix(int[,] matrix);

        void RenderScoreboard(Scoreboard scoreboard);

        void PrintWelcome();

        void PrintGameWon(int moves);

		void PrintLine(string message);

		void Print(string message);
    }
}