namespace GameFifteen.Common
{
    using GameFifteen.Common.Utils;
    using GameFifteen.Common.Contracts;

    class DefaultCommand : Command
    {
        private IRenderer renderer;
        private int[,] matrix;
        private Point emptyPoint;
        private string inputString;
        private bool isPlayerMoved = false;

        //TODO: Separate this class in 2 more classes. MooveCommandExecutor and ValidMooveCommandChecker

        public DefaultCommand(int[,] matrix, IRenderer renderer, Point emptyPoint, string inputString)
        {
            this.matrix = matrix;
            this.renderer = renderer;
            this.emptyPoint = emptyPoint;
            this.inputString = inputString;
        }

        public bool IsPlayerMoved
        {
            get { return this.isPlayerMoved; }
            private set { this.isPlayerMoved = value; }
        }

        public override void Execute()
        {
            this.IsPlayerMoved = false;
            int number = 0;
            if (ValidMooveCommand(ref number, this.inputString))
            {
                ExecuteMooveCommand(ref number, this.matrix, this.emptyPoint);
            }
        }

        private void ExecuteMooveCommand(ref int number, int[,] currentMatrix, Point emptyPoint)
        {
            Point[] directions = Directions.GetDirection;
            int directionsCount = directions.GetLength(0);
            int matrixLength = currentMatrix.GetLength(0);

            Point newPoint = new Point(0, 0);
            for (int i = 0; i <= directionsCount; i++)
            {
                if (i == matrix.GetLength(0))
                {
                    renderer.PrintLine(CommonConstants.INVALID_MOVE);
                    break;
                }
                newPoint.Row = emptyPoint.Row + directions[i].Row;
                newPoint.Col = emptyPoint.Col + directions[i].Col;
                if (OutOfMatrixChecker.CheckIfOutOfMatrix(newPoint, matrixLength))
                {
                    continue;
                }
                if (currentMatrix[newPoint.Row, newPoint.Col] == number)
                {
                    EmptyCellMover.MoveEmptyCell(emptyPoint, new Point(newPoint.Row, newPoint.Col), currentMatrix);
                    this.IsPlayerMoved = true;
                    break;
                }
            }
        }

        private bool ValidMooveCommand(ref int number, string stringInput)
        {
            bool isNumber = int.TryParse(stringInput, out number);
            int lastNumber = CommonConstants.GAME_BOARD_SIZE * CommonConstants.GAME_BOARD_SIZE;

            if (!isNumber)
            {
                renderer.PrintLine(CommonConstants.INVALID_COMMAND);
                return false;
            }

            if (number >= lastNumber || number <= 0)
            {
                renderer.PrintLine(CommonConstants.INVALID_NUMBER);
                return false;
            }

            return true;
        }
    }
}
