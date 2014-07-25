namespace GameFifteen.Logic
{
    using GameFifteen.Contracts;

    class ExitCommand : Command
    {
		private readonly IRenderer renderer;
		private readonly GameEngine engine;

		public ExitCommand(IRenderer renderer, GameEngine engine)
        {
			this.renderer = renderer;
            this.engine = engine;
        }

        public override void Execute()
        {
			engine.Exit(renderer);
        }
    }
}
