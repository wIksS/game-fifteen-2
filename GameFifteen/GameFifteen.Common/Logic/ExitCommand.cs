namespace GameFifteen.Logic
{
    using GameFifteen.Contracts;

    /// <summary>Represents an exit command.</summary>
    class ExitCommand : Command
    {
		private readonly IRenderer renderer;
		private readonly GameEngine engine;

        /// <summary>Constructor.</summary>
        /// <param name="renderer" type="IRenderer">The renderer.</param>
        /// <param name="engine" type="GameEngine">The engine.</param>
		public ExitCommand(IRenderer renderer, GameEngine engine)
        {
			this.renderer = renderer;
            this.engine = engine;
        }

        /// <summary>Executes this object.</summary>
        public override void Execute()
        {
			engine.Exit(renderer);
        }
    }
}
