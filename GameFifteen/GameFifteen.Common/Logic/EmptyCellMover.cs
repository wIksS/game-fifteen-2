namespace GameFifteen.Logic
{
    using System;
    using GameFifteen.Common;

    /// <summary>Represents an empty cell mover.</summary>
    public class EmptyCellMover
    {
        /// <summary>Move empty cell.</summary>
        /// <exception cref="ArgumentNullException">   Thrown when one or more required arguments are
        ///                                            null.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is outside the required
        ///                                            range.</exception>
        /// <param name="emptyPoint" type="Point">The empty point.</param>
        /// <param name="newPoint" type="Point">The new point.</param>
        /// <param name="matrix" type="int[,]">The matrix.</param>
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
