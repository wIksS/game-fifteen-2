﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.Common.Contracts
{
    interface IMatrixRenderer
    {
        void Render(int[,] matrix);
    }
}
