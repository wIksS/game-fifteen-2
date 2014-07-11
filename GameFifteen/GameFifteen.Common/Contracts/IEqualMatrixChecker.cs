﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common.Contracts
{
    public interface IEqualMatrixChecker
    {
        bool CheckMatrix(int[,] matrix);
    }
}
