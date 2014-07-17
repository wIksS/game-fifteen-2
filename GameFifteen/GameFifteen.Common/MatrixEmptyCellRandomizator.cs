namespace GameFifteen.Common
{
    using GameFifteen.Common.Utils;

    class MatrixEmptyCellRandomizator
    {
        private const int INIT_POINT_POSITION = 3;
        private const int MIN_MOOVES_RANDOM_NUMBER = 1;
        private const int MAX_MOOVES_RANDOM_NUMBER = 2;
        private const int MAX_RANDOM_DIRECTION_INDEX = 3;

        private Point emptyPoint = new Point(INIT_POINT_POSITION, INIT_POINT_POSITION);

        public Point Randomize(int[,] matrix)
        {
            int randomizeMoves = RandomUtils.GetRandomNumber(MIN_MOOVES_RANDOM_NUMBER, MAX_MOOVES_RANDOM_NUMBER);
            for (int i = 0; i < randomizeMoves; i++)
            {
                int randomDirection = RandomUtils.GetRandomNumber(MAX_RANDOM_DIRECTION_INDEX);
                Direction direction = Directions.GetDirection[randomDirection];
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
