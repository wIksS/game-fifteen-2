namespace GameFifteen.Logic
{
    using System;
    using GameFifteen.Contracts;
    using GameFifteen.Common;

    /// <summary>Represents an equal matrix checker.</summary>
    public class EqualMatrixChecker : IEqualMatrixChecker
    {
        /// <summary>Query if 'currentMatrix' is sorted.</summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="currentMatrix" type="int[,]">The game field.</param>
        /// <returns>true if sorted, false if not.</returns>
        public bool IsSorted(int[,] currentMatrix)
        {
            if (currentMatrix == null)
            {
                throw new ArgumentNullException("The matrix cannot be null or empty");
            }

            int matrixSize = currentMatrix.GetLength(0);

            INumberGenerator numberGenerator = new NumberGenerator(matrixSize * matrixSize);
            IMatrixGenerator matrixGenerator = new MatrixGenerator(matrixSize, numberGenerator);
            int[,] sortedMatrix = matrixGenerator.GenerateMatrix();

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (currentMatrix[i, j] != sortedMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
