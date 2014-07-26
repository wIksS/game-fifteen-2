using System;
using System.Linq;
using GameFifteen.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Contracts;

namespace GameFifteen.Tests.Logic
{
    [TestClass()]
    public class EqualMatrixCheckerTests
    {
        [TestMethod()]
        public void IsSortedTrueTest()
        {
            IMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);
            EqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker();

            int[,] matrix = testMatrixGenerator.GenerateMatrix();
            Assert.IsTrue(equalMatrixChecker.IsSorted(matrix));
        }

        [TestMethod()]
        public void IsSortedFalseTest()
        {
            IMatrixGenerator testMatrixGenerator = new SortedMatrixGenerator(4);
            EqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker();

            int[,] matrix = testMatrixGenerator.GenerateMatrix();
            int memory = matrix[3, 2];
            matrix[3, 2] = matrix[0, 3];
            matrix[0, 3] = memory;
            Assert.IsFalse(equalMatrixChecker.IsSorted(matrix));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSortedNullOrEmptyTest()
        {
            EqualMatrixChecker equalMatrixChecker = new EqualMatrixChecker();

            int[,] matrix = null;
            equalMatrixChecker.IsSorted(matrix);
        }
    }
}
