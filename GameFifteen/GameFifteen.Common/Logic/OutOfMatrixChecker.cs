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

            if (point.Row >=  length || point.Row < 0 || point.Col < 0 || point.Col >= length)
            {
                return true;
            }

            return false;
        }
    }
}
