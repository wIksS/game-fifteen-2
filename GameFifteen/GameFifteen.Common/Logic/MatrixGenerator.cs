namespace GameFifteen.Logic
{
    using GameFifteen.Contracts;
    using GameFifteen.Common;

    /// <summary>Represents a matrix generator.</summary>
    public class MatrixGenerator : IMatrixGenerator
    {
        private readonly int[,] gameMatrix;
        private readonly int matrixLength;
        private readonly INumberGenerator numberGenerator;

        /// <summary>Constructor.</summary>
        /// <param name="matrixLength" type="int">Length of the matrix.</param>
        /// <param name="numberGenerator" type="INumberGenerator">Number generator.</param>
        public MatrixGenerator(int matrixLength, INumberGenerator numberGenerator)
        {
            this.matrixLength = matrixLength;
            this.gameMatrix = new int[matrixLength, matrixLength];
            this.numberGenerator = numberGenerator;
        }

        /// <summary>Generates a matrix.</summary>
        /// <returns>The matrix.</returns>
        public int[,] GenerateMatrix()
        {
            int tempMatrixValue = CommonConstants.INITIAL_MATRIX_NUMBER;

            for (int i = 0; i < this.matrixLength; i++)
            {
                for (int j = 0; j < this.matrixLength; j++)
                {
                    this.gameMatrix[i, j] = numberGenerator.GetNumber(tempMatrixValue);
                    tempMatrixValue++;
                }
            }

            return this.gameMatrix;
        }
    }
}
