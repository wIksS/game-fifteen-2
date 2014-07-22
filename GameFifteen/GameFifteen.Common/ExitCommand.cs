namespace GameFifteen.Common
{
    class ExitCommand : Command
    {
        private GameEngine engine;

        public ExitCommand(GameEngine engine)
        {
            this.engine = engine;
        }

        public override void Execute()
        {
            engine.Exit();
        }
    }
}
