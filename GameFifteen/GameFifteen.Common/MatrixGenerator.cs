namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;

    public class MatrixGenerator : IMatrixGenerator
    {
        private const int INITIAL_MATRIX_NUMBER = 1;

        private int[,] gameMatrix;
        private int matrixLength;

        public MatrixGenerator(int matrixLength)
        {
            this.matrixLength = matrixLength;
            this.gameMatrix = new int[matrixLength, matrixLength];
        }

        public int[,] GenerateMatrix()
        {
            int tempMatrixValue = INITIAL_MATRIX_NUMBER;

            for (int i = 0; i < this.matrixLength; i++)
            {
                for (int j = 0; j < this.matrixLength; j++)
                {
                    this.gameMatrix[i, j] = tempMatrixValue;
                    tempMatrixValue++;
                }
            }

            return this.gameMatrix;

            //if (IfEqualMatrix())
            //{
            //    GenerateMatrix();
            //}
        }
    }
}
