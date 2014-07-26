namespace GameFifteen.Logic
{
    using System;
    using GameFifteen.Common;

    public class EmptyCellMover
    {
        public static void MoveEmptyCell(Point emptyPoint, Point newPoint, int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("The matrix cannot be null");
            }

            if (emptyPoint == null)
            {
                throw new ArgumentNullException("The empty point position cannot be null");
            }

            if (newPoint == null)
            {
                throw new ArgumentNullException("The new empty point position cannot be null");
            }

            int matrixSize = matrix.GetLength(0);
            bool isNewPointInRange = OutOfMatrixChecker.CheckIfOutOfMatrix(newPoint, matrixSize);
            if (isNewPointInRange)
            {
                throw new IndexOutOfRangeException("The new empty point position is outside the matrix");
            }

            bool isEmptyPointInRange = OutOfMatrixChecker.CheckIfOutOfMatrix(emptyPoint, matrixSize);
            if (isEmptyPointInRange)
            {
                throw new IndexOutOfRangeException("The new empty point position is outside the matrix");
            }

            int swapValue = matrix[newPoint.Row, newPoint.Col];
            matrix[newPoint.Row, newPoint.Col] = CommonConstants.INITIAL_EMPTY_CELL;
            matrix[emptyPoint.Row, emptyPoint.Col] = swapValue;
            emptyPoint.Row = newPoint.Row;
            emptyPoint.Col = newPoint.Col;
        }
    }
}
