﻿namespace GameFifteen.Common
{
    using GameFifteen.Common.Utils;

    public class MatrixEmptyCellRandomizator
    {
        private readonly int MAX_RANDOM_DIRECTION_INDEX = Directions.GetDirection.GetLength(0) - 1;

        private Point emptyPoint = new Point(CommonConstants.INIT_POINT_POSITION, CommonConstants.INIT_POINT_POSITION);

        public Point Randomize(int[,] matrix)
        {
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