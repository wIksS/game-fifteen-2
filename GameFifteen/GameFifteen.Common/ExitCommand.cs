using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
