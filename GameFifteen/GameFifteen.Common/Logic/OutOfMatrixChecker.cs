namespace GameFifteen.Logic
{
    using GameFifteen.Common;

    public class OutOfMatrixChecker
    {
        public static bool CheckIfOutOfMatrix(Point point, int length)
        {
            if (point.Row >=  length || point.Row < 0 || point.Col < 0 || point.Col >= length)
            {
                return true;
            }

            return false;
        }
    }
}
