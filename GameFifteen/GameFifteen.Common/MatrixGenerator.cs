using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common
{
    public class MatrixGenerator
    {
        public const int MatrixLength = 4;

        public bool IfOutOfMAtrix(int row, int col)
        {
            if (row >= MatrixLength || row < 0 || col < 0 || col >= MatrixLength)
            {
                return true;
            }

            return false;
        }
    }
}