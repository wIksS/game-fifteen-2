using GameFifteen.Contracts;
using System;
using System.Linq;

namespace GameFifteen.Tests.Logic
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
