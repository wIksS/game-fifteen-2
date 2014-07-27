namespace GameFifteen.Logic
{
    using GameFifteen.Contracts;
    using GameFifteen.Common;

    /// <summary>Represents a show scoreboard commands.</summary>
    class ShowScoreboardCommand: Command
    {
        private IRenderer renderer;
        private Scoreboard scoreboard;

        /// <summary>Constructor.</summary>
        /// <param name="renderer" type="IRenderer">The renderer.</param>
        /// <param name="scoreboard" type="Scoreboard">The scoreboard.</param>
        public ShowScoreboardCommand(IRenderer renderer, Scoreboard scoreboard)
        {
            this.renderer = renderer;
            this.scoreboard = scoreboard;
        }

        /// <summary>Executes this object.</summary>
        public override void Execute()
        {
            renderer.RenderScoreboard(scoreboard);
        }
    }
}
