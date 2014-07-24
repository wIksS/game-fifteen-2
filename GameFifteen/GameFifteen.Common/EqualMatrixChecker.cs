﻿namespace GameFifteen.Common
{
    using GameFifteen.Common.Contracts;

    public class EqualMatrixChecker : IEqualMatrixChecker
    {
        public bool IsSorted(int[,] currentMatrix)
        {
            int matrixSize=currentMatrix.GetLength(0);
            INumberGenerator numberGenerator=new NumberGenerator(matrixSize*matrixSize);
            IMatrixGenerator matrixGenerator = new MatrixGenerator(matrixSize, numberGenerator);
            int[,] sortedMatrix = matrixGenerator.GenerateMatrix();

            for (int i = 0; i < sortedMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < sortedMatrix.GetLength(0); j++)
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
