namespace GameFifteen.Utils
{
    using System;
    using System.Linq;
    using GameFifteen.Common;

    /// <summary>Represents directions.</summary>
    public static class Directions
    {
        /// <summary>The possibe directions.</summary>
        public static readonly Point[] GetDirection = { new Point(0, 1), new Point(0, -1), new Point(1, 0), new Point(-1, 0) };
    }
}