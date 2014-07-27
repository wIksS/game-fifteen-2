using System;
using System.Linq;

namespace GameFifteen.Tests.Logic
{
    using System;
    using GameFifteen.Contracts;

    public class MatrixComparer : IEqualMatrixChecker
    {
        public bool IsSorted(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("The matrix cannot be null or empty");
            }

            int matrixSize = matrix.GetLength(0);

            IMatrixGenerator matrixGenerator = new SortedMatrixGenerator(matrixSize);
            int[,] sortedMatrix = matrixGenerator.GenerateMatrix();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] != sortedMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool AreEqual(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1 == null)
            {
                throw new ArgumentNullException("The matrix cannot be null or empty");
            }

            int matrixSize = matrix1.GetLength(0);

            if (matrixSize != matrix2.GetLength(0))
            {
                return false;
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
