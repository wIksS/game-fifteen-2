using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Utils

namespace GameFifteen.Common
{
    class MatrixEmptyCellRandomizator
    {
        private int[,] matrix;
        private int[] dirR = new int[4] { -1, 0, 1, 0 };
        private int[] dirC = new int[4] { 0, 1, 0, -1 };
        private Point emptyPoint = new Point(3,3);

        public MatrixEmptyCellRandomizator(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public void Randomize()
        {
            int randomizeMoves = RandomUtils.GetRandomNumber(10, 21);
            for (int i = 0; i < randomizeMoves; i++)
            {
                int randomDirection = RandomUtils.GetRandomNumber(4);
                Point newEmptyPoint = new Point(emptyPoint.Row + dirR[randomDirection], emptyPoint.Col + dirC[randomDirection]);

                if (IfOutOfMAtrix(newRow, newCol))
                {
                    i--;
                    continue;
                }
                else
                {
                    MoveEmptyCell(newRow, newCol);
                }
            }
        }
    }
}
