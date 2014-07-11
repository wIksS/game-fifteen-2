using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Utils;

namespace GameFifteen.Common
{
    class MatrixEmptyCellRandomizator
    {
        private int[] dirR = new int[4] { -1, 0, 1, 0 };
        private int[] dirC = new int[4] { 0, 1, 0, -1 };
        private Point emptyPoint = new Point(3,3);

        public Point Randomize(int[,] matrix)
        {
            int randomizeMoves = RandomUtils.GetRandomNumber(10, 21);
            for (int i = 0; i < randomizeMoves; i++)
            {
                int randomDirection = RandomUtils.GetRandomNumber(4);
                Point newEmptyPoint = new Point(emptyPoint.Row + dirR[randomDirection], emptyPoint.Col + dirC[randomDirection]);

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
