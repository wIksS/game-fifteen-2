using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common
{
    public class OutOfMatrixChecker
    {
        public static bool CheckIfOutOfMatrix(Point point, int length)
        {
            if (point.Row >=  length || point.Row < 0 || point.Col < 0 || point.Col >= length)
            {
                return true;
            }

            return false;
        }
    }
}
