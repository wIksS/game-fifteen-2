namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;
    using GameFifteen.Common.Utils;

    public class MatrixGenerator : IMatrixGenerator
    {
        private int[,] gameMatrix;
        private int matrixLength;
        private INumberGenerator numberGenerator;

        public MatrixGenerator(int matrixLength,INumberGenerator numberGenerator)
        {
            this.matrixLength = matrixLength;
            this.gameMatrix = new int[matrixLength, matrixLength];
            this.numberGenerator = numberGenerator;
        }

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

            //if (IfEqualMatrix())
            //{
            //    GenerateMatrix();
            //}
        }
    }
}
