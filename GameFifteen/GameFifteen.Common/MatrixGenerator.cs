namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    public class MatrixGenerator : IMatrixGenerator
    {
        private int[,] gameMatrix;
        private int matrixLength;

        public MatrixGenerator(int matrixLength)
        {
            this.matrixLength = matrixLength;
            this.gameMatrix = new int[matrixLength, matrixLength];
        }

        public int[,] GenerateMatrix()
        {
            int tempMatrixValue = CommonConstants.INITIAL_MATRIX_NUMBER;

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
