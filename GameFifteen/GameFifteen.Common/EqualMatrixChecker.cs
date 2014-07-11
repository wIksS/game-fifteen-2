using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFifteen.Common.Contracts;

namespace GameFifteen.Common
{
    public class EqualMatrixChecker : IEqualMatrixChecker
    {
        private int[,] matrix;

        public EqualMatrixChecker(int matrixLength, IMatrixGenerator matrixGenerator)
        {
            this.matrix = matrixGenerator.GenerateMatrix();
        }

        public bool CheckMatrix(int[,] currentMatrix)
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    if (currentMatrix[i, j] != this.matrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
