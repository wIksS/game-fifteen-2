using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common
{
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
