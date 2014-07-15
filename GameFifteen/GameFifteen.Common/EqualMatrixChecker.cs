namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;

    public class EqualMatrixChecker : IEqualMatrixChecker
    {
        private readonly int[,] sortedMatrix;

        public EqualMatrixChecker(IMatrixGenerator matrixGenerator)
        {
            this.sortedMatrix = matrixGenerator.GenerateMatrix();
        }

        // always compares to this.sortedMatrix
        public bool IsSorted(int[,] currentMatrix)
        {
            for (int i = 0; i < this.sortedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.sortedMatrix.GetLength(0); j++)
                {
                    if (currentMatrix[i, j] != this.sortedMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
