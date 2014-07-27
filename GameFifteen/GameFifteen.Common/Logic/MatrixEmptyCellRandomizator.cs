namespace GameFifteen.Logic
{
    using System;
    using GameFifteen.Utils;
    using GameFifteen.Common;

    /// <summary>Represents a matrix empty cell randomizator.</summary>
    public class MatrixEmptyCellRandomizator
    {
        private readonly int MAX_RANDOM_DIRECTION_INDEX = Directions.GetDirection.GetLength(0) - 1;

        /// <summary>Randomizes the given matrix.</summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="matrix" type="int[,]">The matrix.</param>
        /// <returns>A Point.</returns>
        public Point Randomize(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("The matrix cannot be null or empty");
            }

            Point emptyPoint = new Point(matrix.GetLength(0)-1, matrix.GetLength(1)-1);

            if (matrix.GetLength(0) <= 1 && matrix.GetLength(1) <= 1)
            {
                return emptyPoint;
            }

            int randomizeMoves = RandomGenerator.GetRandomNumber(CommonConstants.MIN_MOOVES_RANDOM_NUMBER, CommonConstants.MAX_MOOVES_RANDOM_NUMBER);
            for (int i = 0; i < randomizeMoves; i++)
            {
                int randomDirection = RandomGenerator.GetRandomNumber(MAX_RANDOM_DIRECTION_INDEX);
                Point direction = Directions.GetDirection[randomDirection];
                Point newEmptyPoint = new Point(emptyPoint.Row + direction.Row, emptyPoint.Col + direction.Col);

                if (OutOfMatrixChecker.CheckIfOutOfMatrix(newEmptyPoint, matrix.GetLength(0)))
                {
                    i--;
                    continue;
                }
                else
                {
                    EmptyCellMover.MoveEmptyCell(emptyPoint, newEmptyPoint, matrix);
                }
            }

            return emptyPoint;
        }
    }
}
