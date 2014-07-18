namespace GameFifteen.Common
{
    public class EmptyCellMover
    {
		private const int INITIAL_EMPTY_CELL = GameEngine.GAME_BOARD_SIZE * GameEngine.GAME_BOARD_SIZE;
        public static void MoveEmptyCell(Point emptyPoint, Point newPoint, int[,] matrix)
        {
            int swapValue = matrix[newPoint.Row, newPoint.Col];
            matrix[newPoint.Row, newPoint.Col] = INITIAL_EMPTY_CELL;
            matrix[emptyPoint.Row, emptyPoint.Col] = swapValue;
            emptyPoint.Row = newPoint.Row;
            emptyPoint.Col = newPoint.Col;
        }
    }
}
