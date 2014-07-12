namespace GameFifteen.Common
{
    using GameFifteen.Common.Utils;

    class MatrixEmptyCellRandomizator
    {
        private const int GAME_DIRECTIONS_COUNT = 4;
        private const int INIT_POINT_POSITION = 3;
        private const int MIN_RANDOM_NUMBER = 10;
        private const int MAX_RANDOM_NUMBER = 21;
        private const int MAX_RANDOM_DIRECTION_NUMBER = 4;

        private int[] directionRow = new int[GAME_DIRECTIONS_COUNT] { -1, 0, 1, 0 };
        private int[] directionColumn = new int[GAME_DIRECTIONS_COUNT] { 0, 1, 0, -1 };
        private Point emptyPoint = new Point(INIT_POINT_POSITION, INIT_POINT_POSITION);

        public Point Randomize(int[,] matrix)
        {
            int randomizeMoves = RandomUtils.GetRandomNumber(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
            for (int i = 0; i < randomizeMoves; i++)
            {
                int randomDirection = RandomUtils.GetRandomNumber(MAX_RANDOM_DIRECTION_NUMBER);
                Point newEmptyPoint = new Point(emptyPoint.Row + directionRow[randomDirection], emptyPoint.Col + directionColumn[randomDirection]);

                if (OutOfMatrixChecker.CheckIfOutOfMatrix(newEmptyPoint, matrix.GetLength(0)))
                {
                    i--;
                    continue;
                }
                else
                {
                    EmptyCellMover.MoveEmptyCell(emptyPoint,newEmptyPoint,matrix);
                }
            }

            return emptyPoint;
        }
    }
}
