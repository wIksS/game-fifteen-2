namespace GameFifteen.Common
{
    using System;

    class RestartCommand : Command
    {
        private GameEngine engine;

        public RestartCommand(GameEngine engine)
        {
            this.engine = engine;
        }

        public override void Execute()
        {
            engine.Restart();
        }
    }
}
