using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Utils;

namespace GameFifteen.Common
{
    public class MatrixGenerator
    {
        private MatrixEmptyCellRandomizator matrixRandomizator;
        private int[,] matrix;
        private int matrixLength;

        public MatrixGenerator(int matrixLength, MatrixEmptyCellRandomizator matrixRandomizator)
        {
            this.matrixLength = matrixLength;
        }

        private void GenerateMatrix()
        {
            int value = 1;
            for (int i = 0; i < this.matrixLength; i++)
            {
                for (int j = 0; j < this.matrixLength; j++)
                {
                    matrix[i, j] = value;
                    value++;
                }
            }

            if (IfEqualMatrix())
            {
                GenerateMatrix();
            }
        }
    }
}
