using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Utils;

namespace GameFifteen.Common
{
    public class Player
    {
        private string name;
        private int movesCount;

        public Player(string name, int movesCount)
        {
            this.Name = name;
            this.MovesCount = movesCount;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null || value == String.Empty)
                {
                    throw new ArgumentException(CommonConstants.INVALID_PLAYER_NAME);
                }

                this.name = value;
            }
        }

        public int MovesCount
        {
            get { return this.movesCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(CommonConstants.NEGATIVE_MOVE);
                }

                this.movesCount = value;
            }
        }
    }
}
