namespace GameFifteen.Logic
{
    using GameFifteen.Common;
    using System;

    /// <summary>Represents an out of matrix checker.</summary>
    public class OutOfMatrixChecker
    {
        /// <summary>Determine if out of matrix.</summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more arguments are outside the
        ///                                               required range.</exception>
        /// <exception cref="ArgumentNullException">      Thrown when one or more required arguments are
        ///                                               null.</exception>
        /// <param name="point" type="Point">The point.</param>
        /// <param name="length" type="int">The length.</param>
        /// <returns>true if it succeeds, false if it fails.</returns>
        public static bool CheckIfOutOfMatrix(Point point, int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException("The size of the matrix must be greater than 0!");
            }

            if (point == null)
            {
                throw new ArgumentNullException("The point position cannot be null");
            }

            if (point.Row >=  length || point.Row < 0 || point.Col < 0 || point.Col >= length)
            {
                return true;
            }

            return false;
        }
    }
}
