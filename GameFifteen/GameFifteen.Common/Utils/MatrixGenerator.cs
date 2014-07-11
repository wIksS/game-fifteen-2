namespace GameFifteen.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GameFifteen.Common.Utils;

    public class MatrixGenerator
    {
        private int matrixLength;
        private int[,] matrix;

        public int MatrixLength
        {
            get { return this.matrixLength; }
            private set { this.matrixLength = value; }
        }

        public MatrixGenerator(int matrixLength)
        {
            this.MatrixLength = matrixLength;
        }

        public void Generate()
        {
            int value = 1;
            for (int i = 0; i < this.MatrixLength; i++)
            {
                for (int j = 0; j < this.MatrixLength; j++)
                {
                    this.matrix[i, j] = value;
                    value++;
                }
            }
            int ramizeMoves = RandomUtils.GetRandomNumber(10, 21);

            for (int i = 0; i < ramizeMoves; i++)
            {
                int randomDirection = RandomUtils.GetRandomNumber(4);
                int newRow = emptyRow + dirR[randomDirection];
                int newCol = emptyCol + dirC[randomDirection];
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
            if (IfEqualMatrix())
            {
                GenerateMatrix();
            }
        }

        private bool IfOutOfMAtrix(int row, int col)
        {
            if (row >= MatrixLength || row < 0 || col < 0 || col >= MatrixLength)
            {
                return true;
            }

            return false;
        }

    }
}