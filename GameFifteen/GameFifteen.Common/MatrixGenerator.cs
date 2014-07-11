using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Utils;
using GameFifteen.Common.Contracts;

namespace GameFifteen.Common
{
    public class MatrixGenerator : IMatrixGenerator
    {
        private int[,] matrix;
        private int matrixLength;

        public MatrixGenerator(int matrixLength)
        {
            this.matrixLength = matrixLength;
            this.matrix = new int[matrixLength, matrixLength];
        }

        public int[,] GenerateMatrix()
        {
            int value = 1;
            for (int i = 0; i < this.matrixLength; i++)
            {
                for (int j = 0; j < this.matrixLength; j++)
                {
                    this.matrix[i, j] = value;
                    value++;
                }
            }

            return this.matrix;

            //if (IfEqualMatrix())
            //{
            //    GenerateMatrix();
            //}
        }

        
    }
}
