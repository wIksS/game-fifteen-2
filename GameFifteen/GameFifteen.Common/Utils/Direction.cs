using System;
using System.Linq;

namespace GameFifteen.Common.Utils
{
    public class Direction
    {
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Direction(int row, int col)
        {
            if (row < -1 || row > 1 || col < -1 || col > 1 || row == col)
            {
                // TODO implement custom exeption
                throw new ApplicationException("Invalid direction!");
            }
            this.Row = row;
            this.Col = col;
        }
    }
}
