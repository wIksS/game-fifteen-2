using System;
using System.Linq;

namespace GameFifteen.Common.Utils
{
    public static class Directions
    {
        private static readonly Direction[] possibleDirections = { new Direction(0, 1), new Direction(0, -1), new Direction(1, 0), new Direction(-1, 0) };

        public static Direction GetDirection(int directionIndex)
        {
            return possibleDirections[directionIndex];
        }
        //int test = Directions[1].ColDir;
    }
}