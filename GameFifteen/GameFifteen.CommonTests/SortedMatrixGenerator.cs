using GameFifteen.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common.Tests
{
    class SortedMatrixGenerator : IMatrixGenerator
    {
        private readonly int size;

        public SortedMatrixGenerator(int size)
        {
            this.size = size;
        }

        public int[,] GenerateMatrix()
        {
            int tempMatrixValue = 1;
            int[,] matrix = new int[4, 4];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = tempMatrixValue;
                    tempMatrixValue++;
                }
            }

            return matrix;
        }
    }
}
