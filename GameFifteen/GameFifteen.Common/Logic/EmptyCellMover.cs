namespace GameFifteen.Logic
{
    using GameFifteen.Common;

    public class EmptyCellMover
    {
        public static void MoveEmptyCell(Point emptyPoint, Point newPoint, int[,] matrix)
        {
            int swapValue = matrix[newPoint.Row, newPoint.Col];
            matrix[newPoint.Row, newPoint.Col] = CommonConstants.INITIAL_EMPTY_CELL;
            matrix[emptyPoint.Row, emptyPoint.Col] = swapValue;
            emptyPoint.Row = newPoint.Row;
            emptyPoint.Col = newPoint.Col;
        }
    }
}
