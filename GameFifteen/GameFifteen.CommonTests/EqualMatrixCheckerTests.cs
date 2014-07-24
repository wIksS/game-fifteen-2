using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Common.Contracts;

namespace GameFifteen.Common.Tests
{
    [TestClass()]
    public class EqualMatrixCheckerTests
    {
        [TestMethod()]
        public void IsSortedTrueTest()
        {
            IMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);
            EqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker(testMatrixGenerator);

            int[,] currentMatrix = testMatrixGenerator.GenerateMatrix();
            Assert.IsTrue(equalMatrixChecker.IsSorted(currentMatrix));
        }
    }
}
