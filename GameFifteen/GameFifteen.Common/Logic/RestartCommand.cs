namespace GameFifteen.Logic
{
    using System;

    /// <summary>Represents a restart command.</summary>
    class RestartCommand : Command
    {
        private GameEngine engine;

        /// <summary>Constructor.</summary>
        /// <param name="engine" type="GameEngine">The engine.</param>
        public RestartCommand(GameEngine engine)
        {
            this.engine = engine;
        }

        /// <summary>Executes this object.</summary>
        public override void Execute()
        {
            engine.Restart();
        }
    }
}
