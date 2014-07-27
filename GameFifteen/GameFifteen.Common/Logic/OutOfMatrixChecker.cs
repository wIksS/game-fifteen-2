namespace GameFifteen.Logic
{
    using GameFifteen.Common;
    using System;

    public class OutOfMatrixChecker
    {
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

            if (point.Col - length >= 2 || point.Row - length >= 2 || point.Row < -1 || point.Col < -1)
            {
                throw new ArgumentOutOfRangeException("Index is stuck outside of the array");
            }

            if (point.Row >=  length || point.Row < 0 || point.Col < 0 || point.Col >= length)
            {
                return true;
            }

            return false;
        }
    }
}
