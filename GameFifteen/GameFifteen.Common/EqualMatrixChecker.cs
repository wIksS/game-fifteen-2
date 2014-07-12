namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;

    public class EqualMatrixChecker : IEqualMatrixChecker
    {
        private int[,] gameMatrix;

        public EqualMatrixChecker(int matrixLength, IMatrixGenerator matrixGenerator)
        {
            this.gameMatrix = matrixGenerator.GenerateMatrix();
        }

        public bool CheckMatrix(int[,] currentMatrix)
        {
            for (int i = 0; i < this.gameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.gameMatrix.GetLength(0); j++)
                {
                    if (currentMatrix[i, j] != this.gameMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
