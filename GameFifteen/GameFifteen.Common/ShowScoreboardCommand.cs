namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;

    class ShowScoreboardCommand: Command
    {
        private IRenderer renderer;
        private Scoreboard scoreboard;

        public ShowScoreboardCommand(IRenderer renderer, Scoreboard scoreboard)
        {
            this.renderer = renderer;
            this.scoreboard = scoreboard;
        }

        public override void Execute()
        {
            renderer.RenderScoreboard(scoreboard);
        }
    }
}
