using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Contracts;

namespace GameFifteen.Common
{
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
