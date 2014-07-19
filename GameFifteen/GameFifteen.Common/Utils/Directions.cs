using System;
using System.Linq;

namespace GameFifteen.Common.Utils
{
    public static class Directions
    {
        public static readonly Point[] GetDirection = { new Point(0, 1), new Point(0, -1), new Point(1, 0), new Point(-1, 0) };

        //private static readonly Direction[] possibleDirections = { new Direction(0, 1), new Direction(0, -1), new Direction(1, 0), new Direction(-1, 0) };

        //public static Direction GetDirection(int directionIndex)
        //{
        //    return possibleDirections[directionIndex];
        //}
    }
}