namespace GameFifteen.Logic
{
    using GameFifteen.Utils;
    using GameFifteen.Contracts;
    using GameFifteen.Common;

    /// <summary>Represents a default command.</summary>
    internal class DefaultCommand : Command
    {
        private readonly IRenderer renderer;
        private readonly int[,] matrix;
        private readonly Point emptyPoint;
        private readonly string inputString;
        private bool isPlayerMoved = false;

        //TODO: Separate this class in 2 more classes. MooveCommandExecutor and ValidMooveCommandChecker

        /// <summary>Constructor.</summary>
        /// <param name="matrix" type="int[,]">The matrix.</param>
        /// <param name="renderer" type="IRenderer">The renderer.</param>
        /// <param name="emptyPoint" type="Point">The empty point.</param>
        /// <param name="inputString" type="string">The input string.</param>
        public DefaultCommand(int[,] matrix, IRenderer renderer, Point emptyPoint, string inputString)
        {
            this.matrix = matrix;
            this.renderer = renderer;
            this.emptyPoint = emptyPoint;
            this.inputString = inputString;
        }

        /// <summary>Gets or sets a value indicating whether this object is player moved.</summary>
        /// <value>true if this object is player moved, false if not.</value>
        public bool IsPlayerMoved
        {
            get { return this.isPlayerMoved; }
            private set { this.isPlayerMoved = value; }
        }
        /// <summary>Executes this object.</summary>
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
